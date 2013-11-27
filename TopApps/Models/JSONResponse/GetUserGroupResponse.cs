using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopApps.Models.JSONResponse
{
    public class UserGroupData
    {
        public string group_id { get; set; }
        public string creator_user_id { get; set; }
        public string group_name { get; set; }
        public string group_description { get; set; }
        public string group_photo { get; set; }
    }

    public class GetUserGroupResponse
    {
        public string status { get; set; }
        public List<UserGroupData> data { get; set; }
    }
}
