using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using TopApps.Models;
using TopApps.ViewModels;

namespace TopApps
{
    public partial class HomePage : PhoneApplicationPage
    {
        private HomeViewModels _profileVM;
        private HomeViewModels _groupVM;
        private HomeViewModels _eventVM;
        private HomeViewModels _tempProfileVM;
        private HomeViewModels _tempGroupVM;
        private HomeViewModels _tempEventVM;

        public HomePage()
        {
            _profileVM = new HomeViewModels();
            _groupVM = new HomeViewModels();
            _eventVM = new HomeViewModels();
            _tempProfileVM = _profileVM;
            _tempGroupVM = _groupVM;
            _tempEventVM = _eventVM;

            InitializeComponent();

            ProfileItem.DataContext = _profileVM.UserProfile;
            this.DataContext = _profileVM;
        }

        private void ApplicationBarIconButton_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/Views/CreateGroupPage.xaml", UriKind.Relative));
        }

        private void ImgComingEvent_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/EventPage.xaml?eventId=", UriKind.Relative));
        }

        private void Pivot_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //PivotItem selectedItem = (PivotItem)e.AddedItems[0];

            //string strTag = (string)selectedItem.Tag;

            //if(strTag == "EventItem")
            //    this.wc
        }

        #region Command
        #endregion
    }
}