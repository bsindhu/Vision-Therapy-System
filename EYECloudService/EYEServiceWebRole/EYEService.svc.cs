using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Web;
using System.Data.Linq;
using System.Data.Linq.SqlClient;
using System.Collections.ObjectModel;
namespace EYEServiceWebRole
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "EYEService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select EYEService.svc or EYEService.svc.cs at the Solution Explorer and start debugging.
    public class EYEService : IEYEService
    {
        EYEDataClassesDataContext data = new EYEDataClassesDataContext();


        public bool validateUserLogin(String email, String password)
        {
            try
            {

                User aUser = (from user in data.Users
                              where user.Email == email && user.Password == password
                              select user).Single();
                if (aUser.Email.Length > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        /* [OperationContract]
         public int Login(string email, string password)
         {
             //Validate Username and Password against the Database. 

             User aUser = (from user in data.Users
                           where user.Email == email && user.Password == password
                           select user).Single();
             myctxt.Session["UserId"] = aUser.UserId;
             return aUser.UserId;
         }*/



        /*  [OperationContract]
          public string ReturnUser()
          {
              string user;
              user = (string)myctxt.Session["Uname"];
              return user;
          }*/
        public User getUserdetails(int loginId)
        {
            try
            {
                return (from user in data.Users where user.UserId == loginId select user).Single();
            }
            catch
            {
                return null;
            }
        }

        public String getUserRole(String email)
        {
            try
            {
                User aUser = (from user in data.Users
                              where user.Email == email
                              select user).Single();

                return aUser.Role;
            }
            catch
            {
                return null;
            }
        }

        public int getUserId(String email)
        {
            try
            {
                User aUser = (from user in data.Users
                              where user.Email == email
                              select user).Single();

                return aUser.UserId;

            }
            catch
            {
                return -1;
            }
        }


        public bool validateUserEmail(String email)
        {
            try
            {
                User userExisted = (from user in data.Users
                                    where user.Email == email
                                    select user).Single();
                if (userExisted.Email.Length > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }

        }

        public bool addNewUser(User newUser)
        {
            try
            {
                data.Users.InsertOnSubmit(newUser);
                data.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool deleteUser(int userID)
        {
            try
            {
                User userToDelete = (from user in data.Users
                                     where user.UserId == userID
                                     select user).Single();
                data.Users.DeleteOnSubmit(userToDelete);
                data.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool modifyUser(User newUser)
        {
            try
            {
                User userToModify = (from user in data.Users
                                     where user.UserId == newUser.UserId
                                     select user).Single();
                userToModify.FirstName = newUser.FirstName;
                userToModify.MiddleName = newUser.MiddleName;
                userToModify.LastName = newUser.LastName;
                userToModify.Email = newUser.Email;
                userToModify.Role = newUser.Role;
                userToModify.Phone = newUser.Phone;
                userToModify.Password = newUser.Password;
                userToModify.Address = newUser.Address;
                data.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<User> getUsers()
        {
            try
            {
                return (from user in data.Users
                        select user).ToList();
            }
            catch
            {
                return null;
            }
        }

        public bool addNewAddress(Address newAddress)
        {
            try
            {
                data.Addresses.InsertOnSubmit(newAddress);
                data.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool deleteAddress(int addressID)
        {
            try
            {
                Address addressToDelete = (from address in data.Addresses
                                           where address.AddressId == addressID
                                           select address).Single();
                data.Addresses.DeleteOnSubmit(addressToDelete);
                data.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool modifyAddress(Address newAddress)
        {
            try
            {
                Address addressToModify = (from address in data.Addresses
                                           where address.AddressId == newAddress.AddressId
                                           select address).Single();

                addressToModify.AddressLine1 = newAddress.AddressLine1;
                addressToModify.AddressLine2 = newAddress.AddressLine2;
                addressToModify.City = newAddress.City;
                addressToModify.ZipCode = newAddress.ZipCode;
                addressToModify.State = newAddress.State;
                data.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<Address> getAddresses()
        {
            try
            {
                return (from address in data.Addresses
                        select address).ToList();
            }
            catch
            {
                return null;
            }
        }

        public int getAddressId(String addressLine1, String addressLine2, String city, String stateCode, int zipCode)
        {
            try
            {
                Address _address = (from address in data.Addresses
                                    join state in data.States on address.State_fk equals state.StateId
                                    where address.AddressLine1 == addressLine1 && address.AddressLine2 == addressLine2 && address.City == city && address.ZipCode == zipCode && state.StateCode == stateCode
                                    select address).Single();

                return _address.AddressId;

            }
            catch
            {
                return -1;
            }

        }

        public bool addNewState(State newState)
        {
            try
            {
                data.States.InsertOnSubmit(newState);
                data.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool deleteState(int stateID)
        {
            try
            {
                State stateToDelete = (from state in data.States
                                       where state.StateId == stateID
                                       select state).Single();
                data.States.DeleteOnSubmit(stateToDelete);
                data.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool modifyState(State newState)
        {
            try
            {
                State stateToModify = (from state in data.States
                                       where state.StateId == newState.StateId
                                       select state).Single();

                stateToModify.StateCode = newState.StateCode;
                stateToModify.StateName = newState.StateName;
                data.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<State> getStates()
        {
            try
            {
                return (from state in data.States
                        select state).ToList();
            }
            catch
            {
                return null;
            }
        }

        public int getStateId(String stateCode)
        {
            try
            {
                State aState = (from state in data.States
                                where state.StateCode == stateCode
                                select state).Single();

                return aState.StateId;

            }
            catch
            {
                return -1;
            }
        }

        public bool addNewHealthCareProvider(HealthCareProvider newHealthCareProvider)
        {
            try
            {
                data.HealthCareProviders.InsertOnSubmit(newHealthCareProvider);
                data.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool deleteHealthCareProvider(int healthCareProviderID)
        {
            try
            {
                HealthCareProvider healthCareProviderToDelete = (from healthCareProvider in data.HealthCareProviders
                                                                 where healthCareProvider.HealthCareProviderId == healthCareProviderID
                                                                 select healthCareProvider).Single();
                data.HealthCareProviders.DeleteOnSubmit(healthCareProviderToDelete);
                data.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool modifyHealthCareProvider(HealthCareProvider newHealthCareProvider)
        {
            try
            {
                HealthCareProvider healthCareProviderToModify = (from healthCareProvider in data.HealthCareProviders
                                                                 where healthCareProvider.HealthCareProviderId == newHealthCareProvider.HealthCareProviderId
                                                                 select healthCareProvider).Single();

                healthCareProviderToModify.PracticeName = newHealthCareProvider.PracticeName;
                healthCareProviderToModify.RoleInPractice = newHealthCareProvider.RoleInPractice;
                healthCareProviderToModify.ClinicName = newHealthCareProvider.ClinicName;
                healthCareProviderToModify.Gender = newHealthCareProvider.Gender;
                newHealthCareProvider.User = newHealthCareProvider.User;

                data.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<HealthCareProvider> getHealthCareProviders()
        {
            try
            {
                return (from healthCareProvider in data.HealthCareProviders
                        select healthCareProvider).ToList();
            }
            catch
            {
                return null;
            }
        }

        public List<String> getStateCode()
        {
            try
            {
                return (from state in data.States select state.StateCode).ToList();
            }
            catch
            {
                return null;
            }
        }

        public List<Ethnicity> getEthnicities()
        {
            try
            {
                return (from ethnicity in data.Ethnicities
                        select ethnicity).ToList();
            }
            catch
            {
                return null;
            }
        }

        public bool addNewEthnicity(Ethnicity newEthnicity)
        {
            try
            {
                data.Ethnicities.InsertOnSubmit(newEthnicity);
                data.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool deleteEthnicity(int ethnicityId)
        {
            try
            {
                Ethnicity ethnicityToDelete = (from ethnicity in data.Ethnicities
                                               where ethnicity.EthnicityId == ethnicityId
                                               select ethnicity).Single();
                data.Ethnicities.DeleteOnSubmit(ethnicityToDelete);
                data.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool modifyEthnicity(Ethnicity newEthnicity)
        {
            try
            {
                Ethnicity ethnicityToModify = (from ethnicity in data.Ethnicities
                                               where ethnicity.EthnicityId == newEthnicity.EthnicityId
                                               select ethnicity).Single();

                ethnicityToModify.EthnicityName = newEthnicity.EthnicityName;
                data.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool modifyFamily_Patient(Family_Patient newFamilyPatient)
        {
            try
            {
                Family_Patient familyToModify = (from familyPatient in data.Family_Patients
                                                 where familyPatient.FamilyPatientId == newFamilyPatient.FamilyPatientId
                                                 select familyPatient).Single();
                // More statements here
                data.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<Family_Patient> getFamily_Patients()
        {
            try
            {
                return (from familyPatient in data.Family_Patients
                        select familyPatient).ToList();
            }
            catch
            {
                return null;
            }
        }

        public int getSchoolId(string schoolName)
        {
            return ((from school in data.Schools
                     where school.SchoolName == schoolName
                     select school.SchoolId).Single());
        }
        public bool addNewSchool(School newSchool)
        {
            try
            {
                data.Schools.InsertOnSubmit(newSchool);
                data.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool deleteSchool(int schoolID)
        {
            try
            {
                School schoolToDelete = (from school in data.Schools
                                         where school.SchoolId == schoolID
                                         select school).Single();
                data.Schools.DeleteOnSubmit(schoolToDelete);
                data.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool modifySchool(School newSchool)
        {
            try
            {
                School schoolToModify = (from school in data.Schools
                                         where school.SchoolId == newSchool.SchoolId
                                         select school).Single();

                schoolToModify.SchoolName = newSchool.SchoolName;
                schoolToModify.Contact = newSchool.Contact;
                schoolToModify.Address = newSchool.Address;
                data.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<School> getSchools()
        {
            try
            {
                return (from school in data.Schools
                        select school).ToList();
            }
            catch
            {
                return null;
            }
        }

        public int getFamilyId(int userId)
        {
            return (from family in data.Families
                    join user in data.Users on family.UserId_fk equals user.UserId
                    where user.UserId == userId
                    select family.FamilyId).Single();
        }

        /* public Family getFamilyDetails(int userId)
         {
             return (from family in data.Families where family.UserId_fk == userId select family).Single();
         } */
        public bool addNewFamily(Family newFamily)
        {
            try
            {
                data.Families.InsertOnSubmit(newFamily);
                data.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool deleteFamily(int familyID)
        {
            try
            {
                Family familyToDelete = (from family in data.Families
                                         where family.FamilyId == familyID
                                         select family).Single();
                data.Families.DeleteOnSubmit(familyToDelete);
                data.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool modifyFamily(Family newFamily)
        {
            try
            {
                Family familyToModify = (from family in data.Families
                                         where family.FamilyId == newFamily.FamilyId
                                         select family).Single();

                familyToModify.OtherContact = newFamily.OtherContact;
                // More statements here
                data.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<Family> getFamilies()
        {
            try
            {
                return (from family in data.Families
                        select family).ToList();
            }
            catch
            {
                return null;
            }
        }

        public bool addNewPatient(Patient newPatient)
        {
            try
            {
                data.Patients.InsertOnSubmit(newPatient);
                data.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool deletePatient(int patientID)
        {
            try
            {
                Patient patientToDelete = (from patient in data.Patients
                                           where patient.PatientId == patientID
                                           select patient).Single();
                data.Patients.DeleteOnSubmit(patientToDelete);
                data.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool modifyPatient(Patient newPatient)
        {
            try
            {
                Patient patientToModify = (from patient in data.Patients
                                           where patient.PatientId == newPatient.PatientId
                                           select patient).Single();

                patientToModify.FirstName = newPatient.FirstName;
                // More statements here
                data.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }


        public List<Patient> getPatients()
        {
            try
            {
                return (from patient in data.Patients
                        select patient).ToList();

            }
            catch
            {
                return null;
            }
        }

        public bool addNewFamily_Patient(Family_Patient newFamilyPatient)
        {
            try
            {
                data.Family_Patients.InsertOnSubmit(newFamilyPatient);
                data.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool deleteFamily_Patient(int familyPatientId)
        {
            try
            {
                Family_Patient familyPatientToDelete = (from family_Patient in data.Family_Patients
                                                        where family_Patient.FamilyPatientId == familyPatientId
                                                        select family_Patient).Single();
                data.Family_Patients.DeleteOnSubmit(familyPatientToDelete);
                data.SubmitChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<string> getEthnicityNames()
        {
            return (from ethnicity in data.Ethnicities select ethnicity.EthnicityName).ToList();
        }
        public int? abbcd(string statecode)
        {

            string s = "WA";
            int? u = 0;
            data.sp_s1(s, ref u).Single();
            return u;
        }



        public ParentDetail getFamilyDetails(int familyId)
        {
            try
            {
                ParentDetail parent = (from parentdetail in data.ParentDetails
                                       where parentdetail.FamilyId == familyId
                                       select parentdetail).Single();
                return parent;
            }
            catch
            {
                return null;
            }


        }

        public int getPatientId(String firstName, String middleName, string lastName, DateTime dateOfBirth)
        {
            try
            {
                Patient _patient = (from patient in data.Patients
                                    where patient.FirstName == firstName && patient.MiddleName == middleName && patient.LastName == lastName && patient.DateOfBirth == dateOfBirth
                                    select patient).Single();

                return _patient.PatientId;
            }
            catch
            {
                return -1;
            }
        }
        public bool isSchoolExisted(String schoolName)
        {
            try
            {
                School _school = (from school in data.Schools
                                  where school.SchoolName == schoolName
                                  select school).Single();
                if (_school.SchoolName.Length > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        public int getEthnicityId(string ethnicityName)
        {
            try
            {
                Ethnicity _ethnicity = (from ethicity in data.Ethnicities
                                        where ethicity.EthnicityName == ethnicityName
                                        select ethicity).Single();

                return _ethnicity.EthnicityId;
            }
            catch
            {
                return -1;
            }
        }

        public int getFamily_PatientId(int familyID, int patientId)
        {
            try
            {

                Family_Patient _familyPatient = (from family_Patient in data.Family_Patients
                                                 where family_Patient.FamilyId_fk == familyID && family_Patient.PatientId_fk == patientId
                                                 select family_Patient).Single();
                return _familyPatient.FamilyPatientId;

            }
            catch
            {
                return -1;
            }
        }

        public int getHealthCareProviderId(int userID)
        {
            try
            {
                HealthCareProvider _healthCareProvider = (from healthCareProvider in data.HealthCareProviders
                                                          where healthCareProvider.UserId_fk == userID
                                                          select healthCareProvider).Single();

                return _healthCareProvider.HealthCareProviderId;

            }
            catch
            {
                return -1;
            }

        }



        public List<HealthCareProviderList> getProviderSearchListDetails(string firstName, string lastName, string location)
        {
            try
            {
              //  if (location.Length > 0)
              //  {
                    return (from h in data.HealthCareProviderLists where SqlMethods.Like(h.City_, "%" + location + "%") select h).ToList();
               // }
               /* else if (firstName.Length == 0)
                {
                    return (from h in data.HealthCareProviderLists where SqlMethods.Like(h.First_Name, "%" + firstName + "%") select h).ToList();
                }
                else if (lastName.Length > 0)
                {
                    return (from h in data.HealthCareProviderLists where SqlMethods.Like(h.First_Name, "%" + firstName + "%") && SqlMethods.Like(h.Last_Name, "%" + lastName + "%") select h).ToList();
                }
                else
                {
                    return (from h in data.HealthCareProviderLists where SqlMethods.Like(h.First_Name, "%" + firstName + "%") && SqlMethods.Like(h.Last_Name, "%" + lastName + "%") && SqlMethods.Like(h.City_, "%" + location + "%") select h).ToList();
                }*/

            }
            catch
            {
                return null;
            }
        }

        public int addPatient(Patient newPatient)
        {

            data.Patients.InsertOnSubmit(newPatient);
            data.SubmitChanges();
            return newPatient.PatientId;
        }

        public int addAddress(Address newAddress)
        {

            data.Addresses.InsertOnSubmit(newAddress);
            data.SubmitChanges();
            return newAddress.AddressId;
        }

        public int healthCareProviderId(string practiceName)
        {
            return (from healthcareProvider in data.HealthCareProviders where healthcareProvider.PracticeName == practiceName select healthcareProvider.HealthCareProviderId).Single();
        }

        public List<string> patientFullName(int familyId)
        {
            List<Patient> patientList = getPatientList(familyId);
            List<string> patientFullName = new List<string>();
            foreach (Patient s in patientList)
            {
                patientFullName.Add(s.FirstName + " " + s.LastName);
            }

            return patientFullName;
        }

        public int patientId(string fullName)
        {

            return (from patient in data.Patients let patientFullName = patient.FirstName + " " + patient.LastName where patientFullName.Contains(fullName) select patient.PatientId).Single();
        }

        public List<AppointmentListPatient> appointments(int familyId)
        {
            return (from appointments in data.AppointmentListPatients where appointments.FamilyId == familyId select appointments).ToList();

        }

        public void updateAppointment(DateTime date, TimeSpan time, int id, string reason)
        {
            Appointment tomodify = (from a in data.Appointments where a.AppointmentId == id select a).Single();
            tomodify.Date = date;
            tomodify.Time = time;
            tomodify.Reason = reason;
            data.SubmitChanges();
        }

        public bool createAppointment(Appointment newAppointment)
        {
            try
            {
                data.Appointments.InsertOnSubmit(newAppointment);
                data.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public List<Patient> getPatientList(int familyId)
        {
            try
            {
                return (from patient in data.Patients
                        join familyPatient in data.Family_Patients
                        on patient.PatientId equals
                        familyPatient.PatientId_fk
                        where familyPatient.FamilyId_fk == familyId
                        select patient).ToList();
            }
            catch
            {
                return null;
            }
        }

        public bool deleteAppointment(int appointmentID)
        {
            try
            {
               Appointment todelete = (from appointment in data.Appointments
                                     where appointment.AppointmentId == appointmentID
                                     select appointment).Single();
                data.Appointments.DeleteOnSubmit(todelete);
                data.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
     
    }
 
}

