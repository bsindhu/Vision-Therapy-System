using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EYE.EYEServiceReference;
using Windows.UI.Popups;
using System.Collections.ObjectModel;

namespace EYE.ViewModel
{
   class PatientViewModel : ViewModelBase
    {
        public PatientViewModel()
        {
            ethnicityViewModel = new EthnicityViewModel();
            schoolViewModel = new SchoolViewModel();
        }

        async public Task<bool> addNewPatient(string firstName, string middleName, string lastName, DateTime dateOfBirth, string mgender, string ethnicityName,
                                        string schoolName, string schoolPhone, string schoolAddress1, string schoolAddress2, string schoolCity, string schoolState, int schoolZipCode)
        {
            try
            {
                patientId = await webService.getPatientIdAsync(firstName, middleName, lastName, dateOfBirth);

                if (patientId == -1)
                {

                  //  await ethnicityViewModel.addNewEthnicity(ethnicityName);
                    await schoolViewModel.addNewSchool(schoolName, schoolPhone, schoolAddress1, schoolAddress2, schoolCity, schoolState, schoolZipCode);
                    // Patient doesn't exist, insert new patient into the table Patient
                    Patient newPatient = new Patient();
                    newPatient.FirstName = firstName;
                    newPatient.MiddleName = middleName;
                    newPatient.LastName = lastName;
                    newPatient.DateOfBirth = dateOfBirth;
                    newPatient.Gender = mgender;
                    newPatient.EthnicityId_fk = await ethnicityViewModel.getEthnicityId(ethnicityName);
                    newPatient.SchoolId_fk = await schoolViewModel.getSchoolId(schoolName);

                    bool result = await webService.addNewPatientAsync(newPatient);
                    if (result)
                    {
                        patientId = await webService.getPatientIdAsync(firstName, middleName, lastName, dateOfBirth);
                        //MessageDialog messageDialog = new MessageDialog("Patient successfully added.");
                        //await messageDialog.ShowAsync();
                        return true;
                    }
                    else
                    {
                        MessageDialog messageDialog = new MessageDialog("Patient couldn't be added.");
                        await messageDialog.ShowAsync();
                        return false;
                    }
                }
                else
                {
                    MessageDialog messageDialog = new MessageDialog("Patient aready existed.");
                    await messageDialog.ShowAsync();
                    return false;
                }

            }
            catch (Exception ex)
            {
                MessageDialog messageDialog = new MessageDialog(ex.Message);
                messageDialog.ShowAsync();
                return false;
            }
        }

        public async Task<List<Patient>> getPatient(int familyId)
        {
           ObservableCollection<Patient> patientList = await webService.getPatientListAsync(familyId);
           return patientList.ToList();
        }

        public int getPatientId()
        {
            return patientId;
        }

        private EthnicityViewModel ethnicityViewModel;
        private SchoolViewModel schoolViewModel;
        int patientId;
    }
        
}
