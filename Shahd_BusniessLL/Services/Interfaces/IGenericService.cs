using Shahd_DataAccessL.DTO.Requests;
using Shahd_DataAccessL.DTO.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shahd_BusniessLL.Services.Interfaces
{
public  interface IGenericService <TRequest , TResponse , TEntity>
    {

        int Create(TRequest request);
        IEnumerable<TResponse> GetAll(bool onlyActive = false);
        TResponse? GetById(int id);
        int update(int id, TRequest request);

        int Delete(int id);
        public bool ToggleStatus(int id);
    }
}
