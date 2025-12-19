using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_learn.Lessons
{
    // LESSON 27: Properties (Get/Set) - Modern Encapsulation
    // Learn about C# properties - better syntax for getters and setters
    internal class Lesson27_incopsulation_get_set_settings
    {
        public static void Run()
        {
            // ===== TOPIC: PROPERTIES (GET/SET) =====
            // Properties = Modern C# way to encapsulate data with get/set accessors
            // Cleaner syntax than GetX()/SetX() methods
            // Think: Properties look like fields but act like methods

            Console.WriteLine("=== PROPERTIES (GET/SET) ===\n");

            // ===== WHAT ARE PROPERTIES? =====

            Console.WriteLine("=== WHAT ARE PROPERTIES? ===\n");

            Console.WriteLine("Properties = Special methods that look like fields:");
            Console.WriteLine("• Combine field + getter + setter in clean syntax");
            Console.WriteLine("• Use 'get' accessor to read value");
            Console.WriteLine("• Use 'set' accessor to write value");
            Console.WriteLine("• Can add validation, computation, or side effects");
            Console.WriteLine("• Standard C# practice (better than Get/Set methods)");
            Console.WriteLine();

            Console.WriteLine("Syntax:");
            Console.WriteLine("  public int Health");
            Console.WriteLine("  {");
            Console.WriteLine("      get { return _health; }");
            Console.WriteLine("      set { _health = value; }  // 'value' = incoming data");
            Console.WriteLine("  }");
            Console.WriteLine();

            // ===== OLD WAY vs NEW WAY =====

            Console.WriteLine("=== OLD WAY vs NEW WAY ===\n");

            Console.WriteLine("❌ OLD WAY (Getter/Setter Methods):");
            Console.WriteLine("  private int _health;");
            Console.WriteLine("  public int GetHealth() { return _health; }");
            Console.WriteLine("  public void SetHealth(int value) { _health = value; }");
            Console.WriteLine("  // Usage: player.SetHealth(100);");
            Console.WriteLine();

            Console.WriteLine("✅ NEW WAY (Properties):");
            Console.WriteLine("  private int _health;");
            Console.WriteLine("  public int Health");
            Console.WriteLine("  {");
            Console.WriteLine("      get { return _health; }");
            Console.WriteLine("      set { _health = value; }");
            Console.WriteLine("  }");
            Console.WriteLine("  // Usage: player.Health = 100;  (looks like field!)");
            Console.WriteLine();

            // ===== BASIC PROPERTY EXAMPLE =====

            Console.WriteLine("=== BASIC PROPERTY EXAMPLE ===\n");

            Person person = new Person();

            // Set value using property (calls 'set' accessor)
            person.Name = "Alice";
            person.Age = 25;

            // Get value using property (calls 'get' accessor)
            Console.WriteLine($"Person: {person.Name}, Age: {person.Age}");
            Console.WriteLine();

            // ===== PROPERTY WITH VALIDATION =====

            Console.WriteLine("=== PROPERTY WITH VALIDATION ===\n");

            Character hero = new Character("Hero");
            hero.ShowStats();
            Console.WriteLine();

            // Valid operations
            hero.Health = 80;   // Setter validates
            hero.Mana = 40;
            Console.WriteLine("After setting Health=80, Mana=40:");
            hero.ShowStats();
            Console.WriteLine();

            // Invalid operations (validation in setter)
            hero.Health = -20;   // Rejected - negative value
            hero.Health = 150;   // Clamped to max (100)
            hero.Mana = -10;     // Rejected
            Console.WriteLine("After invalid operations:");
            hero.ShowStats();
            Console.WriteLine();

            // ===== READ-ONLY PROPERTIES =====

            Console.WriteLine("=== READ-ONLY PROPERTIES ===\n");

            BankAccount account = new BankAccount("Alice", 1000);

            // Can read balance
            Console.WriteLine($"Account owner: {account.Owner}");
            Console.WriteLine($"Balance: ${account.Balance:F2}");
            Console.WriteLine();

            // ❌ Cannot set balance directly (no 'set' accessor)
            // account.Balance = 999999; // COMPILE ERROR!

            // Must use methods to change balance
            account.Deposit(500);
            account.Withdraw(200);
            Console.WriteLine($"New balance: ${account.Balance:F2}");
            Console.WriteLine();

            // ===== AUTO-PROPERTIES =====

            Console.WriteLine("=== AUTO-PROPERTIES (Shorthand) ===\n");

            Console.WriteLine("Auto-Property = Compiler creates backing field automatically:");
            Console.WriteLine("  public string Name { get; set; }");
            Console.WriteLine("  // Compiler creates: private string _name;");
            Console.WriteLine();

            Console.WriteLine("Usage:");
            SimplePlayer player = new SimplePlayer
            {
                Name = "Warrior",
                Level = 5,
                Score = 1000
            };

            Console.WriteLine($"Player: {player.Name}, Level: {player.Level}, Score: {player.Score}");
            Console.WriteLine();

            // ===== PROPERTY TYPES =====

            Console.WriteLine("=== PROPERTY TYPES ===\n");

            PropertyExamples examples = new PropertyExamples();

            // 1. Read-Write Property
            examples.ReadWriteProperty = 100;
            Console.WriteLine($"Read-Write: {examples.ReadWriteProperty}");

            // 2. Read-Only Property (no setter)
            Console.WriteLine($"Read-Only: {examples.ReadOnlyProperty}");
            // examples.ReadOnlyProperty = 50; // ❌ ERROR!

            // 3. Write-Only Property (rare, no getter)
            examples.WriteOnlyProperty = 42;
            // Console.WriteLine(examples.WriteOnlyProperty); // ❌ ERROR!

            // 4. Computed Property (calculated on-the-fly)
            Console.WriteLine($"Computed: {examples.ComputedProperty}");

            Console.WriteLine();

            // ===== GAME DEV EXAMPLE: PLAYER WITH PROPERTIES =====

            Console.WriteLine("=== GAME DEV: PLAYER CLASS ===\n");

            Player gamePlayer = new Player(10, 5);

            Console.WriteLine($"Player position: ({gamePlayer.X}, {gamePlayer.Y})");

            // Properties can have validation
            gamePlayer.X = 15;   // Valid
            gamePlayer.Y = 20;   // Valid
            Console.WriteLine($"New position: ({gamePlayer.X}, {gamePlayer.Y})");

            gamePlayer.X = -5;   // Rejected (validated in setter)
            gamePlayer.Y = 100;  // Rejected
            Console.WriteLine($"After invalid moves: ({gamePlayer.X}, {gamePlayer.Y})");
            Console.WriteLine();

            // ===== GAME DEV EXAMPLE: WEAPON =====

            Console.WriteLine("=== WEAPON WITH PROPERTIES ===\n");

            Weapon sword = new Weapon("Iron Sword", 25, 100);
            sword.ShowInfo();
            Console.WriteLine();

            // Use properties to modify
            sword.Durability -= 20;
            Console.WriteLine($"After use: Durability = {sword.Durability}%");

            sword.Durability = 150;  // Clamped to 100
            Console.WriteLine($"After repair: Durability = {sword.Durability}%");
            Console.WriteLine();

            // ===== GAME DEV EXAMPLE: QUEST =====

            Console.WriteLine("=== QUEST WITH PROPERTIES ===\n");

            Quest quest = new Quest("Defeat Dragon", "Slay the ancient dragon", 1000);

            Console.WriteLine($"Quest: {quest.Title}");
            Console.WriteLine($"Status: {(quest.IsCompleted ? "Completed" : "Active")}");
            Console.WriteLine($"Progress: {quest.Progress}%");
            Console.WriteLine();

            quest.Progress = 50;
            Console.WriteLine($"Progress updated: {quest.Progress}%");

            quest.Progress = 100;
            Console.WriteLine($"Progress: {quest.Progress}%");
            Console.WriteLine($"Completed: {quest.IsCompleted}");
            Console.WriteLine();

            // ===== PROPERTY INITIALIZATION =====

            Console.WriteLine("=== PROPERTY INITIALIZATION ===\n");

            Console.WriteLine("Method 1: Constructor");
            Enemy goblin = new Enemy("Goblin", 50, 10);
            Console.WriteLine($"  {goblin.Name}: HP={goblin.Health}, Damage={goblin.Damage}");
            Console.WriteLine();

            Console.WriteLine("Method 2: Object Initializer");
            Enemy dragon = new Enemy
            {
                Name = "Dragon",
                Health = 200,
                Damage = 50
            };
            Console.WriteLine($"  {dragon.Name}: HP={dragon.Health}, Damage={dragon.Damage}");
            Console.WriteLine();

            Console.WriteLine("Method 3: Default Values");
            Settings settings = new Settings();
            Console.WriteLine($"  SoundEnabled: {settings.SoundEnabled}");
            Console.WriteLine($"  Volume: {settings.Volume}");
            Console.WriteLine();

            // ===== EXPRESSION-BODIED PROPERTIES =====

            Console.WriteLine("=== EXPRESSION-BODIED PROPERTIES ===\n");

            Console.WriteLine("Short syntax for simple properties (C# 6.0+):");
            Console.WriteLine("  public string FullName => $\"{FirstName} {LastName}\";");
            Console.WriteLine();

            ExpressionExample expr = new ExpressionExample("John", "Doe", 30);
            Console.WriteLine($"Full Name: {expr.FullName}");
            Console.WriteLine($"Is Adult: {expr.IsAdult}");
            Console.WriteLine($"Birth Year: {expr.BirthYear}");
            Console.WriteLine();

            // ===== PROPERTY VS FIELD =====

            Console.WriteLine("=== PROPERTY vs FIELD ===\n");

            Console.WriteLine("┌──────────────────┬─────────────────┬─────────────────┐");
            Console.WriteLine("│ Feature          │ FIELD           │ PROPERTY        │");
            Console.WriteLine("├──────────────────┼─────────────────┼─────────────────┤");
            Console.WriteLine("│ Syntax           │ public int X;   │ public int X    │");
            Console.WriteLine("│                  │                 │ { get; set; }   │");
            Console.WriteLine("│ Validation       │ ❌ No           │ ✅ Yes          │");
            Console.WriteLine("│ Computed values  │ ❌ No           │ ✅ Yes          │");
            Console.WriteLine("│ Read-only        │ readonly only   │ { get; }        │");
            Console.WriteLine("│ C# convention    │ ❌ Avoid        │ ✅ Preferred    │");
            Console.WriteLine("└──────────────────┴─────────────────┴─────────────────┘");
            Console.WriteLine();

            // ===== BEST PRACTICES =====

            Console.WriteLine("=== BEST PRACTICES ===\n");

            Console.WriteLine("✅ DO:");
            Console.WriteLine("• Use properties instead of getter/setter methods");
            Console.WriteLine("• Use auto-properties for simple cases");
            Console.WriteLine("• Add validation in property setters");
            Console.WriteLine("• Use PascalCase for property names (Name, Health, MaxHealth)");
            Console.WriteLine("• Make properties read-only when appropriate");
            Console.WriteLine("• Use expression-bodied properties for computed values");
            Console.WriteLine("• Keep property logic simple (avoid complex operations)");

            Console.WriteLine("\n❌ DON'T:");
            Console.WriteLine("• Don't use public fields (use properties instead)");
            Console.WriteLine("• Don't put complex logic in getters (use methods)");
            Console.WriteLine("• Don't have side effects in getters (reading shouldn't change state)");
            Console.WriteLine("• Don't return different values on each get call");
            Console.WriteLine("• Don't throw exceptions in getters (setters are OK)");
            Console.WriteLine("• Don't create write-only properties (rare cases only)");

            Console.WriteLine();

            // ===== SUMMARY =====

            Console.WriteLine("=== SUMMARY ===\n");

            Console.WriteLine("📋 Key Concepts:");
            Console.WriteLine("• Properties = Modern C# encapsulation");
            Console.WriteLine("• get accessor = reading value");
            Console.WriteLine("• set accessor = writing value (uses 'value' keyword)");
            Console.WriteLine("• Auto-properties = compiler creates backing field");
            Console.WriteLine("• Read-only property = only 'get' accessor");
            Console.WriteLine("• Computed property = calculated value (no backing field)");

            Console.WriteLine("\n🎯 Property Types:");
            Console.WriteLine("• Full property: private field + public get/set");
            Console.WriteLine("• Auto-property: public Type Name { get; set; }");
            Console.WriteLine("• Read-only: public Type Name { get; }");
            Console.WriteLine("• Computed: public Type Name => expression;");

            Console.WriteLine("\n🎮 Game Dev Examples:");
            Console.WriteLine("• public int Health { get; set; } - character stats");
            Console.WriteLine("• public bool IsAlive => Health > 0; - computed status");
            Console.WriteLine("• public float Balance { get; } - read-only bank balance");
            Console.WriteLine("• public string Name { get; set; } = \"Player\"; - default value");

            Console.WriteLine("\n💡 Remember:");
            Console.WriteLine("Properties = Fields that can have logic!");
            Console.WriteLine("Use properties for public interface, fields for internal data.");

            Console.WriteLine("\n🔜 Next Topics:");
            Console.WriteLine("• Init-only properties (C# 9.0)");
            Console.WriteLine("• Required properties (C# 11.0)");
            Console.WriteLine("• Indexers (array-like properties)");
            Console.WriteLine("• Property patterns (pattern matching)");
        }

        // ===== NESTED CLASSES =====

        // Basic property example
        class Person
        {
            // Private backing fields (store actual data)
            private string _name;
            private int _age;

            // Public properties (controlled access)
            public string Name
            {
                get { return _name; }
                set { _name = value; }  // 'value' = incoming data
            }

            public int Age
            {
                get { return _age; }
                set { _age = value; }
            }
        }

        // Property with validation
        class Character
        {
            private string _name;
            private int _health;
            private int _maxHealth = 100;
            private int _mana;
            private int _maxMana = 50;

            public Character(string name)
            {
                _name = name;
                _health = _maxHealth;
                _mana = _maxMana;
            }

            // Property with validation in setter
            public int Health
            {
                get { return _health; }
                set
                {
                    if (value < 0)
                    {
                        Console.WriteLine("❌ Health cannot be negative!");
                        return;
                    }
                    if (value > _maxHealth)
                    {
                        Console.WriteLine($"⚠️ Health clamped to max ({_maxHealth})");
                        _health = _maxHealth;
                    }
                    else
                    {
                        _health = value;
                    }
                }
            }

            public int Mana
            {
                get { return _mana; }
                set
                {
                    if (value < 0)
                    {
                        Console.WriteLine("❌ Mana cannot be negative!");
                        return;
                    }
                    if (value > _maxMana)
                    {
                        _mana = _maxMana;
                    }
                    else
                    {
                        _mana = value;
                    }
                }
            }

            public void ShowStats()
            {
                Console.WriteLine($"{_name}: Health={_health}/{_maxHealth}, Mana={_mana}/{_maxMana}");
            }
        }

        // Read-only property example
        class BankAccount
        {
            private string _owner;
            private float _balance;

            public BankAccount(string owner, float initialBalance)
            {
                _owner = owner;
                _balance = initialBalance;
            }

            // Read-only properties (no 'set' accessor)
            public string Owner
            {
                get { return _owner; }
            }

            public float Balance
            {
                get { return _balance; }
                // No setter - can only change through Deposit/Withdraw methods
            }

            public void Deposit(float amount)
            {
                _balance += amount;
                Console.WriteLine($"Deposited ${amount:F2}");
            }

            public void Withdraw(float amount)
            {
                if (amount <= _balance)
                {
                    _balance -= amount;
                    Console.WriteLine($"Withdrew ${amount:F2}");
                }
                else
                {
                    Console.WriteLine("Insufficient funds!");
                }
            }
        }

        // Auto-properties (shorthand syntax)
        class SimplePlayer
        {
            // Compiler creates backing fields automatically
            public string Name { get; set; }
            public int Level { get; set; }
            public int Score { get; set; }
        }

        // Different property types
        class PropertyExamples
        {
            private int _internalValue = 50;

            // 1. Read-Write Property
            public int ReadWriteProperty { get; set; }

            // 2. Read-Only Property
            public int ReadOnlyProperty
            {
                get { return _internalValue; }
                // No setter
            }

            // 3. Write-Only Property (rare)
            public int WriteOnlyProperty
            {
                // No getter
                set { _internalValue = value; }
            }

            // 4. Computed Property (calculated value)
            public int ComputedProperty
            {
                get { return _internalValue * 2; }
                // No setter, no backing field
            }
        }

        // Player with validated properties
        class Player
        {
            private int _x;
            private int _y;
            private const int MIN = 0;
            private const int MAX = 50;

            public Player(int x, int y)
            {
                _x = x;
                _y = y;
            }

            public int X
            {
                get { return _x; }
                set
                {
                    if (value < MIN || value > MAX)
                    {
                        Console.WriteLine($"❌ X={value} out of bounds ({MIN}-{MAX})");
                        return;
                    }
                    _x = value;
                }
            }

            public int Y
            {
                get { return _y; }
                set
                {
                    if (value < MIN || value > MAX)
                    {
                        Console.WriteLine($"❌ Y={value} out of bounds ({MIN}-{MAX})");
                        return;
                    }
                    _y = value;
                }
            }
        }

        // Renderer (unchanged)
        class Renderer
        {
            public void Draw(int x, int y, char character = '@')
            {
                Console.CursorVisible = false;
                Console.SetCursorPosition(x, y);
                Console.Write(character);
                Console.ReadKey(true);
            }
        }

        // Weapon with properties
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

            public string Name
            {
                get { return _name; }
            }

            public int Damage
            {
                get { return _damage; }
                set { _damage = value; }
            }

            public int Durability
            {
                get { return _durability; }
                set
                {
                    if (value < 0) value = 0;
                    if (value > 100) value = 100;
                    _durability = value;
                }
            }

            public void ShowInfo()
            {
                Console.WriteLine($"Weapon: {_name} (Damage: {_damage}, Durability: {_durability}%)");
            }
        }

        // Quest with properties
        class Quest
        {
            private string _title;
            private string _description;
            private int _reward;
            private int _progress;

            public Quest(string title, string description, int reward)
            {
                _title = title;
                _description = description;
                _reward = reward;
                _progress = 0;
            }

            public string Title
            {
                get { return _title; }
            }

            public int Progress
            {
                get { return _progress; }
                set
                {
                    if (value < 0) value = 0;
                    if (value > 100) value = 100;
                    _progress = value;
                }
            }

            // Computed property
            public bool IsCompleted
            {
                get { return _progress >= 100; }
            }
        }

        // Enemy with object initializer support
        class Enemy
        {
            public string Name { get; set; }
            public int Health { get; set; }
            public int Damage { get; set; }

            public Enemy() { }

            public Enemy(string name, int health, int damage)
            {
                Name = name;
                Health = health;
                Damage = damage;
            }
        }

        // Settings with default values
        class Settings
        {
            public bool SoundEnabled { get; set; } = true;   // Default value
            public int Volume { get; set; } = 50;
            public bool FullScreen { get; set; } = false;
        }

        // Expression-bodied properties (C# 6.0+)
        class ExpressionExample
        {
            private string _firstName;
            private string _lastName;
            private int _age;

            public ExpressionExample(string firstName, string lastName, int age)
            {
                _firstName = firstName;
                _lastName = lastName;
                _age = age;
            }

            // Expression-bodied property (read-only, computed)
            public string FullName => $"{_firstName} {_lastName}";

            public bool IsAdult => _age >= 18;

            public int BirthYear => DateTime.Now.Year - _age;
        }
    }
}