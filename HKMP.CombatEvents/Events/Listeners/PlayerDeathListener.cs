using HKMP.CombatEvents.Packets;
using HKMP.CombatEvents.Shared.Events;
using JetBrains.Annotations;

namespace HKMP.CombatEvents.Events.Listeners
{
    [UsedImplicitly]
    internal class PlayerDeathListener : EventListenerBase<PlayerDeathPacket>
    {
        public PlayerDeathListener() : base(PacketId.PlayerDeath)
        {
        }

        protected override void Initialize()
        {
        }

        protected override void HandlePacket(ushort playerId, PlayerDeathPacket packet)
        {
            var death = packet.Payload;
            death.PlayerId = playerId;
            Api.EventAggregator.GetEvent<PlayerDeathEvent>().Publish(death);
        }
    }
}