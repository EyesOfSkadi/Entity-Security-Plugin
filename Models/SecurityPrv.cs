using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Security_Plugin.Models
{
    public class SecurityPrv
    {

        public string Role { get; set; }

        public Image Create { get; set; }
        public Image Read { get; set; }
        public Image Write { get; set; }
        public Image Delete { get; set; }
        public Image Append { get; set; }
        public Image AppendTo { get; set; }
        public Image Share { get; set; }
        public Image Assign { get; set; }

        public int CreateValue { get; set; }
        public int ReadValue { get; set; }
        public int WriteValue { get; set; }
        public int DeleteValue { get; set; }
        public int AppendValue { get; set; }
        public int AppendToValue { get; set; }
        public int ShareValue { get; set; }
        public int AssignValue { get; set; }

        public SecurityPrv(string SecurityRole)
        {
            Role = SecurityRole;
            byte[] strLevel = Convert.FromBase64String(Constants.Images.NonAccess);
            MemoryStream ms = new MemoryStream(strLevel);
            Read = System.Drawing.Image.FromStream(ms);
            Write = System.Drawing.Image.FromStream(ms);
            Append = System.Drawing.Image.FromStream(ms);
            AppendTo = System.Drawing.Image.FromStream(ms);
            Create = System.Drawing.Image.FromStream(ms);
            Delete = System.Drawing.Image.FromStream(ms);
            Share = System.Drawing.Image.FromStream(ms);
            Assign = System.Drawing.Image.FromStream(ms);
        }

        public void setLevels(string AccessLevel, string SecurityLevel)
        {
            //Set image level
            string levelImg = Constants.Images.NonAccess;
            int levelValue = 0;

            switch (SecurityLevel)
            {
                case Constants.PluginConstants.SLUser:
                    levelImg = Constants.Images.UserLevel;
                    levelValue = 1;
                    break;

                case Constants.PluginConstants.SLBusinessUnit:
                    levelImg = Constants.Images.BULevel;
                    levelValue = 2;
                    break;

                case Constants.PluginConstants.SLChildBusinessUnit:
                    levelImg = Constants.Images.ChildBULevel;
                    levelValue = 3;
                    break;

                case Constants.PluginConstants.SLOrganization:
                    levelImg = Constants.Images.OrganizationLevel;
                    levelValue = 4;
                    break;

                default:
                    break;
            }

            byte[] strLevel = Convert.FromBase64String(levelImg);
            MemoryStream ms = new MemoryStream(strLevel);

            //Set level base on Access
            switch (AccessLevel)
            {
                case Constants.PluginConstants.CREATE:
                    Create = System.Drawing.Image.FromStream(ms);
                    CreateValue = levelValue;
                    break;

                case Constants.PluginConstants.WRITE:
                    Write = System.Drawing.Image.FromStream(ms);
                    WriteValue = levelValue;
                    break;

                case Constants.PluginConstants.READ:
                    Read = System.Drawing.Image.FromStream(ms);
                    ReadValue = levelValue;
                    break;

                case Constants.PluginConstants.DELETE:
                    Delete = System.Drawing.Image.FromStream(ms);
                    DeleteValue = levelValue;
                    break;

                case Constants.PluginConstants.APPEND:
                    Append = System.Drawing.Image.FromStream(ms);
                    AppendValue = levelValue;
                    break;

                case Constants.PluginConstants.APPENDTO:
                    AppendTo = System.Drawing.Image.FromStream(ms);
                    AppendToValue = levelValue;
                    break;

                case Constants.PluginConstants.ASSIGN:
                    Assign = System.Drawing.Image.FromStream(ms);
                    AssignValue = levelValue;
                    break;

                case Constants.PluginConstants.SHARE:
                    Share = System.Drawing.Image.FromStream(ms);
                    ShareValue = levelValue;
                    break;

                default:
                    break;
            }
        }
    }
}
