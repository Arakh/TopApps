using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Newtonsoft.Json.Linq;
using TopApps.Models;
using System.Windows.Media.Imaging;
using TopApps.Helpers;

namespace TopApps.ViewModels
{
    class GroupViewModels : BindableBase
    {

        #region attribute
        private string URL = Resource.BASE_URL;
        private ObservableCollection<Group> _groupCollection ;
        private ObservableCollection<User> _memberGroupsCollection;
        private ObservableCollection<Event> _eventGroupCollection;
        private ObservableCollection<User> _searchUserCollection;
        #endregion

        #region setter getter



        public ObservableCollection<Event> EventGroupCollection
        {
            get { return _eventGroupCollection; }
            set {SetProperty ( ref _eventGroupCollection, value); }
        }
        

        public ObservableCollection<User> MemberGroupsCollection
        {
            get { return _memberGroupsCollection; }
            set {SetProperty (ref  _memberGroupsCollection,  value); }
        }

        public ObservableCollection<Group> GroupCollection
        {
            get { return _groupCollection; }
            set { SetProperty(ref this._groupCollection, value); }
        }
        #endregion

        public void Load()
        {
            this.WCEventGroup();
            this.WCMemberGroup();
        }

        public GroupViewModels()
        {
            _eventGroupCollection = new ObservableCollection<Event>();
            _groupCollection = new ObservableCollection<Group>();
            _memberGroupsCollection = new ObservableCollection<User>();
            _searchUserCollection = new ObservableCollection<User>();
        }


        #region Web Client
        public void WCMemberGroup()
        {
            WebClient wcMemberGroup = new WebClient();
            wcMemberGroup.DownloadStringCompleted += new DownloadStringCompletedEventHandler(MemberGroup);
            wcMemberGroup.DownloadStringAsync(new Uri(URL + "group/get_group_users?group_id="+Navigation.Id));
        }

        public void WCEventGroup()
        {
            WebClient wcEventGroup = new WebClient();
            wcEventGroup.DownloadStringCompleted += new DownloadStringCompletedEventHandler(EventGroup);
            wcEventGroup.DownloadStringAsync(new Uri(URL + "group/get_group_events?group_id="+Navigation.Id)); 
        }
        #endregion

        public GroupViewModels(string view)
        { }

        

        private void EventGroup(object sender, DownloadStringCompletedEventArgs e)
        {
            try
            {
                JObject joEvent = JObject.Parse(e.Result);
                JArray jaEvent = JArray.Parse(joEvent.SelectToken("data").ToString());

                _eventGroupCollection = new ObservableCollection<Event>();

                foreach (var item in jaEvent)
                {
                    Event eEvent = new Event();
                    eEvent.EventId = int.Parse(item.SelectToken("event_id").ToString());
                    eEvent.EventName = item.SelectToken("event_name").ToString();
                    eEvent.GroupId = int.Parse(item.SelectToken("group_id").ToString());
                    eEvent.CreatorUserId = int.Parse(item.SelectToken("creator_user_id").ToString());
                    eEvent.LocationName = item.SelectToken("location_name").ToString();
                    eEvent.Longitude = double.Parse(item.SelectToken("longitude").ToString());
                    eEvent.Latitude = double.Parse(item.SelectToken("latitude").ToString());
                    eEvent.EventTime = DateTime.Parse(item.SelectToken("event_time").ToString());
                    eEvent.CancelTime = DateTime.Parse(item.SelectToken("cancel_time").ToString());
                    _eventGroupCollection.Add(eEvent);
                }
            }
            catch
            {
                MessageBox.Show("Load Event group gagal");
            }
        }

        private void MemberGroup(object sender, DownloadStringCompletedEventArgs e)
        {
            try
            {
                JObject joMember = JObject.Parse(e.Result);
                JArray jaMember = JArray.Parse(joMember.SelectToken("data").ToString());
                _memberGroupsCollection = new ObservableCollection<User>();

                foreach (var item in jaMember)
                {
                    User user = new User();
                    user.UserId = item.SelectToken("user_id").ToString();
                    user.Username = item.SelectToken("user_name").ToString();
                    user.Password = item.SelectToken("password").ToString();
                    user.FbId = item.SelectToken("fb_id").ToString();
                    user.Email = item.SelectToken("email").ToString();
                    user.PhoneNumber = item.SelectToken("phone_number").ToString();
                    user.Photo = item.SelectToken("user_photo").ToString();
                        //new BitmapImage(new Uri(Resource.MEDIA_URL + item.SelectToken("user_photo").ToString(), UriKind.Absolute));
                    user.FbToken = item.SelectToken("fb_token").ToString();
                    user.FbTokenValidTime = item.SelectToken("fb_token_valid_time").ToString();
                    _memberGroupsCollection.Add(user);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        
  
    }
}
