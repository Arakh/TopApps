using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopApps.Models.JSONResponse
{
    public class UserInfoData
    {
        public string user_id { get; set; }
        public string user_name { get; set; }
        public string email { get; set; }
        public string phone_number { get; set; }
        public string user_photo { get; set; }
    }

    class GetUserInfoResponse
    {
        public string status { get; set; }
        public UserInfoData data { get; set; }
    }
}
