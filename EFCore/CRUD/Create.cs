using EFCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.CRUD
{
    internal static class Create
    {
        public static void CreateSeedData()
        {
            using (var context = new Context.CS_Niklas_NegriContext())
            {
                // Skapa 18 campers
                context.Add(new Camper { Name = "Niklas Negri", Email = "niklas.negri@gmail.com", AmountCabinsVisited = 0 });
                context.Add(new Camper { Name = "Frida Johansson", Email = "frida.johansson@gmail.com", AmountCabinsVisited = 0 });
                context.Add(new Camper { Name = "Mathias Jonsson", Email = "mathias.jonsson@gmail.com", AmountCabinsVisited = 0 });
                context.Add(new Camper { Name = "Hjert Liv", Email = "hjert.liv@gmail.com", AmountCabinsVisited = 0 });
                context.Add(new Camper { Name = "Torben Tek", Email = "torben.tek@gmail.com", AmountCabinsVisited = 0 });
                context.Add(new Camper { Name = "Linda Loh", Email = "linda.loh@gmail.com", AmountCabinsVisited = 0 });
                context.Add(new Camper { Name = "Robert Berg", Email = "robert.berg@gmail.com", AmountCabinsVisited = 0 });
                context.Add(new Camper { Name = "Rufus Stor", Email = "rufus.stor@gmail.com", AmountCabinsVisited = 0 });
                context.Add(new Camper { Name = "Martin Mur", Email = "martin.mur@gmail.com", AmountCabinsVisited = 0 });
                context.Add(new Camper { Name = "Evelina Elak", Email = "evelina.elak@gmail.com", AmountCabinsVisited = 0 });
                context.Add(new Camper { Name = "Simon Toredal", Email = "simon.toredal@gmail.com", AmountCabinsVisited = 0 });
                context.Add(new Camper { Name = "Bert Boss", Email = "bert.boss@gmail.com", AmountCabinsVisited = 0 });
                context.Add(new Camper { Name = "Esmeralda Esme", Email = "esmeralda.esme@gmail.com", AmountCabinsVisited = 0 });
                context.Add(new Camper { Name = "Lisa Lund", Email = "lisa.lund@gmail.com", AmountCabinsVisited = 0 });
                context.Add(new Camper { Name = "Rasmus Smurf", Email = "rasmus.smurf@gmail.com", AmountCabinsVisited = 0 });
                context.Add(new Camper { Name = "Luke Walker", Email = "luke.walker@gmail.com", AmountCabinsVisited = 0 });
                context.Add(new Camper { Name = "Erik Aldal", Email = "erik.aldal@gmail.com", AmountCabinsVisited = 0 });
                context.Add(new Camper { Name = "Maral Simonides", Email = "maral.simonides@gmail.com", AmountCabinsVisited = 0 });

                // Skapa 4 nextofkin
                context.Add(new NextOfKin { Name = "Jorgen Bett", Email = "jorgen.liv@gmail.com", EmergencyPhoneNumber = "0701234567" });
                context.Add(new NextOfKin { Name = "Lena Kotte", Email = "lena.tek@gmail.com", EmergencyPhoneNumber = "0731234567" });
                context.Add(new NextOfKin { Name = "Elin Korg", Email = "elin.loh@gmail.com", EmergencyPhoneNumber = "0751234567" });
                context.Add(new NextOfKin { Name = "Gunnel Grek", Email = "gunnel.berg@gmail.com", EmergencyPhoneNumber = "0761234567" });

                // Skapa 3 cabins
                context.Add(new Cabin { });
                context.Add(new Cabin { });
                context.Add(new Cabin { });

                // Skapa 3 Counselors
                context.Add(new Counselor { Name = "Karl Andersson", Email = "karl.andersson@gmail.com", HoursWorkedWeekly = 40 });
                context.Add(new Counselor { Name = "Anna Anka", Email = "anna.anka@gmail.com", HoursWorkedWeekly = 30 });
                context.Add(new Counselor { Name = "Johan Gran", Email = "johan.gran@gmail.com", HoursWorkedWeekly = 20 });

                context.SaveChanges();
            }
        }
        public static void CreateCamperKinRelation()
        {
            using (var context = new Context.CS_Niklas_NegriContext())
            {
                // Skapa relationer mellan 4 nextofkin och campers
                context.Add(new CamperNextOfKin { NextOfKinId = 1, CamperId = 1 });
                context.Add(new CamperNextOfKin { NextOfKinId = 2, CamperId = 2 });
                context.Add(new CamperNextOfKin { NextOfKinId = 3, CamperId = 3 });
                context.Add(new CamperNextOfKin { NextOfKinId = 4, CamperId = 4 });

                context.SaveChanges();
            }
        }
        public static void CreateCabinCamperBooking()
        {
            Read.AvailableCampers();
            Console.WriteLine("Enter camper id\n");
            int chosenCamper = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Available cabins for campers");
            if (Read.AvailableCabinsForCampers())
            {
                Console.WriteLine("Enter cabin id\n");
                int chosenCabin = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Enter start date for camper booking");
                Console.WriteLine("Enter year\n");
                int chosenStartYear = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter month\n");
                int chosenStartMonth = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter day\n");
                int chosenStartDay = Convert.ToInt32(Console.ReadLine());
                DateTime startDate = new(chosenStartYear, chosenStartMonth, chosenStartDay);

                Console.WriteLine("Enter end date for camper booking");
                Console.WriteLine("Enter year\n");
                int chosenEndYear = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter month\n");
                int chosenEndMonth = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter day\n");
                int chosenEndDay = Convert.ToInt32(Console.ReadLine());
                DateTime endDate = new(chosenEndYear, chosenEndMonth, chosenEndDay);

                using (var context = new Context.CS_Niklas_NegriContext())
                {
                    context.Add(new CabinCamper { CabinId = chosenCabin, CamperId = chosenCamper, StartDate = startDate, EndDate = endDate, IsActiveBooking = true });
                    context.SaveChanges();
                }
            }
            else
            {
                Console.WriteLine("No cabins with assigned counselors and empty spots for campers found\n");
            }
        }
        public static void CreateCabinCounselorBooking()
        {
            Read.AvailableCounselors();
            Console.WriteLine("Enter id of counselor to book\n");
            int chosenCounselor = Convert.ToInt32(Console.ReadLine());

            Read.AvailableCabinsForCounselor();
            Console.WriteLine("Enter id of cabin\n");
            int chosenCabin = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter start date for counselor booking");
            Console.WriteLine("Enter year\n");
            int chosenStartYear = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter month\n");
            int chosenStartMonth = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter day\n");
            int chosenStartDay = Convert.ToInt32(Console.ReadLine());
            DateTime startDate = new (chosenStartYear, chosenStartMonth, chosenStartDay);

            Console.WriteLine("Enter end date for counselor booking");
            Console.WriteLine("Enter year\n");
            int chosenEndYear = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter month\n");
            int chosenEndMonth = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter day\n");
            int chosenEndDay = Convert.ToInt32(Console.ReadLine());
            DateTime endDate = new (chosenEndYear, chosenEndMonth, chosenEndDay);

            using (var context = new Context.CS_Niklas_NegriContext())
            {
                context.Add(new CabinCounselor { CabinId = chosenCabin, CounselorId = chosenCounselor, StartDate = startDate, EndDate = endDate, IsActiveBooking = true });
                context.SaveChanges();
            }
        }
        // overloaded method where cabinId is predetermined
        public static void CreateCabinCounselorBooking(int cabinId)
        {
            Read.AvailableCounselors();
            Console.WriteLine("Enter couselor id\n");
            int chosenCounselor = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter start date for counselor booking");
            Console.WriteLine("Enter year\n");
            int chosenStartYear = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter month\n");
            int chosenStartMonth = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter day\n");
            int chosenStartDay = Convert.ToInt32(Console.ReadLine());
            DateTime startDate = new (chosenStartYear, chosenStartMonth, chosenStartDay);

            Console.WriteLine("Enter end date for counselor booking");
            Console.WriteLine("Enter year\n");
            int chosenEndYear = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter month\n");
            int chosenEndMonth = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter day\n");
            int chosenEndDay = Convert.ToInt32(Console.ReadLine());
            DateTime endDate = new (chosenEndYear, chosenEndMonth, chosenEndDay);

            using (var context = new Context.CS_Niklas_NegriContext())
            {
                context.Add(new CabinCounselor { CabinId = cabinId, CounselorId = chosenCounselor, StartDate = startDate, EndDate = endDate });
                context.SaveChanges();
            }
        }
    }
}
