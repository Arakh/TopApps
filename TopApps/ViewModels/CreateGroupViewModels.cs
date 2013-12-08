
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TopApps.Models;

namespace TopApps.ViewModels
{
    class CreateGroupViewModels : BindableBase
    {
        private string URL = Resource.BASE_URL;

        public bool CreateGroup(Group group)
        {
            try
            {
                StringBuilder parameter = new StringBuilder();
                parameter.AppendFormat("{0}={1}&", "creatorId", HttpUtility.HtmlEncode(group.CreatorId));
                parameter.AppendFormat("{0}={1}&", "nameGroup", HttpUtility.HtmlEncode(group.GroupName));
                parameter.AppendFormat("{0}={1}&", "descriptionGroup", HttpUtility.HtmlEncode(group.GroupDescription));
                // parameter.AppendFormat("{0}={1}&", "pictureGroup", HttpUtility.HtmlEncode(group.GroupPhoto));

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

        public void CreateGroup(Object sender, UploadStringCompletedEventArgs e)
        {
            MessageBox.Show(e.Result.ToString());
        }
    }
}
