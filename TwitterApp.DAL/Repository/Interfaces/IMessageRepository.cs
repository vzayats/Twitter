using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TwitterApp.DAL.Entities;

namespace TwitterApp.DAL.Repository.Interfaces
{
    public interface IMessageRepository
    {
        IQueryable<Message> GetMessages();
        IEnumerable<Message> GetFollowMessages();
        Task PostMessage(Message message);
        Task DeleteMessage(int id);
    }
}