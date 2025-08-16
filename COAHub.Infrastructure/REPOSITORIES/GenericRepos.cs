using COAHub.Application.Application_Generics;
using COAHub.Application.Application_Helpers;
using COAHub.Application.Application_Mappers;
using COAHub.Infrastructure.CONTEXT;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace COAHub.Infrastructure.REPOSITORIES
{
    public  class GenericRepos<TModel> : IGenericService<TModel> where TModel : class
    {
        private readonly IDbContextFactory<CoaDbContext> _ContextFactory;
        private readonly ILogger<GenericRepos<TModel>> _Logger;
        public GenericRepos(
         IDbContextFactory<CoaDbContext> contextFactory,
         ILogger<GenericRepos<TModel>> logger)
        {
            _ContextFactory = contextFactory ?? throw new ArgumentNullException(nameof(contextFactory));
            _Logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<ResponseMapper<TModel>> CreateAsync(TModel model)
        {
            if (model == null)
                return ResponseHelper.SetInternalServerError(model, "Model cannot be null.");

            await using var context = await _ContextFactory.CreateDbContextAsync();
            await using var transaction = await context.Database.BeginTransactionAsync();
            try
            {
                context.Set<TModel>().Add(model);
                await context.SaveChangesAsync();
                await transaction.CommitAsync();

                _Logger.LogInformation("Model created successfully.");
                return ResponseHelper.SetSuccess(model, "Model created.");
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                _Logger.LogError(ex, "Error creating model.");
                return ResponseHelper.SetInternalServerError(model, ex.Message);
            }
        }

        public async Task<object> DeleteAsync(int id)
        {
            await using var context = await _ContextFactory.CreateDbContextAsync();
            await using var transaction = await context.Database.BeginTransactionAsync();

            try
            {
                var dbSet = context.Set<TModel>();
                var model = await dbSet.FindAsync(id);

                if (model == null)
                    return ResponseHelper.SetNotFound(id, "Model not found.");

                dbSet.Remove(model);
                await context.SaveChangesAsync();
                await transaction.CommitAsync();

                _Logger.LogInformation("Model deleted.");
                return ResponseHelper.SetSuccess(model, "Deleted.");
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                _Logger.LogError(ex, "Delete failed.");
                return ResponseHelper.SetInternalServerError(id, ex.Message);
            }
        }

        public async Task<ResponseMapper<List<TModel>>> GetAllAsync()
        {
            await using var context = await _ContextFactory.CreateDbContextAsync();
            try
            {
                var dbSet = context.Set<TModel>();
                var models = await dbSet.ToListAsync();

                if (!models.Any())
                    return ResponseHelper.SetNotFound<List<TModel>>(message: "No records found.");

                models.Reverse();
                return ResponseHelper.SetSuccess(models, "Retrieved successfully.");
            }
            catch (Exception ex)
            {
                _Logger.LogError(ex, "GetAllAsync failed.");
                return ResponseHelper.SetInternalServerError<List<TModel>>(message: ex.Message);
            }
        }

        public async Task<ResponseMapper<TModel>> GetByIdAsync(int id)
        {
            await using var context = await _ContextFactory.CreateDbContextAsync();
            try
            {
                var model = await context.Set<TModel>().FindAsync(id);

                if (model == null)
                    return ResponseHelper.SetNotFound<TModel>(message: "Not found.");

                return ResponseHelper.SetSuccess(model, "Retrieved.");
            }
            catch (Exception ex)
            {
                _Logger.LogError(ex, "Error retrieving by ID.");
                return ResponseHelper.SetInternalServerError<TModel>(message: ex.Message);
            }
        }

        public async Task<ResponseMapper<TModel>> UpdateAsync(TModel model)
        {
            if (model == null)
                return ResponseHelper.SetInternalServerError<TModel>(message: "Model is null.");

            await using var context = await _ContextFactory.CreateDbContextAsync();
            await using var transaction = await context.Database.BeginTransactionAsync();

            try
            {
                context.Set<TModel>().Update(model);
                await context.SaveChangesAsync();
                await transaction.CommitAsync();

                return ResponseHelper.SetSuccess(model, "Updated.");
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                _Logger.LogError(ex, "Update failed.");
                return ResponseHelper.SetInternalServerError(model, ex.Message);
            }
        }

        public async Task<ResponseMapper<object>> CreateRangeAsync(List<TModel> models)
        {
            if (models == null || !models.Any())
                return ResponseHelper.SetBadRequest<object>("Empty model list.");

            await using var context = await _ContextFactory.CreateDbContextAsync();
            await using var transaction = await context.Database.BeginTransactionAsync();

            try
            {
                const int batchSize = 1000;
                int inserted = 0;

                foreach (var batch in models.Chunk(batchSize))
                {
                    await context.Set<TModel>().AddRangeAsync(batch);
                    await context.SaveChangesAsync();
                    inserted += batch.Length;
                }

                await transaction.CommitAsync();

                return ResponseHelper.SetSuccess<object>(null, $"Inserted {inserted} records.");
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                _Logger.LogError(ex, "CreateRangeAsync failed.");
                return ResponseHelper.SetInternalServerError<object>(ex.Message);
            }
        }

        public async Task<ResponseMapper<TModel>> GetByIdDetailedAsync(
        long id,
            Func<IQueryable<TModel>, IQueryable<TModel>>? include = null,
            Expression<Func<TModel, bool>>? filter = null)
        {
            await using var context = await _ContextFactory.CreateDbContextAsync();
            try
            {
                IQueryable<TModel> query = context.Set<TModel>();

                if (include != null)
                    query = include(query);

                if (filter != null)
                    query = query.Where(filter);
                else
                {
                    var param = Expression.Parameter(typeof(TModel), "x");
                    var idProp = Expression.Property(param, "Id");
                    var constant = Expression.Constant(id);
                    var equals = Expression.Equal(idProp, constant);
                    var lambda = Expression.Lambda<Func<TModel, bool>>(equals, param);
                    query = query.Where(lambda);
                }

                var model = await query.FirstOrDefaultAsync();

                if (model == null)
                    return ResponseHelper.SetNotFound<TModel>(message: "Entity not found.");

                return ResponseHelper.SetSuccess(model);
            }
            catch (Exception ex)
            {
                _Logger.LogError(ex, "GetByIdDetailedAsync error.");
                return ResponseHelper.SetInternalServerError<TModel>(message: ex.Message);
            }
        }

        public Task<ResponseMapper<TModel>> GetByIdDetailedAsync(int Id, Func<IQueryable<TModel>, IQueryable<TModel>>? include = null, Expression<Func<TModel, bool>>? filter = null)
        {
            throw new NotImplementedException();
        }

    }
}
