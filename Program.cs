namespace LINQ_HW

{
    internal class Program
    {
        class Firm
        {
            public string Name { get; set; }
            public DateTime FoundedDate { get; set; }
            public string BusinessProfile { get; set; }

            public string DirectorFirstName { get; set; }
            public string DirectorLastName { get; set; }

            public int EmployeeCount { get; set; }
            public string Address { get; set; }

            public Firm(string name, DateTime foundedDate, string businessProfile,
                        string directorFirstName, string directorLastName,
                        int employeeCount, string address)
            {
                Name = name;
                FoundedDate = foundedDate;
                BusinessProfile = businessProfile;
                DirectorFirstName = directorFirstName;
                DirectorLastName = directorLastName;
                EmployeeCount = employeeCount;
                Address = address;
            }

            public void ShowInfo()
            {
                Console.WriteLine($"Name: {Name}");
                Console.WriteLine($"Founded Date: {FoundedDate.ToShortDateString()}");
                Console.WriteLine($"Business Profile: {BusinessProfile}");
                Console.WriteLine($"Director: {DirectorFirstName} {DirectorLastName}");
                Console.WriteLine($"Employee Count: {EmployeeCount}");
                Console.WriteLine($"Address: {Address}");
            }
        }

        static void Main(string[] args)
        {
            Firm[] firms = new Firm[]
            {
                new Firm("Tech Solutions", DateTime.Now.AddYears(-1), "IT",
                            "Ivan", "Ivanenko", 150, "Kyiv"),

                new Firm("MarketPro", new DateTime(2018, 3, 22), "Marketing",
                            "Petro", "White", 50, "London"),

                new Firm("FoodCorp", new DateTime(2010, 7, 15), "Construction",
                            "Sydir", "Sydorenko", 200, "Odesa"),

                new Firm("WhiteTech", new DateTime(2020, 1, 1), "IT",
                            "John", "Black", 80, "Berlin"),

                new Firm("OldCompany", DateTime.Now.AddDays(-123), "Marketing",
                            "Oleg", "Petrov", 30, "Paris")
            };

            var rezult = firms.Select(firm => firm);

            foreach (var item in rezult)
            {
                item.ShowInfo();
                Console.WriteLine();
            }
            Console.WriteLine();


            rezult = firms.Where(firm => firm.Name.ToUpper().Contains("FOOD"));

            foreach (var item in rezult)
            {
                Console.WriteLine($"{item.Name}");
            }
            Console.WriteLine();

            rezult = firms.Where(firm => firm.BusinessProfile.ToUpper() == "MARKETING");

            foreach (var item in rezult)
            {
                Console.WriteLine($"{item.Name}");
            }
            Console.WriteLine();


            rezult = firms.Where(firm => firm.BusinessProfile.ToUpper() == "MARKETING" || firm.BusinessProfile.ToUpper() == "IT");

            foreach (var item in rezult)
            {
                Console.WriteLine($"{item.Name}");
            }
            Console.WriteLine();


            rezult = firms.Where(firm => firm.EmployeeCount > 100);

            foreach (var item in rezult)
            {
                Console.WriteLine($"{item.Name}");
            }
            Console.WriteLine();

            rezult = firms.Where(firm => firm.EmployeeCount > 100 && firm.EmployeeCount < 300);

            foreach (var item in rezult)
            {
                Console.WriteLine($"{item.Name}");
            }
            Console.WriteLine();

            rezult = firms.Where(firm => firm.Address.ToUpper() == "LONDON");

            foreach (var item in rezult)
            {
                Console.WriteLine($"{item.Name}");
            }
            Console.WriteLine();

            rezult = firms.Where(firm => firm.DirectorLastName.ToUpper() == "WHITE");

            foreach (var item in rezult)
            {
                Console.WriteLine($"{item.Name}");
            }
            Console.WriteLine();

            rezult = firms.Where(firm => firm.FoundedDate > DateTime.Now.AddYears(-2));

            foreach (var item in rezult)
            {
                Console.WriteLine($"{item.Name}");
            }
            Console.WriteLine();

            rezult = firms.Where(firm => firm.FoundedDate.Date == DateTime.Now.AddDays(-123));

            foreach (var item in rezult)
            {
                Console.WriteLine($"{item.Name}");
            }
            Console.WriteLine();

            rezult = firms.Where(firm => firm.DirectorLastName.ToUpper() == "BLACK" && firm.Name.ToUpper().Contains("WHITE"));

            foreach (var item in rezult)
            {
                Console.WriteLine($"{item.Name}");
            }
            Console.WriteLine();
        }
    }
}