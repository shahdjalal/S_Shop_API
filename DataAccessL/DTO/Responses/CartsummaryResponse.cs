using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shahd_DataAccessL.DTO.Responses
{
    public class CartsummaryResponse
    {
        public List<CartResponse> Items { get; set; } = new List<CartResponse>();
        public decimal CartTotal => Items.Sum(i =>i.TotalPrice);
    }
}
