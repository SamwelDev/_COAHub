using COAHub.Application.Application_Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace COAHub.Application.Application_Generics
{
    public  interface IGenericService<TModel> where TModel : class
    {
        Task<ResponseMapper<TModel>> GetByIdAsync(int Id);

        // Flexible detailed fetch with Include/Filter
        Task<ResponseMapper<TModel>> GetByIdDetailedAsync(
            int Id,
            Func<IQueryable<TModel>, IQueryable<TModel>>? include = null,
            Expression<Func<TModel, bool>>? filter = null);

        Task<ResponseMapper<List<TModel>>> GetAllAsync();

        Task<ResponseMapper<TModel>> CreateAsync(TModel model);

        Task<ResponseMapper<object>> CreateRangeAsync(List<TModel> models);

        Task<ResponseMapper<TModel>> UpdateAsync(TModel model);
    }
}
