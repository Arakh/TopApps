using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopApps.Models
{
    class UserEvent : BindableBase
    {
        private int _userEventId;
        private int _eventId;
        private int _userId;
        private int _groupId;
        private int _status;

        public UserEvent(int userEventId, int eventId, int userId, int groupId, int status)
        {
            this.UserEventId = userEventId;
            this.EventId = eventId;
            this.UserId = userId;
            this.GroupId = groupId;
            this.Status = status;
        }

        public int Status
        {
            get { return _status; }
            set { SetProperty(ref this._status, value); }
        }

        public int GroupId
        {
            get { return _groupId; }
            set { SetProperty(ref this._groupId, value); }
        }

        public int UserId
        {
            get { return _userId; }
            set { SetProperty(ref this._userId, value); }
        }

        public int EventId
        {
            get { return _eventId; }
            set { SetProperty(ref this._eventId, value); }
        }

        public int UserEventId
        {
            get { return _userEventId; }
            set { SetProperty(ref this._userEventId, value); }
        } 
    }
}
