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
using System.Windows;
using System.Collections.ObjectModel;
namespace EYE
{
    /// <summary>
    /// Log in page that validate user email address and password. If the validation is good, then it call appropriate 
    /// screen based on user type such as patient, optometrist, teacher, scientist.
    /// </summary>
    public sealed partial class Login : Page
    {
        EYEServiceClient webService = new EYEServiceClient();
        
        // Constructor method initializes all component for this login page
        public Login()
        {
            this.InitializeComponent();
          
          }

        // This method performs the validation of user and call appropriates pages depends on user's role.
        async private void ButtonLogin_Click(object sender, RoutedEventArgs e)
        {
            
          try 
            {
              
           
                bool isLoginValid = await webService.validateUserLoginAsync(emailInput.Text, passwordInput.Password.ToString());
                if (isLoginValid)
                {
                    String userRole = await webService.getUserRoleAsync(emailInput.Text);
                   
                    int userId = await webService.getUserIdAsync(emailInput.Text);
                    int familyId = await webService.getFamilyIdAsync(userId);
                    FamilyPatient fp = new FamilyPatient(userId, familyId);
                  
                    if (userRole == "Health Care Provider")
                    {
                      // this.Frame.Navigate(typeof(Optometrist), userId);
                    }
                    else if (userRole == "Parent")
                    {
                        
                        this.Frame.Navigate(typeof(ParentHome),fp);
                    }
                    else if (userRole == "Teacher")
                    {
                        this.Frame.Navigate(typeof(Teacher),userId);
                    }
                    else
                    {
                        MessageDialog messageDialog = new MessageDialog("User Role is not valid.");
                        await messageDialog.ShowAsync();
                    }
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

        /// <summary>
        /// This method calls the Registration Page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void registorDoctors_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(DoctorRegistration));
        }

        private void registorTeachers_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(TeacherRegistration));
        }

        private void registorParents_Click(object sender, RoutedEventArgs e)
        {
            
            this.Frame.Navigate(typeof(ParentRegistration));
        }
    }
}
