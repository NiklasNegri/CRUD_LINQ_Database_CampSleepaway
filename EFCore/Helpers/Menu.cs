namespace EFCore.Helpers
{
    internal static class Menu
    {
        public static void MainMenu()
        {
            Console.WriteLine("Camp Sleepaway Niklas Negri\n");
            bool exitMenu = false;
            while (!exitMenu)
            {
                Console.WriteLine("Make a choice in the menu\n" +
                "1. CRUD operations\n" +
                "2. Reports and overview\n" +
                "3. Exit application\n" +
                "1000. Apply seed data to DB\n");

                var input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        CrudMenu();
                        continue;
                    case "2":
                        ReportMenu();
                        continue;
                    case "3":
                        Console.WriteLine("Application shutting down ...");
                        exitMenu = true;
                        break;
                    case "1000":
                        CRUD.Create.CreateSeedData();
                        CRUD.Create.CreateCamperKinRelation();
                        Console.WriteLine("Seed data added to db successfully\n");
                        continue;
                    default:
                        Console.WriteLine("Valid inputs are 1, 2 or 3, please try again.\n");
                        continue;
                }
            }
        }
        public static void CrudMenu()
        {
            Console.WriteLine("CRUD operations for Camp Sleepaway\n");
            bool exitMenu = false;
            while (!exitMenu)
            {
                Console.WriteLine("Make a choice in the menu\n" +
                "1. Create new booking\n" +
                "2. Update existing booking\n" +
                "3. Retire booking to history\n" +
                "4. Back to main menu\n");

                var input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        Console.WriteLine("Do you want to book a camper or a counselor to a cabin?\n" +
                            "1. Camper\n" +
                            "2. Counselor\n");
                        var bookChoice = Console.ReadLine();
                        if (bookChoice == "1")
                        {
                            CRUD.Create.CreateCabinCamperBooking();
                        }
                        else if (bookChoice == "2")
                        {
                            CRUD.Create.CreateCabinCounselorBooking();
                        }
                        else
                        {
                            Console.WriteLine("Invalid input, try again.");
                        }
                        continue;

                    case "2":
                        Console.WriteLine("Do you want to update a campers or a counselors booking?\n" +
                            "1. Camper\n" +
                            "2. Counselor\n");
                        var updateChoice = Console.ReadLine();
                        if (updateChoice == "1")
                        {
                            CRUD.Update.UpdateCamperBooking();
                        }
                        else if (updateChoice == "2")
                        {
                            CRUD.Update.UpdateCounselorBooking();
                        }
                        else
                        {
                            Console.WriteLine("Invalid input, try again.");
                        }
                        continue;

                    case "3":
                        Console.WriteLine("Do you want to retire a counselors or a campers booking?\n" +
                            "1. Counselor\n" +
                            "2. Camper\n");
                        var deleteChoice = Console.ReadLine();
                        if (deleteChoice == "1")
                        {
                            CRUD.Delete.RetireCounselorBooking();

                        }
                        else if (deleteChoice == "2")
                        {
                            CRUD.Delete.RetireCamperBooking();
                        }
                        else
                        {
                            Console.WriteLine("Invalid input, try again.");
                        }
                        continue;

                    case "4":
                        Console.WriteLine("Returning to main menu\n");
                        exitMenu = true; 
                        continue;

                    default:
                        Console.WriteLine("Only valid inputs are 1, 2, 3 or 4, please try again.\n");
                        continue;
                }
            }
        }
        public static void ReportMenu()
        {
            Console.WriteLine("Reports and overview for Camp Sleepaway\n");
            bool exitMenu = false;
            while (!exitMenu)
            {
                Console.WriteLine("Make a choice in the menu\n" +
                "1. Booked cabins\n" +
                "2. Booked counselors\n" +
                "3. Booked campers\n" +
                "4. Available cabins\n" +
                "5. Available counselors\n" +
                "6. Available campers\n" +
                "7. Status of all cabins\n" +
                "8. Status of all counselors\n" +
                "9. Status of all campers\n" +
                "10. Previous bookings per cabin (history)\n" +
                "11. Back to main menu\n");

                var input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        CRUD.Read.CurrentlyBookedCabins();
                        continue;

                    case "2":
                        CRUD.Read.CurrentlyBookedCounselors();
                        continue;

                    case "3":
                        CRUD.Read.CurrentlyBookedCampers();
                        continue;

                    case "4":
                        CRUD.Read.AvailableCabins();
                        continue;

                    case "5":
                        CRUD.Read.AvailableCounselors();
                        continue;

                    case "6":
                        CRUD.Read.AvailableCampers();
                        continue;

                    case "7":
                        CRUD.Read.EveryCabinState();
                        continue;

                    case "8":
                        CRUD.Read.EveryCounselorState();
                        continue;

                    case "9":
                        CRUD.Read.EveryCamperState();
                        continue;
                    case "10":
                        CRUD.Read.OldBookedCabins();
                        continue;
                    case "11":
                        Console.WriteLine("Returning to main menu\n");
                        exitMenu = true;
                        continue;
                    default:
                        Console.WriteLine("Valid inputs are 1, 2, 3, 4, 5, 6, 7, 8, 9 or 10, please try again.\n");
                        continue;
                }
            }
        }
    }
}
