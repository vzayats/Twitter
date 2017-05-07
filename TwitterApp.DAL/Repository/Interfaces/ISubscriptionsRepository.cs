using System.Threading.Tasks;
using TwitterApp.DAL.Entities;

namespace TwitterApp.DAL.Repository.Interfaces
{
    public interface ISubscriptionsRepository
    {
        Task PostSubscription(Subscription subscription);
        Task DeleteSubscription(int id);
    }
}