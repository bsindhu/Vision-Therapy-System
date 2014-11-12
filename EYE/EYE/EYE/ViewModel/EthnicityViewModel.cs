using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using EYE.EYEServiceReference;
using Windows.UI.Popups;

namespace EYE.ViewModel
{
    class EthnicityViewModel : ViewModelBase
    {
        public EthnicityViewModel()
        {
        }
        async public Task addNewEthnicity(string ethnicityName)
        {
            try
            {
                // Check if the ethnicity already existed in Ethnicity table
                int ethnicityId = await webService.getEthnicityIdAsync(ethnicityName);

                if (ethnicityId == -1)
                {
                    // Ethnicity doesn't exist, insert new Ethnicity into the table Ethnicity
                    Ethnicity newEthnicity = new Ethnicity();
                    newEthnicity.EthnicityName = ethnicityName;
                    bool result = await webService.addNewEthnicityAsync(newEthnicity);
                    if (result == true)
                    {
                        //MessageDialog messageDialog = new MessageDialog("Ethnicity successfully added.");
                        //await messageDialog.ShowAsync();
                    }
                    else
                    {
                        MessageDialog messageDialog = new MessageDialog("Ethnicity couldn't be added.");
                        await messageDialog.ShowAsync();
                    }
                }
                else
                {
                    //MessageDialog messageDialog = new MessageDialog("Ethnicity aready existed.");
                    //await messageDialog.ShowAsync();
                }
            }
            catch (Exception ex)
            {
                MessageDialog messageDialog = new MessageDialog(ex.Message);
                messageDialog.ShowAsync();

            }
        }

        async public Task<int> getEthnicityId(string ethnicityName)
        {
            return await webService.getEthnicityIdAsync(ethnicityName);
        }

       /* async public Task<ObservableCollection<String>> getEthicityNames()
        {

           // return await webService.getEthnicityNamesAsync();
        }
        */
    }
}
