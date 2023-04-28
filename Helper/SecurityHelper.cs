using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Query;
using Microsoft.Xrm.Sdk;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Security_Plugin.Helper
{
    public static class SecurityHelper
    {
        public static EntityCollection GetSecurityRole(
          this IOrganizationService orgService,
          Guid businessUnitId = default(Guid))
        {
            string[] strArray = new string[1] { "Support User" };
            QueryExpression query = new QueryExpression("role");
            query.ColumnSet.AddColumns(new string[3]
            {
        "roleid",
        "name",
        "businessunitid"
            });
            query.Criteria.AddCondition(new ConditionExpression("name", (ConditionOperator)9, (object[])strArray));
            if (businessUnitId != Guid.Empty)
                query.Criteria.AddCondition(new ConditionExpression("businessunitid", (ConditionOperator)0, (object)businessUnitId));
            return orgService.FetchAllRecords(query);
        }

        public static EntityCollection GetUsers(
          this IOrganizationService orgService,
          Guid businessUnitId = default(Guid))
        {
            QueryExpression query = new QueryExpression("systemuser");
            query.ColumnSet.AddColumns(new string[9]
            {
        "systemuserid",
        "fullname",
        "businessunitid",
        "domainname",
        "firstname",
        "lastname",
        "title",
        "internalemailaddress",
        "accessmode"
            });
            query.Criteria.AddCondition(new ConditionExpression("isdisabled", (ConditionOperator)0, (object)false));
            query.Criteria.AddCondition(new ConditionExpression("accessmode", (ConditionOperator)1, (object)3));
            query.Criteria.AddCondition(new ConditionExpression("accessmode", (ConditionOperator)1, (object)5));
            if (businessUnitId != Guid.Empty)
                query.Criteria.AddCondition(new ConditionExpression("businessunitid", (ConditionOperator)0, (object)businessUnitId));
            return orgService.FetchAllRecords(query);
        }

        public static EntityCollection GetTeams(
          this IOrganizationService orgService,
          Guid businessUnitId = default(Guid))
        {
            QueryExpression query = new QueryExpression("team");
            query.ColumnSet.AddColumns(new string[4]
            {
        "teamid",
        "name",
        "businessunitid",
        "isdefault"
            });
            query.Criteria.AddCondition(new ConditionExpression("teamtype", (ConditionOperator)0, (object)0));
            query.Criteria.AddCondition(new ConditionExpression("systemmanaged", (ConditionOperator)0, (object)false));
            if (businessUnitId != Guid.Empty)
                query.Criteria.AddCondition(new ConditionExpression("businessunitid", (ConditionOperator)0, (object)businessUnitId));
            return orgService.FetchAllRecords(query);
        }

        public static EntityCollection GetBusinessUnits(this IOrganizationService orgService)
        {
            QueryExpression query = new QueryExpression("businessunit");
            query.ColumnSet.AddColumns(new string[4]
            {
        "name",
        "businessunitid",
        "parentbusinessunitid",
        "isdisabled"
            });
            return orgService.FetchAllRecords(query);
        }

        public static EntityCollection GetUserRole(
          this IOrganizationService orgService,
          List<Guid> userIds = null)
        {
            QueryExpression query = new QueryExpression("systemuserroles");
            if (userIds != null)
                query.Criteria.AddCondition(new ConditionExpression("systemuserid", (ConditionOperator)8, (ICollection)userIds));
            query.ColumnSet.AddColumns(new string[2]
            {
        "roleid",
        "systemuserid"
            });
            return orgService.FetchAllRecords(query);
        }

        public static EntityCollection GetUserTeam(
          this IOrganizationService orgService,
          List<Guid> userIds = null)
        {
            QueryExpression query = new QueryExpression("teammembership");
            if (userIds != null)
                query.Criteria.AddCondition(new ConditionExpression("systemuserid", (ConditionOperator)8, (ICollection)userIds));
            query.ColumnSet.AddColumns(new string[2]
            {
        "systemuserid",
        "teamid"
            });
            return orgService.FetchAllRecords(query);
        }

        public static EntityCollection GetTeamRole(this IOrganizationService orgService)
        {
            QueryExpression query = new QueryExpression("teamroles");
            query.ColumnSet.AddColumns(new string[2]
            {
        "teamid",
        "roleid"
            });
            return orgService.FetchAllRecords(query);
        }

        public static EntityCollection GetFieldSecurityProfiles(this IOrganizationService orgService)
        {
            QueryExpression query = new QueryExpression("fieldsecurityprofile");
            query.ColumnSet.AddColumns(new string[1] { "name" });
            return orgService.FetchAllRecords(query);
        }

        public static EntityCollection GetUserFieldSecurityProfile(
          this IOrganizationService orgService,
          List<Guid> userIds = null)
        {
            QueryExpression query = new QueryExpression("systemuserprofiles");
            if (userIds != null)
                query.Criteria.AddCondition(new ConditionExpression("systemuserid", (ConditionOperator)8, (ICollection)userIds));
            query.ColumnSet.AddColumns(new string[2]
            {
        "systemuserid",
        "fieldsecurityprofileid"
            });
            return orgService.FetchAllRecords(query);
        }

        public static EntityCollection GetTeamFieldSecurityProfile(this IOrganizationService orgService)
        {
            QueryExpression query = new QueryExpression("teamprofiles");
            query.ColumnSet.AddColumns(new string[2]
            {
        "teamid",
        "fieldsecurityprofileid"
            });
            return orgService.FetchAllRecords(query);
        }

        public static EntityCollection GetUserAllRoles(
          this IOrganizationService orgService,
          Guid userId)
        {
            EntityCollection userAllRoles = new EntityCollection();
            EntityCollection userDirectRoles = orgService.GetUserDirectRoles(userId);
            EntityCollection userTeamRoles = orgService.GetUserTeamRoles(userId);
            userAllRoles.Entities.AddRange((IEnumerable<Entity>)userDirectRoles.Entities);
            userAllRoles.Entities.AddRange((IEnumerable<Entity>)userTeamRoles.Entities);
            return userAllRoles;
        }

        public static EntityCollection GetUserDirectRoles(
          this IOrganizationService orgService,
          Guid userId)
        {
            QueryExpression query = new QueryExpression("role");
            query.ColumnSet.AddColumns(new string[3]
            {
        "roleid",
        "name",
        "businessunitid"
            });
            LinkEntity linkEntity = new LinkEntity()
            {
                LinkFromEntityName = "role",
                LinkFromAttributeName = "roleid",
                LinkToEntityName = "systemuserroles",
                LinkToAttributeName = "roleid",
                JoinOperator = (JoinOperator)0,
                EntityAlias = "userroles"
            };
            linkEntity.LinkCriteria.AddCondition(new ConditionExpression("systemuserid", (ConditionOperator)0, (object)userId));
            ((Collection<LinkEntity>)query.LinkEntities).Add(linkEntity);
            return orgService.FetchAllRecords(query);
        }

        public static EntityCollection GetUserTeamRoles(
          this IOrganizationService orgService,
          Guid userId)
        {
            QueryExpression query = new QueryExpression("role");
            query.ColumnSet.AddColumns(new string[3]
            {
        "roleid",
        "name",
        "businessunitid"
            });
            LinkEntity linkEntity1 = new LinkEntity()
            {
                LinkFromEntityName = "role",
                LinkFromAttributeName = "roleid",
                LinkToEntityName = "teamroles",
                LinkToAttributeName = "roleid",
                JoinOperator = (JoinOperator)0,
                EntityAlias = "teamroles"
            };
            ((Collection<LinkEntity>)query.LinkEntities).Add(linkEntity1);
            LinkEntity linkEntity2 = new LinkEntity()
            {
                LinkFromEntityName = "teamroles",
                LinkFromAttributeName = "teamid",
                LinkToEntityName = "team",
                LinkToAttributeName = "teamid",
                JoinOperator = (JoinOperator)0,
                EntityAlias = "teams"
            };
            linkEntity2.Columns.AddColumn("name");
            ((Collection<LinkEntity>)linkEntity1.LinkEntities).Add(linkEntity2);
            LinkEntity linkEntity3 = new LinkEntity()
            {
                LinkFromEntityName = "team",
                LinkFromAttributeName = "teamid",
                LinkToEntityName = "teammembership",
                LinkToAttributeName = "teamid",
                JoinOperator = (JoinOperator)0,
                EntityAlias = "members"
            };
            linkEntity3.LinkCriteria.AddCondition(new ConditionExpression("systemuserid", (ConditionOperator)0, (object)userId));
            ((Collection<LinkEntity>)linkEntity2.LinkEntities).Add(linkEntity3);
            EntityCollection userTeamRoles = orgService.FetchAllRecords(query);
            foreach (Entity entity in (Collection<Entity>)userTeamRoles.Entities)
            {
                string str = string.Empty;
                if (entity.Contains("teams.name"))
                    str = ((AliasedValue)entity["teams.name"]).Value.ToString();
                if (string.IsNullOrEmpty(str))
                    str = "--";
                ((DataCollection<string, object>)entity.Attributes).Add(new KeyValuePair<string, object>("teamname", (object)str));
            }
            return userTeamRoles;
        }

        public static EntityCollection GetPrivileges(
          this IOrganizationService orgService,
          Guid[] securityRoleIds)
        {
            QueryExpression query = new QueryExpression("roleprivileges");
            query.ColumnSet.AddColumns(new string[2]
            {
        "privilegeid",
        "privilegedepthmask"
            });
            LinkEntity linkEntity1 = query.AddLink("role", "roleid", "roleid");
            linkEntity1.EntityAlias = "roles";
            linkEntity1.Columns.AddColumns(new string[2]
            {
        "name",
        "roleid"
            });
            if (securityRoleIds.Length > 1)
            {
                FilterExpression filterExpression = new FilterExpression((LogicalOperator)1);
                foreach (Guid securityRoleId in securityRoleIds)
                    ((Collection<ConditionExpression>)filterExpression.Conditions).Add(new ConditionExpression("roleid", (ConditionOperator)0, (object)securityRoleId));
                ((Collection<FilterExpression>)linkEntity1.LinkCriteria.Filters).Add(filterExpression);
            }
            else if (securityRoleIds.Length == 1)
                linkEntity1.LinkCriteria.AddCondition("roleid", (ConditionOperator)0, new object[1]
                {
          (object) securityRoleIds[0]
                });
            LinkEntity linkEntity2 = query.AddLink("privilege", "privilegeid", "privilegeid");
            linkEntity2.EntityAlias = "privileges";
            linkEntity2.Columns.AddColumns(new string[6]
            {
        "name",
        "accessright",
        "canbebasic",
        "canbedeep",
        "canbeglobal",
        "canbelocal"
            });
            LinkEntity linkEntity3 = linkEntity2.AddLink("privilegeobjecttypecodes", "privilegeid", "privilegeid");
            linkEntity3.EntityAlias = "pva";
            linkEntity3.Columns.AddColumns(new string[1]
            {
        "objecttypecode"
            });
            return orgService.FetchAllRecords(query);
        }

        public static void MergerRoles(
          this IOrganizationService orgService,
          EntityCollection allRolePrevs,
          string newSecurityRoleName,
          Guid businessUnitId = default(Guid))
        {
            if (businessUnitId == Guid.Empty)
            {
                QueryExpression query = new QueryExpression("businessunit");
                query.Criteria.AddCondition(new ConditionExpression("parentbusinessunitid", (ConditionOperator)12));
                businessUnitId = ((Collection<Entity>)orgService.FetchAllRecords(query).Entities)[0].Id;
            }
            Guid guid = orgService.Create(new Entity("role")
            {
                ["name"] = (object)newSecurityRoleName,
                ["businessunitid"] = (object)new EntityReference("businessunit", businessUnitId)
            });
            IEnumerable<Entity> entities = ((IEnumerable<Entity>)allRolePrevs.Entities).GroupBy<Entity, object>((Func<Entity, object>)(a => ((DataCollection<string, object>)a.Attributes)["privilegeid"])).Select<IGrouping<object, Entity>, Entity>((Func<IGrouping<object, Entity>, Entity>)(group => group.First<Entity>()));
            List<RolePrivilege> rolePrivilegeList = new List<RolePrivilege>();
            foreach (Entity entity in entities)
            {
                Entity prv = entity;
                ((IEnumerable<Entity>)allRolePrevs.Entities).Where<Entity>((Func<Entity, bool>)(c => (Guid)((DataCollection<string, object>)c.Attributes)["privilegeid"] == (Guid)prv["privilegeid"])).Count<Entity>();
                object depth = ((IEnumerable<Entity>)allRolePrevs.Entities).Where<Entity>((Func<Entity, bool>)(c => (Guid)((DataCollection<string, object>)c.Attributes)["privilegeid"] == (Guid)prv["privilegeid"])).GroupBy<Entity, object>((Func<Entity, object>)(a => ((DataCollection<string, object>)a.Attributes)["privilegeid"])).Select<IGrouping<object, Entity>, object>((Func<IGrouping<object, Entity>, object>)(group => group.Max<Entity, object>((Func<Entity, object>)(b => ((DataCollection<string, object>)b.Attributes)["privilegedepthmask"])))).FirstOrDefault<object>();
                RolePrivilege rolePrivilege = new RolePrivilege()
                {
                    Depth = depth != null ? SecurityHelper.GetDepth((int)depth) : (PrivilegeDepth)(object)0,
                    PrivilegeId = (Guid)prv["privilegeid"]
                };
                rolePrivilegeList.Add(rolePrivilege);
            }
            AddPrivilegesRoleRequest privilegesRoleRequest = new AddPrivilegesRoleRequest()
            {
                RoleId = guid,
                Privileges = rolePrivilegeList.ToArray()
            };
            AddPrivilegesRoleResponse privilegesRoleResponse = (AddPrivilegesRoleResponse)orgService.Execute((OrganizationRequest)privilegesRoleRequest);
        }

        public static PrivilegeDepth GetDepth(int depth)
        {
            switch (depth)
            {
                case 2:
                    return (PrivilegeDepth)1;
                case 4:
                    return (PrivilegeDepth)2;
                case 8:
                    return (PrivilegeDepth)3;
                default:
                    return (PrivilegeDepth)0;
            }
        }

        private static EntityCollection FetchAllRecords(
          this IOrganizationService orgService,
          QueryExpression query)
        {
            List<Entity> entityList = new List<Entity>();
            query.PageInfo = new PagingInfo();
            query.PageInfo.PageNumber = 1;
            while (true)
            {
                EntityCollection entityCollection = orgService.RetrieveMultiple((QueryBase)query);
                if (((Collection<Entity>)entityCollection.Entities).Count >= 1)
                    entityList.AddRange((IEnumerable<Entity>)entityCollection.Entities);
                if (entityCollection.MoreRecords)
                {
                    ++query.PageInfo.PageNumber;
                    query.PageInfo.PagingCookie = entityCollection.PagingCookie;
                }
                else
                    break;
            }
            return new EntityCollection((IList<Entity>)entityList);
        }
    }
}
