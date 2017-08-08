using ConsoleTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HIMS
{
    class Program
    {
        static List<Physician> physicians = new List<Physician>()
        {
            //Seed data
            new Physician
            { Id = 1, FirstName = "FirstName", MiddleName = "MiddleName", BirthDate = DateTime.Now, Gender = "M", LastName = "Last Name", Height = 171, Weight=50,
                ContactInfo = new List<ContactInfo>() { new ContactInfo { PhysicianId = 1, HomeAddress = "Home", HomePhone = "1234"
                } } , Specialization = new List<Specialization>() { new Specialization { PhysicianId = 1, Name = "Optalmologist", Description = "descibe" } }

            }
        };


        static void Main(string[] args)
        { 

            var whileRunning = true;

            Console.WriteLine("=====================================================");

            Console.WriteLine(" Welcome to PW Hospital Information Management System! ");

            Console.WriteLine("=====================================================");

            while (whileRunning)
            {

                Console.WriteLine("=====================================================");

                Console.WriteLine(" MENU ");

                Console.WriteLine("=====================================================");

                Console.WriteLine(" 1.Add Physician records");
                Console.WriteLine(" 2.Delete Physician records");
                Console.WriteLine(" 3.Update Physician records");
                Console.WriteLine(" 4.View all Physician records");
                Console.WriteLine(" 5.Find a Physician by ID");
                Console.WriteLine(" 6.Clear Screen");
                Console.WriteLine(" 7.Exit");

                Console.Write("Type a number and hit <enter>: ");

                var choice = GetUserInput("[1234567]");

                switch (choice)
                {

                    case "1":
                        AddPhysician();
                        Console.Clear();
                        break;

                    case "2":
                        DeletePhysician();
                        break;

                    case "3":
                        UpdatePhysician();
                        Console.Clear();
                        break;

                    case "4":
                        ViewAllPhysician();
                        whileRunning = false;
                        break;

                    case "5":
                        GetPhysicianById();
                        whileRunning = false;
                        break;

                    case "6":

                        Console.Clear();
                        break;

                    case "7":
                        whileRunning = false;
                        break;
                }
            }

        }

        private static void GetPhysicianById()

        {
            Console.Write("Enter Physician Id: ");
            int id = Convert.ToInt32(Console.ReadLine());

            physicians = physicians.Where(x => x.Id == id).ToList();
            if (physicians.Count > 0)
            {


                Console.WriteLine("______________________________Physician_______________________________");
                Console.WriteLine("______________________________________________________________________");

                Console.WriteLine("Id  FirstName  MiddleName  LastName  BirthDate  Gender  Weight  Height");

                Console.WriteLine("_______________________________________________________________________");

                foreach (var item in physicians)
                {
                    Console.Write("{0,-1}", item.Id);

                    Console.Write("{0,10}", item.FirstName);

                    Console.Write("{0,10}", item.MiddleName);

                    Console.Write("{0,15}", item.LastName);

                    Console.Write("{0,10}", item.BirthDate.ToShortDateString());

                    Console.Write("{0,6}", item.Gender);

                    Console.Write("{0,10}", item.Weight);

                    Console.Write("{0,6}", item.Height);


                    Console.WriteLine();

                }

                Console.WriteLine("_______________________________________________________________________");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("__________________No Physician Found!___________________________________");
                Console.ReadLine();

            }
        }

        private static void UpdatePhysician()
        {
            throw new NotImplementedException();
        }

        private static void ViewAllPhysician()
        {
            Console.WriteLine("__________________________List Of Physicians__________________________");
            Console.WriteLine("______________________________________________________________________");

            Console.WriteLine("Id  FirstName  MiddleName  LastName  BirthDate  Gender  Weight  Height");

            Console.WriteLine("_______________________________________________________________________");

            foreach (var item in physicians)
            {
                Console.Write("{0,-1}", item.Id);

                Console.Write("{0,10}", item.FirstName);

                Console.Write("{0,10}",item.MiddleName);

                Console.Write("{0,15}",item.LastName);

                Console.Write("{0,10}",item.BirthDate.ToShortDateString());

                Console.Write("{0,6}", item.Gender);

                Console.Write("{0,10}", item.Weight);

                Console.Write("{0,6}",item.Height);


                Console.WriteLine();

            }

            Console.WriteLine("_______________________________________________________________________");
            Console.ReadLine();

            //ConsoleTable.From<Physician>(physicians).Write();
        }

        private static void DeletePhysician()
        {
            throw new NotImplementedException();
        }

        private static void AddPhysician()
        {
            Console.Clear();
            Console.WriteLine("______________________________Add Physician_____________________________");

            Console.WriteLine("________________________________________________________________________");


            Physician input = new Physician();

           
            if (physicians.Count > 0) {
                input.Id = physicians.Last().Id + 1; 
                    }
            else
            {
                input.Id = 1;
            }

            Console.Write("First Name: ");
            input.FirstName = Console.ReadLine();

            Console.Write("Middle Name: ");
            input.MiddleName = Console.ReadLine();

            Console.Write("Last Name: ");
            input.LastName = Console.ReadLine();

            Console.Write("Birth Date: ");
            input.BirthDate = Convert.ToDateTime(Console.ReadLine());

            Console.Write("Gender:");
            input.Gender = Console.ReadLine();

            Console.Write("Weight:");
            input.Weight = Convert.ToInt32(Console.ReadLine());

            Console.Write("Height:");
            input.Height = Convert.ToInt32(Console.ReadLine());


            AddRecord(input);
            ViewAllPhysician();


        }
        public static void AddRecord(Physician physician)

        {

            Physician phys = new Physician();

            phys.Id = physician.Id;
            phys.FirstName = physician.FirstName;
            phys.MiddleName = physician.MiddleName;
            phys.LastName = physician.LastName;
            phys.BirthDate = physician.BirthDate;
            phys.Gender = physician.Gender;
            phys.Height = physician.Height;
            phys.Weight = physician.Weight;

            physicians.Add(phys);
           

        }
        private static string GetUserInput(string validPattern = null)
        {
            var input = Console.ReadLine();
            input = input.Trim();

            if (validPattern != null && !System.Text.RegularExpressions.Regex.IsMatch(input, validPattern))
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("\"" + input + "\" is not valid.\n");
                Console.ResetColor();
                return null;
            }

            return input;
        }

    }
    public class Physician
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Gender { get; set; }
        public int? Weight { get; set; }
        public int? Height { get; set; }
        public List<ContactInfo> ContactInfo { get; set; }
        public List<Specialization> Specialization { get; set; }

    }
    public class ContactInfo
    {
        public int PhysicianId { get; set; }
        public string HomeAddress { get; set; }
        public string HomePhone { get; set; }

    }
    public class Specialization
    {
        public int PhysicianId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

    }
}
