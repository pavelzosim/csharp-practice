using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_learn.Lessons
{
    // LESSON 23: Methods in Classes
    // Learn about class methods, parameters, return values, and method types
    internal class Lesson23_methods
    {
        public static void Run()
        {
            // ===== TOPIC: METHODS IN CLASSES =====
            // Methods = Functions inside classes that define object BEHAVIOR
            // Methods can: take parameters, return values, access class fields
            // Think: Methods are ACTIONS that objects can perform

            Console.WriteLine("=== METHODS IN CLASSES ===\n");

            // ===== WHAT ARE METHODS? =====

            Console.WriteLine("=== WHAT ARE METHODS? ===\n");

            Console.WriteLine("Methods define what an object can DO:");
            Console.WriteLine("• Fields = WHAT an object HAS (data)");
            Console.WriteLine("• Methods = WHAT an object DOES (actions/behavior)");
            Console.WriteLine();

            Console.WriteLine("Real-world analogy (Car):");
            Console.WriteLine("• Fields: color, speed, fuelLevel (properties)");
            Console.WriteLine("• Methods: Start(), Accelerate(), Brake() (actions)");
            Console.WriteLine();

            Console.WriteLine("Method structure:");
            Console.WriteLine("  [access] [return type] MethodName(parameters)");
            Console.WriteLine("  {");
            Console.WriteLine("      // method body");
            Console.WriteLine("      return value; // if return type is not void");
            Console.WriteLine("  }");

            Console.WriteLine();

            // ===== METHOD WITHOUT PARAMETERS OR RETURN =====

            Console.WriteLine("=== VOID METHODS (No Return) ===\n");

            SimplePerson person = new SimplePerson();
            person.Name = "Alice";
            person.Age = 25;

            // Call void methods (no return value)
            person.Introduce();      // Prints greeting
            person.SayGoodbye();     // Prints goodbye

            Console.WriteLine();

            // ===== METHOD WITH PARAMETERS =====

            Console.WriteLine("=== METHODS WITH PARAMETERS ===\n");

            Calculator calc = new Calculator();

            // Methods that take parameters (input)
            calc.PrintSum(10, 20);           // 30
            calc.PrintSum(5, 15);            // 20
            calc.PrintProduct(6, 7);         // 42
            calc.Greet("Bob", "Hello");      // Custom greeting

            Console.WriteLine();

            // ===== METHOD WITH RETURN VALUE =====

            Console.WriteLine("=== METHODS WITH RETURN VALUES ===\n");

            MathOperations math = new MathOperations();

            // Methods that return values
            int sum = math.Add(10, 20);
            int product = math.Multiply(5, 6);
            double average = math.Average(10, 20, 30);

            Console.WriteLine($"Sum: {sum}");
            Console.WriteLine($"Product: {product}");
            Console.WriteLine($"Average: {average:F2}");
            Console.WriteLine();

            // Use return value in expressions
            int result = math.Add(5, 10) * 2;
            Console.WriteLine($"(5 + 10) * 2 = {result}");

            Console.WriteLine();

            // ===== METHOD WITH PARAMETERS AND RETURN =====

            Console.WriteLine("=== METHODS: PARAMETERS + RETURN ===\n");

            StringHelper helper = new StringHelper();

            string reversed = helper.Reverse("Hello");
            Console.WriteLine($"Reversed 'Hello': {reversed}");

            bool isPalindrome = helper.IsPalindrome("racecar");
            Console.WriteLine($"'racecar' is palindrome: {isPalindrome}");

            int wordCount = helper.CountWords("Hello world from C#");
            Console.WriteLine($"Word count: {wordCount}");

            Console.WriteLine();

            // ===== METHODS ACCESSING CLASS FIELDS =====

            Console.WriteLine("=== METHODS ACCESSING FIELDS ===\n");

            Counter counter = new Counter();

            Console.WriteLine($"Initial count: {counter.GetCount()}");

            counter.Increment();
            counter.Increment();
            counter.Increment();

            Console.WriteLine($"After 3 increments: {counter.GetCount()}");

            counter.Decrement();

            Console.WriteLine($"After 1 decrement: {counter.GetCount()}");

            counter.Reset();

            Console.WriteLine($"After reset: {counter.GetCount()}");

            Console.WriteLine();

            // ===== GAME DEV EXAMPLE: PLAYER =====

            Console.WriteLine("=== GAME DEV: PLAYER CLASS ===\n");

            Player player = new Player("Knight", 100, 50);
            player.ShowStats();
            Console.WriteLine();

            // Combat methods
            Console.WriteLine("=== Combat ===");
            player.TakeDamage(20);
            player.UseMana(15);
            player.Heal(10);
            player.RestoreMana(20);
            Console.WriteLine();

            player.ShowStats();
            Console.WriteLine();

            // Check status
            bool alive = player.IsAlive();
            bool canCast = player.CanCastSpell(30);
            Console.WriteLine($"Player alive: {alive}");
            Console.WriteLine($"Can cast 30 mana spell: {canCast}");

            Console.WriteLine();

            // ===== GAME DEV EXAMPLE: ENEMY =====

            Console.WriteLine("=== GAME DEV: ENEMY CLASS ===\n");

            Enemy goblin = new Enemy("Goblin", 50, 10);
            Enemy dragon = new Enemy("Dragon", 200, 35);

            goblin.DisplayInfo();
            dragon.DisplayInfo();
            Console.WriteLine();

            // Enemy actions
            int goblinDmg = goblin.Attack();
            int dragonDmg = dragon.Attack();
            Console.WriteLine($"Goblin deals {goblinDmg} damage");
            Console.WriteLine($"Dragon deals {dragonDmg} damage");
            Console.WriteLine();

            goblin.TakeDamage(30);
            dragon.TakeDamage(50);

            Console.WriteLine();

            // ===== GAME DEV EXAMPLE: WEAPON =====

            Console.WriteLine("=== GAME DEV: WEAPON CLASS ===\n");

            Weapon sword = new Weapon("Iron Sword", 25, 100);
            sword.DisplayInfo();
            Console.WriteLine();

            // Weapon methods
            int damage = sword.GetDamage();
            Console.WriteLine($"Base damage: {damage}");

            // Use weapon multiple times
            for (int i = 0; i < 5; i++)
            {
                if (sword.CanUse())
                {
                    int dmg = sword.Use();
                    Console.WriteLine($"Attack {i + 1}: {dmg} damage, Durability: {sword.GetDurability()}%");
                }
                else
                {
                    Console.WriteLine($"Attack {i + 1}: Weapon broken!");
                }
            }
            Console.WriteLine();

            sword.Repair(50);
            Console.WriteLine($"After repair: {sword.GetDurability()}%");

            Console.WriteLine();

            // ===== GAME DEV EXAMPLE: INVENTORY =====

            Console.WriteLine("=== GAME DEV: INVENTORY CLASS ===\n");

            Inventory inventory = new Inventory(10);

            // Add items
            inventory.AddItem("Health Potion", 5);
            inventory.AddItem("Mana Potion", 3);
            inventory.AddItem("Sword", 1);
            Console.WriteLine();

            inventory.DisplayItems();
            Console.WriteLine();

            // Check and use items
            if (inventory.HasItem("Health Potion"))
            {
                Console.WriteLine("Found Health Potion!");
                inventory.RemoveItem("Health Potion", 2);
            }
            Console.WriteLine();

            int potionCount = inventory.GetItemCount("Health Potion");
            Console.WriteLine($"Remaining Health Potions: {potionCount}");
            Console.WriteLine();

            inventory.DisplayItems();

            Console.WriteLine();

            // ===== METHOD OVERLOADING =====

            Console.WriteLine("=== METHOD OVERLOADING ===\n");

            Printer printer = new Printer();

            // Same method name, different parameters
            printer.Print("Hello");           // string
            printer.Print(42);                // int
            printer.Print(3.14);              // double
            printer.Print("Alice", 25);       // string + int
            printer.Print(10, 20, 30);        // multiple ints

            Console.WriteLine();

            // ===== OPTIONAL PARAMETERS =====

            Console.WriteLine("=== OPTIONAL PARAMETERS ===\n");

            Greeter greeter = new Greeter();

            greeter.Greet("Alice");                    // Uses default greeting
            greeter.Greet("Bob", "Good morning");      // Custom greeting
            greeter.Greet("Charlie", "Hey", 3);        // Custom greeting + times

            Console.WriteLine();

            // ===== EXPRESSION-BODIED METHODS =====

            Console.WriteLine("=== EXPRESSION-BODIED METHODS ===\n");

            MathHelper mathHelper = new MathHelper();

            int squared = mathHelper.Square(5);
            bool isEven = mathHelper.IsEven(10);
            bool isPositive = mathHelper.IsPositive(-5);
            int max = mathHelper.Max(10, 20);

            Console.WriteLine($"5 squared: {squared}");
            Console.WriteLine($"10 is even: {isEven}");
            Console.WriteLine($"-5 is positive: {isPositive}");
            Console.WriteLine($"Max(10, 20): {max}");

            Console.WriteLine();

            // ===== STATIC vs INSTANCE METHODS =====

            Console.WriteLine("=== STATIC vs INSTANCE METHODS ===\n");

            // Static methods - called on CLASS (no object needed)
            int staticSum = MathUtility.Add(10, 20);
            int staticMax = MathUtility.Max(15, 25);
            Console.WriteLine($"Static Add: {staticSum}");
            Console.WriteLine($"Static Max: {staticMax}");
            Console.WriteLine();

            // Instance methods - called on OBJECT
            InstanceExample obj = new InstanceExample();
            obj.SetValue(100);
            int value = obj.GetValue();
            Console.WriteLine($"Instance value: {value}");

            Console.WriteLine();

            // ===== THIS KEYWORD =====

            Console.WriteLine("=== THIS KEYWORD ===\n");

            ThisExample example = new ThisExample("Alice", 25);
            example.DisplayInfo();

            Console.WriteLine();

            // ===== CHAINING METHODS =====

            Console.WriteLine("=== METHOD CHAINING ===\n");

            FluentPlayer fluentPlayer = new FluentPlayer("Warrior");

            // Chain multiple methods together
            fluentPlayer
                .AddHealth(50)
                .AddMana(30)
                .LevelUp()
                .DisplayInfo();

            Console.WriteLine();

            // ===== HELPER METHODS (PRIVATE) =====

            Console.WriteLine("=== PRIVATE HELPER METHODS ===\n");

            ValidatedPlayer validPlayer = new ValidatedPlayer("Mage", 100, 50);
            validPlayer.TakeDamage(20);
            validPlayer.TakeDamage(150); // Overkill damage
            validPlayer.Heal(30);        // Can't heal dead player

            Console.WriteLine();

            // ===== BEST PRACTICES =====

            Console.WriteLine("=== BEST PRACTICES ===\n");

            Console.WriteLine("✅ DO:");
            Console.WriteLine("• Use VERBS for method names (Calculate, Get, Set, Display)");
            Console.WriteLine("• Use PascalCase: CalculateTotal(), GetPlayerName()");
            Console.WriteLine("• Keep methods SHORT and focused (one responsibility)");
            Console.WriteLine("• Validate parameters at the start of method");
            Console.WriteLine("• Return meaningful values");
            Console.WriteLine("• Use private methods for internal helper logic");
            Console.WriteLine("• Document complex methods with comments");

            Console.WriteLine("\n❌ DON'T:");
            Console.WriteLine("• Don't create methods that do too many things");
            Console.WriteLine("• Don't use ambiguous names (DoStuff, Process, Handle)");
            Console.WriteLine("• Don't modify parameters unexpectedly");
            Console.WriteLine("• Don't return null when possible (use bool + out parameter)");
            Console.WriteLine("• Don't make everything public (use private for helpers)");

            Console.WriteLine();

            // ===== METHOD NAMING CONVENTIONS =====

            Console.WriteLine("=== METHOD NAMING CONVENTIONS ===\n");

            Console.WriteLine("Common method prefixes:");
            Console.WriteLine("• Get...()    - Returns a value (GetHealth, GetName)");
            Console.WriteLine("• Set...()    - Sets a value (SetHealth, SetName)");
            Console.WriteLine("• Is...()     - Returns bool (IsAlive, IsValid)");
            Console.WriteLine("• Can...()    - Returns bool (CanMove, CanAttack)");
            Console.WriteLine("• Has...()    - Returns bool (HasItem, HasPermission)");
            Console.WriteLine("• Calculate..() - Performs calculation (CalculateDamage)");
            Console.WriteLine("• Display..()  - Shows information (DisplayStats)");
            Console.WriteLine("• Update...()  - Updates state (UpdatePosition)");
            Console.WriteLine("• Initialize..() - Sets up initial state");

            Console.WriteLine();

            // ===== SUMMARY =====

            Console.WriteLine("=== SUMMARY ===\n");

            Console.WriteLine("📋 Method Types:");
            Console.WriteLine("• void Method() - no parameters, no return");
            Console.WriteLine("• void Method(int x) - with parameters, no return");
            Console.WriteLine("• int Method() - no parameters, returns value");
            Console.WriteLine("• int Method(int x) - with parameters, returns value");

            Console.WriteLine("\n🎯 Method Components:");
            Console.WriteLine("• Access modifier (public, private)");
            Console.WriteLine("• Return type (void, int, string, bool, etc.)");
            Console.WriteLine("• Method name (PascalCase, descriptive verb)");
            Console.WriteLine("• Parameters (input values)");
            Console.WriteLine("• Method body (implementation)");
            Console.WriteLine("• return statement (if not void)");

            Console.WriteLine("\n🎮 Game Dev Examples:");
            Console.WriteLine("• void Attack() - perform attack action");
            Console.WriteLine("• int CalculateDamage() - compute damage value");
            Console.WriteLine("• bool IsAlive() - check player status");
            Console.WriteLine("• void TakeDamage(int amount) - reduce health");
            Console.WriteLine("• Player GetNearestEnemy() - find closest enemy");

            Console.WriteLine("\n💡 Key Concepts:");
            Console.WriteLine("• Methods define object BEHAVIOR (actions)");
            Console.WriteLine("• Fields define object STATE (data)");
            Console.WriteLine("• Methods can access and modify class fields");
            Console.WriteLine("• Use return values to get information from methods");
            Console.WriteLine("• Use parameters to pass information to methods");

            Console.WriteLine("\n🔜 Next Topics:");
            Console.WriteLine("• Constructors (special methods for object creation)");
            Console.WriteLine("• Properties (get/set methods with special syntax)");
            Console.WriteLine("• Method overriding (inheritance)");
            Console.WriteLine("• Delegates and events (method references)");
        }
    }

    // ===== EXAMPLE CLASSES =====

    // Simple void methods (no parameters, no return)
    class SimplePerson
    {
        public string Name;
        public int Age;

        public void Introduce()
        {
            Console.WriteLine($"Hi, I'm {Name} and I'm {Age} years old.");
        }

        public void SayGoodbye()
        {
            Console.WriteLine($"{Name} says: Goodbye!");
        }
    }

    // Methods with parameters (void return)
    class Calculator
    {
        public void PrintSum(int a, int b)
        {
            int sum = a + b;
            Console.WriteLine($"{a} + {b} = {sum}");
        }

        public void PrintProduct(int a, int b)
        {
            int product = a * b;
            Console.WriteLine($"{a} * {b} = {product}");
        }

        public void Greet(string name, string greeting)
        {
            Console.WriteLine($"{greeting}, {name}!");
        }
    }

    // Methods with return values
    class MathOperations
    {
        public int Add(int a, int b)
        {
            return a + b;
        }

        public int Multiply(int a, int b)
        {
            return a * b;
        }

        public double Average(int a, int b, int c)
        {
            return (a + b + c) / 3.0;
        }
    }

    // String manipulation methods
    class StringHelper
    {
        public string Reverse(string text)
        {
            char[] chars = text.ToCharArray();
            Array.Reverse(chars);
            return new string(chars);
        }

        public bool IsPalindrome(string text)
        {
            string reversed = Reverse(text);
            return text.Equals(reversed, StringComparison.OrdinalIgnoreCase);
        }

        public int CountWords(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return 0;

            string[] words = text.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            return words.Length;
        }
    }

    // Methods accessing class fields
    class Counter
    {
        private int _count = 0;

        public void Increment()
        {
            _count++;
        }

        public void Decrement()
        {
            _count--;
        }

        public void Reset()
        {
            _count = 0;
        }

        public int GetCount()
        {
            return _count;
        }
    }

    // Game Dev: Player class
    class Player
    {
        private string _name;
        private int _health;
        private int _maxHealth;
        private int _mana;
        private int _maxMana;

        public Player(string name, int maxHealth, int maxMana)
        {
            _name = name;
            _maxHealth = maxHealth;
            _health = maxHealth;
            _maxMana = maxMana;
            _mana = maxMana;
        }

        public void ShowStats()
        {
            Console.WriteLine($"=== {_name} ===");
            Console.WriteLine($"Health: {_health}/{_maxHealth}");
            Console.WriteLine($"Mana: {_mana}/{_maxMana}");
        }

        public void TakeDamage(int damage)
        {
            _health -= damage;
            if (_health < 0) _health = 0;
            Console.WriteLine($"{_name} took {damage} damage! Health: {_health}/{_maxHealth}");
        }

        public void Heal(int amount)
        {
            _health += amount;
            if (_health > _maxHealth) _health = _maxHealth;
            Console.WriteLine($"{_name} healed {amount} HP! Health: {_health}/{_maxHealth}");
        }

        public void UseMana(int amount)
        {
            _mana -= amount;
            if (_mana < 0) _mana = 0;
            Console.WriteLine($"{_name} used {amount} mana! Mana: {_mana}/{_maxMana}");
        }

        public void RestoreMana(int amount)
        {
            _mana += amount;
            if (_mana > _maxMana) _mana = _maxMana;
            Console.WriteLine($"{_name} restored {amount} mana! Mana: {_mana}/{_maxMana}");
        }

        public bool IsAlive()
        {
            return _health > 0;
        }

        public bool CanCastSpell(int manaCost)
        {
            return _mana >= manaCost;
        }
    }

    // Game Dev: Enemy class
    class Enemy
    {
        private string _name;
        private int _health;
        private int _damage;

        public Enemy(string name, int health, int damage)
        {
            _name = name;
            _health = health;
            _damage = damage;
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"Enemy: {_name} (HP: {_health}, Damage: {_damage})");
        }

        public int Attack()
        {
            Console.WriteLine($"{_name} attacks!");
            return _damage;
        }

        public void TakeDamage(int damage)
        {
            _health -= damage;
            if (_health < 0) _health = 0;
            Console.WriteLine($"{_name} took {damage} damage! Health: {_health}");

            if (_health == 0)
            {
                Console.WriteLine($"💀 {_name} has been defeated!");
            }
        }
    }

    // Game Dev: Weapon class
    class Weapon
    {
        private string _name;
        private int _damage;
        private int _durability;

        public Weapon(string name, int damage, int durability)
        {
            _name = name;
            _damage = damage;
            _durability = durability;
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"Weapon: {_name} (Damage: {_damage}, Durability: {_durability}%)");
        }

        public int GetDamage()
        {
            return _damage;
        }

        public int GetDurability()
        {
            return _durability;
        }

        public bool CanUse()
        {
            return _durability > 0;
        }

        public int Use()
        {
            if (_durability <= 0)
                return 0;

            _durability -= 10;
            if (_durability < 0) _durability = 0;

            return _damage;
        }

        public void Repair(int amount)
        {
            _durability += amount;
            if (_durability > 100) _durability = 100;
        }
    }

    // Game Dev: Inventory class
    class Inventory
    {
        private Dictionary<string, int> _items;
        private int _maxSlots;

        public Inventory(int maxSlots)
        {
            _items = new Dictionary<string, int>();
            _maxSlots = maxSlots;
        }

        public void AddItem(string itemName, int quantity)
        {
            if (_items.Count >= _maxSlots && !_items.ContainsKey(itemName))
            {
                Console.WriteLine("Inventory full!");
                return;
            }

            if (_items.ContainsKey(itemName))
            {
                _items[itemName] += quantity;
            }
            else
            {
                _items[itemName] = quantity;
            }

            Console.WriteLine($"Added {quantity} {itemName}");
        }

        public void RemoveItem(string itemName, int quantity)
        {
            if (!_items.ContainsKey(itemName))
            {
                Console.WriteLine($"{itemName} not found in inventory");
                return;
            }

            _items[itemName] -= quantity;

            if (_items[itemName] <= 0)
            {
                _items.Remove(itemName);
                Console.WriteLine($"{itemName} removed from inventory");
            }
            else
            {
                Console.WriteLine($"Removed {quantity} {itemName}");
            }
        }

        public bool HasItem(string itemName)
        {
            return _items.ContainsKey(itemName);
        }

        public int GetItemCount(string itemName)
        {
            if (_items.TryGetValue(itemName, out int count))
                return count;
            return 0;
        }

        public void DisplayItems()
        {
            Console.WriteLine("=== Inventory ===");
            if (_items.Count == 0)
            {
                Console.WriteLine("(Empty)");
                return;
            }

            foreach (var item in _items)
            {
                Console.WriteLine($"  {item.Key} x{item.Value}");
            }
        }
    }

    // Method overloading example
    class Printer
    {
        public void Print(string text)
        {
            Console.WriteLine($"String: {text}");
        }

        public void Print(int number)
        {
            Console.WriteLine($"Integer: {number}");
        }

        public void Print(double number)
        {
            Console.WriteLine($"Double: {number:F2}");
        }

        public void Print(string name, int age)
        {
            Console.WriteLine($"Name: {name}, Age: {age}");
        }

        public void Print(int a, int b, int c)
        {
            Console.WriteLine($"Three numbers: {a}, {b}, {c}");
        }
    }

    // Optional parameters example
    class Greeter
    {
        public void Greet(string name, string greeting = "Hello", int times = 1)
        {
            for (int i = 0; i < times; i++)
            {
                Console.WriteLine($"{greeting}, {name}!");
            }
        }
    }

    // Expression-bodied methods (C# 6.0+)
    class MathHelper
    {
        // Short methods can use => syntax
        public int Square(int x) => x * x;

        public bool IsEven(int x) => x % 2 == 0;

        public bool IsPositive(int x) => x > 0;

        public int Max(int a, int b) => a > b ? a : b;
    }

    // Static vs Instance methods
    static class MathUtility
    {
        // Static methods - no object needed
        public static int Add(int a, int b)
        {
            return a + b;
        }

        public static int Max(int a, int b)
        {
            return a > b ? a : b;
        }
    }

    class InstanceExample
    {
        private int _value;

        // Instance methods - need object
        public void SetValue(int value)
        {
            _value = value;
        }

        public int GetValue()
        {
            return _value;
        }
    }

    // This keyword example
    class ThisExample
    {
        private string _name;
        private int _age;

        public ThisExample(string name, int age)
        {
            this._name = name;  // this. refers to class field
            this._age = age;
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"Name: {this._name}, Age: {this._age}");
        }
    }

    // Method chaining example
    class FluentPlayer
    {
        private string _name;
        private int _health;
        private int _mana;
        private int _level;

        public FluentPlayer(string name)
        {
            _name = name;
            _health = 100;
            _mana = 50;
            _level = 1;
        }

        public FluentPlayer AddHealth(int amount)
        {
            _health += amount;
            return this; // Return self for chaining
        }

        public FluentPlayer AddMana(int amount)
        {
            _mana += amount;
            return this;
        }

        public FluentPlayer LevelUp()
        {
            _level++;
            return this;
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"{_name}: HP={_health}, Mana={_mana}, Level={_level}");
        }
    }

    // Private helper methods example
    class ValidatedPlayer
    {
        private string _name;
        private int _health;
        private int _maxHealth;
        private int _mana;

        public ValidatedPlayer(string name, int maxHealth, int maxMana)
        {
            _name = name;
            _maxHealth = maxHealth;
            _health = maxHealth;
            _mana = maxMana;
        }

        public void TakeDamage(int damage)
        {
            _health -= damage;
            ClampHealth(); // Private helper method
            CheckDeath();  // Private helper method
        }

        public void Heal(int amount)
        {
            if (!IsAlive())
            {
                Console.WriteLine($"{_name} is dead and cannot be healed!");
                return;
            }

            _health += amount;
            ClampHealth();
            Console.WriteLine($"{_name} healed {amount} HP. Health: {_health}/{_maxHealth}");
        }

        // Private helper methods (internal logic)
        private void ClampHealth()
        {
            if (_health < 0) _health = 0;
            if (_health > _maxHealth) _health = _maxHealth;
        }

        private void CheckDeath()
        {
            if (_health == 0)
            {
                Console.WriteLine($"💀 {_name} has died!");
            }
            else
            {
                Console.WriteLine($"{_name} Health: {_health}/{_maxHealth}");
            }
        }

        private bool IsAlive()
        {
            return _health > 0;
        }
    }
}