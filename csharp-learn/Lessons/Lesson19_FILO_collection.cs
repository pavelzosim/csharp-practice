using System;
using System.Collections.Generic;

namespace csharp_learn.Lessons
{
    // LESSON 19: Stack<T> Collection (LIFO/FILO - Last In, First Out)
    // Learn about stack data structure where last added element is first removed
    internal class Lesson19_filo_collection
    {
        public static void Run()
        {
            // ===== TOPIC: STACK COLLECTION (LIFO) =====
            // Stack = Last In, First Out (like a stack of plates)
            // Last plate you put on top is the first plate you take off
            // Think: Undo/Redo, browser back button, call stack in programming

            Console.WriteLine("=== STACK<T> COLLECTION (LIFO) ===\n");

            // ===== WHAT IS LIFO? =====

            Console.WriteLine("=== WHAT IS LIFO/FILO? ===\n");

            Console.WriteLine("LIFO = Last In, First Out (same as FILO - First In, Last Out)");
            Console.WriteLine("Like a stack of plates:");
            Console.WriteLine("1. Put plate A on table (bottom)");
            Console.WriteLine("2. Put plate B on top of A");
            Console.WriteLine("3. Put plate C on top of B (top)");
            Console.WriteLine("Taking order: C → B → A (reverse order!)");
            Console.WriteLine();

            // Visual representation
            Console.WriteLine("Visual stack:");
            Console.WriteLine("  [C] ← Top (removed first)");
            Console.WriteLine("  [B]");
            Console.WriteLine("  [A] ← Bottom (removed last)");
            Console.WriteLine();

            // ===== CREATING STACKS =====

            Console.WriteLine("=== CREATING STACKS ===\n");

            // Create empty stack
            Stack<string> emptyStack = new Stack<string>();
            Console.WriteLine($"Empty stack count: {emptyStack.Count}");

            // Create stack with initial capacity (optimization)
            Stack<int> stackWithCapacity = new Stack<int>(10);
            Console.WriteLine($"Stack with capacity count: {stackWithCapacity.Count}");

            // Create stack from existing collection
            string[] words = { "First", "Second", "Third" };
            Stack<string> wordStack = new Stack<string>(words);
            Console.WriteLine($"Stack from array count: {wordStack.Count}");
            Console.WriteLine($"Top element: {wordStack.Peek()}"); // "Third" is on top!

            Console.WriteLine();

            // ===== PUSH - ADDING TO STACK =====

            Console.WriteLine("=== PUSH (Adding Elements) ===\n");

            Stack<string> books = new Stack<string>();

            Console.WriteLine("Stacking books:");

            // Push = Add to the TOP of stack
            books.Push("Book 1: C# Basics");
            Console.WriteLine("  Pushed: Book 1: C# Basics (bottom)");

            books.Push("Book 2: Advanced C#");
            Console.WriteLine("  Pushed: Book 2: Advanced C# (middle)");

            books.Push("Book 3: Game Dev");
            Console.WriteLine("  Pushed: Book 3: Game Dev (top)");

            Console.WriteLine($"\nTotal books stacked: {books.Count}");
            Console.WriteLine($"Book on top: {books.Peek()}");
            Console.WriteLine();

            // ===== POP - REMOVING FROM STACK =====

            Console.WriteLine("=== POP (Removing Elements) ===\n");

            Console.WriteLine("Taking books from stack (LIFO order):\n");

            // Pop = Remove and return from the TOP of stack
            string firstBook = books.Pop();
            Console.WriteLine($"Took: {firstBook}");
            Console.WriteLine($"Books remaining: {books.Count}");

            string secondBook = books.Pop();
            Console.WriteLine($"Took: {secondBook}");
            Console.WriteLine($"Books remaining: {books.Count}");

            string thirdBook = books.Pop();
            Console.WriteLine($"Took: {thirdBook}");
            Console.WriteLine($"Books remaining: {books.Count}");

            Console.WriteLine();

            // ===== PEEK - LOOK WITHOUT REMOVING =====

            Console.WriteLine("=== PEEK (Look Without Removing) ===\n");

            Stack<string> dishes = new Stack<string>();
            dishes.Push("Plate 1");
            dishes.Push("Plate 2");
            dishes.Push("Plate 3");

            // Peek = Look at top item WITHOUT removing it
            string topDish = dishes.Peek();
            Console.WriteLine($"Top dish: {topDish}");
            Console.WriteLine($"Stack still has {dishes.Count} dishes"); // Still 3!

            // Pop actually removes it
            string takenDish = dishes.Pop();
            Console.WriteLine($"Took: {takenDish}");
            Console.WriteLine($"Stack now has {dishes.Count} dishes"); // Now 2

            Console.WriteLine();

            // ===== CONTAINS - CHECK IF EXISTS =====

            Console.WriteLine("=== CONTAINS (Check Existence) ===\n");

            Stack<int> numbers = new Stack<int>();
            numbers.Push(10);
            numbers.Push(20);
            numbers.Push(30);

            // Check if specific item is in stack
            bool has20 = numbers.Contains(20);
            Console.WriteLine($"Stack contains 20: {has20}");

            bool has100 = numbers.Contains(100);
            Console.WriteLine($"Stack contains 100: {has100}");

            Console.WriteLine();

            // ===== CLEAR - REMOVE ALL =====

            Console.WriteLine("=== CLEAR (Remove All) ===\n");

            Stack<string> cards = new Stack<string>();
            cards.Push("Card 1");
            cards.Push("Card 2");
            cards.Push("Card 3");
            Console.WriteLine($"Stack count before clear: {cards.Count}");

            cards.Clear();
            Console.WriteLine($"Stack count after clear: {cards.Count}");

            Console.WriteLine();

            // ===== ITERATING THROUGH STACK =====

            Console.WriteLine("=== ITERATING THROUGH STACK ===\n");

            Stack<string> actions = new Stack<string>();
            actions.Push("Action 1: Open file");
            actions.Push("Action 2: Edit text");
            actions.Push("Action 3: Save file");

            Console.WriteLine("Actions in stack (top to bottom):");

            // foreach - reads from TOP to BOTTOM, doesn't remove
            foreach (string action in actions)
            {
                Console.WriteLine($"  {action}");
            }

            Console.WriteLine($"\nStack still has {actions.Count} actions (foreach doesn't remove)");

            Console.WriteLine();

            // ===== PROCESSING ENTIRE STACK =====

            Console.WriteLine("=== PROCESSING ENTIRE STACK ===\n");

            Stack<string> notifications = new Stack<string>();
            notifications.Push("Notification 1");
            notifications.Push("Notification 2");
            notifications.Push("Notification 3");

            Console.WriteLine("Processing all notifications (LIFO order):");

            // Process until stack is empty
            while (notifications.Count > 0)
            {
                string notification = notifications.Pop();
                Console.WriteLine($"  Processing: {notification}");
            }

            Console.WriteLine($"All notifications processed. Stack count: {notifications.Count}");

            Console.WriteLine();

            // ===== TOARRAY - CONVERT TO ARRAY =====

            Console.WriteLine("=== TOARRAY (Convert to Array) ===\n");

            Stack<int> scoreStack = new Stack<int>();
            scoreStack.Push(100);
            scoreStack.Push(85);
            scoreStack.Push(92);

            // Convert stack to array (doesn't remove items from stack)
            // Array order: top to bottom
            int[] scoreArray = scoreStack.ToArray();

            Console.WriteLine("Array elements (top to bottom):");
            for (int i = 0; i < scoreArray.Length; i++)
            {
                Console.WriteLine($"  [{i}] = {scoreArray[i]}");
            }

            Console.WriteLine($"Stack still has {scoreStack.Count} items");

            Console.WriteLine();

            // ===== PRACTICAL EXAMPLE: UNDO/REDO SYSTEM =====

            Console.WriteLine("=== PRACTICAL EXAMPLE: UNDO/REDO SYSTEM ===\n");

            Stack<string> undoStack = new Stack<string>();
            Stack<string> redoStack = new Stack<string>();

            // Perform actions
            Console.WriteLine("=== Performing Actions ===");
            PerformAction("Type 'Hello'", undoStack, redoStack);
            PerformAction("Type ' World'", undoStack, redoStack);
            PerformAction("Add exclamation", undoStack, redoStack);

            Console.WriteLine($"Undo stack: {undoStack.Count} actions");
            Console.WriteLine($"Redo stack: {redoStack.Count} actions\n");

            // Undo actions
            Console.WriteLine("=== Undoing Actions ===");
            UndoAction(undoStack, redoStack);
            UndoAction(undoStack, redoStack);

            Console.WriteLine($"Undo stack: {undoStack.Count} actions");
            Console.WriteLine($"Redo stack: {redoStack.Count} actions\n");

            // Redo actions
            Console.WriteLine("=== Redoing Actions ===");
            RedoAction(undoStack, redoStack);

            Console.WriteLine($"Undo stack: {undoStack.Count} actions");
            Console.WriteLine($"Redo stack: {redoStack.Count} actions");

            Console.WriteLine();

            // ===== PRACTICAL EXAMPLE: BROWSER HISTORY =====

            Console.WriteLine("=== PRACTICAL EXAMPLE: BROWSER HISTORY ===\n");

            Stack<string> browserHistory = new Stack<string>();

            Console.WriteLine("Visiting websites:");
            browserHistory.Push("google.com");
            Console.WriteLine("  Navigated to: google.com");

            browserHistory.Push("github.com");
            Console.WriteLine("  Navigated to: github.com");

            browserHistory.Push("stackoverflow.com");
            Console.WriteLine("  Navigated to: stackoverflow.com");

            Console.WriteLine($"\nCurrent page: {browserHistory.Peek()}");
            Console.WriteLine($"History depth: {browserHistory.Count}");

            // Go back
            Console.WriteLine("\nGoing back:");
            string previousPage = browserHistory.Pop();
            Console.WriteLine($"  Left: {previousPage}");
            Console.WriteLine($"  Now on: {browserHistory.Peek()}");

            Console.WriteLine();

            // ===== PRACTICAL EXAMPLE: EXPRESSION EVALUATION =====

            Console.WriteLine("=== PRACTICAL EXAMPLE: PARENTHESES MATCHING ===\n");

            string expression1 = "((a + b) * (c - d))";
            string expression2 = "((a + b) * (c - d)";

            Console.WriteLine($"Expression: {expression1}");
            Console.WriteLine($"Balanced: {IsBalancedParentheses(expression1)}");

            Console.WriteLine($"\nExpression: {expression2}");
            Console.WriteLine($"Balanced: {IsBalancedParentheses(expression2)}");

            Console.WriteLine();

            // ===== GAME DEV EXAMPLES =====

            Console.WriteLine("=== GAME DEV EXAMPLES ===\n");

            // Example 1: Move history (undo moves)
            Stack<string> moveHistory = new Stack<string>();
            moveHistory.Push("Move to (5, 10)");
            moveHistory.Push("Move to (8, 15)");
            moveHistory.Push("Move to (12, 20)");

            Console.WriteLine("Player move history:");
            Console.WriteLine($"Current position: {moveHistory.Peek()}");

            Console.WriteLine("\nUndo last move:");
            string undoneMove = moveHistory.Pop();
            Console.WriteLine($"  Undid: {undoneMove}");
            Console.WriteLine($"  Back to: {moveHistory.Peek()}");

            Console.WriteLine();

            // Example 2: Game state stack (for pausing/returning)
            Stack<string> gameStates = new Stack<string>();
            gameStates.Push("MainMenu");
            gameStates.Push("Gameplay");
            gameStates.Push("PauseMenu");

            Console.WriteLine("Game state stack:");
            Console.WriteLine($"Current state: {gameStates.Peek()}");

            Console.WriteLine("\nResuming game (pop pause menu):");
            string removedState = gameStates.Pop();
            Console.WriteLine($"  Removed: {removedState}");
            Console.WriteLine($"  Current state: {gameStates.Peek()}");

            Console.WriteLine();

            // Example 3: Item pickup history (for dropping in reverse)
            Stack<string> pickupHistory = new Stack<string>();
            pickupHistory.Push("Sword");
            pickupHistory.Push("Shield");
            pickupHistory.Push("Potion");

            Console.WriteLine("Item pickup order:");
            foreach (string item in pickupHistory)
            {
                Console.WriteLine($"  {item}");
            }

            Console.WriteLine("\nDropping last picked item:");
            string droppedItem = pickupHistory.Pop();
            Console.WriteLine($"  Dropped: {droppedItem}");

            Console.WriteLine();

            // ===== STACK vs QUEUE vs LIST =====

            Console.WriteLine("=== STACK vs QUEUE vs LIST ===\n");

            Console.WriteLine("📋 STACK (LIFO - Last In, First Out):");
            Console.WriteLine("  Add: Push(item) → adds to TOP");
            Console.WriteLine("  Remove: Pop() → removes from TOP");
            Console.WriteLine("  Use: Undo/Redo, browser back, call stack, game states");
            Console.WriteLine();

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

            // ===== VISUAL COMPARISON =====

            Console.WriteLine("=== VISUAL COMPARISON ===\n");

            Console.WriteLine("STACK (plates):");
            Console.WriteLine("  Push(3) →  [3] ← Pop() removes this");
            Console.WriteLine("             [2]");
            Console.WriteLine("             [1]");
            Console.WriteLine();

            Console.WriteLine("QUEUE (line):");
            Console.WriteLine("  Enqueue → [1][2][3] → Dequeue removes [1]");
            Console.WriteLine("           FRONT   END");
            Console.WriteLine();

            Console.WriteLine("LIST (array):");
            Console.WriteLine("  [0][1][2][3] ← Access any index");
            Console.WriteLine();

            // ===== PERFORMANCE NOTES =====

            Console.WriteLine("=== PERFORMANCE ===\n");

            Console.WriteLine("⚡ Stack Performance (all O(1) - constant time):");
            Console.WriteLine("• Push() - O(1) - very fast");
            Console.WriteLine("• Pop() - O(1) - very fast");
            Console.WriteLine("• Peek() - O(1) - very fast");
            Console.WriteLine("• Contains() - O(n) - slow (searches all)");
            Console.WriteLine("• Clear() - O(n) - linear time");
            Console.WriteLine();

            Console.WriteLine("🎯 Stack is OPTIMIZED for adding and removing from the same end!");

            Console.WriteLine();

            // ===== BEST PRACTICES =====

            Console.WriteLine("=== BEST PRACTICES ===\n");

            Console.WriteLine("✅ DO:");
            Console.WriteLine("• Use Stack when you need LIFO behavior (reverse order)");
            Console.WriteLine("• Check Count > 0 before Pop() or Peek()");
            Console.WriteLine("• Use for Undo/Redo systems");
            Console.WriteLine("• Use for tracking history (browser, game states)");
            Console.WriteLine("• Use for recursive algorithm simulations");
            Console.WriteLine("• Use for parsing expressions (parentheses matching)");

            Console.WriteLine("\n❌ DON'T:");
            Console.WriteLine("• Don't call Pop() on empty stack (throws exception)");
            Console.WriteLine("• Don't use Stack if you need FIFO (use Queue)");
            Console.WriteLine("• Don't use Stack if you need random access (use List)");
            Console.WriteLine("• Don't modify stack while iterating with foreach");

            Console.WriteLine();

            // ===== SAFE POP PATTERN =====

            Console.WriteLine("=== SAFE POP PATTERN ===\n");

            Stack<string> safeStack = new Stack<string>();
            safeStack.Push("Item 1");
            safeStack.Push("Item 2");

            // ❌ UNSAFE - might throw exception if empty
            // string item = safeStack.Pop();

            // ✅ SAFE - check Count first
            if (safeStack.Count > 0)
            {
                string item = safeStack.Pop();
                Console.WriteLine($"Safely popped: {item}");
            }
            else
            {
                Console.WriteLine("Stack is empty!");
            }

            // ✅ SAFE - check with Peek first
            if (safeStack.Count > 0)
            {
                string top = safeStack.Peek();
                Console.WriteLine($"Top item: {top}");
            }

            Console.WriteLine();

            // ===== ADVANCED EXAMPLE: REVERSE STRING =====

            Console.WriteLine("=== ADVANCED: REVERSE STRING WITH STACK ===\n");

            string original = "Hello";
            string reversed = ReverseString(original);
            Console.WriteLine($"Original: {original}");
            Console.WriteLine($"Reversed: {reversed}");

            Console.WriteLine();

            // ===== SUMMARY =====

            Console.WriteLine("=== SUMMARY ===\n");

            Console.WriteLine("📋 Stack<T> Features:");
            Console.WriteLine("• LIFO (Last In, First Out) behavior");
            Console.WriteLine("• Push(item) - add to top");
            Console.WriteLine("• Pop() - remove from top");
            Console.WriteLine("• Peek() - look at top without removing");
            Console.WriteLine("• O(1) performance for add/remove operations");

            Console.WriteLine("\n🎯 When to use Stack:");
            Console.WriteLine("• Undo/Redo functionality");
            Console.WriteLine("• Browser back/forward navigation");
            Console.WriteLine("• Expression evaluation (calculators)");
            Console.WriteLine("• Parentheses/bracket matching");
            Console.WriteLine("• Depth-First Search (DFS) algorithm");
            Console.WriteLine("• Reversing sequences");
            Console.WriteLine("• Call stack simulation");

            Console.WriteLine("\n🎮 Game Dev Examples:");
            Console.WriteLine("• Stack<GameState> stateStack - pause menus, state management");
            Console.WriteLine("• Stack<Vector3> moveHistory - undo player movements");
            Console.WriteLine("• Stack<Item> pickupOrder - drop items in reverse order");
            Console.WriteLine("• Stack<string> dialogueHistory - backtrack conversations");
            Console.WriteLine("• Stack<Action> commandHistory - replay/undo actions");

            Console.WriteLine("\n💡 Key Differences:");
            Console.WriteLine("• Stack: Last In, First Out (reverse order)");
            Console.WriteLine("• Queue: First In, First Out (fair ordering)");
            Console.WriteLine("• List: Random access (any order)");

            Console.WriteLine("\n🔗 Real-world analogy:");
            Console.WriteLine("Stack of plates: You always take the top plate (last added)");
            Console.WriteLine("Queue at store: First person in line is served first");
        }

