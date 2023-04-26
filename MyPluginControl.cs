using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entity_Security_Plugin.Business;
using XrmToolBox.Extensibility;
using Microsoft.Xrm.Sdk.Query;
using Microsoft.Xrm.Sdk;
using McTools.Xrm.Connection;
using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Metadata;
using Newtonsoft.Json;
using Entity_Security_Plugin.Models;
using XrmToolBox.Forms;

namespace Entity_Security_Plugin
{
    public partial class MyPluginControl : PluginControlBase
    {
        private Settings mySettings;
        private List<EntityMetadata> entityList;
        public List<SecurityPrv> currentListSecPrv;

        private string selectedEntity;

        public MyPluginControl()
        {
            InitializeComponent();
        }

        private void MyPluginControl_Load(object sender, EventArgs e)
        {
            ShowInfoNotification("Xin chào ^_^!", new Uri("https://www.facebook.com/M12Green/"));

            // Loads or creates the settings for the plugin
            if (!SettingsManager.Instance.TryLoad(GetType(), out mySettings))
            {
                mySettings = new Settings();

                LogWarning("Settings not found => a new settings file has been created!");
            }
            else
            {
                LogInfo("Settings found and loaded");
            }

            this.setTableRoleDefinition();
        }

        private void tsbClose_Click(object sender, EventArgs e)
        {
            CloseTool();
        }
        #region Actions
        private void tbsGetData_Click(object sender, EventArgs e)
        {
            // The ExecuteMethod method handles connecting to an
            // organization if XrmToolBox is not yet connected
            ExecuteMethod(GetAllEntities);
        }

