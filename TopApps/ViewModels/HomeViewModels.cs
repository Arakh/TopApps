using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using TopApps.Models;
using System.Windows;
using TopApps.Helpers;
using Newtonsoft.Json;
using TopApps.Models.JSONResponse;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Input;

namespace TopApps.ViewModels
{
    class HomeViewModels : BindableBase
    {
        #region Attribute

        private string URL = Resource.BASE_URL;
        private User _user;
        private ObservableCollection<Group> _groupCollection;
        private ObservableCollection<Event> _eventCollection;

        #endregion

        #region Getter Setter

        public ObservableCollection<Event> EventCollection
        {
            get { return _eventCollection; }
            set { SetProperty(ref _eventCollection, value); }
        }

        public ObservableCollection<Group> GroupCollection
        {
            get { return _groupCollection; }
            set { SetProperty (ref _groupCollection,  value); }
        }

        public User UserProfile
        {
            get { return _user; }
            set { SetProperty(ref _user, value); }
        }

        #endregion

        public HomeViewModels()
        {
            _user = new User();
            _groupCollection = new ObservableCollection<Group>();
            _eventCollection = new ObservableCollection<Event>();
        }

        #region ILoadable

        public void Load()
        {
            this.WCUser();
            this.WCEvent();
            this.WCGroup();
        }

        public void Refresh()
        {
            
        }

        #endregion

        #region Web Client
        public void WCUser()
        {
            WebClient wcUser = new WebClient();
            wcUser.DownloadStringCompleted += new DownloadStringCompletedEventHandler(DownloadProfileComplete);
            wcUser.DownloadStringAsync(new Uri(URL + "user/get_user_info?user_id=2"));
        }

        public void WCGroup()
        {
            WebClient wcGroup = new WebClient();
            wcGroup.DownloadStringCompleted += new DownloadStringCompletedEventHandler(DownloadGroupComplete);
            wcGroup.DownloadStringAsync(new Uri(URL + "user/get_user_group?user_id=6"));
        }

        public void WCEvent()
        {
            WebClient wcEvent = new WebClient();
            wcEvent.DownloadStringCompleted += new DownloadStringCompletedEventHandler(DownloadEventComplete);
            Uri uri = new Uri(URL + "user/get_user_event?user_id=2");
            wcEvent.DownloadStringAsync(uri);
        }

        #endregion

        #region DownloadString
        private void DownloadEventComplete(object sender, DownloadStringCompletedEventArgs e)
        {
            try
            {
                EventCollection.Clear();
                GetUserEventResponse response = JsonConvert.DeserializeObject<GetUserEventResponse>(e.Result);
                foreach (UserEventData item in response.data)
                {
                    EventCollection.Add(new Event(int.Parse(item.event_id), int.Parse(item.creator_user_id), int.Parse(item.group_id), item.event_name, item.location_name, Double.Parse(item.latitude), Double.Parse(item.longitude), DateTime.Parse(item.event_time), DateTime.Parse(item.cancel_time)));
                }
            }
            catch (Exception)
            {
                 MessageBox.Show("Load event gagal");
            }
        }

        private void DownloadGroupComplete(object sender, DownloadStringCompletedEventArgs e)
        {
            try
            {
                GroupCollection.Clear();
                GetUserGroupResponse response = JsonConvert.DeserializeObject<GetUserGroupResponse>(e.Result);

                foreach (UserGroupData item in response.data)
                {
                    GroupCollection.Add(new Group(item.group_id, item.group_name, item.group_description, item.group_photo));
                }
            }
            catch (Exception)
            {
                // MessageBox.Show("Load group gagal");
            }
        }

        private void DownloadProfileComplete(object sender, DownloadStringCompletedEventArgs e)
        {
            try
            {
                GetUserInfoResponse response = JsonConvert.DeserializeObject<GetUserInfoResponse>(e.Result);

                this.UserProfile.UserId = response.data.user_id;
                this.UserProfile.Username = response.data.user_name;
                this.UserProfile.Email = response.data.email;
                this.UserProfile.PhoneNumber = response.data.phone_number;
                this.UserProfile.Photo = response.data.user_photo;
                    //new BitmapImage(new Uri(Resource.MEDIA_URL + response.data.user_photo, UriKind.Absolute));
            }
            catch (Exception)
            {
               //  MessageBox.Show("Load user gagal");
            }
        }
        #endregion

    }
}
