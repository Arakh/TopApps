using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using TopApps.Models;

namespace TopApps.ViewModels
{
    class UserInfoViewModels : BindableBase
    {
        private ObservableCollection<User> _userCollection = new ObservableCollection<User>();
        const string URL = "http://project.aditiarakhmat.com/TopApps/index.php/";

        public ObservableCollection<User> UserCollection
        {
            get { return _userCollection; }
            set { SetProperty(ref _userCollection, value); }
        }

        public UserInfoViewModels()
        {
            WebClient wcUserInfo = new WebClient();
            wcUserInfo.DownloadStringCompleted += new DownloadStringCompletedEventHandler(ProfileDownloadCompleted);
            wcUserInfo.DownloadStringAsync(new Uri(URL + "user/get_user_info?user_id=2"));
        }

        private void ProfileDownloadCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            User user = new User();
            JObject joUser = JObject.Parse(e.Result);
            
            user.UserId = joUser.SelectToken("data").SelectToken("user_id").ToString();
            user.Username = joUser.SelectToken("data").SelectToken("user_name").ToString();
            user.Email = joUser.SelectToken("data").SelectToken("email").ToString();
            user.PhoneNumber = Int32.Parse(joUser.SelectToken("data").SelectToken("phone_number").ToString());
            user.Photo = joUser.SelectToken("data").SelectToken("user_photo").ToString();
            UserCollection.Add(user);
        }
    }
}
