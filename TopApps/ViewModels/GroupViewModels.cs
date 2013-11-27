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

namespace TopApps.ViewModels
{
    class GroupViewModels : BindableBase
    {
        private string URL = Resource.URL;
        private ObservableCollection<Group> _groupCollection = new ObservableCollection<Group>();
        private ObservableCollection<User> _memberGroupsCollection;
        private ObservableCollection<Event> _eventGroupCollection;
        private ObservableCollection<User> _searchUserCollection;

        internal ObservableCollection<User> SearchUserCollection
        {
            get { return _searchUserCollection; }
            set { SetProperty(ref _searchUserCollection, value); }
        }


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

        public GroupViewModels()
        {
            WebClient wcMemberGroup = new WebClient();
            wcMemberGroup.DownloadStringCompleted += new DownloadStringCompletedEventHandler(MemberGroup);
            wcMemberGroup.DownloadStringAsync(new Uri(URL + "group/get_group_users?group_id=3"));

            WebClient wcEventGroup = new WebClient();
            wcEventGroup.DownloadStringCompleted += new DownloadStringCompletedEventHandler(EventGroup);
            wcEventGroup.DownloadStringAsync(new Uri(URL + "group/get_group_events?group_id=3")); 
        }

        public GroupViewModels(string view)
        { }

        public void SearchUser(string query, string groupId)
        {
            WebClient wcSearch = new WebClient();
            wcSearch.DownloadStringCompleted += new DownloadStringCompletedEventHandler(SearchUser);
            wcSearch.DownloadStringAsync(new Uri(URL + "user/search_user?group_id="+groupId+"&query="+query));
        }

        public bool CreateGroup(Group group)
        {
            try
            {
                StringBuilder parameter = new StringBuilder();
                parameter.AppendFormat("{0}={1}&", "creatorId", HttpUtility.HtmlEncode(group.CreatorId));
                parameter.AppendFormat("{0}={1}&", "nameGroup", HttpUtility.HtmlEncode(group.GroupName));
                parameter.AppendFormat("{0}={1}&", "descriptionGroup", HttpUtility.HtmlEncode(group.GroupDescription));
                parameter.AppendFormat("{0}={1}&", "pictureGroup", HttpUtility.HtmlEncode(group.GroupPhoto));

                WebClient wcCreateGroup = new WebClient();
                wcCreateGroup.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
                wcCreateGroup.Headers[HttpRequestHeader.ContentLength] = parameter.Length.ToString();
                wcCreateGroup.UploadStringCompleted += new UploadStringCompletedEventHandler(CreateGroup);
                wcCreateGroup.UploadStringAsync(new Uri(URL + "group/creator_user_id"), "POST", parameter.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return false;
        }

        private void SearchUser(object sender, DownloadStringCompletedEventArgs e)
        {
            try
            {
                JObject joSearch = JObject.Parse(e.Result);
                JArray jaSearch = JArray.Parse(joSearch.SelectToken("data").ToString());
                _searchUserCollection = new ObservableCollection<User>();
                foreach(var item in jaSearch)
                {
                    User user = new User();
                    user.UserId = item.SelectToken("user_id").ToString();
                    user.Username = item.SelectToken("user_name").ToString();
                    user.Password = item.SelectToken("password").ToString();
                    user.FbId = item.SelectToken("fb_id").ToString();
                    user.Email = item.SelectToken("email").ToString();
                    user.PhoneNumber = int.Parse(item.SelectToken("phone_number").ToString());
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

        private void EventGroup(object sender, DownloadStringCompletedEventArgs e)
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
                    user.PhoneNumber = int.Parse(item.SelectToken("phone_number").ToString());
                    user.Photo = item.SelectToken("user_photo").ToString();
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

        public void CreateGroup(Object sender, UploadStringCompletedEventArgs e)
        {
            MessageBox.Show(e.Result.ToString());
        }
  
    }
}
