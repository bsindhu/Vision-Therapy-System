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
using System.Collections.ObjectModel;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace EYE
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SearchDoctor : Page
    {
        EYEServiceClient webService = new EYEServiceClient();
        FamilyPatient fp;
        string query;
        public SearchDoctor()
        {
            this.InitializeComponent();
            searchList.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            this.Loaded +=SearchDoctor_Loaded;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            fp = (FamilyPatient)e.Parameter;
        }

        void SearchDoctor_Loaded(object sender, RoutedEventArgs e)
        {

            getFamilydetails();
        }
        async void getFamilydetails()
        {
            User family = await webService.getUserdetailsAsync(fp.userID);
            firstName.Text = family.FirstName;
        }

      async  private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            string firstName = firstNameInput.Text;
            string lastName = lastNameInput.Text;
            string location = locationInput.Text;
        
          ObservableCollection<HealthCareProviderList> search = await webService.getProviderSearchListDetailsAsync(firstName,lastName,location);
           searchList.Visibility = Windows.UI.Xaml.Visibility.Visible;
          searchList.ItemsSource = search;
         }

      private void backButton_Click(object sender, RoutedEventArgs e)
      {
          if (Frame.CanGoBack)
          {
              Frame.GoBack();
          }
      }
    }
}
