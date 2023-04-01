using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
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
        private List<Entity> rolesList;
        private List<Entity> prvList;
        private List<Entity> roleprvList;
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
           var filePath = new ExportExcel().Execute(this.tbRoles);
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
                            entityCBdata.Add(data.LogicalName, data.DisplayName.UserLocalizedLabel.Label.ToString());
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
                    List<SecurityPrv> dataSource = new List<SecurityPrv>();

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


                        if (dataSource.Find(t => t.Role.Equals(SecurityRoleName)) == null)
                        {
                            dataSource.Add(new SecurityPrv(SecurityRoleName));
                        }

                        dataSource.Find(t => t.Role.Equals(SecurityRoleName)).setLevels(AccessLevel, SecurityLevel);

                        //Test
                        //result += "Security Role name:" + rur["name"] + "\n";
                        //result += "Privilige name:" + ((AliasedValue)rur["P.name"]).Value.ToString() + "\n";
                        //result += "Access Right :" + ((AliasedValue)rur["P.accessright"]).Value.ToString() + "\n";
                        //result += "Security Level:" + ((AliasedValue)rur["RP.privilegedepthmask"]).Value.ToString() + "\n";

                        //result += "------------------\n";
                    }

                    args.Result = dataSource.OrderBy(t => t.Role).ToList();


                },

                PostWorkCallBack = (args) =>
                {
                    if (args.Error != null)
                        MessageBox.Show(args.Error.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                    {
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

        private void Test()
        {
            WorkAsync(new WorkAsyncInfo
            {
                // Showing message until background work is completed
                Message = "Retrieving WhoAmI Information",

                // Main task which will be executed asynchronously
                Work = (worker, args) =>
                {
                    //Saved code
                    var query = new QueryExpression("privilege");
                    query.ColumnSet = new ColumnSet(true);
                    //query.Criteria.AddCondition(new ConditionExpression("name", ConditionOperator.Like, "%"+ selectedEntity + "%"));
                    var privileges = Service.RetrieveMultiple(query).Entities.ToList();
                    prvList = privileges.Where(t => t.Attributes["name"].ToString().Contains("prvAssign" + selectedEntity) ||
                    t.Attributes["name"].ToString().Contains("prvShare" + selectedEntity) ||
                    t.Attributes["name"].ToString().Contains("prvAppendTo" + selectedEntity) ||
                    t.Attributes["name"].ToString().Contains("prvRead" + selectedEntity) ||
                    t.Attributes["name"].ToString().Contains("prvDelete" + selectedEntity) ||
                    t.Attributes["name"].ToString().Contains("prvCreate" + selectedEntity) ||
                    t.Attributes["name"].ToString().Contains("prvWrite" + selectedEntity) ||
                    t.Attributes["name"].ToString().Contains("prvAppend" + selectedEntity)).ToList();
                    string jsonPrivileges = JsonConvert.SerializeObject(privileges);

                    query = new QueryExpression("role");
                    query.ColumnSet = new ColumnSet(true);
                    var role = Service.RetrieveMultiple(query).Entities.ToList().Where(t => t.Attributes["name"].ToString().Equals("VF Showroom Sales Advisor") && t.Attributes["businessunitid"] != null).ToList();
                    string jsonRole = JsonConvert.SerializeObject(role);

                    List<Entity> relatedRoleprivileges = new List<Entity>();
                    query = new QueryExpression("roleprivileges");
                    query.ColumnSet = new ColumnSet(true);
                    var roleprivileges = Service.RetrieveMultiple(query).Entities.ToList();

                    relatedRoleprivileges.AddRange(roleprivileges.Where(t => t.Attributes["roleid"].ToString().Equals(role[0].Id)));
                    string jsonrelatedRoleprivileges = JsonConvert.SerializeObject(relatedRoleprivileges);


                    args.Result = null;
                },

                // Work is completed, results can be shown to user
                PostWorkCallBack = (args) =>
                {
                    if (args.Error != null)
                        MessageBox.Show(args.Error.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    // Binding result data to ListBox Control
                    //lst_UserData.DataSource = args.Result;
                }
            });
        }

    }
}