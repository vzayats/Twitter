using System.Linq;
using TwitterApp.DAL.Entities;

namespace TwitterApp.DAL.Repository.Interfaces
{
    public interface ISubscribeRepository
    {
        IQueryable<User> GetUsers();
        IQueryable<User> GetSubscribeUsers();
        IQueryable<User> GetSubscribtionsUsers();
    }
}