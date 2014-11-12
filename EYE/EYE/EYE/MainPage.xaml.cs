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

namespace EYE
{
    /// <summary>
    /// This is the first pape of the application. It is displayed a list of  therapy games
    /// downloaded on the current device. It has a login button at the top right conner to 
    /// bring up the user login page
    /// </summary>
    public sealed partial class BankPage1 : Page
    {
        public BankPage1()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// This method call the Login page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Login));
        }
    }
}
