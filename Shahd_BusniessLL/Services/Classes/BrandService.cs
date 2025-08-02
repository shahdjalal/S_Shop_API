using Mapster;
using Shahd_BusniessLL.Services.Interfaces;
using Shahd_DataAccessL.DTO.Requests;
using Shahd_DataAccessL.DTO.Responses;
using Shahd_DataAccessL.Models;
using Shahd_DataAccessL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shahd_BusniessLL.Services.Classes
{
    public class BrandService : GenericService<BrandRequest, BrandResponse, Brand>, IBrandService
    {


        public BrandService(IBrandRepo BrandRepository) : base(BrandRepository)
        {

        }

    }
}
