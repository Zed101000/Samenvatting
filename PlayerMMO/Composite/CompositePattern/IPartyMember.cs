using System;
using GameBase.DefaultClasses;

namespace Composite.CompositePattern
{
    // Marker interface for composite pattern, can be IPlayer or IMonster
    public interface IPartyMember
    {
        HashSet<IPartyMember> PartyMembers { get; }

        public IPartyMember? Leader { get; set; }
        string PartyName { get; }

        void AddMember(IPartyMember member);
        void RemoveMember(IPartyMember member);

        void DisbandParty();

        void Attack();
        void Play();
    }
}
