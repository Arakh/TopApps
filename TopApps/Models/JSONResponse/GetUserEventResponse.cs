using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopApps.Models.JSONResponse
{
    public class UserEventData
    {
        public string event_id { get; set; }
        public string group_id { get; set; }
        public string creator_user_id { get; set; }
        public string location_name { get; set; }
        public string event_name { get; set; }
        public string latitude { get; set; }
        public string longitude { get; set; }
        public string event_time { get; set; }
        public string cancel_time { get; set; }
    }

    public class GetUserEventResponse
    {
        public string status { get; set; }
        public List<UserEventData> data { get; set; }
    }
}
