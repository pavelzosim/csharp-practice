using System;
using System.Collections.Generic;

namespace csharp_learn.Lessons
{
    // LESSON 18: Queue<T> Collection (FIFO - First In, First Out)
    // Learn about queue data structure where first added element is first removed
    internal class Lesson18_fifo_collection
    {
        public static void Run()
        {
            // ===== TOPIC: QUEUE COLLECTION (FIFO) =====
            // Queue = First In, First Out (like a line of people waiting)
            // First person to join the line is first person to be served
            // Think: Line at a store, printer queue, task scheduler

            Console.WriteLine("=== QUEUE<T> COLLECTION (FIFO) ===\n");

            // ===== WHAT IS FIFO? =====

            Console.WriteLine("=== WHAT IS FIFO? ===\n");

            Console.WriteLine("FIFO = First In, First Out");
            Console.WriteLine("Like a line at a coffee shop:");
            Console.WriteLine("1. Alice arrives → joins line (first)");
            Console.WriteLine("2. Bob arrives → joins line (second)");
            Console.WriteLine("3. Charlie arrives → joins line (third)");
            Console.WriteLine("Serving order: Alice → Bob → Charlie");
            Console.WriteLine();

            // ===== CREATING QUEUES =====

            Console.WriteLine("=== CREATING QUEUES ===\n");

            // Create empty queue
            Queue<string> emptyQueue = new Queue<string>();
            Console.WriteLine($"Empty queue count: {emptyQueue.Count}");

            // Create queue with initial capacity (optimization)
            Queue<int> queueWithCapacity = new Queue<int>(10);
            Console.WriteLine($"Queue with capacity count: {queueWithCapacity.Count}");

            // Create queue from existing collection
            string[] names = { "Alice", "Bob", "Charlie" };
            Queue<string> nameQueue = new Queue<string>(names);
            Console.WriteLine($"Queue from array count: {nameQueue.Count}");

            Console.WriteLine();

            // ===== ENQUEUE - ADDING TO QUEUE =====

            Console.WriteLine("=== ENQUEUE (Adding Elements) ===\n");

            Queue<string> patients = new Queue<string>();

            Console.WriteLine("Adding patients to queue:");

            // Enqueue = Add to the END of queue
            patients.Enqueue("Patient 1 - John");
            Console.WriteLine("  Enqueued: Patient 1 - John");

            patients.Enqueue("Patient 2 - Sarah");
            Console.WriteLine("  Enqueued: Patient 2 - Sarah");

            patients.Enqueue("Patient 3 - Mike");
            Console.WriteLine("  Enqueued: Patient 3 - Mike");

            Console.WriteLine($"\nTotal patients waiting: {patients.Count}");
            Console.WriteLine();

            // ===== DEQUEUE - REMOVING FROM QUEUE =====

            Console.WriteLine("=== DEQUEUE (Removing Elements) ===\n");

            Console.WriteLine("Serving patients in FIFO order:\n");

            // Dequeue = Remove and return from the FRONT of queue
            string firstPatient = patients.Dequeue();
            Console.WriteLine($"Now serving: {firstPatient}");
            Console.WriteLine($"Patients remaining: {patients.Count}");

            string secondPatient = patients.Dequeue();
            Console.WriteLine($"Now serving: {secondPatient}");
            Console.WriteLine($"Patients remaining: {patients.Count}");

            Console.WriteLine();

            // ===== PEEK - LOOK WITHOUT REMOVING =====

            Console.WriteLine("=== PEEK (Look Without Removing) ===\n");

            Queue<string> orders = new Queue<string>();
            orders.Enqueue("Order #101 - Pizza");
            orders.Enqueue("Order #102 - Burger");
            orders.Enqueue("Order #103 - Salad");

            // Peek = Look at next item WITHOUT removing it
            string nextOrder = orders.Peek();
            Console.WriteLine($"Next order to process: {nextOrder}");
            Console.WriteLine($"Queue still has {orders.Count} orders"); // Still 3!

            // Dequeue actually removes it
            string processedOrder = orders.Dequeue();
            Console.WriteLine($"Processed: {processedOrder}");
            Console.WriteLine($"Queue now has {orders.Count} orders"); // Now 2

            Console.WriteLine();

            // ===== CONTAINS - CHECK IF EXISTS =====

            Console.WriteLine("=== CONTAINS (Check Existence) ===\n");

            Queue<string> printQueue = new Queue<string>();
            printQueue.Enqueue("Document1.pdf");
            printQueue.Enqueue("Document2.docx");
            printQueue.Enqueue("Photo.jpg");

            // Check if specific item is in queue
            bool hasPdf = printQueue.Contains("Document1.pdf");
            Console.WriteLine($"Queue contains 'Document1.pdf': {hasPdf}");

            bool hasExcel = printQueue.Contains("Spreadsheet.xlsx");
            Console.WriteLine($"Queue contains 'Spreadsheet.xlsx': {hasExcel}");

            Console.WriteLine();

            // ===== CLEAR - REMOVE ALL =====

            Console.WriteLine("=== CLEAR (Remove All) ===\n");

            Queue<int> numbers = new Queue<int>();
            numbers.Enqueue(10);
            numbers.Enqueue(20);
            numbers.Enqueue(30);
            Console.WriteLine($"Queue count before clear: {numbers.Count}");

            numbers.Clear();
            Console.WriteLine($"Queue count after clear: {numbers.Count}");

            Console.WriteLine();

            // ===== ITERATING THROUGH QUEUE =====

            Console.WriteLine("=== ITERATING THROUGH QUEUE ===\n");

            Queue<string> tasks = new Queue<string>();
            tasks.Enqueue("Task 1: Compile code");
            tasks.Enqueue("Task 2: Run tests");
            tasks.Enqueue("Task 3: Deploy app");

            Console.WriteLine("Current tasks in queue:");

            // foreach - doesn't remove items, just reads
            foreach (string task in tasks)
            {
                Console.WriteLine($"  - {task}");
            }

            Console.WriteLine($"\nQueue still has {tasks.Count} tasks (foreach doesn't remove)");

            Console.WriteLine();

            // ===== PROCESSING ENTIRE QUEUE =====

            Console.WriteLine("=== PROCESSING ENTIRE QUEUE ===\n");

            Queue<string> emails = new Queue<string>();
            emails.Enqueue("Email from Boss");
            emails.Enqueue("Email from Client");
            emails.Enqueue("Newsletter");

            Console.WriteLine("Processing all emails:");

            // Process until queue is empty
            while (emails.Count > 0)
            {
                string email = emails.Dequeue();
                Console.WriteLine($"  Reading: {email}");
            }

            Console.WriteLine($"All emails processed. Queue count: {emails.Count}");

            Console.WriteLine();

            // ===== TOARRAY - CONVERT TO ARRAY =====

            Console.WriteLine("=== TOARRAY (Convert to Array) ===\n");

            Queue<int> scoreQueue = new Queue<int>();
            scoreQueue.Enqueue(100);
            scoreQueue.Enqueue(85);
            scoreQueue.Enqueue(92);

            // Convert queue to array (doesn't remove items from queue)
            int[] scoreArray = scoreQueue.ToArray();

            Console.WriteLine("Array elements:");
            for (int i = 0; i < scoreArray.Length; i++)
            {
                Console.WriteLine($"  [{i}] = {scoreArray[i]}");
            }

            Console.WriteLine($"Queue still has {scoreQueue.Count} items");

            Console.WriteLine();

            // ===== PRACTICAL EXAMPLE: CUSTOMER SERVICE =====

            Console.WriteLine("=== PRACTICAL EXAMPLE: CUSTOMER SERVICE ===\n");

            Queue<string> customerLine = new Queue<string>();

            // Customers arrive
            Console.WriteLine("=== Customers Arriving ===");
            customerLine.Enqueue("Customer: Alice");
            Console.WriteLine("Alice joins the line");

            customerLine.Enqueue("Customer: Bob");
            Console.WriteLine("Bob joins the line");

            customerLine.Enqueue("Customer: Charlie");
            Console.WriteLine("Charlie joins the line");

            Console.WriteLine($"Total customers waiting: {customerLine.Count}\n");

            // Serve customers
            Console.WriteLine("=== Serving Customers ===");
            int customerNumber = 1;
            while (customerLine.Count > 0)
            {
                string customer = customerLine.Dequeue();
                Console.WriteLine($"{customerNumber}. Now serving: {customer}");
                customerNumber++;
            }

            Console.WriteLine("\nAll customers served!");

            Console.WriteLine();

            // ===== PRACTICAL EXAMPLE: PRINT QUEUE =====

            Console.WriteLine("=== PRACTICAL EXAMPLE: PRINT QUEUE ===\n");

            Queue<string> printer = new Queue<string>();

            // Add print jobs
            printer.Enqueue("Report.pdf (10 pages)");
            printer.Enqueue("Invoice.docx (2 pages)");
            printer.Enqueue("Photo.jpg (1 page)");

            Console.WriteLine($"Print jobs in queue: {printer.Count}");
            Console.WriteLine($"Next to print: {printer.Peek()}\n");

            // Process print jobs
            Console.WriteLine("Printing documents:");
            while (printer.Count > 0)
            {
                string document = printer.Dequeue();
                Console.WriteLine($"  Printing: {document}");
                System.Threading.Thread.Sleep(500); // Simulate printing delay
            }

            Console.WriteLine("\nAll documents printed!");

            Console.WriteLine();

            // ===== GAME DEV EXAMPLES =====

            Console.WriteLine("=== GAME DEV EXAMPLES ===\n");

            // Example 1: Enemy spawn queue
            Queue<string> spawnQueue = new Queue<string>();
            spawnQueue.Enqueue("Goblin");
            spawnQueue.Enqueue("Orc");
            spawnQueue.Enqueue("Troll");

            Console.WriteLine("Enemy spawn queue:");
            Console.WriteLine($"Next enemy to spawn: {spawnQueue.Peek()}");

            string spawnedEnemy = spawnQueue.Dequeue();
            Console.WriteLine($"Spawned: {spawnedEnemy}");
            Console.WriteLine($"Enemies left in queue: {spawnQueue.Count}");

            Console.WriteLine();

            // Example 2: Action queue (combo system)
            Queue<string> actionQueue = new Queue<string>();
            actionQueue.Enqueue("Punch");
            actionQueue.Enqueue("Kick");
            actionQueue.Enqueue("Jump");

            Console.WriteLine("Player action combo:");
            while (actionQueue.Count > 0)
            {
                Console.WriteLine($"  Execute: {actionQueue.Dequeue()}");
            }

            Console.WriteLine();

            // Example 3: Dialogue queue
            Queue<string> dialogue = new Queue<string>();
            dialogue.Enqueue("Hero: Hello, stranger!");
            dialogue.Enqueue("NPC: Greetings, adventurer!");
            dialogue.Enqueue("Hero: Can you help me?");
            dialogue.Enqueue("NPC: Of course! Follow me.");

            Console.WriteLine("Dialogue sequence:");
            while (dialogue.Count > 0)
            {
                Console.WriteLine($"  {dialogue.Dequeue()}");
                System.Threading.Thread.Sleep(800);
            }

            Console.WriteLine();

            // ===== QUEUE vs LIST vs STACK =====

            Console.WriteLine("=== QUEUE vs LIST vs STACK ===\n");

            Console.WriteLine("📋 QUEUE (FIFO - First In, First Out):");
            Console.WriteLine("  Add: Enqueue(item) → adds to END");
            Console.WriteLine("  Remove: Dequeue() → removes from FRONT");
            Console.WriteLine("  Use: Customer lines, print jobs, task scheduling");
            Console.WriteLine();

            Console.WriteLine("📋 LIST (Random Access):");
            Console.WriteLine("  Add: Add(item) → adds to end");
            Console.WriteLine("  Remove: Remove(item) / RemoveAt(index)");
            Console.WriteLine("  Access: list[index] → any position");
            Console.WriteLine("  Use: General collections, inventories");
            Console.WriteLine();

            Console.WriteLine("📋 STACK (LIFO - Last In, First Out):");
            Console.WriteLine("  Add: Push(item) → adds to TOP");
            Console.WriteLine("  Remove: Pop() → removes from TOP");
            Console.WriteLine("  Use: Undo/Redo, browser history (covered in Lesson 19)");

            Console.WriteLine();

            // ===== PERFORMANCE NOTES =====

            Console.WriteLine("=== PERFORMANCE ===\n");

            Console.WriteLine("⚡ Queue Performance (all O(1) - constant time):");
            Console.WriteLine("• Enqueue() - O(1) - very fast");
            Console.WriteLine("• Dequeue() - O(1) - very fast");
            Console.WriteLine("• Peek() - O(1) - very fast");
            Console.WriteLine("• Contains() - O(n) - slow (searches all)");
            Console.WriteLine("• Clear() - O(n) - linear time");
            Console.WriteLine();

            Console.WriteLine("🎯 Queue is OPTIMIZED for adding to end and removing from front!");

            Console.WriteLine();

            // ===== BEST PRACTICES =====

            Console.WriteLine("=== BEST PRACTICES ===\n");

            Console.WriteLine("✅ DO:");
            Console.WriteLine("• Use Queue when order matters (FIFO behavior)");
            Console.WriteLine("• Use Peek() before Dequeue() to check if queue is not empty");
            Console.WriteLine("• Use while(queue.Count > 0) to process entire queue");
            Console.WriteLine("• Use for task scheduling, message processing, buffering");

            Console.WriteLine("\n❌ DON'T:");
            Console.WriteLine("• Don't call Dequeue() on empty queue (throws exception)");
            Console.WriteLine("• Don't use Queue if you need random access (use List)");
            Console.WriteLine("• Don't use Queue if you need LIFO (use Stack)");
            Console.WriteLine("• Don't modify queue while iterating with foreach");

            Console.WriteLine();

            // ===== SAFE DEQUEUE PATTERN =====

            Console.WriteLine("=== SAFE DEQUEUE PATTERN ===\n");

            Queue<string> safeQueue = new Queue<string>();
            safeQueue.Enqueue("Item 1");
            safeQueue.Enqueue("Item 2");

            // ❌ UNSAFE - might throw exception if empty
            // string item = safeQueue.Dequeue();

            // ✅ SAFE - check Count first
            if (safeQueue.Count > 0)
            {
                string item = safeQueue.Dequeue();
                Console.WriteLine($"Safely dequeued: {item}");
            }
            else
            {
                Console.WriteLine("Queue is empty!");
            }

            // ✅ SAFE - check with Peek first
            if (safeQueue.Count > 0)
            {
                string next = safeQueue.Peek();
                Console.WriteLine($"Next item: {next}");
            }

            Console.WriteLine();

            // ===== SUMMARY =====

            Console.WriteLine("=== SUMMARY ===\n");

            Console.WriteLine("📋 Queue<T> Features:");
            Console.WriteLine("• FIFO (First In, First Out) behavior");
            Console.WriteLine("• Enqueue(item) - add to end");
            Console.WriteLine("• Dequeue() - remove from front");
            Console.WriteLine("• Peek() - look at front without removing");
            Console.WriteLine("• O(1) performance for add/remove operations");

            Console.WriteLine("\n🎯 When to use Queue:");
            Console.WriteLine("• Customer service lines");
            Console.WriteLine("• Print job management");
            Console.WriteLine("• Task scheduling (first come, first served)");
            Console.WriteLine("• Message/event processing");
            Console.WriteLine("• Breadth-First Search (BFS) algorithm");
            Console.WriteLine("• Buffer management");

            Console.WriteLine("\n🎮 Game Dev Examples:");
            Console.WriteLine("• Queue<Enemy> spawnQueue - enemy spawning order");
            Console.WriteLine("• Queue<string> dialogueQueue - dialogue sequences");
            Console.WriteLine("• Queue<Action> actionQueue - combo system");
            Console.WriteLine("• Queue<NetworkMessage> messageQueue - network packets");
            Console.WriteLine("• Queue<AudioClip> soundQueue - sound playback order");

            Console.WriteLine("\n💡 Key Difference:");
            Console.WriteLine("• Queue: First In, First Out (fair ordering)");
            Console.WriteLine("• Stack (next lesson): Last In, First Out (reverse ordering)");
        }
    }
}