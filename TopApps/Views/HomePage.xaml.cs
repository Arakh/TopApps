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
using TopApps.Models;
using TopApps.ViewModels;

namespace TopApps
{
    public partial class HomePage : PhoneApplicationPage
    {
        private UserInfoViewModels userVM;
        public HomePage()
        {
            userVM = new UserInfoViewModels();
            InitializeComponent();
            profileContent.ItemsSource = userVM.UserCollection;
        }
    }
}