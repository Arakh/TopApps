using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopApps.Models
{
    class Event : BindableBase
    {
        private int _eventId;
        private int _creatorUserId;
        private int _groupId;
        private string _eventName;
        private string _locationName;
        private double _latitude;
        private double _longitude;
        private DateTime _eventTime;
        private DateTime _cancelTime;
        private string _imgGroup;

        public string ImgGroup
        {
            get { return "/TopApps;component/Assets/Images/GroupPicture.jpg"; }
            set { _imgGroup = "/TopApps;component/Assets/Images/GroupPicture.jpg"; }
        }

        public Event(int eventId, int creatorUserId, int groupId, string eventName, string locationName, double latitude, double longitude, DateTime eventTime, DateTime cancelTime)
        {
            this.EventId = eventId;
            this.CreatorUserId = creatorUserId;
            this.GroupId = groupId;
            this.EventName = eventName;
            this.LocationName = locationName;
            this.Latitude = latitude;
            this.Longitude = longitude;
            this.EventName = eventName;
            this.CancelTime = cancelTime;
        }

        public  Event()
        { }

        public DateTime CancelTime
        {
            get { return _cancelTime; }
            set { SetProperty( ref this._cancelTime, value); }
        }

        public DateTime EventTime
        {
            get { return _eventTime; }
            set { SetProperty(ref this._eventTime, value); }
        }

        public double Longitude
        {
            get { return _longitude; }
            set { SetProperty(ref this._longitude, value); ; }
        }

        public double Latitude
        {
            get { return _latitude; }
            set { SetProperty(ref this._latitude, value); }
        }

        public string LocationName
        {
            get { return _locationName; }
            set { SetProperty(ref this._locationName, value); }
        }

        public string EventName
        {
            get { return _eventName; }
            set { SetProperty(ref this._eventName, value); }
        }

        public int GroupId
        {
            get { return _groupId; }
            set { SetProperty(ref this._groupId, value); }
        }

        public int CreatorUserId
        {
            get { return _creatorUserId; }
            set { SetProperty(ref this._creatorUserId, value); }
        }

        public int EventId
        {
            get { return _eventId; }
            set { SetProperty(ref this._eventId, value); }
        }
    }
}
