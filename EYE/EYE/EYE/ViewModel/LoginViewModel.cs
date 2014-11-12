using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EYE.EYEServiceReference;
using Windows.UI.Popups;

namespace EYE.ViewModel
{
    class LoginViewModel : ViewModelBase
    {
        public LoginViewModel()
        {
            userRole = null;
        }
        async public Task validateUserLogin(string email, string password)
        {
            try
            {
                bool isLoginValid = await webService.validateUserLoginAsync(email, password);
                if (isLoginValid)
                {
                    userRole = await webService.getUserRoleAsync(email);
           
                }
                else
                {
                    MessageDialog messageDialog = new MessageDialog("User Email and/or password is invalid.");
                    await messageDialog.ShowAsync();
                }
            }

            catch (Exception ex)
            {
                MessageDialog messageDialog = new MessageDialog(ex.Message);
                messageDialog.ShowAsync();

            }
        }

        public string getUserRole()
        {
            return userRole;
        }

        private string userRole;
    }
}
