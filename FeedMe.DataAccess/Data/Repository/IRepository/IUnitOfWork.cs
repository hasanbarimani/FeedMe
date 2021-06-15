using System;
using System.Collections.Generic;
using System.Text;

namespace FeedMe.DataAccess.Data.Repository.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        ICooperationRepository Cooperation { get; }
        IFeedBackRepository FeedBack{ get; }

        void Save();
    }
}
