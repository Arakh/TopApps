using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopApps.Models
{
    class Vote : BindableBase
    {
        private int _voteId;
        private int _userId;
        private int _groupId;
        private int _punishmentId;
        private bool _status;

        public Vote(int voteId, int userId, int groupId, int punishmnetId, bool status)
        {
            this.VoteId = voteId;
            this.UserId = userId;
            this.GroupId = groupId;
            this.PunishmentId = punishmnetId;
            this.Status = status;
        }

        public bool Status
        {
            get { return _status; }
            set { SetProperty(ref this._status, value); }
        }

        public int PunishmentId
        {
            get { return _punishmentId; }
            set { SetProperty(ref this._punishmentId, value); }
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

        public int VoteId
        {
            get { return _voteId; }
            set { SetProperty(ref this._voteId, value); }
        }
    }
}
