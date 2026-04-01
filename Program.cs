using System;
using System.Linq;

namespace LINQ_HW
{
    internal class Program
    {
        class Employee
        {
            public string FullName { get; set; }
            public string Position { get; set; }
            public string Phone { get; set; }
            public string Email { get; set; }
            public decimal Salary { get; set; }

            public Employee(string fullName, string position, string phone, string email, decimal salary)
            {
                FullName = fullName;
                Position = position;
                Phone = phone;
                Email = email;
                Salary = salary;
            }

            public void ShowInfo()
            {
                Console.WriteLine($"{FullName}, {Position}, {Phone}, {Email}, {Salary}$");
            }
        }

        class Firm
        {
            public string Name { get; set; }
            public DateTime FoundedDate { get; set; }
            public string BusinessProfile { get; set; }
            public string DirectorFirstName { get; set; }
            public string DirectorLastName { get; set; }
            public int EmployeeCount { get; set; }
            public string Address { get; set; }
            public Employee[] Employees { get; set; }

            public Firm(string name, DateTime foundedDate, string businessProfile,
                        string directorFirstName, string directorLastName,
                        int employeeCount, string address, Employee[] employees)
            {
                Name = name;
                FoundedDate = foundedDate;
                BusinessProfile = businessProfile;
                DirectorFirstName = directorFirstName;
                DirectorLastName = directorLastName;
                EmployeeCount = employeeCount;
                Address = address;
                Employees = employees;
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
            var employeesTech = new Employee[]
            {
                new Employee("Lionel Messi", "Developer", "231234567", "lionel@tech.com", 2500),
                new Employee("Anna Ivanova", "Manager", "231234568", "anna@tech.com", 3000),
                new Employee("John Doe", "Developer", "451234569", "john@tech.com", 2000)
            };

            var employeesMarket = new Employee[]
            {
                new Employee("Di Caprio", "Manager", "231111111", "di.cap@market.com", 4000),
                new Employee("Elena Petrova", "Analyst", "441234567", "elena@market.com", 2200)
            };

            Firm[] firms = new Firm[]
            {
                new Firm("Tech Solutions", DateTime.Now.AddYears(-1), "IT", "Ivan", "Ivanenko", 150, "Kyiv", employeesTech),
                new Firm("MarketPro", new DateTime(2018, 3, 22), "Marketing", "Petro", "White", 50, "London", employeesMarket),
                new Firm("FoodCorp", new DateTime(2010, 7, 15), "Construction", "Sydir", "Sydorenko", 200, "Odesa", new Employee[0]),
                new Firm("WhiteTech", new DateTime(2020, 1, 1), "IT", "John", "Black", 80, "Berlin", new Employee[0]),
                new Firm("OldCompany", DateTime.Now.AddDays(-123), "Marketing", "Oleg", "Petrov", 30, "Paris", new Employee[0])
            };

            
            var result = firms.Select(firm => firm);
            foreach (var item in result) { item.ShowInfo(); Console.WriteLine(); }
            Console.WriteLine();

            result = firms.Where(firm => firm.Name.ToUpper().Contains("FOOD"));
            foreach (var item in result) Console.WriteLine($"{item.Name}");
            Console.WriteLine();

            result = firms.Where(firm => firm.BusinessProfile.ToUpper() == "MARKETING");
            foreach (var item in result) Console.WriteLine($"{item.Name}");
            Console.WriteLine();

            result = firms.Where(firm => firm.BusinessProfile.ToUpper() == "MARKETING" || firm.BusinessProfile.ToUpper() == "IT");
            foreach (var item in result) Console.WriteLine($"{item.Name}");
            Console.WriteLine();

            result = firms.Where(firm => firm.EmployeeCount > 100);
            foreach (var item in result) Console.WriteLine($"{item.Name}");
            Console.WriteLine();

            result = firms.Where(firm => firm.EmployeeCount > 100 && firm.EmployeeCount < 300);
            foreach (var item in result) Console.WriteLine($"{item.Name}");
            Console.WriteLine();

            result = firms.Where(firm => firm.Address.ToUpper() == "LONDON");
            foreach (var item in result) Console.WriteLine($"{item.Name}");
            Console.WriteLine();

            result = firms.Where(firm => firm.DirectorLastName.ToUpper() == "WHITE");
            foreach (var item in result) Console.WriteLine($"{item.Name}");
            Console.WriteLine();

            result = firms.Where(firm => firm.FoundedDate > DateTime.Now.AddYears(-2));
            foreach (var item in result) Console.WriteLine($"{item.Name}");
            Console.WriteLine();

            result = firms.Where(firm => firm.FoundedDate.Date == DateTime.Now.AddDays(-123));
            foreach (var item in result) Console.WriteLine($"{item.Name}");
            Console.WriteLine();

            result = firms.Where(firm => firm.DirectorLastName.ToUpper() == "BLACK" && firm.Name.ToUpper().Contains("WHITE"));
            foreach (var item in result) Console.WriteLine($"{item.Name}");
            Console.WriteLine();

            
            var employeeQuery = firms.First(f => f.Name == "Tech Solutions").Employees;
            Console.WriteLine("Employees of Tech Solutions:");
            foreach (var emp in employeeQuery) emp.ShowInfo();
            Console.WriteLine();

            employeeQuery = employeeQuery.Where(e => e.Salary > 2500).ToArray();
            Console.WriteLine("Employees with salary > 2500 in Tech Solutions:");
            foreach (var emp in employeeQuery) emp.ShowInfo();
            Console.WriteLine();

            employeeQuery = firms.SelectMany(f => f.Employees)
                                .Where(e => e.Position.ToUpper() == "MANAGER")
                                .ToArray();
            Console.WriteLine("All Managers in all firms:");
            foreach (var emp in employeeQuery) emp.ShowInfo();
            Console.WriteLine();

            employeeQuery = firms.SelectMany(f => f.Employees)
                                .Where(e => e.Phone.StartsWith("23"))
                                .ToArray();
            Console.WriteLine("Employees with phone starting with 23:");
            foreach (var emp in employeeQuery) emp.ShowInfo();
            Console.WriteLine();

            employeeQuery = firms.SelectMany(f => f.Employees)
                                .Where(e => e.Email.StartsWith("di", StringComparison.OrdinalIgnoreCase))
                                .ToArray();
            Console.WriteLine("Employees with email starting with 'di':");
            foreach (var emp in employeeQuery) emp.ShowInfo();
            Console.WriteLine();

            employeeQuery = firms.SelectMany(f => f.Employees)
                                .Where(e => e.FullName.StartsWith("Lionel"))
                                .ToArray();
            Console.WriteLine("Employees with name Lionel:");
            foreach (var emp in employeeQuery) emp.ShowInfo();
            Console.WriteLine();

            
            int[] numbers = { 121, 75, 81 };
            var sortedAsc = numbers.OrderBy(n => SumOfDigits(n));
            Console.WriteLine("Sorted ascending by sum of digits:");
            foreach (var n in sortedAsc) Console.WriteLine(n);
            Console.WriteLine();


            var sortedDesc = numbers.OrderByDescending(n => SumOfDigits(n));
            Console.WriteLine("Sorted descending by sum of digits:");
            foreach (var n in sortedDesc) Console.WriteLine(n);
            Console.WriteLine();

        }

        static int SumOfDigits(int number)
        {
            int sum = 0;
            while (number != 0)
            {
                sum += number % 10;
                number /= 10;
            }
            return sum;
        }
    }
}