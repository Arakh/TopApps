using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopApps.Models
{
    class Punishment : BindableBase
    {

        public Punishment(int punishmentId, int groupId, int userId, int userPoint, string description)
        {
            this.PunishmentId = punishmentId;
            this.GroupId = groupId;
            this.UserId = userId;
            this.UserPoint = userPoint;
            this.Description = description;
        }

        private int _punishmentId;
        private int _groupId;
        private int _userId;
        private int _userPoint;
        private string _description;

        public string Description
        {
            get { return _description; }
            set { SetProperty(ref this._description, value); }
        }

        public int UserPoint
        {
            get { return _userPoint; }
            set { SetProperty(ref this._userPoint, value); }
        }

        public int UserId
        {
            get { return _userId; }
            set { SetProperty(ref this._userId, value); }
        }

        public int GroupId
        {
            get { return _groupId; }
            set { SetProperty(ref this._groupId, value); }
        }

        public int PunishmentId
        {
            get { return _punishmentId; }
            set { SetProperty(ref this._punishmentId, value); }
        }
    }
}
