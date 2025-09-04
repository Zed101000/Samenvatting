using GameBase.DefaultClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite.CompositePattern
{
    public class PartyComposite : IPartyMember
    {
        private readonly HashSet<IPartyMember> members = new HashSet<IPartyMember>();

        public HashSet<IPartyMember> PartyMembers => members;
        public IPartyMember? Leader { get; set; }
        public string PartyName { get; private set; }

        public PartyComposite(string name, IPartyMember? leader = null)
        {
            if (string.IsNullOrWhiteSpace(name) && leader == null)
                throw new ArgumentException("A party must have a name if there is no leader.");
            PartyName = !string.IsNullOrWhiteSpace(name) ? name : leader?.PartyName ?? "Unnamed Party";
            Leader = leader;
        }

        public void AddMember(IPartyMember member)
        {
            members.Add(member);
        }

        public void RemoveMember(IPartyMember member)
        {
            members.Remove(member);
        }

        public void DisbandParty()
        {
            members.Clear();
            Console.WriteLine($"Party {PartyName} has been disbanded.");
        }

        public void Attack()
        {
            Console.WriteLine($"Party {PartyName} attacks!");
            foreach (var member in members)
                member.Attack();
        }

        public void Play()
        {
            Console.WriteLine($"Party {PartyName} is playing:");
            foreach (var member in members)
                member.Play();
        }
    }
}
