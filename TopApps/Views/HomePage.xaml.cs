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
        private HomeViewModels vm;

        public HomePage()
        {
            InitializeComponent();

            this.vm = new HomeViewModels();
            this.DataContext = vm;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            this.vm.Load();
        }

        private void ApplicationBarIconButton_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/Views/GroupPage.xaml", UriKind.Relative));
        }

        private void ImgComingEvent_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            //NavigationService.Navigate(new Uri("/EventPage.xaml?eventId=", UriKind.Relative));
        }

        private void Pivot_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //PivotItem selectedItem = (PivotItem)e.AddedItems[0];

            //string strTag = (string)selectedItem.Tag;

            //if(strTag == "EventItem")
            //    this.wc
        }


        private void newGroupApp_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/Views/CreateGroupPage.xaml", UriKind.Relative));
        }

        private void ItemsSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var eventId = ((Models.Event)EventContent.SelectedValue).EventId;
            NavigationService.Navigate(new Uri("/Views/EventPage.xaml?eventId=" + eventId, UriKind.Relative));
         }

        private void GroupContent_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var groupId = ((Models.Group)GroupContent.SelectedValue).GroupId;
            NavigationService.Navigate(new Uri("/Views/GroupPage.xaml?groupId=" + groupId, UriKind.Relative));
        }

    }
}