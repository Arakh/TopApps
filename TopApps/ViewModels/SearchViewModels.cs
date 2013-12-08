using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TopApps.Helpers;
using TopApps.Models;

namespace TopApps.ViewModels
{
    class SearchViewModels : BindableBase
    {

        private string URL = Resource.BASE_URL;
        private ObservableCollection<User> _searchUserCollection;

        public ObservableCollection<User> SearchUserCollection
        {
            get { return _searchUserCollection; }
            set { SetProperty(ref _searchUserCollection, value); }
        }

        public SearchViewModels()
        {
        }


        public void SearchUser(string query, string groupId)
        {
            WebClient wcSearch = new WebClient();
            wcSearch.DownloadStringCompleted += new DownloadStringCompletedEventHandler(SearchUser);
            wcSearch.DownloadStringAsync(new Uri(URL + "user/search_user?group_id=" + Navigation.Id + "&query=" + query));
        }

        private void SearchUser(object sender, DownloadStringCompletedEventArgs e)
        {
            try
            {
                JObject joSearch = JObject.Parse(e.Result);
                JArray jaSearch = JArray.Parse(joSearch.SelectToken("data").ToString());
                _searchUserCollection = new ObservableCollection<User>();
                foreach (var item in jaSearch)
                {
                    User user = new User();
                    user.UserId = item.SelectToken("user_id").ToString();
                    user.Username = item.SelectToken("user_name").ToString();
                    user.Password = item.SelectToken("password").ToString();
                    user.FbId = item.SelectToken("fb_id").ToString();
                    user.Email = item.SelectToken("email").ToString();
                    user.PhoneNumber = item.SelectToken("phone_number").ToString();
                    user.Photo = item.SelectToken("user_photo").ToString();
                    user.FbToken = item.SelectToken("fb_token").ToString();
                    user.FbTokenValidTime = item.SelectToken("fb_token_valid_time").ToString();
                    _searchUserCollection.Add(user);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
