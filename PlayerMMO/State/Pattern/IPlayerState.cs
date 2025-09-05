using GameBase.DefaultClasses;

namespace State.Pattern
{
    public interface IPlayerState
    {
        void Attack(PlayerContext context);
        void Defend(PlayerContext context);
        void Heal(PlayerContext context);
        void Play(PlayerContext context);
        void CheckStateTransition(PlayerContext context);
    }
}
