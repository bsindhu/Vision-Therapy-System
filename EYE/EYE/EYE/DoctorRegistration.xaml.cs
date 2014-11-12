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
    public sealed partial class DoctorRegistration : Page
    {
        EYEServiceClient webService = new EYEServiceClient();
        public DoctorRegistration()
        {
            this.InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Login));
        }

        async private void registerButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                bool isEmailUsed = await webService.validateUserEmailAsync(emailInput.Text);
                if (isEmailUsed == true)
                {
                    MessageDialog messageDialog = new MessageDialog("User email already used.");
                    await messageDialog.ShowAsync();
                    return;
                }

                bool result;

                // Check if the State already existed in State table
                int stateId = await webService.getStateIdAsync(stateInput.Text);


                if (stateId == -1)
                {
                    // State doesn't exist, insert new State into the table State
                    State newState = new State();
                    newState.StateCode = stateInput.Text;
                    newState.StateName = "";
                    result = await webService.addNewStateAsync(newState);
                    /*if (result == true)
                    {
                        MessageDialog messageDialog = new MessageDialog("State successfully added.");
                        await messageDialog.ShowAsync();
                    }
                    else
                    {
                        MessageDialog messageDialog = new MessageDialog("State couldn't be added.");
                        await messageDialog.ShowAsync();
                    }*/
                    // Get new stateId
                    stateId = await webService.getStateIdAsync(stateInput.Text);
                }

                // Check if the Address already existed in Address table
                int addressId = await webService.getAddressIdAsync(addressInput.Text, "", cityInput.Text, stateInput.Text, Convert.ToInt32(zipCodeInput.Text));
                if (addressId == -1)
                {
                    // Address doesnt' exist, insert new address into the Address Table
                    Address newAddress = new Address();
                    newAddress.AddressLine1 = addressInput.Text;
                    newAddress.AddressLine2 = "";
                    newAddress.City = cityInput.Text;
                    newAddress.ZipCode = Convert.ToInt32(zipCodeInput.Text);
                    newAddress.State_fk = stateId;
                    result = await webService.addNewAddressAsync(newAddress);
                    /*if (result)
                    {
                        MessageDialog messageDialog = new MessageDialog("Address successfully added.");
                        await messageDialog.ShowAsync();
                    }
                    else
                    {
                        MessageDialog messageDialog = new MessageDialog("Address couldn't be added.");
                        await messageDialog.ShowAsync();
                    }*/
                    // Get new addressId
                    addressId = await webService.getAddressIdAsync(addressInput.Text, "", cityInput.Text, stateInput.Text, Convert.ToInt32(zipCodeInput.Text));
                    
                }

                // Add new row to User table
                User newUser = new User();
                newUser.FirstName = firstNameInput.Text;
                newUser.MiddleName = middleNameInput.Text;
                newUser.LastName = lastNameInput.Text;
                newUser.Role = "Health Care Provider";
                newUser.Email = emailInput.Text;
                newUser.Phone = phoneInput.Text;
                newUser.Password = passwordInput.Password;
                newUser.AddressId_fk = addressId;
                result = await webService.addNewUserAsync(newUser);
              
                /*if (result == true)
                {
                    MessageDialog messageDialog2 = new MessageDialog("User successfully added.");
                    await messageDialog2.ShowAsync();
                }
                else
                {
                    MessageDialog messageDialog2 = new MessageDialog("User couldn't be added.");
                    await messageDialog2.ShowAsync();
                }*/
                // Get new userId
                int userId = await webService.getUserIdAsync(emailInput.Text);

                // Add new row to Health Care Provider Table
                HealthCareProvider newHealthCareProvider = new HealthCareProvider();
                newHealthCareProvider.PracticeName = practiceNameInput.Text;
                newHealthCareProvider.RoleInPractice = roleInPracticeInput.Text;
                newHealthCareProvider.Gender = genderInput.SelectedValue.ToString();
                newHealthCareProvider.ClinicName = clinicInput.Text;
                newHealthCareProvider.UserId_fk = userId;
                result = await webService.addNewHealthCareProviderAsync(newHealthCareProvider);
                if (result)
                {
                     MessageDialog messageDialog = new MessageDialog("Health Care Provider successfully added.");
                     await messageDialog.ShowAsync();
                }
                else
                {
                     MessageDialog messageDialog = new MessageDialog("Health Care Provider couldn't be added.");
                     await messageDialog.ShowAsync();
                }
                    
            }
            catch (Exception ex)
            {
                MessageDialog messageDialog = new MessageDialog(ex.Message);
                messageDialog.ShowAsync();

            }
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
