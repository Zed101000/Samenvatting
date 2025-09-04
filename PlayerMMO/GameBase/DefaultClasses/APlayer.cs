
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
namespace GameBase.DefaultClasses
{
    public abstract class APlayer : IPlayer
{
    public string Name { get; protected set; }
    public int Health { get; set; }
    public int Mana { get; set; }
    public int AttackPower { get; set; }
    public int Defense { get; set; }
    public int Level { get; set; }

    public APlayer(string name, int health = 100, int mana = 50, int attackPower = 10, int defense = 5, int level = 1)
    {
        Name = name;
        Health = health;
        Mana = mana;
        AttackPower = attackPower;
        Defense = defense;
        Level = level;
    }

    // Leave Play() abstract for subclasses/decorators to implement
    public virtual void Play() { 
        Console.WriteLine(this.ToString());
    }
    public abstract void Attack();
    public abstract void Defend();
    public abstract void Heal();
    public override string ToString()
    {
        return $"{Name} - Health: {Health}, Mana: {Mana}, Attack: {AttackPower}, Defense: {Defense}, Level: {Level}";
    }

    // Correct signature for Unequip
    public virtual IPlayer Unequip()
    {
        Console.WriteLine($"{Name} has nothing to unequip.");
        return this;
    }
}
}
