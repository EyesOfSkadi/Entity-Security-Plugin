using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Security_Plugin.Constants
{
    public class PluginConstants
    {
        public const string SLNoAccess = "";
        public const string SLUser = "1";
        public const string SLBusinessUnit = "2";
        public const string SLChildBusinessUnit = "4";
        public const string SLOrganization = "8";


        public const string READ = "1";
        public const string WRITE = "2";
        public const string APPEND = "4";
        public const string APPENDTO = "16";
        public const string CREATE = "32";
        public const string DELETE = "65536";
        public const string SHARE = "262144";
        public const string ASSIGN = "524288";
    }
}
