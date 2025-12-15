using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_learn.Lessons
{
    // LESSON 24: Constructors
    // Learn about special methods that initialize objects when created
    internal class Lesson24_MethodConstructor
    {
        public static void Run()
        {
            // ===== TOPIC: CONSTRUCTORS =====
            // Constructor = Special method that runs AUTOMATICALLY when creating an object
            // Purpose: Initialize object fields with valid starting values
            // Think: Constructor is like a "birth certificate" - sets up initial state

            Console.WriteLine("=== CONSTRUCTORS ===\n");

            // ===== WHAT IS A CONSTRUCTOR? =====

            Console.WriteLine("=== WHAT IS A CONSTRUCTOR? ===\n");

            Console.WriteLine("Constructor = Special method for object initialization:");
            Console.WriteLine("• Runs AUTOMATICALLY when you create an object (new keyword)");
            Console.WriteLine("• Same name as the class");
            Console.WriteLine("• NO return type (not even void)");
            Console.WriteLine("• Sets initial values for fields");
            Console.WriteLine("• Ensures object starts in a valid state");
            Console.WriteLine();

            Console.WriteLine("Real-world analogy:");
            Console.WriteLine("• Creating a car: Constructor sets initial fuel, color, mileage");
            Console.WriteLine("• Creating a player: Constructor sets starting health, name, level");
            Console.WriteLine();

            // ===== PROBLEM WITHOUT CONSTRUCTOR =====

            Console.WriteLine("=== PROBLEM: NO CONSTRUCTOR ===\n");

            // Without constructor - manual initialization (tedious!)
            PersonWithoutConstructor person1 = new PersonWithoutConstructor();
            person1.Name = "Alice";  // Must set manually
            person1.Age = 25;        // Must set manually
            person1.IsAlive = true;  // Must set manually

            Console.WriteLine("Manual initialization (tedious):");
            person1.Introduce();
            Console.WriteLine();

            // Easy to forget fields!
            PersonWithoutConstructor person2 = new PersonWithoutConstructor();
            // Forgot to set Name and Age!
            person2.Introduce(); // Will show empty/default values
            Console.WriteLine();

            // ===== SOLUTION: WITH CONSTRUCTOR =====

            Console.WriteLine("=== SOLUTION: WITH CONSTRUCTOR ===\n");

            // With constructor - automatic initialization!
            PersonWithConstructor person3 = new PersonWithConstructor("Bob", 30);
            person3.Introduce(); // Already initialized!
            Console.WriteLine();

            PersonWithConstructor person4 = new PersonWithConstructor("Charlie", 22);
            person4.Introduce(); // Ready to use!
            Console.WriteLine();

            // ===== DEFAULT CONSTRUCTOR =====

            Console.WriteLine("=== DEFAULT CONSTRUCTOR ===\n");

            Console.WriteLine("Default Constructor:");
            Console.WriteLine("• Provided automatically by C# if you don't write any constructor");
            Console.WriteLine("• Takes NO parameters: new ClassName()");
            Console.WriteLine("• Sets fields to default values (0, null, false)");
            Console.WriteLine("• Disappears if you create ANY custom constructor");
            Console.WriteLine();

            // This class has automatic default constructor
            DefaultConstructorExample obj1 = new DefaultConstructorExample();
            obj1.Display();
            Console.WriteLine();

            // ===== PARAMETERIZED CONSTRUCTOR =====

            Console.WriteLine("=== PARAMETERIZED CONSTRUCTOR ===\n");

            // Constructor with parameters - most common!
            Car car1 = new Car("Toyota", "Corolla", 2020);
            car1.DisplayInfo();
            Console.WriteLine();

            Car car2 = new Car("Honda", "Civic", 2021);
            car2.DisplayInfo();
            Console.WriteLine();

            // ===== CONSTRUCTOR OVERLOADING =====

            Console.WriteLine("=== CONSTRUCTOR OVERLOADING ===\n");

            // Multiple constructors with different parameters
            Player player1 = new Player("Warrior");                    // Name only
            Player player2 = new Player("Mage", 80);                   // Name + Health
            Player player3 = new Player("Rogue", 90, 60);              // Name + Health + Mana

            player1.ShowStats();
            Console.WriteLine();
            player2.ShowStats();
            Console.WriteLine();
            player3.ShowStats();
            Console.WriteLine();

            // ===== CONSTRUCTOR CHAINING (this) =====

            Console.WriteLine("=== CONSTRUCTOR CHAINING ===\n");

            // Constructors can call other constructors using 'this'
            Enemy enemy1 = new Enemy("Goblin");                        // Uses default values
            Enemy enemy2 = new Enemy("Orc", 100);                      // Custom health
            Enemy enemy3 = new Enemy("Dragon", 200, 50);               // Full customization

            enemy1.DisplayInfo();
            enemy2.DisplayInfo();
            enemy3.DisplayInfo();
            Console.WriteLine();

            // ===== PRIVATE CONSTRUCTOR =====

            Console.WriteLine("=== PRIVATE CONSTRUCTOR ===\n");

            Console.WriteLine("Private Constructor:");
            Console.WriteLine("• Cannot create objects from outside the class");
            Console.WriteLine("• Used for Singleton pattern (only one instance)");
            Console.WriteLine("• Used for utility classes (all static methods)");
            Console.WriteLine();

            // Cannot create objects - constructor is private
            // Singleton singleton = new Singleton(); // ❌ COMPILE ERROR

            // Access through static method
            Singleton instance1 = Singleton.GetInstance();
            Singleton instance2 = Singleton.GetInstance();

            Console.WriteLine($"Same instance? {instance1 == instance2}"); // True!
            Console.WriteLine();

            // ===== STATIC CONSTRUCTOR =====

            Console.WriteLine("=== STATIC CONSTRUCTOR ===\n");

            Console.WriteLine("Static Constructor:");
            Console.WriteLine("• Runs ONCE when class is first used");
            Console.WriteLine("• Initializes static fields");
            Console.WriteLine("• NO parameters, NO access modifier");
            Console.WriteLine();

            // Static constructor runs automatically before first use
            GameConfig.DisplayConfig();
            GameConfig.DisplayConfig(); // Static constructor won't run again
            Console.WriteLine();

            // ===== GAME DEV EXAMPLE: WEAPON =====

            Console.WriteLine("=== GAME DEV: WEAPON CLASS ===\n");

            Weapon sword = new Weapon("Iron Sword", 25);
            Weapon bow = new Weapon("Wooden Bow", 15);
            Weapon axe = new Weapon("Battle Axe", 35, 80); // Custom durability

            sword.DisplayInfo();
            bow.DisplayInfo();
            axe.DisplayInfo();
            Console.WriteLine();

            // ===== GAME DEV EXAMPLE: INVENTORY ITEM =====

            Console.WriteLine("=== GAME DEV: INVENTORY ITEM ===\n");

            Item potion = new Item("Health Potion", 5);
            Item sword2 = new Item("Steel Sword");        // Quantity defaults to 1
            Item gold = new Item("Gold", 100, 0.1f);      // With price

            potion.DisplayInfo();
            sword2.DisplayInfo();
            gold.DisplayInfo();
            Console.WriteLine();

            // ===== GAME DEV EXAMPLE: QUEST =====

            Console.WriteLine("=== GAME DEV: QUEST CLASS ===\n");

            Quest quest1 = new Quest("Kill 10 Goblins", "Defeat the goblin raiders");
            Quest quest2 = new Quest("Find the Sword", "Locate the legendary blade", 500);

            quest1.DisplayInfo();
            quest2.DisplayInfo();
            Console.WriteLine();

            // ===== VALIDATION IN CONSTRUCTOR =====

            Console.WriteLine("=== CONSTRUCTOR VALIDATION ===\n");

            // Good: Constructor validates input
            try
            {
                ValidatedPlayer validPlayer1 = new ValidatedPlayer("Hero", 100);
                validPlayer1.ShowStats();
                Console.WriteLine();

                // This will throw exception - invalid data!
                ValidatedPlayer invalidPlayer = new ValidatedPlayer("", -50);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Error creating player: {ex.Message}");
            }
            Console.WriteLine();

            // ===== READONLY FIELDS IN CONSTRUCTOR =====

            Console.WriteLine("=== READONLY FIELDS ===\n");

            BankAccount account = new BankAccount("ACC-12345", "Alice");
            account.DisplayInfo();
            Console.WriteLine();

            // account.AccountNumber = "NEW"; // ❌ COMPILE ERROR - readonly!
            Console.WriteLine("Readonly fields can ONLY be set in constructor");
            Console.WriteLine();

            // ===== OBJECT INITIALIZER (ALTERNATIVE) =====

            Console.WriteLine("=== OBJECT INITIALIZER ===\n");

            // Alternative: Object initializer syntax
            SimplePlayer player4 = new SimplePlayer
            {
                Name = "Knight",
                Health = 100,
                Level = 1
            };

            player4.ShowStats();
            Console.WriteLine();

            Console.WriteLine("Object Initializer:");
            Console.WriteLine("• Alternative to constructor");
            Console.WriteLine("• Sets properties after construction");
            Console.WriteLine("• Good for classes with many optional properties");
            Console.WriteLine();

            // ===== COLLECTION INITIALIZATION IN CONSTRUCTOR =====

            Console.WriteLine("=== INITIALIZING COLLECTIONS ===\n");

            Inventory inventory = new Inventory();
            inventory.DisplayItems();
            Console.WriteLine();

            // ===== BEST PRACTICES =====

            Console.WriteLine("=== BEST PRACTICES ===\n");

            Console.WriteLine("✅ DO:");
            Console.WriteLine("• Always initialize fields in constructor");
            Console.WriteLine("• Validate parameters in constructor");
            Console.WriteLine("• Use constructor overloading for flexibility");
            Console.WriteLine("• Use 'this' for constructor chaining (avoid duplication)");
            Console.WriteLine("• Keep constructors simple (just initialization)");
            Console.WriteLine("• Throw exceptions for invalid constructor parameters");
            Console.WriteLine("• Use readonly for fields that shouldn't change");

            Console.WriteLine("\n❌ DON'T:");
            Console.WriteLine("• Don't do complex logic in constructors");
            Console.WriteLine("• Don't call virtual methods in constructors");
            Console.WriteLine("• Don't leave fields uninitialized");
            Console.WriteLine("• Don't create constructors with too many parameters (use builder)");
            Console.WriteLine("• Don't forget to validate input");

            Console.WriteLine();

            // ===== CONSTRUCTOR vs METHOD =====

            Console.WriteLine("=== CONSTRUCTOR vs METHOD ===\n");

            Console.WriteLine("┌─────────────────┬─────────────────┬─────────────────┐");
            Console.WriteLine("│ Feature         │ Constructor     │ Regular Method  │");
            Console.WriteLine("├─────────────────┼─────────────────┼─────────────────┤");
            Console.WriteLine("│ Name            │ Same as class   │ Any name        │");
            Console.WriteLine("│ Return type     │ NO return type  │ Has return type │");
            Console.WriteLine("│ When called     │ At creation     │ Manually        │");
            Console.WriteLine("│ Purpose         │ Initialize      │ Perform action  │");
            Console.WriteLine("│ Call with 'new' │ ✅ Yes          │ ❌ No           │");
            Console.WriteLine("└─────────────────┴─────────────────┴─────────────────┘");

            Console.WriteLine();

            // ===== COMMON PATTERNS =====

            Console.WriteLine("=== COMMON CONSTRUCTOR PATTERNS ===\n");

            Console.WriteLine("Pattern 1: Simple Initialization");
            Console.WriteLine("  public Player(string name, int health)");
            Console.WriteLine("  {");
            Console.WriteLine("      _name = name;");
            Console.WriteLine("      _health = health;");
            Console.WriteLine("  }");
            Console.WriteLine();

            Console.WriteLine("Pattern 2: Constructor Chaining");
            Console.WriteLine("  public Player(string name) : this(name, 100) { }");
            Console.WriteLine("  public Player(string name, int health)");
            Console.WriteLine("  {");
            Console.WriteLine("      _name = name;");
            Console.WriteLine("      _health = health;");
            Console.WriteLine("  }");
            Console.WriteLine();

            Console.WriteLine("Pattern 3: Validation");
            Console.WriteLine("  public Player(string name, int health)");
            Console.WriteLine("  {");
            Console.WriteLine("      if (string.IsNullOrEmpty(name))");
            Console.WriteLine("          throw new ArgumentException();");
            Console.WriteLine("      _name = name;");
            Console.WriteLine("  }");
            Console.WriteLine();

            Console.WriteLine("Pattern 4: Default Values");
            Console.WriteLine("  public Player(string name, int health = 100, int level = 1)");
            Console.WriteLine("  {");
            Console.WriteLine("      _name = name;");
            Console.WriteLine("      _health = health;");
            Console.WriteLine("      _level = level;");
            Console.WriteLine("  }");

            Console.WriteLine();

            // ===== SUMMARY =====

            Console.WriteLine("=== SUMMARY ===\n");

            Console.WriteLine("📋 Key Concepts:");
            Console.WriteLine("• Constructor = special method for initialization");
            Console.WriteLine("• Same name as class, NO return type");
            Console.WriteLine("• Runs automatically when creating object (new)");
            Console.WriteLine("• Can be overloaded (multiple versions)");
            Console.WriteLine("• Can chain constructors with 'this'");
            Console.WriteLine("• Default constructor provided if you don't write any");

            Console.WriteLine("\n🎯 Constructor Types:");
            Console.WriteLine("• Default: ClassName() { } - no parameters");
            Console.WriteLine("• Parameterized: ClassName(int x) { } - with parameters");
            Console.WriteLine("• Private: private ClassName() { } - singleton pattern");
            Console.WriteLine("• Static: static ClassName() { } - class initialization");

            Console.WriteLine("\n🎮 Game Dev Examples:");
            Console.WriteLine("• Player(name, health, level) - initialize player stats");
            Console.WriteLine("• Enemy(type) - create enemy with type-specific values");
            Console.WriteLine("• Weapon(name, damage) - create weapon with properties");
            Console.WriteLine("• Quest(title, description, reward) - initialize quest data");

            Console.WriteLine("\n💡 Why Use Constructors?");
            Console.WriteLine("• Ensure objects start in valid state");
            Console.WriteLine("• Force required data at creation time");
            Console.WriteLine("• Reduce repetitive initialization code");
            Console.WriteLine("• Validate data immediately");
            Console.WriteLine("• Make object creation more readable");

            Console.WriteLine("\n🔜 Next Topics:");
            Console.WriteLine("• Properties (get/set with special syntax)");
            Console.WriteLine("• Auto-properties (shorthand properties)");
            Console.WriteLine("• Destructors (cleanup when object destroyed)");
            Console.WriteLine("• Static classes and members");
        }

        // ===== NESTED CLASSES (All classes defined INSIDE Lesson24_MethodConstructor) =====

        // Without constructor (manual initialization)
        class PersonWithoutConstructor
        {
            public string Name;
            public int Age;
            public bool IsAlive;

            public void Introduce()
            {
                Console.WriteLine($"Name: {Name}, Age: {Age}, Alive: {IsAlive}");
            }
        }

        // With constructor (automatic initialization)
        class PersonWithConstructor
        {
            private string _name;
            private int _age;

            // Constructor - runs when object is created
            public PersonWithConstructor(string name, int age)
            {
                _name = name;
                _age = age;
                Console.WriteLine($"Constructor called! Created person: {_name}");
            }

            public void Introduce()
            {
                Console.WriteLine($"Hi, I'm {_name}, age {_age}");
            }
        }

        // Default constructor (automatic)
        class DefaultConstructorExample
        {
            public int Value;
            public string Text;

            // No constructor written - C# provides default:
            // public DefaultConstructorExample() { }

            public void Display()
            {
                Console.WriteLine($"Value: {Value}, Text: {Text ?? "(null)"}");
            }
        }

        // Parameterized constructor
        class Car
        {
            private string _brand;
            private string _model;
            private int _year;

            // Constructor with parameters
            public Car(string brand, string model, int year)
            {
                _brand = brand;
                _model = model;
                _year = year;
            }

            public void DisplayInfo()
            {
                Console.WriteLine($"Car: {_year} {_brand} {_model}");
            }
        }

        // Constructor overloading
        class Player
        {
            private string _name;
            private int _health;
            private int _mana;

            // Constructor 1: Name only
            public Player(string name)
            {
                _name = name;
                _health = 100;  // Default value
                _mana = 50;     // Default value
            }

            // Constructor 2: Name + Health
            public Player(string name, int health)
            {
                _name = name;
                _health = health;
                _mana = 50;     // Default value
            }

            // Constructor 3: Name + Health + Mana
            public Player(string name, int health, int mana)
            {
                _name = name;
                _health = health;
                _mana = mana;
            }

            public void ShowStats()
            {
                Console.WriteLine($"Player: {_name}, HP: {_health}, Mana: {_mana}");
            }
        }

        // Constructor chaining with 'this'
        class Enemy
        {
            private string _name;
            private int _health;
            private int _damage;

            // Constructor 1: Calls Constructor 2
            public Enemy(string name) : this(name, 50)
            {
                // Calls Constructor 2 with default health
            }

            // Constructor 2: Calls Constructor 3
            public Enemy(string name, int health) : this(name, health, 10)
            {
                // Calls Constructor 3 with default damage
            }

            // Constructor 3: Main constructor with all parameters
            public Enemy(string name, int health, int damage)
            {
                _name = name;
                _health = health;
                _damage = damage;
                Console.WriteLine($"Enemy created: {_name}");
            }

            public void DisplayInfo()
            {
                Console.WriteLine($"Enemy: {_name} (HP: {_health}, Damage: {_damage})");
            }
        }

        // Private constructor (Singleton pattern)
        class Singleton
        {
            private static Singleton _instance;

            // Private constructor - cannot create from outside
            private Singleton()
            {
                Console.WriteLine("Singleton instance created");
            }

            // Public method to get the single instance
            public static Singleton GetInstance()
            {
                if (_instance == null)
                {
                    _instance = new Singleton();
                }
                return _instance;
            }
        }

        // Static constructor
        class GameConfig
        {
            public static string GameName;
            public static string Version;

            // Static constructor - runs once when class is first used
            static GameConfig()
            {
                Console.WriteLine("Static constructor running...");
                GameName = "My Game";
                Version = "1.0.0";
            }

            public static void DisplayConfig()
            {
                Console.WriteLine($"Game: {GameName}, Version: {Version}");
            }
        }

        // Game Dev: Weapon
        class Weapon
        {
            private string _name;
            private int _damage;
            private int _durability;

            // Constructor with default durability
            public Weapon(string name, int damage) : this(name, damage, 100)
            {
            }

            // Main constructor
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
        }

        // Game Dev: Item
        class Item
        {
            private string _name;
            private int _quantity;
            private float _price;

            // Constructor 1: Name only
            public Item(string name) : this(name, 1, 0.0f)
            {
            }

            // Constructor 2: Name + Quantity
            public Item(string name, int quantity) : this(name, quantity, 0.0f)
            {
            }

            // Constructor 3: Full initialization
            public Item(string name, int quantity, float price)
            {
                _name = name;
                _quantity = quantity;
                _price = price;
            }

            public void DisplayInfo()
            {
                Console.WriteLine($"Item: {_name} x{_quantity} (${_price:F2})");
            }
        }

        // Game Dev: Quest
        class Quest
        {
            private string _title;
            private string _description;
            private int _reward;
            private bool _isCompleted;

            // Constructor with default reward
            public Quest(string title, string description) : this(title, description, 100)
            {
            }

            // Main constructor
            public Quest(string title, string description, int reward)
            {
                _title = title;
                _description = description;
                _reward = reward;
                _isCompleted = false;
            }

            public void DisplayInfo()
            {
                Console.WriteLine($"Quest: {_title}");
                Console.WriteLine($"  Description: {_description}");
                Console.WriteLine($"  Reward: {_reward} gold");
                Console.WriteLine($"  Status: {(_isCompleted ? "Completed" : "Active")}");
            }
        }

        // Constructor validation
        class ValidatedPlayer
        {
            private string _name;
            private int _health;

            public ValidatedPlayer(string name, int health)
            {
                // Validate name
                if (string.IsNullOrWhiteSpace(name))
                {
                    throw new ArgumentException("Name cannot be empty!");
                }

                // Validate health
                if (health <= 0)
                {
                    throw new ArgumentException("Health must be positive!");
                }

                _name = name;
                _health = health;
                Console.WriteLine($"✅ Valid player created: {_name}");
            }

            public void ShowStats()
            {
                Console.WriteLine($"Player: {_name}, Health: {_health}");
            }
        }

        // Readonly fields in constructor
        class BankAccount
        {
            private readonly string _accountNumber;  // Can only be set in constructor
            private readonly string _owner;
            private float _balance;

            public BankAccount(string accountNumber, string owner)
            {
                _accountNumber = accountNumber;
                _owner = owner;
                _balance = 0.0f;
            }

            public void DisplayInfo()
            {
                Console.WriteLine($"Account: {_accountNumber}");
                Console.WriteLine($"Owner: {_owner}");
                Console.WriteLine($"Balance: ${_balance:F2}");
            }
        }

        // Object initializer alternative
        class SimplePlayer
        {
            public string Name;
            public int Health;
            public int Level;

            public void ShowStats()
            {
                Console.WriteLine($"Player: {Name}, HP: {Health}, Level: {Level}");
            }
        }

        // Initializing collections in constructor
        class Inventory
        {
            private List<string> _items;
            private int _maxSlots;

            public Inventory()
            {
                // Initialize collection in constructor
                _items = new List<string>();
                _maxSlots = 20;

                // Add some starting items
                _items.Add("Rusty Sword");
                _items.Add("Health Potion");

                Console.WriteLine("Inventory initialized with starting items");
            }

            public void DisplayItems()
            {
                Console.WriteLine("Inventory:");
                foreach (string item in _items)
                {
                    Console.WriteLine($"  - {item}");
                }
            }
        }
    }
}