using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * CAFE ADMINISTRATOR - Table Reservation System
 * 
 * This program demonstrates a real-world application using classes and objects
 * for managing table reservations in a cafe/restaurant.
 * 
 * Key concepts practiced:
 * 1. Classes and Objects - Creating custom types (Table class)
 * 2. Constructors - Initializing objects with data (table number, max places)
 * 3. Methods - Behavior/actions (ShowInfo, Reserve)
 * 4. Fields - Object state/data (Number, MaxPlaces, FreePlaces)
 * 5. Arrays of objects - Managing multiple table instances
 * 6. Boolean return values - Success/failure status from methods
 * 7. Object-oriented design - Separating data and behavior
 * 8. User input validation and feedback
 * 
 * Program flow:
 * 1. Initialize cafe with multiple tables (each with capacity)
 * 2. Display all tables with availability
 * 3. Allow user to select table and reserve seats
 * 4. Validate reservation (check if enough free places)
 * 5. Update table state and show result
 * 6. Repeat until user exits
 */

namespace csharp_learn.Practice
{
    internal class Practice13_CafeAdministrator
    {
        public static void Run()
        {
            // ============================
            // SYSTEM INITIALIZATION
            // ============================

            // Flag to control main loop - cafe is open for business
            bool isOpen = true;

            // ============================
            // CREATE CAFE TABLES
            // ============================

            // OLD WAY (manual creation - tedious for many tables):
            // Table table1 = new Table(1, 4); 
            // Table table2 = new Table(2, 8);
            // Problem: Must create and name each variable individually

            // BETTER WAY: Array of Table objects
            // Each Table constructor takes: (table number, max capacity)
            Table[] tables =
            {
                new Table(1, 4),   // Table 1: 4 seats
                new Table(2, 8),   // Table 2: 8 seats (large)
                new Table(3, 10)   // Table 3: 10 seats (extra large)
            };

            // ============================
            // MAIN PROGRAM LOOP
            // ============================

            // Continuous loop while cafe is open
            // In production: isOpen could be controlled by admin command
            while (isOpen)
            {
                // ============================
                // DISPLAY SYSTEM HEADER
                // ============================

                Console.WriteLine("=== CAFE ADMINISTRATION SYSTEM ===\n");

                // ============================
                // SHOW ALL TABLES STATUS
                // ============================

                // Iterate through all table objects and display their info
                // Each table knows how to display itself (ShowInfo method)
                for (int i = 0; i < tables.Length; i++)
                {
                    tables[i].ShowInfo();
                }

                // ============================
                // USER INPUT: SELECT TABLE
                // ============================

                Console.WriteLine("\n=== MAKE RESERVATION ===");
                Console.Write("Select table number (or 0 to exit): ");
                int selectedTableNumber = Convert.ToInt32(Console.ReadLine());

                // Exit condition - user wants to close system
                if (selectedTableNumber == 0)
                {
                    Console.WriteLine("\nClosing cafe administration system...");
                    isOpen = false;
                    break;
                }

                // Convert user input (1-based) to array index (0-based)
                // User sees: Table 1, 2, 3 (human-friendly)
                // Array uses: Index 0, 1, 2 (computer indexing)
                int tableIndex = selectedTableNumber - 1;

                // ============================
                // INPUT VALIDATION: TABLE EXISTS
                // ============================

                // Check if selected table number is valid (within array bounds)
                if (tableIndex < 0 || tableIndex >= tables.Length)
                {
                    Console.WriteLine("\n❌ Invalid table number! Please try again.");
                    Console.WriteLine("\nPress any key to continue...");
                    Console.ReadKey();
                    Console.Clear();
                    continue; // Skip to next iteration
                }

                // ============================
                // USER INPUT: NUMBER OF SEATS
                // ============================

                Console.Write("\nEnter the number of seats to reserve: ");
                int desiredPlaces = Convert.ToInt32(Console.ReadLine());

                // ============================
                // INPUT VALIDATION: POSITIVE NUMBER
                // ============================

                if (desiredPlaces <= 0)
                {
                    Console.WriteLine("\n❌ Invalid number! Must reserve at least 1 seat.");
                    Console.WriteLine("\nPress any key to continue...");
                    Console.ReadKey();
                    Console.Clear();
                    continue;
                }

                // ============================
                // ATTEMPT RESERVATION
                // ============================

                // Call Reserve method on selected table object
                // Returns: true if successful, false if not enough seats
                // The table object manages its own state (FreePlaces)
                bool isReservationCompleted = tables[tableIndex].Reserve(desiredPlaces);

                // ============================
                // DISPLAY RESULT
                // ============================

                Console.WriteLine(); // Blank line for readability

                if (isReservationCompleted)
                {
                    Console.WriteLine("✅ Reservation completed successfully!");
                    Console.WriteLine($"Table {selectedTableNumber}: {desiredPlaces} seat(s) reserved.");
                }
                else
                {
                    Console.WriteLine("❌ Reservation failed!");
                    Console.WriteLine($"Not enough free seats at Table {selectedTableNumber}.");
                    Console.WriteLine($"Requested: {desiredPlaces}, Available: {tables[tableIndex].FreePlaces}");
                }

                // ============================
                // PAUSE AND REFRESH SCREEN
                // ============================

                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();   // Wait for user to read the message
                Console.Clear();     // Clear screen for next iteration
            }

            // ============================
            // PROGRAM EXIT
            // ============================

            Console.WriteLine("\nThank you for using Cafe Administrator!");
        }

        // ============================
        // TABLE CLASS DEFINITION
        // ============================

        /// <summary>
        /// Represents a cafe table with reservation capabilities
        /// Encapsulates table data (number, capacity) and behavior (reserve, show info)
        /// </summary>
        class Table
        {
            // ============================
            // FIELDS (Object State/Data)
            // ============================

            // Table identifier (e.g., 1, 2, 3)
            public int Number;

            // Maximum seating capacity (never changes)
            public int MaxPlaces;

            // Currently available seats (changes with reservations)
            public int FreePlaces;

            // ============================
            // CONSTRUCTOR (Object Initialization)
            // ============================

            /// <summary>
            /// Creates a new table with specified number and capacity
            /// Automatically sets FreePlaces equal to MaxPlaces (all seats available)
            /// </summary>
            /// <param name="number">Table identifier (e.g., 1, 2, 3)</param>
            /// <param name="maxPlaces">Maximum seating capacity</param>
            public Table(int number, int maxPlaces)
            {
                Number = number;
                MaxPlaces = maxPlaces;
                FreePlaces = maxPlaces; // Initially all seats are free
            }

            // ============================
            // METHODS (Object Behavior)
            // ============================

            /// <summary>
            /// Displays table information to console
            /// Shows: table number, free seats, and total capacity
            /// </summary>
            public void ShowInfo()
            {
                Console.WriteLine($"Table {Number}: {FreePlaces}/{MaxPlaces} seats available");
            }

            /// <summary>
            /// Attempts to reserve seats at this table
            /// Validates if enough free seats are available
            /// Updates FreePlaces if successful
            /// </summary>
            /// <param name="places">Number of seats to reserve</param>
            /// <returns>true if reservation successful, false if not enough seats</returns>
            public bool Reserve(int places)
            {
                // Check if we have enough free seats for the reservation
                if (FreePlaces >= places)
                {
                    // Reservation successful: reduce free places
                    FreePlaces -= places;
                    return true; // Indicate success
                }
                else
                {
                    // Not enough seats available
                    return false; // Indicate failure
                }
            }
        }
    }
}