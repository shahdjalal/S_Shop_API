using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shahd_DataAccessL.DTO.Requests
{
  public  class BrandRequest
    {
        public string Name { get; set; }
        public IFormFile Image { get; set; }
    }
}