        private void btnGetRoles_Click(object sender, EventArgs e)
        {
            if (cbEntities.SelectedValue != null && !String.IsNullOrWhiteSpace(cbEntities.SelectedValue.ToString()))
            {
                selectedEntity = cbEntities.SelectedValue.ToString().Trim();
                tbRoles.DataSource = null;
                tbRoles.Refresh();
                ExecuteMethod(GetAllRelatedRoles);
                btnExport.Enabled = true;
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            var filePath = new ExportExcel().Execute(this.tbRoles, cbEntities.SelectedValue.ToString());
            if (!string.IsNullOrEmpty(filePath))
                MessageBox.Show("Done with :" + filePath);
        }
        #endregion

        #region logic
        //get all Entities
        private void GetAllEntities()
        {
            WorkAsync(new WorkAsyncInfo
            {
                Message = "Getting Data",

                Work = (worker, args) =>
                {
                    var allEntitiesResponse = (RetrieveAllEntitiesResponse)Service.Execute(new RetrieveAllEntitiesRequest());

                    entityList = allEntitiesResponse.EntityMetadata.Where(x => x.IsValidForAdvancedFind == true).ToList();

                    var entityCBdata = new Dictionary<string, string>();
                    foreach (var data in allEntitiesResponse.EntityMetadata)
                    {
                        if (data != null && data.DisplayName != null && data.DisplayName.UserLocalizedLabel != null)
                        {
                            entityCBdata.Add(data.LogicalName, data.DisplayName.UserLocalizedLabel.Label.ToString() + " (" + data.LogicalName + ")");
                        }
                        else
                        {
                            entityCBdata.Add(data.LogicalName, data.LogicalName);
                        }
                    }

                    args.Result = entityCBdata.OrderBy(x => x.Value);
                },

                PostWorkCallBack = (args) =>
                {
                    if (args.Error != null)
                        MessageBox.Show(args.Error.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                        // Binding result data to ListBox Control
                        cbEntities.DataSource = new BindingSource(args.Result, null);

                    cbEntities.DisplayMember = "Value";
                    cbEntities.ValueMember = "Key";
                }
            });
        }

        //get all related roles of the selected entities
        private void GetAllRelatedRoles()
        {
            WorkAsync(new WorkAsyncInfo
            {
                Message = "Getting Securities Roles",

                Work = (worker, args) =>
                {

                    QueryExpression query = new QueryExpression();
                    query.EntityName = "role";
                    query.ColumnSet = new ColumnSet("name");

                    //LinkEntity systemUseRole = new LinkEntity();
                    //systemUseRole.LinkFromEntityName = "role";
                    //systemUseRole.LinkFromAttributeName = "roleid";
                    //systemUseRole.LinkToEntityName = "systemuserroles";
                    //systemUseRole.LinkToAttributeName = "roleid";
                    //systemUseRole.JoinOperator = JoinOperator.Inner;
                    //systemUseRole.EntityAlias = "SUR";

                    //LinkEntity userRoles = new LinkEntity();
                    //userRoles.LinkFromEntityName = "systemuserroles";
                    //userRoles.LinkFromAttributeName = "systemuserid";
                    //userRoles.LinkToEntityName = "systemuser";
                    //userRoles.LinkToAttributeName = "systemuserid";
                    //userRoles.JoinOperator = JoinOperator.Inner;
                    //userRoles.EntityAlias = "SU";
                    //userRoles.Columns = new ColumnSet("fullname");

                    LinkEntity rolePrivileges = new LinkEntity();
                    rolePrivileges.LinkFromEntityName = "role";
                    rolePrivileges.LinkFromAttributeName = "roleid";
                    rolePrivileges.LinkToEntityName = "roleprivileges";
                    rolePrivileges.LinkToAttributeName = "roleid";
                    rolePrivileges.JoinOperator = JoinOperator.Inner;
                    rolePrivileges.EntityAlias = "RP";
                    rolePrivileges.Columns = new ColumnSet("privilegedepthmask");

                    LinkEntity privilege = new LinkEntity();
                    privilege.LinkFromEntityName = "roleprivileges";
                    privilege.LinkFromAttributeName = "privilegeid";
                    privilege.LinkToEntityName = "privilege";
                    privilege.LinkToAttributeName = "privilegeid";
                    privilege.JoinOperator = JoinOperator.Inner;
                    privilege.EntityAlias = "P";
                    privilege.Columns = new ColumnSet("name", "accessright");

                    LinkEntity privilegeObjectTypeCodes = new LinkEntity();
                    privilegeObjectTypeCodes.LinkFromEntityName = "roleprivileges";
                    privilegeObjectTypeCodes.LinkFromAttributeName = "privilegeid";
                    privilegeObjectTypeCodes.LinkToEntityName = "privilegeobjecttypecodes";
                    privilegeObjectTypeCodes.LinkToAttributeName = "privilegeid";
                    privilegeObjectTypeCodes.JoinOperator = JoinOperator.Inner;
                    privilegeObjectTypeCodes.EntityAlias = "POTC";
                    privilegeObjectTypeCodes.Columns = new ColumnSet("objecttypecode");

                    ConditionExpression conditionExpression = new ConditionExpression();
                    conditionExpression.AttributeName = "objecttypecode";
                    conditionExpression.Operator = ConditionOperator.Equal;
                    conditionExpression.Values.Add(selectedEntity);

                    privilegeObjectTypeCodes.LinkCriteria = new FilterExpression();
                    privilegeObjectTypeCodes.LinkCriteria.Conditions.Add(conditionExpression);

                    //systemUseRole.LinkEntities.Add(userRoles);
                    //query.LinkEntities.Add(systemUseRole);

                    rolePrivileges.LinkEntities.Add(privilege);
                    rolePrivileges.LinkEntities.Add(privilegeObjectTypeCodes);
                    query.LinkEntities.Add(rolePrivileges);

                    EntityCollection retUserRoles = Service.RetrieveMultiple(query);

                    Console.WriteLine("Retrieved {0} records", retUserRoles.Entities.Count);
                    //string result = "";
                    currentListSecPrv = new List<SecurityPrv>();

                    foreach (Entity rur in retUserRoles.Entities)
                    {
                        //string UserName = String.Empty;
                        string SecurityRoleName = String.Empty;
                        string PriviligeName = String.Empty;
                        string AccessLevel = String.Empty;
                        string SecurityLevel = String.Empty;
                        string EntityName = String.Empty;

                        //UserName = ((AliasedValue)(rur["SU.fullname"])).Value.ToString();
                        SecurityRoleName = (string)rur["name"];
                        EntityName = ((AliasedValue)(rur["POTC.objecttypecode"])).Value.ToString();
                        PriviligeName = ((AliasedValue)(rur["P.name"])).Value.ToString();
                        AccessLevel = ((AliasedValue)(rur["P.accessright"])).Value.ToString();
                        SecurityLevel = ((AliasedValue)(rur["RP.privilegedepthmask"])).Value.ToString();


                        if (currentListSecPrv.Find(t => t.Role.Equals(SecurityRoleName)) == null)
                        {
                            currentListSecPrv.Add(new SecurityPrv(SecurityRoleName));
                        }

                        currentListSecPrv.Find(t => t.Role.Equals(SecurityRoleName)).setLevels(AccessLevel, SecurityLevel);

                        //Test
                        //result += "Security Role name:" + rur["name"] + "\n";
                        //result += "Privilige name:" + ((AliasedValue)rur["P.name"]).Value.ToString() + "\n";
                        //result += "Access Right :" + ((AliasedValue)rur["P.accessright"]).Value.ToString() + "\n";
                        //result += "Security Level:" + ((AliasedValue)rur["RP.privilegedepthmask"]).Value.ToString() + "\n";

                        //result += "------------------\n";
                    }

                    args.Result = currentListSecPrv.OrderBy(t => t.Role).ToList();
                },

                PostWorkCallBack = (args) =>
                {
                    if (args.Error != null)
                        MessageBox.Show(args.Error.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                    {
                        tbRoles.AutoGenerateColumns = false;
                        tbRoles.DataSource = args.Result;
                    }
                }
            });
        }

        private void GetAccounts()
        {
            WorkAsync(new WorkAsyncInfo
            {
                Message = "Getting accounts",
                Work = (worker, args) =>
                {

                    args.Result = Service.RetrieveMultiple(new QueryExpression("account")
                    {
                        TopCount = 50
                    });
                },
                PostWorkCallBack = (args) =>
                {
                    if (args.Error != null)
                    {
                        MessageBox.Show(args.Error.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    var result = args.Result as EntityCollection;
                    if (result != null)
                    {
                        MessageBox.Show($"Found {result.Entities.Count} accounts");
                    }
                }
            });
        }

        #endregion

        #region UI

        private void setTableRoleDefinition()
        {
            byte[] strLevel = Convert.FromBase64String(Constants.Images.NonAccess);
            MemoryStream ms = new MemoryStream(strLevel);
            var noneAccess = System.Drawing.Image.FromStream(ms);
            PictureBox noneAccessPB = new PictureBox();
            noneAccessPB.Image = noneAccess;
            noneAccessPB.SizeMode = PictureBoxSizeMode.CenterImage;

            strLevel = Convert.FromBase64String(Constants.Images.UserLevel);
            ms = new MemoryStream(strLevel);
            var userLevel = System.Drawing.Image.FromStream(ms);
            PictureBox userLevelPB = new PictureBox();
            userLevelPB.Image = userLevel;
            userLevelPB.SizeMode = PictureBoxSizeMode.CenterImage;

            strLevel = Convert.FromBase64String(Constants.Images.BULevel);
            ms = new MemoryStream(strLevel);
            var buLevel = System.Drawing.Image.FromStream(ms);
            PictureBox buLevelPB = new PictureBox();
            buLevelPB.Image = buLevel;
            buLevelPB.SizeMode = PictureBoxSizeMode.CenterImage;

            strLevel = Convert.FromBase64String(Constants.Images.ChildBULevel);
            ms = new MemoryStream(strLevel);
            var childBuLevel = System.Drawing.Image.FromStream(ms);
            PictureBox childBuLevelPB = new PictureBox();
            childBuLevelPB.Image = childBuLevel;
            childBuLevelPB.SizeMode = PictureBoxSizeMode.CenterImage;

            strLevel = Convert.FromBase64String(Constants.Images.OrganizationLevel);
            ms = new MemoryStream(strLevel);
            var organizationLevel = System.Drawing.Image.FromStream(ms);
            PictureBox organizationLevelPB = new PictureBox();
            organizationLevelPB.Image = organizationLevel;
            organizationLevelPB.SizeMode = PictureBoxSizeMode.CenterImage;

            this.tbRoleDefinition.Controls.Add(noneAccessPB, 1, 0);
            this.tbRoleDefinition.Controls.Add(userLevelPB, 1, 1);
            this.tbRoleDefinition.Controls.Add(buLevelPB, 1, 2);
            this.tbRoleDefinition.Controls.Add(childBuLevelPB, 1, 3);
            this.tbRoleDefinition.Controls.Add(organizationLevelPB, 1, 4);
        }
        #endregion
        /// <summary>
        /// This event occurs when the plugin is closed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MyPluginControl_OnCloseTool(object sender, EventArgs e)
        {
            // Before leaving, save the settings
            SettingsManager.Instance.Save(GetType(), mySettings);
        }

        /// <summary>
        /// This event occurs when the connection has been updated in XrmToolBox
        /// </summary>
        public override void UpdateConnection(IOrganizationService newService, ConnectionDetail detail, string actionName, object parameter)
        {
            base.UpdateConnection(newService, detail, actionName, parameter);

            if (mySettings != null && detail != null)
            {
                mySettings.LastUsedOrganizationWebappUrl = detail.WebApplicationUrl;
                LogInfo("Connection has changed to: {0}", detail.WebApplicationUrl);
            }
        }


    }
}