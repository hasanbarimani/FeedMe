using FeedMe.DataAccess.Data.Repository.IRepository;
using FeedMe.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FeedMe.DataAccess.Data.Repository
{
    public class FeedBackRepository : Repository<FeedBack>, IFeedBackRepository
    {
        private readonly ApplicationDbContext _db;

        public FeedBackRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
    }
}
