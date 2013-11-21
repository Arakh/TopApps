using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopApps.Models
{
    class User : BindableBase
    {
        private string _userId;
        private string _fbId;
        private string _password;
        private string _email;
        private int _phoneNumber;
        private string _username;
        private string _photo;


        public User(string userId, string fbId, string username, string password, string email, int phoneNumber, string photo)
        {
            this.UserId = userId;
            this.FbId = fbId;
            this.Username = username;
            this.Password = password;
            this.Email = email;
            this.PhoneNumber = phoneNumber;
            this.Photo = photo;
        }

        public User()
        {
            
        }



        public int PhoneNumber
        {
            get { return _phoneNumber; }
            set { SetProperty(ref this._phoneNumber, value); }
        }

        public string Email
        {
            get { return _email; }
            set { SetProperty(ref this._email, value); }
        }

        public string Password
        {
            get { return _password; }
            set { SetProperty (ref this._password, value); }
        }

        public string UserId
        {
            get { return _userId; }
            set { SetProperty(ref this._userId, value); }
        }

        public string FbId
        {
            get { return _fbId; }
            set { SetProperty( ref this._fbId, value); }
        }

        public string Username
        {
            get { return _username; }
            set { SetProperty( ref this._username, value); }
        }

        public string Photo
        {
            get { return _photo; }
            set { SetProperty(ref this._photo, value); }
        }
    }
}
