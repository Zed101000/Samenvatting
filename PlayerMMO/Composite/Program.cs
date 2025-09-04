using System;
using Composite.CompositePattern;
using GameBase.DefaultClasses;

namespace Composite
{
	class Program
	{
		static void Main(string[] args)
		{
			// Create players and monsters (leaves)
			var player1 = new PlayerPartyMemberAdapter(new BasePlayer("Alice"));
			var player2 = new PlayerPartyMemberAdapter(new BasePlayer("Bob"));
			var monster1 = new MonsterPartyMemberAdapter(new Monster("Goblin", defense: 3, attackPower: 7, health: 30, level: 1));
			var monster2 = new MonsterPartyMemberAdapter(new Monster("Orc", defense: 5, attackPower: 12, health: 50, level: 2));

			// Create party composites
			var party1 = new PartyComposite("Alpha Squad");
			var party2 = new PartyComposite("Monster Mob");

			// Build the composite structure
			party1.AddMember(player1);
			party1.AddMember(player2);
			party2.AddMember(monster1);
			party2.AddMember(monster2);

			var mainParty = new PartyComposite("Alliance");
			mainParty.AddMember(party1);
			mainParty.AddMember(party2);

			// Use the composite
			mainParty.Play();
			mainParty.Attack();
		}
	}
}
