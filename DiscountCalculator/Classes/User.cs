using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DiscountCalculator.Classes
{
    public class User
    {
        #region Properties

        [PrimaryKey,AutoIncrement]
        public int Id { get; set; }
        [Required]
        public string UserId { get; set; }
        [Required]
        public string  Password { get; set; }

        #endregion
    }
}
