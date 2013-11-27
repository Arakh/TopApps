using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using Microsoft.Devices;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Microsoft.Phone.Tasks;
using TopApps.Models;
using TopApps.ViewModels;

namespace TopApps
{
    public partial class CreateGroupPage : PhoneApplicationPage
    {
        private Stream _bitmapGroupPicture;
            
        private GroupViewModels _viewModels;

        public CreateGroupPage()
        {
            InitializeComponent();
        }

        private void tbGroupName_GotFocus(object sender, RoutedEventArgs e)
        {

        }

        private void groupPicture_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            popupGroupPicture.IsOpen = true;
        }

        private void doneAppBar_Click(object sender, EventArgs e)
        {
            _viewModels = new GroupViewModels("create");
            TopApps.Models.Group group = new TopApps.Models.Group();
            group.CreatorId = "2";
            group.GroupName = tbGroupName.Text;
            group.GroupDescription = tbDescription.Text;
            group.GroupPhoto = groupPicture.Source;
            
            if (_viewModels.CreateGroup(group))
            {
                NavigationService.Navigate(new Uri("/Views/GroupPage.xaml", UriKind.Relative));
            }
        }

        public void PhotoChoosen_Completed(object sender, PhotoResult e)
        {
            if (e.ChosenPhoto != null)
            {
                _bitmapGroupPicture = e.ChosenPhoto;

                BitmapImage bmp = new BitmapImage();
                bmp.SetSource(e.ChosenPhoto);
                groupPicture.Source = bmp;
                popupGroupPicture.IsOpen = false;
            }
        }

        private void galleryButton_Click(object sender, RoutedEventArgs e)
        {
            PhotoChooserTask photoChooser = new PhotoChooserTask();
            photoChooser.Completed += new EventHandler<PhotoResult>(PhotoChoosen_Completed);
            photoChooser.Show();
        }


        private void cameraButton_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            CameraCaptureTask cameraCapture = new CameraCaptureTask();
            cameraCapture.Completed += new EventHandler<PhotoResult>(PhotoChoosen_Completed);
            cameraCapture.Show();
        }


    }
}