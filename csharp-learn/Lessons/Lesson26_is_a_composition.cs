using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_learn.Lessons
{
    // LESSON 26: IS-A Relationship (Inheritance)
    // Learn about inheritance - when one class inherits from another (parent-child relationship)
    internal class Lesson26_is_a_composition
    {
        public static void Run()
        {
            // ===== TOPIC: IS-A RELATIONSHIP (INHERITANCE) =====
            // Inheritance = When one class INHERITS from another class (base/parent class)
            // "IS-A" relationship: Knight IS-A Warrior, Dog IS-A Animal
            // Think: Child class gets all features of parent class + adds its own

            Console.WriteLine("=== IS-A RELATIONSHIP (INHERITANCE) ===\n");

            // ===== WHAT IS INHERITANCE? =====

            Console.WriteLine("=== WHAT IS INHERITANCE? ===\n");

            Console.WriteLine("Inheritance (IS-A) = One class INHERITS from another:");
            Console.WriteLine("• Knight IS-A Warrior");
            Console.WriteLine("• Barbarian IS-A Warrior");
            Console.WriteLine("• Dog IS-A Animal");
            Console.WriteLine("• Car IS-A Vehicle");
            Console.WriteLine();

            Console.WriteLine("Key concepts:");
            Console.WriteLine("• Base/Parent class - provides common features");
            Console.WriteLine("• Derived/Child class - inherits + adds specific features");
            Console.WriteLine("• Use ':' to inherit: class Knight : Warrior");
            Console.WriteLine("• Child gets ALL public/protected members from parent");
            Console.WriteLine("• Avoids code duplication (DRY - Don't Repeat Yourself)");
            Console.WriteLine();

            // ===== INHERITANCE EXAMPLE: WARRIORS =====

            Console.WriteLine("=== WARRIOR INHERITANCE EXAMPLE ===\n");

            // Create warriors with different types
            // Both Knight and Barbarian inherit Health, Armor, Damage from Warrior
            Knight knight = new Knight(100, 10, 15);
            Barbarian barbarian = new Barbarian(120, 5, 20);

            Console.WriteLine("=== Initial Stats ===");
            knight.ShowStats();
            barbarian.ShowStats();
            Console.WriteLine();

            // Use inherited method (from Warrior base class)
            Console.WriteLine("=== Taking Damage ===");
            knight.TakeDamage(20);
            barbarian.TakeDamage(25);
            Console.WriteLine();

            knight.ShowStats();
            barbarian.ShowStats();
            Console.WriteLine();

            // Use class-specific methods
            Console.WriteLine("=== Class-Specific Abilities ===");
            knight.Pray();      // Only Knight has this
            Console.WriteLine("Knight prayed! Armor increased.");

            barbarian.Rage();   // Only Barbarian has this
            Console.WriteLine("Barbarian raged! Damage increased.");
            Console.WriteLine();

            knight.ShowStats();
            barbarian.ShowStats();
            Console.WriteLine();

            // ===== INHERITANCE HIERARCHY =====

            Console.WriteLine("=== INHERITANCE HIERARCHY ===\n");

            Console.WriteLine("Warrior (BASE CLASS)");
            Console.WriteLine("  ├── Knight (inherits from Warrior)");
            Console.WriteLine("  │   └── Has: Health, Armor, Damage, TakeDamage()");
            Console.WriteLine("  │   └── Adds: Pray()");
            Console.WriteLine("  │");
            Console.WriteLine("  └── Barbarian (inherits from Warrior)");
            Console.WriteLine("      └── Has: Health, Armor, Damage, TakeDamage()");
            Console.WriteLine("      └── Adds: Rage()");
            Console.WriteLine();

            // ===== GAME DEV EXAMPLE: ANIMAL HIERARCHY =====

            Console.WriteLine("=== GAME DEV: ANIMAL HIERARCHY ===\n");

            Dog dog = new Dog("Rex", 5);
            Cat cat = new Cat("Whiskers", 3);
            Bird bird = new Bird("Tweety", 1);

            Console.WriteLine("Animals:");
            dog.ShowInfo();
            cat.ShowInfo();
            bird.ShowInfo();
            Console.WriteLine();

            Console.WriteLine("Actions:");
            dog.Eat();      // Inherited from Animal
            dog.Sleep();    // Inherited from Animal
            dog.Bark();     // Specific to Dog
            Console.WriteLine();

            cat.Eat();
            cat.Sleep();
            cat.Meow();     // Specific to Cat
            Console.WriteLine();

            bird.Eat();
            bird.Sleep();
            bird.Fly();     // Specific to Bird
            Console.WriteLine();

            // ===== GAME DEV EXAMPLE: VEHICLE HIERARCHY =====

            Console.WriteLine("=== VEHICLE HIERARCHY ===\n");

            Car car = new Car("Toyota", 4);
            Motorcycle bike = new Motorcycle("Harley", true);
            Truck truck = new Truck("Ford", 5000);

            car.Start();
            car.Drive();
            car.Honk();
            Console.WriteLine();

            bike.Start();
            bike.Drive();
            bike.DoWheelie();
            Console.WriteLine();

            truck.Start();
            truck.Drive();
            truck.LoadCargo(3000);
            Console.WriteLine();

            // ===== BASE KEYWORD =====

            Console.WriteLine("=== BASE KEYWORD ===\n");

            Console.WriteLine("'base' keyword usage:");
            Console.WriteLine("• base(...) - calls parent class constructor");
            Console.WriteLine("• base.Method() - calls parent class method");
            Console.WriteLine();

            Console.WriteLine("Example constructor chain:");
            Console.WriteLine("  class Knight : Warrior");
            Console.WriteLine("  {");
            Console.WriteLine("      public Knight(int h, int a, int d)");
            Console.WriteLine("          : base(h, a, d)  // Calls Warrior constructor");
            Console.WriteLine("      {");
            Console.WriteLine("          // Knight-specific initialization");
            Console.WriteLine("      }");
            Console.WriteLine("  }");
            Console.WriteLine();

            // ===== PROTECTED ACCESS MODIFIER =====

            Console.WriteLine("=== PROTECTED ACCESS MODIFIER ===\n");

            Console.WriteLine("Access modifiers with inheritance:");
            Console.WriteLine("• public    - accessible everywhere (including child classes)");
            Console.WriteLine("• private   - accessible ONLY in the same class (NOT in children)");
            Console.WriteLine("• protected - accessible in class AND child classes");
            Console.WriteLine();

            ProtectedExample example = new ProtectedExample();
            example.ShowData();
            Console.WriteLine();

            // ===== INHERITANCE vs COMPOSITION =====

            Console.WriteLine("=== INHERITANCE vs COMPOSITION ===\n");

            Console.WriteLine("┌────────────────┬─────────────────────┬─────────────────────┐");
            Console.WriteLine("│ Aspect         │ INHERITANCE (IS-A)  │ COMPOSITION (HAS-A) │");
            Console.WriteLine("├────────────────┼─────────────────────┼─────────────────────┤");
            Console.WriteLine("│ Relationship   │ Knight IS-A Warrior │ Car HAS-A Engine    │");
            Console.WriteLine("│ Keyword        │ : (colon)           │ Field/Property      │");
            Console.WriteLine("│ Code reuse     │ Inherit members     │ Delegate to object  │");
            Console.WriteLine("│ Flexibility    │ Fixed at compile    │ Runtime changeable  │");
            Console.WriteLine("│ When to use    │ 'is a' makes sense  │ 'has a' makes sense │");
            Console.WriteLine("└────────────────┴─────────────────────┴─────────────────────┘");
            Console.WriteLine();

            Console.WriteLine("Examples:");
            Console.WriteLine("✅ INHERITANCE: Dog IS-A Animal (use inheritance)");
            Console.WriteLine("✅ COMPOSITION: Car HAS-A Engine (use composition)");
            Console.WriteLine();

            // ===== WHEN TO USE INHERITANCE =====

            Console.WriteLine("=== WHEN TO USE INHERITANCE ===\n");

            Console.WriteLine("✅ Use inheritance when:");
            Console.WriteLine("• Clear IS-A relationship exists");
            Console.WriteLine("• Child class is a SPECIALIZED version of parent");
            Console.WriteLine("• You need to reuse common behavior");
            Console.WriteLine("• Relationship won't change at runtime");
            Console.WriteLine();

            Console.WriteLine("Examples:");
            Console.WriteLine("• Knight IS-A Warrior ✅");
            Console.WriteLine("• Dog IS-A Animal ✅");
            Console.WriteLine("• Circle IS-A Shape ✅");
            Console.WriteLine();

            Console.WriteLine("❌ Don't use inheritance when:");
            Console.WriteLine("• Relationship is HAS-A (use composition)");
            Console.WriteLine("• You just want to reuse code (use composition)");
            Console.WriteLine("• Inheritance hierarchy becomes too deep (3+ levels)");
            Console.WriteLine("• You need multiple inheritance (C# doesn't support it)");
            Console.WriteLine();

            // ===== BEST PRACTICES =====

            Console.WriteLine("=== BEST PRACTICES ===\n");

            Console.WriteLine("✅ DO:");
            Console.WriteLine("• Use inheritance for IS-A relationships");
            Console.WriteLine("• Keep inheritance hierarchy shallow (2-3 levels max)");
            Console.WriteLine("• Make base class methods virtual if they should be overridable");
            Console.WriteLine("• Use 'base' keyword to call parent constructors/methods");
            Console.WriteLine("• Use 'protected' for members accessed by children");
            Console.WriteLine("• Follow Liskov Substitution Principle (child should work where parent works)");

            Console.WriteLine("\n❌ DON'T:");
            Console.WriteLine("• Don't inherit just for code reuse (use composition)");
            Console.WriteLine("• Don't create deep inheritance hierarchies (hard to maintain)");
            Console.WriteLine("• Don't violate IS-A relationship (Square IS-A Rectangle? No!)");
            Console.WriteLine("• Don't forget to call base constructor");
            Console.WriteLine("• Don't make everything public in base class");

            Console.WriteLine();

            // ===== SUMMARY =====

            Console.WriteLine("=== SUMMARY ===\n");

            Console.WriteLine("📋 Key Concepts:");
            Console.WriteLine("• Inheritance = IS-A relationship");
            Console.WriteLine("• Use ':' to inherit: class Child : Parent");
            Console.WriteLine("• Child gets all public/protected members from parent");
            Console.WriteLine("• base keyword calls parent constructor/methods");
            Console.WriteLine("• Avoids code duplication");
            Console.WriteLine("• Creates class hierarchies");

            Console.WriteLine("\n🎯 Real-World Examples:");
            Console.WriteLine("• Animal → Dog, Cat, Bird");
            Console.WriteLine("• Vehicle → Car, Motorcycle, Truck");
            Console.WriteLine("• Shape → Circle, Rectangle, Triangle");
            Console.WriteLine("• Employee → Manager, Engineer, Designer");

            Console.WriteLine("\n🎮 Game Dev Examples:");
            Console.WriteLine("• Warrior → Knight, Barbarian, Paladin");
            Console.WriteLine("• Enemy → Goblin, Dragon, Boss");
            Console.WriteLine("• Weapon → Sword, Bow, Staff");
            Console.WriteLine("• Character → Player, NPC, Monster");

            Console.WriteLine("\n💡 Remember:");
            Console.WriteLine("'Favor composition over inheritance'");
            Console.WriteLine("Use inheritance only when IS-A truly makes sense!");

            Console.WriteLine("\n🔜 Next Topics:");
            Console.WriteLine("• Method overriding (virtual/override)");
            Console.WriteLine("• Polymorphism (using base class reference for child objects)");
            Console.WriteLine("• Abstract classes (cannot be instantiated)");
            Console.WriteLine("• Interfaces (contracts for classes)");
        }

        // ===== NESTED CLASSES =====

        // ===== WARRIOR HIERARCHY =====

        // Base class - common features for all warriors
        class Warrior
        {
            // Fields inherited by all child classes
            public int Health;
            public int Armor;
            public int Damage;

            // Constructor
            public Warrior(int health, int armor, int damage)
            {
                Health = health;
                Armor = armor;
                Damage = damage;
            }

            // Method inherited by all child classes
            public void TakeDamage(int damage)
            {
                int actualDamage = damage - Armor;
                if (actualDamage < 0) actualDamage = 0;

                Health -= actualDamage;
                if (Health < 0) Health = 0;

                Console.WriteLine($"Took {actualDamage} damage! Health: {Health}");
            }

            public void ShowStats()
            {
                Console.WriteLine($"Health: {Health}, Armor: {Armor}, Damage: {Damage}");
            }
        }

        // Child class - inherits from Warrior
        class Knight : Warrior
        {
            // Constructor - calls parent constructor with 'base'
            public Knight(int health, int armor, int damage)
                : base(health, armor, damage)  // Calls Warrior(health, armor, damage)
            {
                // Knight-specific initialization (if needed)
            }

            // Knight-specific method (NOT inherited, unique to Knight)
            public void Pray()
            {
                Armor += 2;
                Console.WriteLine("Knight prayed and increased armor!");
            }

            // Note: Knight automatically has:
            // - Health, Armor, Damage (inherited fields)
            // - TakeDamage() (inherited method)
            // - ShowStats() (inherited method)
        }

        // Another child class - also inherits from Warrior
        class Barbarian : Warrior
        {
            public Barbarian(int health, int armor, int damage)
                : base(health, armor, damage)
            {
            }

            // Barbarian-specific method
            public void Rage()
            {
                Damage += 2;
                Console.WriteLine("Barbarian raged and increased damage!");
            }

            // Note: Barbarian also has all Warrior members
        }

        // ===== ANIMAL HIERARCHY =====

        class Animal
        {
            protected string _name;  // protected = accessible in child classes
            protected int _age;

            public Animal(string name, int age)
            {
                _name = name;
                _age = age;
            }

            public void ShowInfo()
            {
                Console.WriteLine($"  {_name} (Age: {_age})");
            }

            public void Eat()
            {
                Console.WriteLine($"{_name} is eating.");
            }

            public void Sleep()
            {
                Console.WriteLine($"{_name} is sleeping.");
            }
        }

        class Dog : Animal
        {
            public Dog(string name, int age) : base(name, age)
            {
            }

            public void Bark()
            {
                Console.WriteLine($"{_name} says: Woof! Woof!");
            }
        }

        class Cat : Animal
        {
            public Cat(string name, int age) : base(name, age)
            {
            }

            public void Meow()
            {
                Console.WriteLine($"{_name} says: Meow!");
            }
        }

        class Bird : Animal
        {
            public Bird(string name, int age) : base(name, age)
            {
            }

            public void Fly()
            {
                Console.WriteLine($"{_name} is flying!");
            }
        }

        // ===== VEHICLE HIERARCHY =====

        class Vehicle
        {
            protected string _brand;

            public Vehicle(string brand)
            {
                _brand = brand;
            }

            public void Start()
            {
                Console.WriteLine($"{_brand} engine started.");
            }

            public void Drive()
            {
                Console.WriteLine($"{_brand} is driving.");
            }
        }

        class Car : Vehicle
        {
            private int _doors;

            public Car(string brand, int doors) : base(brand)
            {
                _doors = doors;
            }

            public void Honk()
            {
                Console.WriteLine($"{_brand} car: Beep beep! ({_doors} doors)");
            }
        }

        class Motorcycle : Vehicle
        {
            private bool _hasSidecar;

            public Motorcycle(string brand, bool hasSidecar) : base(brand)
            {
                _hasSidecar = hasSidecar;
            }

            public void DoWheelie()
            {
                Console.WriteLine($"{_brand} motorcycle doing a wheelie!");
            }
        }

        class Truck : Vehicle
        {
            private int _cargoCapacity;

            public Truck(string brand, int cargoCapacity) : base(brand)
            {
                _cargoCapacity = cargoCapacity;
            }

            public void LoadCargo(int weight)
            {
                if (weight <= _cargoCapacity)
                {
                    Console.WriteLine($"{_brand} truck loaded {weight}kg cargo (Capacity: {_cargoCapacity}kg)");
                }
                else
                {
                    Console.WriteLine($"Cannot load! Exceeds capacity of {_cargoCapacity}kg");
                }
            }
        }

        // ===== PROTECTED ACCESS MODIFIER EXAMPLE =====

        class BaseClass
        {
            private int _privateData = 10;      // Only accessible in BaseClass
            protected int _protectedData = 20;  // Accessible in BaseClass AND child classes
            public int _publicData = 30;        // Accessible everywhere
        }

        class ProtectedExample : BaseClass
        {
            public void ShowData()
            {
                // Console.WriteLine(_privateData);   // ❌ ERROR! Cannot access private from child
                Console.WriteLine($"Protected data: {_protectedData}"); // ✅ OK! Can access protected
                Console.WriteLine($"Public data: {_publicData}");       // ✅ OK! Can access public
            }
        }
    }
}