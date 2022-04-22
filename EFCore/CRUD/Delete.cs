namespace EFCore.CRUD
{
    internal static class Delete
    {
        public static void RetireCamperBooking()
        {
            if (Read.CurrentlyBookedCampers())
            {
                Console.WriteLine("Enter the camper id to retire its booking\n");
                int chosenCamper = Convert.ToInt32(Console.ReadLine());
                using (var context = new Context.CS_Niklas_NegriContext())
                {
                    var retiredCamperBooking = context.CabinCampers
                        .Single(c => c.CamperId == chosenCamper);
                    retiredCamperBooking.IsActiveBooking = false;
                    context.SaveChanges();
                }
            }
        }
        public static void RetireCounselorBooking()
        {
            if (Read.CurrentlyBookedCounselors())
            {
                using (var context = new Context.CS_Niklas_NegriContext())
                {
                    Console.WriteLine("Which cabin do you want to retire the counselors booking from?\n");

                    int chosenCabinId = Convert.ToInt32(Console.ReadLine());

                    var retireCounselorBooking = context.CabinCounselors
                        .Single(c => c.CabinId == chosenCabinId);
                    retireCounselorBooking.IsActiveBooking = false;
                    Console.WriteLine("Counselor removed, do you want to assign a new counselor? Else campers in the cabin bookings will also be removed\n" +
                        "1. Assign new counselor\n" +
                        "2. Dont assign new counselor and retire active camper bookings in cabin\n");

                    var input = Console.ReadLine();

                    if (input == "1")
                    {
                        Create.CreateCabinCounselorBooking(chosenCabinId);
                    }
                    else if (input == "2")
                    {
                        var removeCamperBooking = context.CabinCampers
                        .Where(c => c.CabinId == chosenCabinId);

                        foreach (var item in removeCamperBooking)
                        {
                            item.IsActiveBooking = false;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid input, try again.");
                    }
                    context.SaveChanges();
                }
            }
        }
    }
}
