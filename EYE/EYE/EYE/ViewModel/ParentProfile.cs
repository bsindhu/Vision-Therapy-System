using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EYE.EYEServiceReference;

namespace EYE
{
   class ParentProfile
    {
       EYEServiceClient webService = new EYEServiceClient();
  
       public async void getDetails(int familyId)
        {

            await webService.getFamilyDetailsAsync(familyId);
        }

        
    }
}
