using Azure.Core;
using Azure;
using Shahd_BusniessLL.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shahd_DataAccessL.Models;
using Shahd_DataAccessL.Repositories.Interfaces;
using Mapster;
using Shahd_DataAccessL.DTO.Responses;

namespace Shahd_BusniessLL.Services.Classes
{
    public class GenericService<TRequest, TResponse, TEntity> : IGenericService<TRequest, TResponse, TEntity>
          where TEntity : BaseModel


    {
        private readonly IGenericRepository<TEntity> _repository;

        public GenericService(IGenericRepository<TEntity> genericRepository)
        {
            _repository = genericRepository;
        }
        public int Create(TRequest request)
        {
            var entity = request.Adapt<TEntity>();
            return _repository.Add(entity);
        }

        public int Delete(int id)
        {
            var entity = _repository.GetById(id);
            if (entity is null) return 0;

            return _repository.Remove(entity);
        }

        public IEnumerable<TResponse> GetAll()
        {
            var entity = _repository.GetAll();

            return entity.Adapt<IEnumerable<TResponse>>();
        }

        public TResponse? GetById(int id)
        {
            var entity = _repository.GetById(id);
            return entity is null ? default : entity.Adapt<TResponse>();
        }

        public bool ToggleStatus(int id)
        {
            var entity = _repository.GetById(id);

            if (entity is null) return false;

            entity.Status = entity.Status == Status.Active ? Status.InActive : Status.Active;
            _repository.Update(entity);

            return true;
        }

        public int update(int id, TRequest request)
        {
            var entity = _repository.GetById(id);

            if (entity is null) return 0;

            var updatedEntity = request.Adapt(entity);
            return _repository.Update(updatedEntity);
        }
    }
}
