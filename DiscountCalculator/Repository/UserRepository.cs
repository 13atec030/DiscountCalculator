using DiscountCalculator.Classes;
using DiscountCalculator.Repository.IRepository;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DiscountCalculator.Repository
{
    public class UserRepository : IUserRepository
    {
        #region Fields

        private readonly string DbFilePath; 

        #endregion

        #region Constractor

        public UserRepository(string dbFilePath)
        {
            DbFilePath = dbFilePath;
        }

        #endregion
        #region Methods

        public bool AuthenticateUser(string userId, string password)
        {
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(DbFilePath))
                {
                    connection.CreateTable<User>();
                    var user = connection.Table<User>().ToList().Where(useer => useer.UserId == userId && useer.Password == password).FirstOrDefault();

                    if (user != null)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public bool AddDefaultUser() 
        {
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(DbFilePath))
                {
                    connection.CreateTable<User>();
                    int count = connection.Insert(new User { UserId = "shubham", Password = "123" });

                    if (count > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        #endregion
    }
}
