using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_learn.Practice
{
    internal class Practice14_HeroFight
    {
        public static void Run()
        {
            Fighter[] fighters =
            {
                new Fighter("Warrior", 100, 20, 5), // array of fighters health, damage, armor
                new Fighter("Mage", 80, 25, 3),
                new Fighter("Rogue", 90, 15, 4),
                new Fighter("Paladin", 110, 18, 6)
            };

            int fighterNumber;

            for (int i = 0; i < fighters.Length; i++)
            {
                Console.Write(i + 1 + " ");
                fighters[i].ShowStats();
            }

            Console.WriteLine("\n** " + new string('-', 25) + " **"); // separator line - 25 dashes
            Console.Write("\nChoose first fighter number: ");
            fighterNumber = Convert.ToInt32(Console.ReadLine()) - 1;
            Fighter firstFighter = fighters[fighterNumber];

            Console.Write("\nChoose second fighter number: ");
            fighterNumber = Convert.ToInt32(Console.ReadLine()) - 1;
            Fighter secondFighter = fighters[fighterNumber];
            Console.WriteLine("\n** " + new string('-', 25) + " **");

            while(firstFighter.Health > 0 && secondFighter.Health > 0)
            {
                firstFighter.TakeDamage(secondFighter.Damage);
                secondFighter.TakeDamage(firstFighter.Damage);
                firstFighter.ShowCurrentHealth();
                secondFighter.ShowCurrentHealth();

                if (firstFighter.Health <= 0)
                {   
                    Console.WriteLine("The winner is: ");
                }
            }
        }

    }

        class Fighter // class Fighter
        {
            private string _name;
            private int _health;
            private int _damage;
            private int _armor;

        public int Health // property to get health return value 
        {
             get { return _health; }
        }

        public int Damage // property to get damage return value
        {
            get { return _damage; }
        }

            public Fighter(string name, int health, int damage, int armor) // method constructor
            {
                _name = name;
                _health = health;
                _damage = damage;
                _armor = armor;
            }

            public void ShowStats() // method to show stats
            {
                Console.WriteLine($"{_name} - Health: {_health}, Damage: {_damage}, Armor: {_armor}");
            }

            public void ShowCurrentHealth() // method to show current health
            {
                Console.WriteLine($"{_name} - Current Health: {_health}");
            }

            public void TakeDamage(int damage)
            {
                _health -= damage - _armor;
            }

        }
    }
