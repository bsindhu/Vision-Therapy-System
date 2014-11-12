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
using System.Collections.ObjectModel;
using EYE.ViewModel;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace EYE
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class PatientRegistration : Page
    {
        EYEServiceClient webService = new EYEServiceClient();
        PatientViewModel patientViewModel;
        FamilyPatient fp;
      // int parentId;

        public PatientRegistration()
        {
            
            this.InitializeComponent();
            this.Loaded +=PatientRegistration_Loaded;
           
        }
        void PatientRegistration_Loaded(object sender, RoutedEventArgs e)
        {
            
            getComboxList();
        }
       

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {

            base.OnNavigatedTo(e);
            fp = (FamilyPatient)e.Parameter;
            //parentId = (int)e.Parameter;
            getFamilydetails();


        }
        async void getFamilydetails()
        {
            User family = await webService.getUserdetailsAsync(fp.userID);
            parentfirstName.Text = family.FirstName;

        }
        async void getComboxList()
        {
            ObservableCollection<String> stateList = await webService.getStateCodeAsync();
            ObservableCollection<String> ethnicityList = await webService.getEthnicityNamesAsync();
            schoolState.ItemsSource = stateList;
            ethnicityInput.ItemsSource = ethnicityList;
            
        }

      async  public void registerButton_Click(object sender, RoutedEventArgs e)
        {
            int patientId = 0;
            int schoolId = 0;
            Patient newPatient = new Patient();
            School newSchool = new School();
            Address newAddress = new Address();
            patientId = await webService.getPatientIdAsync(firstName.Text, middleName.Text, lastName.Text, dateOfbirth.Date.Date.Date);
            if (patientId == -1)
            {
            newPatient.FirstName = firstName.Text;
            newPatient.MiddleName = middleName.Text;
            newPatient.LastName = lastName.Text;
            newPatient.DateOfBirth = dateOfbirth.Date.Date.Date;
            newPatient.Gender = gender.SelectedItem.ToString();
            try
            {
                int ethnicityId = await webService.getEthnicityIdAsync(ethnicityInput.SelectedValue.ToString());
                newPatient.EthnicityId_fk = ethnicityId;
                
                 bool isSchoolExisted = await webService.isSchoolExistedAsync(schoolName.Text);
                  if (isSchoolExisted == true)
                          {
                                  schoolId = await webService.getSchoolIdAsync(schoolName.Text);
                          }
                          else
                          {
                              // Add new school to the school table
                           
                              newSchool.SchoolName = schoolName.Text;
                              newSchool.Contact = schoolPhoneFirstPartInput.Text + "-" + schoolPhoneSecondPartInput.Text + "-" + schoolPhoneThirdPartInput.Text;
                      
                      //Add address to the address table
                      newAddress.AddressLine1 = schoolAddress.Text;
                      newAddress.AddressLine2 = "";
                      newAddress.City = schoolCity.Text;
                      newAddress.State_fk = await webService.getStateIdAsync(schoolState.SelectedValue.ToString());
                      newAddress.ZipCode = Convert.ToInt32( schoolZipCode.Text);
                      bool a = await webService.addNewAddressAsync(newAddress);
                      int id = await webService.getAddressIdAsync(schoolAddress.Text, "", schoolCity.Text, schoolState.SelectedValue.ToString(), Convert.ToInt32(schoolZipCode.Text));
                      newSchool.AddressId_fk = await webService.addAddressAsync(newAddress);   
                      bool result = await webService.addNewSchoolAsync(newSchool);
                      schoolId = await webService.getSchoolIdAsync(schoolName.Text);
                      newPatient.SchoolId_fk = schoolId;
                      patientId = await webService.addPatientAsync(newPatient);
                      MessageDialog messageDialog = new MessageDialog("Child added.");
                      await messageDialog.ShowAsync();
                  }
            } catch (Exception ex)
            {
                MessageDialog messageDialog = new MessageDialog(ex.Message);
                messageDialog.ShowAsync();
            } 
            }
                Family_PatientViewModel family_Patient = new Family_PatientViewModel();
                await family_Patient.addNewFamily_Patient(fp.familyID, patientId);
         }

      private void backButton_Click(object sender, RoutedEventArgs e)
      {
          if (Frame.CanGoBack)
          {
              Frame.GoBack();
          }
      }

      private void ListPatient_Click(object sender, RoutedEventArgs e)
      {
          this.Frame.Navigate(typeof(PatientList), fp);
      }

      private void GoHome_Click(object sender, RoutedEventArgs e)
      {
          this.Frame.Navigate(typeof(ParentHome), fp);
      }

      private void Find_Click(object sender, RoutedEventArgs e)
      {
          this.Frame.Navigate(typeof(SearchDoctor), fp);
      }
    }
}
