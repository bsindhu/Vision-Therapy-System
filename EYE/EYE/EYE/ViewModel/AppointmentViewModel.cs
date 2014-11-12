using EYE.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Contacts;
using Windows.UI.Popups;
using EYE.EYEServiceReference;
namespace EYE
{
    class AppointmentViewModel : ViewModelBase
    {
        EYEServiceClient webService = new EYEServiceClient();
        async public void createNewAppointment(string healthcareProvidername,string patientname,DateTime date,TimeSpan time,string reason,int familyId)
        {
            Appointment newappointment = new Appointment();
            getProviderId(healthcareProvidername);
            getPatientId(patientname);
            newappointment.ProviderId_fk = healthcareproviderid;
            newappointment.PatientId_fk = patientId;
            newappointment.Date = date;
            newappointment.Time = time;
            newappointment.Reason = reason;
            newappointment.FamilyId_fk = familyId;
            newappointment.IsNewRequestFromParent = true;
          
            bool s = await webService.createAppointmentAsync(newappointment);
        }

        async void deleteAppointment(int appointmentID)
        {
            AppointmentListPatient appointment = new AppointmentListPatient();
            await webService.deleteAppointmentAsync(appointmentID);
        }
        async void getPatientId(string name)
        {
            patientId = await webService.patientIdAsync(name);
        }

        async void getProviderId(string name)
        {
            healthcareproviderid = await webService.healthCareProviderIdAsync(name);
        }


       
      /*  async void updateAppointment()
        {
            
        }*/




        int patientId;
        int healthcareproviderid;
    }
}
