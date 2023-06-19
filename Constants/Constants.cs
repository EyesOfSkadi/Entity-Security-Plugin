using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Security_Plugin.Constants
{
    public class PluginConstants
    {
        //roleprivileges - privilegedepthmask - bit format, get by linq
        public const string SLNoAccess = "";
        public const string SLUser = "1";
        public const string SLBusinessUnit = "2";
        public const string SLChildBusinessUnit = "4";
        public const string SLOrganization = "8";

        public const int Basic = 0;
        public const int Local = 1;
        public const int Deep = 2;
        public const int Global = 3;

        //privilege - accessright
        public const string READ = "1";
        public const string WRITE = "2";
        public const string APPEND = "4";
        public const string APPENDTO = "16";
        public const string CREATE = "32";
        public const string DELETE = "65536";
        public const string SHARE = "262144";
        public const string ASSIGN = "524288";
    }

    public class CommentVote
    {
        public const string CommentVoteGUID = "cos_ces_commentvoteid";
        public const string Participation = "cos_ces_participation";
        public const string ResponseName = "cos_name";
        public const string CommentID = "cos_commentid";
        public const string CommentText = "cos_commenttext";
        public const string TotalVoteCount = "cos_totalvotecount";
        public const string UpVoteCount = "cos_upvotecount";
        public const string DownVoteCount = "cos_downvotecount";
        public const string PassUnsureCount = "cos_passunsurecount";
        public const string Question = "cos_question";
        public const string CreatedOn = "createdon";
    }
}
