using FeedMe.DataAccess.Data.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Text;


namespace FeedMe.DataAccess.Data.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Cooperation = new CooperationRepository(_db);
            FeedBack = new FeedBackRepository(_db);
     

        }

        public ICooperationRepository Cooperation { get; private set; }
        public IFeedBackRepository FeedBack { get; private set; }
    
        public void Dispose()
        {
            _db.Dispose();
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
