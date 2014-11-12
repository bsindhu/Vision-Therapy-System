using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EYE.EYEServiceReference;

namespace EYE.ViewModel
{
    class ViewModelBase
    {
        public ViewModelBase()
        {
            webService = new EYEServiceClient();
        }

        protected EYEServiceClient webService;
    }
}
