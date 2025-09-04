using Adapter.AdapterPattern;
using GameBase.DefaultClasses;
using Decorator.ItemsDecorator; // This brings SwordDecorator into scope
using System;

class Program
{
    static void Main(string[] args)
    {
        // Create a Monster
        Monster monster = new Monster("Goblin", 100, 10, 20, 1);

        // Adapt Monster to Player
        IPlayer monsterPlayer = new MonsterToPlayerAdapter(monster);

        Console.WriteLine($"Monster as Player: {monsterPlayer.Name}");
        Console.WriteLine($"Health: {monsterPlayer.Health}, Mana: {monsterPlayer.Mana}");

        // Decorate the player with a sword
        monsterPlayer = new SwordDecorator(monsterPlayer);

        Console.WriteLine("After equipping sword:");
        Console.WriteLine($"Attack Power: {monsterPlayer.AttackPower}");

        // Perform player actions
        monsterPlayer.Attack();
        monsterPlayer.Defend();
        monsterPlayer.Heal(); // Should show monster cannot heal

        // Demonstrate Unequip logic
        for (int i = 0; i < 5; i++)
        {
            monsterPlayer = monsterPlayer.Unequip();
            Console.WriteLine($"Attack Power after unequip: {monsterPlayer.AttackPower}");
        }

        Console.WriteLine("Adapter demo complete.");
    }
}
