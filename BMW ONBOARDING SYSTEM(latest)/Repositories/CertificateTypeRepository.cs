﻿//using BMW_ONBOARDING_SYSTEM.Interfaces;
//using BMW_ONBOARDING_SYSTEM.Models;
//using Microsoft.EntityFrameworkCore;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace BMW_ONBOARDING_SYSTEM.Repositories
//{
//    public class CertificateTypeRepository : ICertificateTypeRepository
//    {
//        private readonly INF370DBContext _inf370ContextDB;

//        public CertificateTypeRepository(INF370DBContext inf370ContextDB)
//        {
//            _inf370ContextDB = inf370ContextDB;
//        }
//        public void Add<T>(T entity) where T : class
//        {
//            _inf370ContextDB.Add(entity);
//        }

//        public void Delete<T>(T entity) where T : class
//        {
//            _inf370ContextDB.Remove(entity);
//        }

//        public async Task<CertificateType[]> GetAllCertificateTypesAsync()
//        {
//            IQueryable<CertificateType> results = _inf370ContextDB.cert;

//            return await results.ToArrayAsync();
//        }

//        public Task<CertificateType> GetCertificateTypeByIdAsync(int id)
//        {
//            IQueryable<CertificateType> existingCertificateType = _inf370ContextDB.CertificateType.Where(i => i.CertificateTypeId == id);



//            return existingCertificateType.FirstOrDefaultAsync();

//        }

//        public async Task<bool> SaveChangesAsync()
//        {
//            return await _inf370ContextDB.SaveChangesAsync() > 0;
//        }
//    }
//}
