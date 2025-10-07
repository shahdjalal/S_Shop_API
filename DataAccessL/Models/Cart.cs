using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shahd_DataAccessL.Models
{

    [PrimaryKey(nameof(ProuductId),nameof(UserId))]
   public class Cart
    {

        public int ProuductId { get; set; }

        public Product Product { get; set; }

        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        public int Count { get; set; }
    }
}
