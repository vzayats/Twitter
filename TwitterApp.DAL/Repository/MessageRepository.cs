using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TwitterApp.DAL.Context;
using TwitterApp.DAL.Entities;
using TwitterApp.DAL.Properties;
using TwitterApp.DAL.Repository.Interfaces;

namespace TwitterApp.DAL.Repository
{
    public class MessageRepository : IMessageRepository
    {
        private TwitterContext db = new TwitterContext();

        private readonly int _fakeUserId = Settings.Default.FakeUser;

        public IQueryable<Message> GetMessages()
        {
            return db.Messages.Where(c => c.UserId == _fakeUserId);
        }

        public IEnumerable<Message> GetFollowMessages()
        {
            return db.Messages.Distinct().Join(
                db.Subscriptions,
                p => p.UserId,
                c => c.SubscribeUserId,
                (p, c) => p).Where(c => c.UserId != _fakeUserId).Distinct();
        }

        public async Task PostMessage(Message message)
        {
            Message mes = new Message
            {
                UserId = _fakeUserId,
                Tweet = message.Tweet,
                DateCreated = DateTime.Now
            };
            db.Messages.Add(mes);

            await db.SaveChangesAsync();
        }

        public async Task DeleteMessage(int id)
        {
            Message message = await db.Messages.FindAsync(id);

            if (message != null)
            {
                db.Messages.Remove(message);
            }

            await db.SaveChangesAsync();
        }

        protected void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            Dispose(disposing);
        }
    }
}