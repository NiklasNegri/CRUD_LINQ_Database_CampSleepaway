using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.CRUD
{
    internal static class Read
    {
        public static void OldBookedCabins()
        {
            using (var context = new Context.CS_Niklas_NegriContext())
            {
                var bookedCamperCabins = context.CabinCampers
                    .Where(c => c.IsActiveBooking == false)
                    .ToList();
                foreach (var item in bookedCamperCabins)
                {
                    Console.WriteLine($"Cabin with id { item.CabinId } was booked for camper with id { item.CamperId } from { item.StartDate } until { item.EndDate } with booking id { item.Id }\n");
                }

                var bookedCounselorCabins = context.CabinCounselors
                    .Where(c => c.IsActiveBooking == false)
                    .ToList();
                foreach (var item in bookedCounselorCabins)
                {
                    Console.WriteLine($"Cabin with id { item.CabinId } was booked for counselor with id { item.CounselorId } from { item.StartDate } until { item.EndDate } with booking id { item.Id }\n");
                }
            }
        }
        public static void CurrentlyBookedCabins()
        {
            using (var context = new Context.CS_Niklas_NegriContext())
            {
                var bookedCamperCabins = context.CabinCampers
                    .Where(c => c.IsActiveBooking == true)
                    .ToList();
                foreach (var item in bookedCamperCabins)
                {
                    Console.WriteLine($"Cabin with id { item.CabinId } is currently booked for camper with id { item.CamperId } until { item.EndDate } with booking id { item.Id }\n");
                }

                var bookedCounselorCabins = context.CabinCounselors
                    .Where(c => c.IsActiveBooking == true)
                    .ToList();
                foreach (var item in bookedCounselorCabins)
                {
                    Console.WriteLine($"Cabin with id { item.CabinId } is currently booked for counselor with id { item.CounselorId } until { item.EndDate } with booking id { item.Id }\n");
                }
            }
        }
        public static bool CurrentlyBookedCampers()
        {
            using (var context = new Context.CS_Niklas_NegriContext())
            {
                var camperBookings = context.CabinCampers
                    .Where(c => c.IsActiveBooking == true)
                    .ToList();

                if (camperBookings.Count > 0)
                {
                    Console.WriteLine("Currently booked campers\n");
                    foreach (var item in camperBookings)
                    {
                        Console.WriteLine($"Camper with id { item.CamperId } is currently booked for cabin with id { item.CabinId } until { item.EndDate } with booking id { item.Id }\n");
                    }
                    return true;
                }
                else
                {
                    Console.WriteLine("No campers are currently booked\n");
                    return false;
                }
            }
        }
        public static bool CurrentlyBookedCounselors()
        {
            using (var context = new Context.CS_Niklas_NegriContext())
            {
                var counselorBookings = context.CabinCounselors
                    .Where(c => c.IsActiveBooking == true)
                    .ToList();

                if (counselorBookings.Count > 0)
                {
                    Console.WriteLine("Currently booked counselors\n");
                    foreach (var item in counselorBookings)
                    {
                        Console.WriteLine($"Counselor with id { item.CounselorId } is currently booked for ---> cabin with id { item.CabinId } <--- until { item.EndDate } with booking id { item.Id }\n");
                    }
                    return true;
                }
                else
                {
                    Console.WriteLine("No counselors are currently booked\n");
                    return false;
                }
            }
        }
        public static void AvailableCabins()
        {
            using (var context = new Context.CS_Niklas_NegriContext())
            {
                var allCabinIds = context.Cabins
                    .Select(c => c.Id)
                    .ToList();
                var cabinsOccupiedByCounselor = context.CabinCounselors
                    .Where(x => x.IsActiveBooking == true)
                    .Select(c => c.CabinId)
                    .ToList();
                var cabinsOccupiedByCamper = context.CabinCampers
                    .Where(x => x.IsActiveBooking == true)
                    .Select(c => c.CabinId)
                    .ToList();

                foreach (int cabinId in allCabinIds)
                {
                    if (!cabinsOccupiedByCounselor.Contains(cabinId))
                    {
                        Console.WriteLine($"Cabin with id { cabinId } available for counselors");
                    }
                    else if (DoesCabinHaveCounselor(cabinId) && CountCampersPerCabin(cabinsOccupiedByCamper, cabinId) < 4)
                    {
                        Console.WriteLine($"Cabin with id { cabinId } has an assigned counselor and { 4 - CountCampersPerCabin(cabinsOccupiedByCamper, cabinId) } available spots for campers");
                    }
                }
            }
        }
        public static bool AvailableCabinsForCampers()
        {
            using (var context = new Context.CS_Niklas_NegriContext())
            {
                bool returnBool = false;

                var allCabinIds = context.Cabins
                    .Select(c => c.Id)
                    .ToList();

                var cabinsOccupiedByCamper = context.CabinCampers
                    .Where(x => x.IsActiveBooking == true)
                    .Select(c => c.CabinId)
                    .ToList();

                foreach (int cabinId in allCabinIds)
                {
                    if (DoesCabinHaveCounselor(cabinId) && CountCampersPerCabin(cabinsOccupiedByCamper, cabinId) < 4)
                    {
                        returnBool = true;
                        Console.WriteLine($"Cabin with id { cabinId } has an assigned counselor and { 4 - CountCampersPerCabin(cabinsOccupiedByCamper, cabinId) } available spots for campers");
                    }
                }
                return returnBool;
            }
        }
        public static void AvailableCabinsForCounselor()
        {
            using (var context = new Context.CS_Niklas_NegriContext())
            {
                // Hämtar alla CabinId
                var allCabins = context.Cabins
                    .Select(c => c.Id)
                    .ToList();

                // Hämtar alla CabinId i CabinCounselors
                var bookedCabins = context.CabinCounselors
                    .Where(x => x.IsActiveBooking == true)
                    .Select(c => c.CabinId)
                    .ToList();

                Console.WriteLine("Available cabins for counselors:");

                // Jämför listorna, skriver ut CabinId's som inte finns i CabinCounselor (dvs bokade cabins)
                foreach (var item in allCabins)
                {
                    if (!bookedCabins.Contains(item))
                    {
                        Console.WriteLine($"Cabin with id { item }");
                    }
                }
            }
        }
        public static void AvailableCampers()
        {
            using (var context = new Context.CS_Niklas_NegriContext())
            {
                var allCampers = context.Campers
                    .Select(c => c.Id)
                    .ToList();

                var bookedCampers = context.CabinCampers
                    .Where(x => x.IsActiveBooking == true)
                    .Select(c => c.CamperId)
                    .ToList();

                Console.WriteLine("Available campers:");

                foreach (var item in allCampers)
                {
                    if (!bookedCampers.Contains(item))
                    {
                        Console.WriteLine($"Camper with id { item }");
                    }
                }
            }
        } 
        public static void AvailableCounselors()
        {
            using (var context = new Context.CS_Niklas_NegriContext())
            {
                var allCounselors = context.Counselors
                    .Select(c => c.Id)
                    .ToList();

                var bookedCounselours = context.CabinCounselors
                    .Where(x => x.IsActiveBooking == true)
                    .Select(c => c.CounselorId)
                    .ToList();

                Console.WriteLine("Available counselors:");

                foreach (var item in allCounselors)
                {
                    if (!bookedCounselours.Contains(item))
                    {
                        Console.WriteLine($"Counselor with id { item }");
                    }
                }
            }
        }
        public static void EveryCabinState()
        {
            using (var context = new Context.CS_Niklas_NegriContext())
            {
                var allCabinIds = context.Cabins
                    .Select(c => c.Id)
                    .ToList();
                var cabinsOccupiedByCounselor = context.CabinCounselors
                    .Where(x => x.IsActiveBooking == true)
                    .Select(c => c.CabinId)
                    .ToList();
                var cabinsOccupiedByCamper = context.CabinCampers
                    .Where(x => x.IsActiveBooking == true)
                    .Select(c => c.CabinId)
                    .ToList();

                foreach (int cabinId in allCabinIds)
                {
                    if (!cabinsOccupiedByCounselor.Contains(cabinId))
                    {
                        Console.WriteLine($"Cabin with id { cabinId } available for counselors");
                    }
                    else if (DoesCabinHaveCounselor(cabinId) && CountCampersPerCabin(cabinsOccupiedByCamper, cabinId) < 4)
                    {
                        Console.WriteLine($"Cabin with id { cabinId } has an assigned counselor and { CountCampersPerCabin(cabinsOccupiedByCamper, cabinId) }/4 spots filled by campers");
                    }
                    else if (!DoesCabinHaveCounselor(cabinId) && CountCampersPerCabin(cabinsOccupiedByCamper, cabinId) < 4)
                    {
                        Console.WriteLine($"Cabin with id { cabinId } has { CountCampersPerCabin(cabinsOccupiedByCamper, cabinId) }/4 spots filled by campers but no counselor assigned");
                    }
                    else if (DoesCabinHaveCounselor(cabinId) && CountCampersPerCabin(cabinsOccupiedByCamper, cabinId) >= 4)
                    {
                        Console.WriteLine($"Cabin with id { cabinId } has an assigned counselor but no empty spots for campers");
                    }
                    else
                    {
                        Console.WriteLine($"Cabin with id { cabinId } booked by another counselor");
                    }
                }
            }
        }
        public static void EveryCamperState()
        {
            using (var context = new Context.CS_Niklas_NegriContext())
            {
                var allCampers = context.Campers
                    .Select(c => c.Id)
                    .ToList();

                var bookedCampers = context.CabinCampers
                    .Where(x => x.IsActiveBooking == true)
                    .Select(c => c.CamperId)
                    .ToList();

                foreach (var item in allCampers)
                {
                    if (!bookedCampers.Contains(item))
                    {
                        Console.WriteLine($"Camper with id { item } not currently booked");
                    }
                    else if (bookedCampers.Contains(item))
                    {
                        Console.WriteLine($"Camper with id { item } is currently booked");
                    }
                }
            }
        }
        public static void EveryCounselorState()
        {
            using (var context = new Context.CS_Niklas_NegriContext())
            {
                var allCounselors = context.Counselors
                    .Select(c => c.Id)
                    .ToList();

                var bookedCounselors = context.CabinCounselors
                    .Where(x => x.IsActiveBooking == true)
                    .Select(c => c.CounselorId)
                    .ToList();

                foreach (var item in allCounselors)
                {
                    if (!bookedCounselors.Contains(item))
                    {
                        Console.WriteLine($"Counselor with id { item } not currently booked");
                    }
                    else if (bookedCounselors.Contains(item))
                    {
                        Console.WriteLine($"Counselor with id { item } is currently booked");
                    }
                }
            }
        }
        public static int CountCampersPerCabin(List<int> list, int cabinId)
        {
            return list.Where(x => x.Equals(cabinId)).Count();
        }
        public static bool DoesCabinHaveCounselor(int cabinId)
        {
            using (var context = new Context.CS_Niklas_NegriContext())
            {
                var bookedCabins = context.CabinCounselors
                    .Select(c => c.CabinId)
                    .ToList();
                if (bookedCabins.Contains(cabinId))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
