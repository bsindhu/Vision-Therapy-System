using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EYE.EYEServiceReference;
using Windows.UI.Popups;

namespace EYE.ViewModel
{
    class AddressViewModel : ViewModelBase
    {
        public AddressViewModel()
        {
            stateViewModel = new StateViewModel();
            addressId = -1;
        }

        async public Task addNewAddress(string streetAddress1, string streetAddress2, string city, string stateCode, int zipCode)
        {
            try
            {


                // Check if the Address already existed in Address table
                addressId = await webService.getAddressIdAsync(streetAddress1, streetAddress2, city, stateCode, zipCode);
                if (addressId == -1)
                {
                    // Add new state 
                    await stateViewModel.addNewState(stateCode, "");
                    int stateId = stateViewModel.getStateId();

                    // Address doesnt' exist, insert new address into the Address Table
                    Address newAddress = new Address();
                    newAddress.AddressLine1 = streetAddress1;
                    newAddress.AddressLine2 = streetAddress2;
                    newAddress.City = city;
                    newAddress.ZipCode = zipCode;
                    newAddress.State_fk = stateId;
                    bool result = await webService.addNewAddressAsync(newAddress);
                    if (result)
                    {
                        //MessageDialog messageDialog = new MessageDialog("Address successfully added.");
                        //await messageDialog.ShowAsync();
                    }
                    else
                    {
                        MessageDialog messageDialog = new MessageDialog("Address couldn't be added.");
                        await messageDialog.ShowAsync();
                    }
                    // Get new addressId
                    addressId = await webService.getAddressIdAsync(streetAddress1, streetAddress2, city, stateCode, zipCode);

                }
               
            }
            catch (Exception ex)
            {
                MessageDialog messageDialog = new MessageDialog(ex.Message);
                messageDialog.ShowAsync();

            }
        }

        public int getAddressId()
        {
            return addressId;
        }
        StateViewModel stateViewModel;
        private int addressId;
    }
}