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
    class StateViewModel : ViewModelBase
    {

        public StateViewModel()
        {
            stateCode = new ObservableCollection<string>();
        }

        async public Task addNewState(string stateCode, string stateName)
        {
            try
            {
                // Check if the State already existed in State table
                stateId = await webService.getStateIdAsync(stateCode);

                if (stateId == -1)
                {
                    bool result;
                    // State doesn't exist, insert new State into the table State
                    State newState = new State();
                    newState.StateCode = stateCode;
                    newState.StateName = stateName;
                    result = await webService.addNewStateAsync(newState);
                    // Get new stateId
                    stateId = await webService.getStateIdAsync(stateCode);
                    if (result == true)
                    {
                        //MessageDialog messageDialog1 = new MessageDialog("State successfully added.");
                        //await messageDialog.ShowAsync();
                    }
                    else
                    {
                        MessageDialog messageDialog = new MessageDialog("State couldn't be added.");
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

        async public Task<ObservableCollection<String>> getStateCode()
        {

            return await webService.getStateCodeAsync();
        }

        public int getStateId()
        {
            return stateId;
        }
        ObservableCollection<String> stateCode;
        int stateId;
    }
}
