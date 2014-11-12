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
using Windows.ApplicationModel.Contacts;
using EYE.EYEServiceReference;
using System.Collections.ObjectModel;
using EYE.ViewModel;
using Windows.UI.Popups;


// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace EYE
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class RequestAppointment : Page
    {
        FamilyPatient fp;
        PatientViewModel patientViewModel = new PatientViewModel();
        EYEServiceClient webService = new EYEServiceClient();
        List<Patient> p;
        List<string> patientNameList;
        public RequestAppointment()
        {
            this.InitializeComponent();
            this.Loaded +=RequestAppointment_Loaded;
        }

        private async void RequestAppointment_Loaded(object sender, RoutedEventArgs e)
        {
           // ObservableCollection<Patient> patientNames = await webService.getPatientListAsync(fp.familyID);
          ObservableCollection<string> patientNames = await webService.patientFullNameAsync(fp.familyID);

          // p = patientNames.ToList();
            patientNameList = patientNames.ToList();
            foreach (string patient in patientNames)
            {
                patientName.Items.Add(patient);
            }
            ObservableCollection<HealthCareProvider> healthCareProviderlist = await webService.getHealthCareProvidersAsync();
            List<HealthCareProvider> s = healthCareProviderlist.ToList();
            
           foreach(HealthCareProvider element in s)
           {
               healthcareprovider.Items.Add(element.PracticeName);
           }


        }
        
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            fp = (FamilyPatient)e.Parameter;
        }

      async private void Button_Click(object sender, RoutedEventArgs e)
        {
           
            AppointmentViewModel appointmentViewModel = new AppointmentViewModel();
           // appointmentViewModel.createNewAppointment(healthcareprovider.SelectedValue.ToString(), patientName.SelectedValue.ToString(), appointmentDate.Date.Date.Date, appointmentTime.Time, reason.Text, fp.familyID);
            Appointment newappointment = new Appointment();
            string fullname = patientName.SelectedValue.ToString();
        
            string healthCareProvider = healthcareprovider.SelectedValue.ToString();
            int healthCareProviderId = await webService.healthCareProviderIdAsync(healthCareProvider);
            int patientId = await webService.patientIdAsync(fullname);
            newappointment.ProviderId_fk = healthCareProviderId;
            newappointment.PatientId_fk = patientId;
            newappointment.Date= appointmentDate.Date.Date.Date;
            newappointment.Time = appointmentTime.Time;
            newappointment.Reason = reason.Text;
            newappointment.FamilyId_fk = fp.familyID;
            newappointment.IsNewRequestFromParent = true;

            bool s = await webService.createAppointmentAsync(newappointment);
            MessageDialog messageDialog = new MessageDialog("Appointment Request sent.");
            await messageDialog.ShowAsync();
          
          
        }

      private void List_Click(object sender, RoutedEventArgs e)
      {
          this.Frame.Navigate(typeof(ViewAppointment), fp);
      }

      private void GoHome_Click(object sender, RoutedEventArgs e)
      {
          this.Frame.Navigate(typeof(ParentHome), fp);
      }
  
    }
}
