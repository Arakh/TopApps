using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopApps.Models
{
    class Log : BindableBase
    {
        private int _logId;
        private int _userId;
        private int _groupId;
        private int _action;

        public Log(int logId, int userId, int groupId, int action)
        {
            this.LogId = logId;
            this.UserId = userId;
            this.GroupId = groupId;
            this.Action = action;
        }

        public int Action
        {
            get { return _action; }
            set { SetProperty(ref this._action, value); }
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

        public int LogId
        {
            get { return _logId; }
            set { SetProperty(ref this._logId, value); }
        }
    }
}
