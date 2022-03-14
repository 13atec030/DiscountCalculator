using DiscountCalculator.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace DiscountCalculatorUnitTests
{
    public class UserRepositoryTests
    {
        [Fact]
        public void AuthenticateUser_ValidUserIdAndPassword_ReturnsTrue()
        {
            UserRepository userRepository = new UserRepository(@"C:\Users\shubh\Documents\DiscountCalculator.db");

            var isValid = userRepository.AuthenticateUser("shubham", "123");

            Assert.True(isValid);
        }

        [Fact]
        public void AuthenticateUser_InvalidUserIdAndPassword_ReturnsFalse()
        {
            UserRepository userRepository = new UserRepository(@"C:\Users\shubh\Documents\DiscountCalculator.db");

            var isValid = userRepository.AuthenticateUser("fdfhdfj", "gfchgj");

            Assert.False(isValid);
        }
    }
}
