using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Discom.UP.Backend.UpDash.Interfaces.Infrastructure
{
    public class UserInfoModel
    {
        public string User { get; set; }
        public bool IsAuthenticated { get; set; }
        public string RandomUser { get; set; }

        public UserInfoModel()
        {
            User = "unknown";
            IsAuthenticated = false;
            RandomUser = "unknown";        
        }

        public void SetRandomUser()
        {
            string[] colors = new string[] { "Red", "Green", "Blue", "Yellow", "Orange", "Violet", "Brown", "Black", "White", "Grey", "Pink" };
            string[] cars = new string[] { "Jaguar", "Audi", "VW", "Porsche", "Chevy", "BMW", "Corvette", "Mercedes", "Mustang", "Ferrari", "Alfa", "Lamborghini","Volvo", "Maserrati", "Trabi" };

            Random rand = new Random(DateTime.Now.Second);

            string FirstName = colors[rand.Next(0, colors.Length - 1)];
            string LastName = cars[rand.Next(0, cars.Length - 1)];

            RandomUser = FirstName + LastName;
        }

    }
}
