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
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using TopApps.ViewModels;
using TopApps.Helpers;

namespace TopApps
{
    public partial class GroupEventPage : PhoneApplicationPage
    {
        private string groupId;
        private GroupViewModels vm;

        public GroupEventPage()
        {
            InitializeComponent();
            vm = new GroupViewModels();
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            if (NavigationContext.QueryString.TryGetValue("groupId", out groupId))
            {
                Navigation.Id = Convert.ToInt32(groupId);   
            }
            this.DataContext = vm;
            vm.Load();
        }
    }
}