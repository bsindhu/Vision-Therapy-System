using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EYE.EYEServiceReference;
using Windows.UI.Popups;

namespace EYE.ViewModel
{
    class SchoolViewModel : ViewModelBase
    {
        public SchoolViewModel()
        {
            addressViewModel = new AddressViewModel(); 
        }    

        async public Task addNewSchool(string schoolName, string phone, string streetAddress1, string streetAddress2, string city, string stateCode, int zipCode)
        {
            try
            {

                bool isSchoolExisted = await webService.isSchoolExistedAsync(schoolName);

                if (isSchoolExisted == true)
                {
                    //MessageDialog messageDialog = new MessageDialog("School already existed.");
                    //await messageDialog.ShowAsync();
                }
                else
                {
                    await addressViewModel.addNewAddress(streetAddress1, streetAddress2, city, stateCode, zipCode);
                    int addressId = addressViewModel.getAddressId();

                    // Add new school to the school table
                    School newSchool = new School();
                    newSchool.SchoolName = schoolName;
                    newSchool.Contact = phone;
                    newSchool.AddressId_fk = addressId;
                    bool result = await webService.addNewSchoolAsync(newSchool);
                    if (result)
                    {
                        //MessageDialog messageDialog = new MessageDialog("School successfully added.");
                        //await messageDialog.ShowAsync();
                    }
                    else
                    {
                        MessageDialog messageDialog = new MessageDialog("School couldn't be added.");
                        await messageDialog.ShowAsync();
                    }
                }

            }
            catch (Exception ex)
            {
                MessageDialog messageDialog = new MessageDialog(ex.Message);
                messageDialog.ShowAsync();
            }
        }

        async public Task<int> getSchoolId(string schoolName)
        {
            return await webService.getSchoolIdAsync(schoolName);
        }
        
        private AddressViewModel addressViewModel;
    }
}
