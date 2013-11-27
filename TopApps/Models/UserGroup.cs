using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopApps.Models
{
    class UserGroup : BindableBase
    {
        private string _userGroupId;
        private string _groupId;
        private string _userId;
        private int _numberOfLate;
        private int _numberOfMissSchedule;
        private int _numberOfOnTime;
        private int _numberOfAbsent;
        private bool _status;

        public UserGroup(string userGroupId, string groupId, string userId, int numberOfLate, int numberOfMissSchedule, int numberOfOnTime, int numberOfAbsent, bool status)
        {
            this.UserGroupId = userGroupId;
            this.GroupId = groupId;
            this.UserId = userId;
            this.NumberOfLate = numberOfLate;
            this.NumberOfMissSchedule = numberOfMissSchedule;
            this.NumberOfAbsent = numberOfAbsent;
            this.Status = status;
        }

        public UserGroup()
        { }

        public bool Status
        {
            get { return _status; }
            set { SetProperty( ref this._status, value); }
        }

        public int NumberOfAbsent
        {
            get { return _numberOfAbsent; }
            set { SetProperty(ref this._numberOfAbsent, value); }
        }

        public int NumberOfOnTime
        {
            get { return _numberOfOnTime; }
            set { SetProperty(ref this._numberOfOnTime, value); }
        }

        public int NumberOfMissSchedule
        {
            get { return _numberOfMissSchedule; }
            set { SetProperty(ref this._numberOfMissSchedule, value); }
        }

        public int NumberOfLate
        {
            get { return _numberOfLate; }
            set { SetProperty(ref this._numberOfLate, value); }
        }

        public string UserId
        {
            get { return _userId; }
            set { SetProperty(ref this._userId, value); ; }
        }

        public string GroupId
        {
            get { return _groupId; }
            set { SetProperty(ref this._groupId, value); }
        }

        public string UserGroupId
        {
            get { return _userGroupId; }
            set { SetProperty(ref this._userGroupId, value); }
        }
    }
}
