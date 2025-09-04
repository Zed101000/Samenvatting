using GameBase.DefaultClasses;
using Decorator.ItemsDecorator;
Console.WriteLine("Creating player...");
IPlayer player = new BasePlayer("Hero", 100, 50, 30, 200, 1);

Console.WriteLine($"Player: {player.Name}, Mana: {player.Mana}, Defense: {player.Defense}, Attack: {player.AttackPower}, Health: {player.Health}, Level: {player.Level}");

Console.WriteLine("\nBase player actions:");
player.Play();
player.Attack();
player.Defend();
player.Heal();

Console.WriteLine("\nEquipping shield...");
player = new ShieldDecorator(player);
player.Play();
player.Attack();
player.Defend();
player.Heal();

Console.WriteLine("\nEquipping sword...");
player = new SwordDecorator(player);
player.Play();
player.Attack();
player.Defend();
player.Heal();

Console.WriteLine("\nEquipping staff...");
player = new StaffDecorator(player);
player.Play();
player.Attack();
player.Defend();
player.Heal();

Console.WriteLine("\nUnequipping staff...");
player = player.Unequip();
player.Play();
player.Attack();
player.Defend();
player.Heal();

Console.WriteLine("\nUnequipping sword...");
player = player.Unequip();
player.Play();
player.Attack();
player.Defend();
player.Heal();

Console.WriteLine("\nUnequipping shield...");
player = player.Unequip();
player.Play();
player.Attack();
player.Defend();
player.Heal();