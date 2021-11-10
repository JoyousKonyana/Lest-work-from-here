using BMW_ONBOARDING_SYSTEM.Interfaces;
using BMW_ONBOARDING_SYSTEM.Models;
using BMW_ONBOARDING_SYSTEM.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BMW_ONBOARDING_SYSTEM.Repositories
{
    public class EquipmentQueryRepository : IEquipmentQueryRepository
    {
        private readonly INF370DBContext _inf370ContextDB;

        public EquipmentQueryRepository(INF370DBContext inf370ContextDB)
        {
            _inf370ContextDB = inf370ContextDB;
        }
        public void Add<T>(T entity) where T : class
        {
            _inf370ContextDB.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _inf370ContextDB.Remove(entity);
        }

        public Task<EquipmentQuery[]> GetAllqueriesAsync()
        {
            IQueryable<EquipmentQuery> query = _inf370ContextDB.EquipmentQuery.Include(x=> x.Equipment).Include(x => x.Onboarder).ThenInclude(x=>x.Employee);


            return query.ToArrayAsync();
        }

        public Task<QueryStatus[]> GetAllQueryStatuses()
        {
            IQueryable<QueryStatus> queryStatuses = _inf370ContextDB.QueryStatus;

            return queryStatuses.ToArrayAsync();
        }

        public Task<QueryStatus> GetQueryStatusByIDAsync(int id)
        {
            IQueryable<QueryStatus> query = _inf370ContextDB.QueryStatus.
                Where(i => i.Id == id);

            return query.FirstOrDefaultAsync();
        }

        public Task<EquipmentQuery[]> GetQueryByOnboarderIDc(int id)
        {
            IQueryable<EquipmentQuery> query = _inf370ContextDB.EquipmentQuery.Where(x => x.OnboarderID == id).Include(x=>x.Equipment).Include(x=> x.QueryStatus).Include(x=>x.Onboarder).ThenInclude(x=>x.Employee);

            return query.ToArrayAsync();
        }

        public Task<EquipmentQueryStatus[]> GetQueryStatusByID(ResolveQueryViewModel model)
        {
            IQueryable<EquipmentQueryStatus> query = _inf370ContextDB.EquipmentQueryStatus;


            return query.ToArrayAsync();
        }

        //public Task<EquipmentQuery[]> GetQueryByOnboarderIDc(int id)
        //{
        //    IQueryable<OnboarderEquipment> query = _inf370ContextDB.OnboarderEquipment.
        //        Include(x => x.equp)
        //        Where(i => i.OnboarderId ==id);

        //    return query.FirstOrDefaultAsync();
        //}

        public async Task<bool> SaveChangesAsync()
        {
            return await _inf370ContextDB.SaveChangesAsync() > 0;
        }

        public Task<EquipmentQuery> GetQueryByIDAsync(int id)
        {
            IQueryable<EquipmentQuery> query = _inf370ContextDB.EquipmentQuery.Where(x => x.Id == id);


            return query.FirstOrDefaultAsync();


        }
    }
}
