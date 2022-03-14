using System;
using System.Collections.Generic;
using System.Text;

namespace DiscountCalculator.Repository.IRepository
{
    interface IUserRepository
    {
        bool AuthenticateUser(string userId, string password);
    }
}
