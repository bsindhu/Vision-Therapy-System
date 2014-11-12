using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EYE.EYEServiceReference;
using Windows.UI.Popups;

namespace EYE.ViewModel
{
    class Family_PatientViewModel : ViewModelBase
    {
        public Family_PatientViewModel()
        {
            family_PatientId = -1;
        }

        async public Task addNewFamily_Patient(int familyId, int patientId)
        {
            try
            {
                // Check if the State already existed in State table
                family_PatientId = await webService.getFamily_PatientIdAsync(familyId, patientId);

                if (family_PatientId == -1)
                {
                    bool result;
                    // Family_Patient doesn't exist, insert new family_patient into the table Family_Patient Table
                    Family_Patient newFamily_Patient = new Family_Patient();
                    newFamily_Patient.FamilyId_fk = familyId;
                    newFamily_Patient.PatientId_fk = patientId;

                    result = await webService.addNewFamily_PatientAsync(newFamily_Patient);

                    if (result == true)
                    {
                        //MessageDialog messageDialog = new MessageDialog("Family_Patient successfully added.");
                        //await messageDialog.ShowAsync();
                    }
                    else
                    {
                        MessageDialog messageDialog = new MessageDialog("Family_Patient couldn't be added.");
                        await messageDialog.ShowAsync();
                    }
                    // Get new Family_Patient Id
                    family_PatientId = await webService.getFamily_PatientIdAsync(familyId, patientId);
                }
            }
            catch (Exception ex)
            {
                MessageDialog messageDialog = new MessageDialog(ex.Message);
                messageDialog.ShowAsync();

            }
        }

        public int getQualificationId()
        {
            return family_PatientId;
        }

        private int family_PatientId;
    }
}
