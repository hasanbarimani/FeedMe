using FeedMe.DataAccess.Data.Repository.IRepository;
using FeedMe.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FeedMe.DataAccess.Data.Repository
{
    public class CooperationRepository:Repository<CooperationModel>,ICooperationRepository
    {
        private readonly ApplicationDbContext _db;

        public CooperationRepository (ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
    }
}
