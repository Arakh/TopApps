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

namespace TopApps.ViewModels
{
    class HomeViewModels : BindableBase
    {
        private string URL = Resource.URL;
        private User _user;
        private ObservableCollection<Group> _groupCollection;
        private ObservableCollection<Event> _eventCollection;
       
        #region ObservableCollection

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
            //this.WCEvent();
            this.WCUser();
        }

        #region Web Client
        public void WCUser()
        {
            WebClient wcUser = new WebClient();
            wcUser.DownloadStringCompleted += new DownloadStringCompletedEventHandler(DownloadProfile);
            wcUser.DownloadStringAsync(new Uri(URL + "user/get_user_info?user_id=2"));
        }

        public void WCGroup()
        {
            WebClient wcGroup = new WebClient();
            wcGroup.DownloadStringCompleted += new DownloadStringCompletedEventHandler(DownloadGroup);
            wcGroup.DownloadStringAsync(new Uri(URL + "user/get_user_group?user_id=6"));
        }

        public void WCEvent()
        {
            WebClient wcEvent = new WebClient();
            wcEvent.DownloadStringCompleted += new DownloadStringCompletedEventHandler(DownloadEvent);
            wcEvent.DownloadStringAsync(new Uri(URL + "user/get_user_event?user_id=6"));
        }

        #endregion


        #region DownloadString
        private void DownloadEvent(object sender, DownloadStringCompletedEventArgs e)
        {
            try
            {
                JObject joEvent = JObject.Parse(e.Result);
                JArray jaEvent = JArray.Parse(joEvent.SelectToken("data").ToString());
                EventCollection.Clear();
                foreach (var item in jaEvent)
                {
                    Event events = new Event();
                    events.EventId = int.Parse(item.SelectToken("event_id").ToString());
                    events.GroupId = int.Parse(item.SelectToken("group_id").ToString());
                    events.EventName = item.SelectToken("event_name").ToString();
                    events.CreatorUserId = int.Parse(item.SelectToken("creator_user_id").ToString());
                    events.LocationName = item.SelectToken("location_name").ToString();
                    events.Latitude = double.Parse(item.SelectToken("latitude").ToString());
                    events.Longitude = double.Parse(item.SelectToken("longitude").ToString());
                    events.EventTime = DateTime.Parse(item.SelectToken("event_time").ToString());
                    events.CancelTime = DateTime.Parse(item.SelectToken("cancel_time").ToString());
                    EventCollection.Add(events);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DownloadGroup(object sender, DownloadStringCompletedEventArgs e)
        {
            try
            {
                JObject joGroup = JObject.Parse(e.Result);
                JArray jaGroup = JArray.Parse(joGroup.SelectToken("data").ToString());
                GroupCollection.Clear();

                foreach (var item in jaGroup)
                {
                    Group group = new Group();
                    group.GroupId = item.SelectToken("group_id").ToString();
                    group.CreatorId = item.SelectToken("creator_user_id").ToString();
                    group.GroupName = item.SelectToken("group_name").ToString();
                    group.GroupDescription = item.SelectToken("group_description").ToString();
                    group.GroupPhoto = item.SelectToken("group_photo").ToString();
                    _groupCollection.Add(group);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DownloadProfile(object sender, DownloadStringCompletedEventArgs e)
        {
            try
            {
                User user = new User();
                JObject joUser = JObject.Parse(e.Result);
   
                user.UserId = joUser.SelectToken("data").SelectToken("user_id").ToString();
                user.Username = joUser.SelectToken("data").SelectToken("user_name").ToString();
                user.Email = joUser.SelectToken("data").SelectToken("email").ToString();
                user.PhoneNumber = Int32.Parse(joUser.SelectToken("data").SelectToken("phone_number").ToString());
                user.Photo = joUser.SelectToken("data").SelectToken("user_photo").ToString();

                UserProfile = user;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.ToString());
            }
        }
            #endregion


         #region Command

            
           

            private void SetEventId(object parameter)
            {
                Event selectItemData = parameter as Event;

                if(selectItemData != null)
                    Navigation.Id = selectItemData.EventId;
            }

            private bool CanSetEventId(object parameter)
            {
                return true;
            }
            #endregion
        
    }
}
