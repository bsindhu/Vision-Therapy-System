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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace EYE
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class PatientHome : Page
    {
        Patient p;
        public PatientHome()
        {
            this.InitializeComponent();
            this.Loaded += PatientHome_Loaded;
            
        }

        void PatientHome_Loaded(object sender, RoutedEventArgs e)
        {
            patientname.Text = p.FirstName;
          
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            p = (Patient)e.Parameter;
           

        }

        private void GoHome_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(ParentHome));
        }

        private void PatientList_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(PatientList));
        }
    }
}
