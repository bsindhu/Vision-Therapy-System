using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using EYE.EYEServiceReference;
using Windows.UI.Popups;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace EYE
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ParentHome : Page
    {

        EYEServiceClient webService = new EYEServiceClient();
        FamilyPatient fp;
       
        public ParentHome()
        {
            this.InitializeComponent();
           this.Loaded += this.ParentHome_Loaded;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
           base.OnNavigatedTo(e);
           fp = (FamilyPatient)e.Parameter;
         
          }

        void ParentHome_Loaded(object sender, RoutedEventArgs e)
        {

            getFamilydetails();
        }
        async void getFamilydetails()
        {
            User family = await webService.getUserdetailsAsync(fp.userID);
            firstName.Text = family.FirstName;
        }
       private void Appointment_Tapped(object sender, TappedRoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(ViewAppointment), fp);
        }

        private void MyProfile_Tapped(object sender, TappedRoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(ParentEditProfile), fp);
        }

        private void Children_Tapped(object sender, TappedRoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(PatientList), fp);
        }

       async private void AskDoctor_Tapped(object sender, TappedRoutedEventArgs e)
        {
            try
            {
                var mailto = new Uri("mailto:?to=recipient@example.com&subject=The subject of an email&body=Type your message.");
                await Windows.System.Launcher.LaunchUriAsync(mailto);
            }
            catch (Exception ex)
            {
                MessageDialog msg = new MessageDialog("Error in mail send");
                msg.ShowAsync();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(SearchDoctor),fp);
        }

        private void doctorSearchBox_QuerySubmitted(SearchBox sender, SearchBoxQuerySubmittedEventArgs args)
        {
            this.Frame.Navigate(typeof(SearchDoctor), args.QueryText);
        }
      
    }
}
