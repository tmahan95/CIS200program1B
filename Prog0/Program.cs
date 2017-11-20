/* Timothy Mahan
 * Program 1B
 * Due 10/17/16
 * Course Section: 76
 * This program creates a bunch of test objects that include Letters, GroundPackages, NextDayAirPackages, and TwoDayAirPackages.
 * This program then adds these test objects to a list and searches through them using linq queries.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog0
{
    class Program
    {
        // Precondition:  None
        // Postcondition: Small list of Parcels is created and displayed
        static void Main(string[] args)
        {
            Address a1 = new Address("John Smith", "123 Any St.", "Apt. 45", 
                "Louisville", "KY", 40202); // Test Address 1
            Address a2 = new Address("Jane Doe", "987 Main St.", "", 
                "Beverly Hills", "CA", 90210); // Test Address 2
            Address a3 = new Address("James Kirk", "654 Roddenberry Way", "Suite 321", 
                "El Paso", "TX", 79901); // Test Address 3
            Address a4 = new Address("John Crichton", "678 Pau Place", "Apt. 7",
                "Portland", "ME", 04101); // Test Address 4
            Address a5 = new Address("James Haverstock", "10101 Linn Station Rd", "Suite 200",
                "Louisville", "KY", 40223); // Test Address 5
            Address a6 = new Address("Paul Jacob", "4107 SpyGlass Ct", "", 
                "Louisville", "KY", 40229); // Test Address 6
            Address a7 = new Address("Laura Payne", "320 E Esplenade Ave", "", 
                "Louisville", "KY", 40213); // Test Address 7
            Address a8 = new Address("Geraldine Spicer", "8601 Timberhallow Ct", "",
                "Louisville", "KY", 40219); // Test Address 8

            Letter l1 = new Letter(a1, a3, 1.50M); // Test Letter 1
            Letter l2 = new Letter(a2, a4, 1.25M); // Test Letter 2
            Letter l3 = new Letter(a4, a1, 1.75M); // Test Letter 3
            GroundPackage g1 = new GroundPackage(3, 6, 9, 12, a1, a6); // Test GroundPackage 1
            GroundPackage g2 = new GroundPackage(12, 9, 6, 3, a5, a8); // Test GroundPackage 2
            GroundPackage g3 = new GroundPackage(6, 7, 9, 100, a3, a7); // Test GroundPackage 3
            NextDayAirPackage nA1 = new NextDayAirPackage(500, 12, 12, 12, 12, a4, a7); // Test NextDayAirPackage 1
            NextDayAirPackage nA2 = new NextDayAirPackage(20, 7, 7, 7, 70, a7, a2); // Test NextDayAirPackage 2
            NextDayAirPackage nA3 = new NextDayAirPackage(5, 1, 2, 3, 4, a3, a1); // Test NextDayAirPackage 3
            TwoDayAirPackage tA1 = new TwoDayAirPackage(9, 9, 9, 200, a6, a3, TwoDayAirPackage.Delivery.Saver); //Test TwoDayAirPackage 1
            TwoDayAirPackage tA2 = new TwoDayAirPackage(10, 20, 30, 40, a7, a8,TwoDayAirPackage.Delivery.Early); //Test TwoDayAirPackage 2
            TwoDayAirPackage tA3 = new TwoDayAirPackage(100, 90, 80, 76, a4, a3,TwoDayAirPackage.Delivery.Saver); //Test TwoDayAirPackage 3

            List<Parcel> parcels = new List<Parcel>(); // Test list of parcels

            // Add test data to list
            parcels.Add(l1);
            parcels.Add(l2);
            parcels.Add(l3);
            parcels.Add(g1);
            parcels.Add(g2);
            parcels.Add(g3);
            parcels.Add(nA1);
            parcels.Add(nA2);
            parcels.Add(nA3);
            parcels.Add(tA1);
            parcels.Add(tA2);
            parcels.Add(tA3);

            //Begin LINQ Queries
            //Query 1
            Console.WriteLine("=========================================");
            Console.WriteLine("This lists all parcels by their destination Zip in decending order.");
            Console.WriteLine();
            //Query that lists all parcels by destination zip in descending order.
            var dZip =
                from x in parcels //Temporary variable to hold parcels for LINQ queries
                orderby -x.DestinationAddress.Zip //list in descending order
                select x;
            foreach (var parcel in dZip) // Temporary variable to hold parcel objects for display
            {
                Console.WriteLine(parcel);
                Console.WriteLine("---------------------------");
                Console.WriteLine();
            }

            //Query 2
            Console.WriteLine("=========================================");
            Console.WriteLine("This lists all parcels by their cost in ascending order");
            Console.WriteLine();
            // query that lists all parcels by their cost in ascending order
            var costA =
                from x in parcels //Temporary variable to hold parcels for LINQ queries
                orderby x.CalcCost() // Method used for calculating the cost of shipping a parcel in ascending order
                select x;
            foreach (var parcel in parcels)
            {
                Console.WriteLine(parcel);
                Console.WriteLine("---------------------------");
                Console.WriteLine();
            }

            //Query 3
            Console.WriteLine("=========================================");
            Console.WriteLine("This lists all parcels by their type.");
            Console.WriteLine();
            // query that lists all parcels by their respective types alphabetically
            var parcelT =
                from x in parcels //Temporary variable to hold parcels for LINQ queries
                orderby x.GetType() // Method used to get the type of the parcel
                orderby x.CalcCost() // Method used to get the cost of shipping a parcel in ascending order
                select x;
            foreach (var parcel in parcels) // Temporary variable to hold parcels for display in the foreach loop
            {
                Console.WriteLine(parcel.GetType().ToString());
                Console.WriteLine(parcel);
                Console.WriteLine("---------------------------");
                Console.WriteLine();
            }

            //Query 4
            Console.WriteLine("=========================================");
            Console.WriteLine("This shows all heavy airpackages and orders them by weight.");
            Console.WriteLine();
            // Query that lists only Heavy objects and sorts them by weight
            var airPackages =
                from x in parcels //Temporary variable to hold parcels for LINQ queries
                where x is AirPackage && ((AirPackage)x).IsHeavy() == true
                let airP = (AirPackage)x // Cast x as AirPackage and store in another temporary variable for sorting.
                orderby -airP.Weight //list in descending order
                select x;
            foreach (var airPackage in airPackages) //Temporary variable used to display airPackage objects
            {
                Console.WriteLine(airPackage);
                Console.WriteLine("------------------------------");
                Console.WriteLine();
            }
        }
    }
}
