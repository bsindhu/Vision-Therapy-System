using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EYE.EYEServiceReference;
using Windows.UI.Popups;

namespace EYE.ViewModel
{
    class ParentViewModel : UserViewModel
    {
        public ParentViewModel()
        {
            
        }    

        async public Task addNewParent(string firstName, string middleName, string lastName, string role, string email, string phone, string otherPhone, string password,
                                                   string streetAddress1, string streetAddress2, string city, string stateCode, int zipCode)
        {
            try
            {
                bool isEmailUsed = await webService.validateUserEmailAsync(email);
                if (isEmailUsed == true)
                {
                    MessageDialog messageDialog = new MessageDialog("User email already used.");
                    await messageDialog.ShowAsync();
                    return;
                }

                await addNewUser(firstName, middleName, lastName, role, email, phone, password, streetAddress1, streetAddress2, city, stateCode, zipCode);
                int userId = await getUserId(email);

                // Add new row to Family Table
                Family newFamily = new Family();
                newFamily.OtherContact = otherPhone;
                newFamily.UserId_fk = userId;
                bool result = await webService.addNewFamilyAsync(newFamily);
                if (result)
                {
                    //MessageDialog messageDialog = new MessageDialog("Family successfully added.");
                    //await messageDialog.ShowAsync();
                }
                else
                {
                    MessageDialog messageDialog = new MessageDialog("Family couldn't be added.");
                    await messageDialog.ShowAsync();
                }

                parentId = await webService.getFamilyIdAsync(userId);

            }
            catch (Exception ex)
            {
                MessageDialog messageDialog = new MessageDialog(ex.Message);
                messageDialog.ShowAsync();
            }
        }

        public int getParentId()
        {
            return parentId;
        }
        int parentId;
    }
}
