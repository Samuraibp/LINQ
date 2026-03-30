namespace LINQ_HW

{
    internal class Program
    {
        class Firm
        {
            public string Name { get; set; }
            public DateTime FoundedDate { get; set; }
            public string BusinessProfile { get; set; }
            public string DirectorFullName { get; set; }
            public int EmployeeCount { get; set; }
            public string Address { get; set; }

            public Firm(string name, DateTime foundedDate, string businessProfile,
                        string directorFullName, int employeeCount, string address)
            {
                Name = name;
                FoundedDate = foundedDate;
                BusinessProfile = businessProfile;
                DirectorFullName = directorFullName;
                EmployeeCount = employeeCount;
                Address = address;
            }

            public void ShowInfo()
            {
                Console.WriteLine($"Name: {Name}");
                Console.WriteLine($"Founded Date: {FoundedDate.ToShortDateString()}");
                Console.WriteLine($"Business Profile: {BusinessProfile}");
                Console.WriteLine($"Director: {DirectorFullName}");
                Console.WriteLine($"Employee Count: {EmployeeCount}");
                Console.WriteLine($"Address: {Address}");
            }
        }

        static void Main(string[] args)
        {
            Firm[] firms = new Firm[]
            {
                new Firm("Tech Solutions", new DateTime(2015, 5, 10), "IT",
                            "Ivanenko Ivan Ivanovych", 120, "Kyiv"),

                new Firm("MarketPro", new DateTime(2018, 3, 22), "Marketing",
                            "Petrenko Petro Petrovych", 50, "Lviv"),

                new Firm("BuildCorp", new DateTime(2010, 7, 15), "Construction",
                            "Sydorenko Sydir Sydorovych", 200, "Odesa")
            };

            var rezult = from firm in firms
                         select firm;

            foreach (var item in rezult)
            {
                item.ShowInfo();
            }


           
        }
    }
}