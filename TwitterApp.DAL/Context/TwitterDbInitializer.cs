using System;
using System.Data.Entity;
using TwitterApp.DAL.Entities;

namespace TwitterApp.DAL.Context
{
    public class TwitterDbInitializer : DropCreateDatabaseAlways<TwitterContext>
    {
        protected override void Seed(TwitterContext db)
        {
            db.Users.Add(new User { Name = "Vasil", Surname = "Zaiats", City = "Lviv", Description = "Sample Twitter user", UserId = 1, Birthday = new DateTime(1991, 7, 20, 18, 30, 25), CreatedAt = DateTime.Now, UserName = "vzaiats", WebSite = "vzaiats.com.ua" });
            db.Users.Add(new User { Name = "Ivan", Surname = "Petrenko", City = "Lviv", Description = "Sample Twitter user", UserId = 2, Birthday = new DateTime(1993, 5, 5, 18, 30, 25), CreatedAt = DateTime.Now, UserName = "IvanPetrenko", WebSite = "IvanPetrenko.com.ua" });
            db.Users.Add(new User { Name = "Nick", Surname = "Ivanchuk", City = "Kiyv", Description = "Sample Twitter user", UserId = 3, Birthday = new DateTime(1995, 4, 10, 18, 30, 25), CreatedAt = DateTime.Now, UserName = "nIvanchuk", WebSite = "nivanchuk.com.ua" });
            db.Users.Add(new User { Name = "Oksana", Surname = "Mazur", City = "Odessa", Description = "Sample Twitter user", UserId = 4, Birthday = new DateTime(1997, 6, 11, 18, 30, 25), CreatedAt = DateTime.Now, UserName = "OksanaMazur", WebSite = "omazur.com.ua" });
            db.Users.Add(new User { Name = "Vitaliy", Surname = "Levchenko", City = "Kharkiv", Description = "Sample Twitter user", UserId = 5, Birthday = new DateTime(1995, 1, 15, 18, 30, 25), CreatedAt = DateTime.Now, UserName = "VitaliyLevchenko", WebSite = "vitaliylevchenko.com.ua" });
            db.Users.Add(new User { Name = "Vitaliy", Surname = "Kovalenko", City = "Lviv", Description = "Sample Twitter user", UserId = 6, Birthday = new DateTime(1994, 5, 10, 18, 30, 25), CreatedAt = DateTime.Now, UserName = "VitaliyKovalenko", WebSite = "VitaliyKovalenko.com.ua" });
            db.Users.Add(new User { Name = "Nadiya", Surname = "Koval", City = "Kharkiv", Description = "Sample Twitter user", UserId = 7, Birthday = new DateTime(1990, 7, 17, 18, 30, 25), CreatedAt = DateTime.Now, UserName = "NadiyaKoval", WebSite = "nadiyakoval.com.ua" });
            db.Users.Add(new User { Name = "Mykola", Surname = "Lytvyn", City = "Lviv", Description = "Sample Twitter user", UserId = 8, Birthday = new DateTime(1992, 10, 11, 18, 30, 25), CreatedAt = DateTime.Now, UserName = "mLytvyn", WebSite = "mytvyn.com.ua" });
            db.Users.Add(new User { Name = "Natalia", Surname = "Yurchenko", City = "Odessa", Description = "Sample Twitter user", UserId = 9, Birthday = new DateTime(1993, 2, 5, 18, 30, 25), CreatedAt = DateTime.Now, UserName = "NataliaYurchenko", WebSite = "nataliayurchenko.com.ua" });
            db.Users.Add(new User { Name = "Roman", Surname = "Shevchenko", City = "Lviv", Description = "Sample Twitter user", UserId = 10, Birthday = new DateTime(1996, 4, 10, 18, 30, 25), CreatedAt = DateTime.Now, UserName = "rShevchenko", WebSite = "romanshevchenko.com.ua" });

            db.Messages.Add(new Message { Tweet = "Sample Tweet 1", Id = 1, DateCreated = new DateTime(2015, 7, 20, 18, 30, 25), UserId = 1 });
            db.Messages.Add(new Message { Tweet = "Sample Tweet 2", Id = 2, DateCreated = new DateTime(2016, 7, 20, 18, 30, 25), UserId = 2 });
            db.Messages.Add(new Message { Tweet = "Sample Tweet 3", Id = 3, DateCreated = new DateTime(2017, 1, 20, 18, 30, 25), UserId = 4 });
            db.Messages.Add(new Message { Tweet = "Sample Tweet 4", Id = 4, DateCreated = new DateTime(2017, 1, 20, 18, 30, 25), UserId = 5 });
            db.Messages.Add(new Message { Tweet = "Sample Tweet 5", Id = 5, DateCreated = new DateTime(2017, 1, 20, 18, 30, 25), UserId = 1 });
            db.Messages.Add(new Message { Tweet = "Sample Tweet 6", Id = 6, DateCreated = new DateTime(2017, 1, 20, 18, 30, 25), UserId = 4 });
            db.Messages.Add(new Message { Tweet = "Sample Tweet 7", Id = 7, DateCreated = new DateTime(2017, 1, 20, 18, 30, 25), UserId = 2 });
            db.Messages.Add(new Message { Tweet = "Sample Tweet 8", Id = 8, DateCreated = new DateTime(2017, 1, 20, 18, 30, 25), UserId = 3 });
            db.Messages.Add(new Message { Tweet = "Sample Tweet 9", Id = 9, DateCreated = new DateTime(2017, 1, 20, 18, 30, 25), UserId = 1 });
            db.Messages.Add(new Message { Tweet = "Sample Tweet 10", Id = 10, DateCreated = new DateTime(2017, 1, 20, 18, 30, 25), UserId = 2 });
            db.Messages.Add(new Message { Tweet = "Sample Tweet 11", Id = 11, DateCreated = new DateTime(2017, 1, 20, 18, 30, 25), UserId = 4 });
            db.Messages.Add(new Message { Tweet = "Sample Tweet 12", Id = 12, DateCreated = new DateTime(2017, 1, 20, 18, 30, 25), UserId = 2 });
            db.Messages.Add(new Message { Tweet = "Sample Tweet 13", Id = 13, DateCreated = new DateTime(2017, 1, 20, 18, 30, 25), UserId = 2 });
            db.Messages.Add(new Message { Tweet = "Sample Tweet 14", Id = 14, DateCreated = new DateTime(2017, 1, 20, 18, 30, 25), UserId = 2 });
            db.Messages.Add(new Message { Tweet = "Sample Tweet 15", Id = 15, DateCreated = new DateTime(2017, 1, 20, 18, 30, 25), UserId = 1 });
            db.Messages.Add(new Message { Tweet = "Sample Tweet 16", Id = 16, DateCreated = new DateTime(2017, 1, 20, 18, 30, 25), UserId = 3 });
            db.Messages.Add(new Message { Tweet = "Sample Tweet 17", Id = 17, DateCreated = new DateTime(2017, 1, 20, 18, 30, 25), UserId = 3 });
            db.Messages.Add(new Message { Tweet = "Sample Tweet 18", Id = 18, DateCreated = new DateTime(2017, 1, 20, 18, 30, 25), UserId = 1 });
            db.Messages.Add(new Message { Tweet = "Sample Tweet 19", Id = 19, DateCreated = new DateTime(2017, 1, 20, 18, 30, 25), UserId = 5 });
            db.Messages.Add(new Message { Tweet = "Sample Tweet 20", Id = 20, DateCreated = new DateTime(2017, 1, 20, 18, 30, 25), UserId = 1 });
            db.Messages.Add(new Message { Tweet = "Sample Tweet 21", Id = 21, DateCreated = new DateTime(2017, 1, 20, 18, 30, 25), UserId = 2 });
            db.Messages.Add(new Message { Tweet = "Sample Tweet 22", Id = 22, DateCreated = new DateTime(2017, 1, 20, 18, 30, 25), UserId = 4 });
            db.Messages.Add(new Message { Tweet = "Sample Tweet 23", Id = 23, DateCreated = new DateTime(2017, 4, 20, 10, 30, 25), UserId = 1 });
            db.Messages.Add(new Message { Tweet = "Sample Tweet 24", Id = 24, DateCreated = new DateTime(2016, 2, 20, 9, 30, 25), UserId = 1 });
            db.Messages.Add(new Message { Tweet = "Sample Tweet 25", Id = 25, DateCreated = new DateTime(2017, 4, 20, 10, 30, 25), UserId = 1 });
            db.Messages.Add(new Message { Tweet = "Sample Tweet 26", Id = 26, DateCreated = new DateTime(2016, 2, 10, 20, 30, 20), UserId = 1 });
            db.Messages.Add(new Message { Tweet = "Sample Tweet 27", Id = 27, DateCreated = new DateTime(2016, 1, 25, 20, 30, 20), UserId = 1 });
            db.Messages.Add(new Message { Tweet = "Sample Tweet 28", Id = 28, DateCreated = new DateTime(2017, 4, 25, 7, 20, 20), UserId = 1 });
            db.Messages.Add(new Message { Tweet = "Sample Tweet 29", Id = 29, DateCreated = new DateTime(2016, 10, 15, 7, 20, 20), UserId = 1 });
            db.Messages.Add(new Message { Tweet = "Sample Tweet 30", Id = 30, DateCreated = new DateTime(2017, 4, 25, 7, 20, 20), UserId = 1 });
            db.Messages.Add(new Message { Tweet = "Sample Tweet 31", Id = 31, DateCreated = new DateTime(2016, 10, 15, 7, 20, 20), UserId = 1 });
            db.Messages.Add(new Message { Tweet = "Sample Tweet 32", Id = 32, DateCreated = new DateTime(2017, 1, 27, 7, 20, 20), UserId = 1 });
            db.Messages.Add(new Message { Tweet = "Sample Tweet 33", Id = 33, DateCreated = new DateTime(2017, 3, 8, 10, 10, 20), UserId = 1 });
            db.Messages.Add(new Message { Tweet = "Sample Tweet 34", Id = 34, DateCreated = new DateTime(2017, 4, 10, 22, 10, 20), UserId = 1 });
            db.Messages.Add(new Message { Tweet = "Sample Tweet 35", Id = 35, DateCreated = new DateTime(2017, 2, 2, 5, 10, 20), UserId = 1 });
            db.Messages.Add(new Message { Tweet = "Sample Tweet 36", Id = 36, DateCreated = new DateTime(2017, 2, 1, 22, 10, 20), UserId = 1 });
            db.Messages.Add(new Message { Tweet = "Sample Tweet 37", Id = 37, DateCreated = new DateTime(2017, 4, 2, 5, 10, 20), UserId = 1 });
            db.Messages.Add(new Message { Tweet = "Sample Tweet 38", Id = 38, DateCreated = new DateTime(2017, 2, 10, 10, 5, 20), UserId = 1 });
            db.Messages.Add(new Message { Tweet = "Sample Tweet 39", Id = 39, DateCreated = new DateTime(2017, 2, 10, 5, 10, 20), UserId = 1 });
            db.Messages.Add(new Message { Tweet = "Sample Tweet 40", Id = 40, DateCreated = new DateTime(2017, 3, 25, 11, 5, 20), UserId = 1 });
            db.Messages.Add(new Message { Tweet = "Sample Tweet 41", Id = 41, DateCreated = new DateTime(2017, 3, 25, 11, 2, 20), UserId = 1 });
            db.Messages.Add(new Message { Tweet = "Sample Tweet 42", Id = 42, DateCreated = new DateTime(2017, 3, 25, 12, 3, 20), UserId = 1 });
            db.Messages.Add(new Message { Tweet = "Sample Tweet 43", Id = 43, DateCreated = new DateTime(2017, 4, 24, 11, 2, 20), UserId = 2 });
            db.Messages.Add(new Message { Tweet = "Sample Tweet 44", Id = 44, DateCreated = new DateTime(2017, 4, 25, 12, 3, 20), UserId = 1 });
            db.Messages.Add(new Message { Tweet = "Sample Tweet 45", Id = 45, DateCreated = new DateTime(2017, 4, 20, 10, 5, 20), UserId = 2 });
            db.Messages.Add(new Message { Tweet = "Sample Tweet 46", Id = 46, DateCreated = new DateTime(2017, 2, 10, 11, 5, 20), UserId = 6 });
            db.Messages.Add(new Message { Tweet = "Sample Tweet 47", Id = 47, DateCreated = new DateTime(2017, 2, 10, 11, 7, 20), UserId = 6 });
            db.Messages.Add(new Message { Tweet = "Sample Tweet 48", Id = 48, DateCreated = new DateTime(2017, 4, 11, 12, 5, 20), UserId = 7 });
            db.Messages.Add(new Message { Tweet = "Sample Tweet 49", Id = 49, DateCreated = new DateTime(2017, 4, 10, 10, 7, 20), UserId = 7 });
            db.Messages.Add(new Message { Tweet = "Sample Tweet 50", Id = 50, DateCreated = new DateTime(2017, 5, 1, 9, 5, 20), UserId = 8 });
            db.Messages.Add(new Message { Tweet = "Sample Tweet 51", Id = 51, DateCreated = new DateTime(2017, 5, 1, 10, 30, 20), UserId = 8 });
            db.Messages.Add(new Message { Tweet = "Sample Tweet 52", Id = 52, DateCreated = new DateTime(2017, 5, 1, 12, 25, 20), UserId = 9 });
            db.Messages.Add(new Message { Tweet = "Sample Tweet 53", Id = 53, DateCreated = new DateTime(2017, 5, 1, 11, 10, 20), UserId = 9 });
            db.Messages.Add(new Message { Tweet = "Sample Tweet 54", Id = 54, DateCreated = new DateTime(2017, 4, 25, 22, 10, 20), UserId = 10 });
            db.Messages.Add(new Message { Tweet = "Sample Tweet 55", Id = 55, DateCreated = new DateTime(2017, 4, 25, 10, 10, 20), UserId = 10 });

            //db.Subscriptions.Add(new Subscription { SubscriptionId = 1, UserId = 1, SubscribeUserId = 2 });
            //db.Subscriptions.Add(new Subscription { SubscriptionId = 2, UserId = 1, SubscribeUserId = 3 });
            //db.Subscriptions.Add(new Subscription { SubscriptionId = 3, UserId = 2, SubscribeUserId = 1 });
            //db.Subscriptions.Add(new Subscription { SubscriptionId = 4, UserId = 2, SubscribeUserId = 2 });
            //db.Subscriptions.Add(new Subscription { SubscriptionId = 5, UserId = 2, SubscribeUserId = 3 });
            //db.Subscriptions.Add(new Subscription { SubscriptionId = 6, UserId = 3, SubscribeUserId = 2 });

            base.Seed(db);
        }
    }
}