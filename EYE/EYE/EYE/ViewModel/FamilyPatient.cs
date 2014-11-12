using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using EYE.EYEServiceReference;
using System.Collections.ObjectModel;

namespace EYE
{
    class FamilyPatient :ObservableCollection<String>
    {
      
        public int userID; //User id for the family in the user table
        public int familyID; //family id for the family in the family table

         public  int patientId; 

        public FamilyPatient() { }
        public FamilyPatient(int userId,int familyId){
           
            userID = userId;
            this.familyID = familyId;
}
       }

    
   }

