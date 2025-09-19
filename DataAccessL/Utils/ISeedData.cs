using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shahd_DataAccessL.Utils
{
   public interface ISeedData
    {

        //Task : async
        Task DataSeedingAsync();
        Task IdentityDataSeedingAsync();
    }
}
