using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EYE.EYEServiceReference;
using Windows.UI.Popups;

namespace EYE.ViewModel
{
    class UserViewModel : ViewModelBase
    {
        public UserViewModel()
        {
            addressViewModel = new AddressViewModel();
        }

        async public Task addNewUser(string firstName, string middleName, string lastName, string role, string email, string phone, string password,
                                     string streetAddress1, string streetAddress2, string city, string stateCode, int zipCode)
        {
            try
            {
                await addressViewModel.addNewAddress(streetAddress1, streetAddress2, city, stateCode, zipCode);
                int addressId = addressViewModel.getAddressId();

                // Add new row to User table
                User newUser = new User();
                newUser.FirstName = firstName;
                newUser.MiddleName = middleName;
                newUser.LastName = lastName;
                newUser.Role = role;
                newUser.Email = email;
                newUser.Phone = phone;
                newUser.Password = password;
                newUser.AddressId_fk = addressId;

                bool result = await webService.addNewUserAsync(newUser);
                if (result == true)
                {
                    //MessageDialog messageDialog = new MessageDialog("User successfully added.");
                    //await messageDialog.ShowAsync();
                }
                else
                {
                    MessageDialog messageDialog = new MessageDialog("User couldn't be added.");
                    await messageDialog.ShowAsync();
                }
               
            }
            catch (Exception ex)
            {
                MessageDialog messageDialog = new MessageDialog(ex.Message);
                messageDialog.ShowAsync();

            }
        }

        async public Task<int>  getUserId(string email)
        {
            return await webService.getUserIdAsync(email);
        }
        private AddressViewModel addressViewModel;
    }
}
