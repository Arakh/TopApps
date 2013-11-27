using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using TopApps.ViewModels;

namespace TopApps
{
    public partial class SearchPage : PhoneApplicationPage
    {
        private GroupViewModels _viewModels;

        public SearchPage()
        {
            InitializeComponent();
        }

        private void SearchAppBar_Click(object sender, EventArgs e)
        {
            _viewModels = new GroupViewModels("search");
            _viewModels.SearchUser(tbUsername.Text, "2");
            SearchContent.ItemsSource = _viewModels.SearchUserCollection;
        }

       
    }
}