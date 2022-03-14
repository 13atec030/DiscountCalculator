using DiscountCalculator.Classes;
using DiscountCalculator.Repository;
using System;

namespace DiscountCalculator
{
    class Program
    {
        #region Fields

        private const string databaseName = "DiscountCalculator.db";

        #endregion

        #region Properties

        public static string DatabasePath { get; private set; }

        #endregion

        #region Methods
        static void Main(string[] args)
        {
            DatabasePath = SetDbFolderPath();
            GoldConsole();
        }

        private static void GoldConsole()
        {
            UserRepository userRepository = new UserRepository(Program.DatabasePath);

            //Calling this method to add default user in db
            //UserID : shubham, Password : 123
            userRepository.AddDefaultUser();

            Calculator calculator = new Calculator();

            Console.WriteLine("Please provide User ID");
            var userId = Console.ReadLine();

            Console.WriteLine("Please provide password");
            var password = Console.ReadLine();

            if (userRepository.AuthenticateUser(userId, password) == true)
            {
                Console.WriteLine("Gold price (per gram)?");
                string price = Console.ReadLine();

                Console.WriteLine("Weight of the gold (in grams)?");
                string weight = Console.ReadLine();

                Console.WriteLine("Discount (in percentage)?");
                string discount = Console.ReadLine();

                try
                {
                    double totalPrice = calculator.CalculateTotalPrice(price, weight, discount);
                    Console.WriteLine("Total Price : {0}", totalPrice);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Invalid input provided!");
                }
            }
            else
            {
                Console.WriteLine("Invlid user!");
            }
        }

        private static string SetDbFolderPath()
        {
            string folderPath = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            return System.IO.Path.Combine(folderPath, databaseName);
        }

        #endregion
    }
}
