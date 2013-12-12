using Newtonsoft.Json;
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
using TopApps.Models.JSONResponse;

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
            _searchUserCollection = new ObservableCollection<User>();
        }


        public void SearchUser(string query, string groupId)
        {
            WebClient wcSearch = new WebClient();
            wcSearch.DownloadStringCompleted += new DownloadStringCompletedEventHandler(SearchUser);
            wcSearch.DownloadStringAsync(new Uri(URL + "user/search_user?group_id=3&query=t"));
            MessageBox.Show(Navigation.Id.ToString());
        }

        private void SearchUser(object sender, DownloadStringCompletedEventArgs e)
        {
            try
            {
                GetUserSearchResponse response = JsonConvert.DeserializeObject<GetUserSearchResponse>(e.Result);
                SearchUserCollection.Clear();
                foreach (UserSearchData item in response.data)
                {
                    SearchUserCollection.Add(new User(item.user_id,"",item.user_name,"",item.email,item.phone_number,item.user_photo));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
