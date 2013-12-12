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
using TopApps.Helpers;

namespace TopApps
{
    public partial class SearchPage : PhoneApplicationPage
    {
        private SearchViewModels vm;
        private string groupId;

        public SearchPage()
        {
            InitializeComponent();
            vm = new SearchViewModels();
            this.DataContext = vm.SearchUserCollection;
        }

        private void SearchAppBar_Click(object sender, EventArgs e)
        {
            vm.SearchUser(groupId,tbUsername.Text);
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            if (NavigationContext.QueryString.TryGetValue("groupId", out groupId))
            { }
        }

    }
}