        // ===== HELPER METHODS =====

        // Undo/Redo system helpers
        static void PerformAction(string action, Stack<string> undoStack, Stack<string> redoStack)
        {
            Console.WriteLine($"  Performed: {action}");
            undoStack.Push(action);
            redoStack.Clear(); // Clear redo when new action performed
        }

        static void UndoAction(Stack<string> undoStack, Stack<string> redoStack)
        {
            if (undoStack.Count > 0)
            {
                string action = undoStack.Pop();
                redoStack.Push(action);
                Console.WriteLine($"  Undid: {action}");
            }
            else
            {
                Console.WriteLine("  Nothing to undo");
            }
        }

        static void RedoAction(Stack<string> undoStack, Stack<string> redoStack)
        {
            if (redoStack.Count > 0)
            {
                string action = redoStack.Pop();
                undoStack.Push(action);
                Console.WriteLine($"  Redid: {action}");
            }
            else
            {
                Console.WriteLine("  Nothing to redo");
            }
        }

        // Check if parentheses are balanced using stack
        static bool IsBalancedParentheses(string expression)
        {
            Stack<char> stack = new Stack<char>();

            foreach (char c in expression)
            {
                // If opening bracket, push to stack
                if (c == '(' || c == '[' || c == '{')
                {
                    stack.Push(c);
                }
                // If closing bracket, check if matches
                else if (c == ')' || c == ']' || c == '}')
                {
                    if (stack.Count == 0)
                        return false; // No matching opening bracket

                    char opening = stack.Pop();

                    // Check if brackets match
                    if (c == ')' && opening != '(') return false;
                    if (c == ']' && opening != '[') return false;
                    if (c == '}' && opening != '{') return false;
                }
            }

            // Stack should be empty if balanced
            return stack.Count == 0;
        }

        // Reverse string using stack
        static string ReverseString(string input)
        {
            Stack<char> stack = new Stack<char>();

            // Push all characters onto stack
            foreach (char c in input)
            {
                stack.Push(c);
            }

            // Pop characters to build reversed string
            string reversed = "";
            while (stack.Count > 0)
            {
                reversed += stack.Pop();
            }

            return reversed;
        }
    }
}