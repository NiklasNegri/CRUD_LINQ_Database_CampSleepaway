using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.CRUD
{
    internal static class Update
    {
        public static void UpdateCamperBooking()
        {
            if (Read.CurrentlyBookedCampers())
            {
                using (var context = new Context.CS_Niklas_NegriContext())
                {
                    Console.WriteLine("Update booking of which camper?");
                    int chosenCamper = Convert.ToInt32(Console.ReadLine());
                    var removeCamperBooking = context.CabinCampers
                        .Single(c => c.CamperId == chosenCamper);
                    context.CabinCampers.Remove(removeCamperBooking);
                    context.SaveChanges();

                    Console.WriteLine("Enter new camper booking\n");
                    Create.CreateCabinCamperBooking();

                    context.SaveChanges();
                }
            }
            else
            {
                Console.WriteLine("No bookings found for any campers\n");
            }
        }
        public static void UpdateCounselorBooking()
        {
            if (Read.CurrentlyBookedCounselors())
            {
                using (var context = new Context.CS_Niklas_NegriContext())
                {
                    Console.WriteLine("Update booking of which counselor?");
                    int chosenCounselor = Convert.ToInt32(Console.ReadLine());
                    var removeCounselorBooking = context.CabinCounselors
                        .Single(c => c.CounselorId == chosenCounselor);
                    context.CabinCounselors.Remove(removeCounselorBooking);
                    context.SaveChanges();
                    Console.WriteLine("Enter new counselor booking\n");
                    Create.CreateCabinCounselorBooking();
                    context.SaveChanges();
                }
            }
            else
            {
                Console.WriteLine("No bookings found for any counselors\n");
            }
        }
    }
}
