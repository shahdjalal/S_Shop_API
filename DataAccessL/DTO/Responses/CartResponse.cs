using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shahd_DataAccessL.DTO.Responses
{
   public class CartResponse
    {
        public int ProuductId { get; set; }
        public string ProuductName { get; set; }

        public int Count { get; set; }

        public decimal Price { get; set; }

        public decimal TotalPrice => Price * Count;
    }
}
