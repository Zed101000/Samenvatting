using GameBase.DefaultClasses;
using System;

namespace Composite.CompositePattern
{
    public class PlayerPartyMemberAdapter : IPartyMember
    {
        private readonly IPlayer player;

        public PlayerPartyMemberAdapter(IPlayer player)
        {
            this.player = player;
        }

        public HashSet<IPartyMember> PartyMembers => new(); // Leaf: no children
        public IPartyMember? Leader { get; set; }
        public string PartyName => player.Name;

        public void AddMember(IPartyMember member) { /* Leaf: do nothing or throw */ }
        public void RemoveMember(IPartyMember member) { /* Leaf: do nothing or throw */ }
        public void DisbandParty() { /* Leaf: do nothing or throw */ }
        public void Attack() => player.Attack();
        public void Play() => player.Play();
    }
}
