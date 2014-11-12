using EYE.Common;
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

// The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234237

namespace EYE
{
    /// <summary>
    /// A basic page that provides characteristics common to most applications.
    /// </summary>
    public sealed partial class ViewAppointment : Page
    {

        private NavigationHelper navigationHelper;
        private ObservableDictionary defaultViewModel = new ObservableDictionary();
        EYEServiceClient webService = new EYEServiceClient();
        FamilyPatient fp;

        /// <summary>
        /// This can be changed to a strongly typed view model.
        /// </summary>
        public ObservableDictionary DefaultViewModel
        {
            get { return this.defaultViewModel; }
        }

        /// <summary>
        /// NavigationHelper is used on each page to aid in navigation and 
        /// process lifetime management
        /// </summary>
        public NavigationHelper NavigationHelper
        {
            get { return this.navigationHelper; }
        }


        public ViewAppointment()
        {
            this.InitializeComponent();
            this.navigationHelper = new NavigationHelper(this);
        
            this.Loaded += ViewAppointment_Loaded;
        }

      async  void ViewAppointment_Loaded(object sender, RoutedEventArgs e)
        {
          appointmentListBox.ItemsSource = await webService.appointmentsAsync(fp.familyID);
        }


         #region NavigationHelper registration

        /// The methods provided in this section are simply used to allow
        /// NavigationHelper to respond to the page's navigation methods.
        /// 
        /// Page specific logic should be placed in event handlers for the  
        /// <see cref="GridCS.Common.NavigationHelper.LoadState"/>
        /// and <see cref="GridCS.Common.NavigationHelper.SaveState"/>.
        /// The navigation parameter is available in the LoadState method 
        /// in addition to page state preserved during an earlier session.

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
           // navigationHelper.OnNavigatedTo(e);
            base.OnNavigatedTo(e);
            fp = (FamilyPatient)e.Parameter;
        }

        
        #endregion

        private void addAppointment_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(RequestAppointment), fp);
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            if (Frame.CanGoBack)
            {
                Frame.GoBack();
            }
        }

        async private void Update_Click(object sender, RoutedEventArgs e)
        {
            
            AppointmentListPatient appointment = new AppointmentListPatient();
            appointment.AppointmentID_ = (appointmentListBox.SelectedItem as AppointmentListPatient).AppointmentID_;
            Appointment updateAppointment = new Appointment();
            
            updateAppointment.Date = dateInput.Date.Date.Date;
            updateAppointment.Time = timeInput.Time;
            updateAppointment.Reason = nameInput.Text;
            await webService.updateAppointmentAsync(dateInput.Date.Date.Date, timeInput.Time, appointment.AppointmentID_,nameInput.Text);

           MessageDialog messageDialog = new MessageDialog("Updated the appointment.");
           await messageDialog.ShowAsync();
           appointmentListBox.ItemsSource = await webService.appointmentsAsync(fp.familyID);
        }

       

      async  private void deleteAppointment_Click(object sender, RoutedEventArgs e)
        {
            AppointmentListPatient appointment = new AppointmentListPatient();
            appointment.AppointmentID_ = (appointmentListBox.SelectedItem as AppointmentListPatient).AppointmentID_;
         }

      private void List_Click(object sender, RoutedEventArgs e)
      {
          this.Frame.Navigate(typeof(ViewAppointment), fp);
      } 
    }
}
