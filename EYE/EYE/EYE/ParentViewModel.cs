using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EYE.EYEServiceReference;

namespace EYE
{
    class ParentViewModel
    {
        EYEServiceClient webService = new EYEServiceClient();
        FamilyPatient fp = new FamilyPatient();
       

        public int getuserId()
        {
            return userId;
        }
      async  public Task getfamilyId()
        {
             familyId = await webService.getUserIdAsync(email); 
        }
     public  ParentViewModel(string email)
       {
           this.email = email;
       }
     async void userdetails()
     {
         
          familyId = await webService.getFamilyIdAsync(userId);
     }

     string email;
     int userId;
     int familyId;
    }
}
