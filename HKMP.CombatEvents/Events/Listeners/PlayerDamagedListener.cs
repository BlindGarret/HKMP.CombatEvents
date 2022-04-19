using HKMP.CombatEvents.Packets;
using HKMP.CombatEvents.Shared.Events;

namespace HKMP.CombatEvents.Events.Listeners
{
    internal class PlayerDamagedListener : EventListenerBase<PlayerDamagedPacket>
    {
        public PlayerDamagedListener() : base(PacketId.PlayerDamaged)
        {
        }

        protected override void Initialize()
        {
        }

        protected override void HandlePacket(ushort playerId, PlayerDamagedPacket packet)
        {
            var damaged = packet.Payload;
            damaged.PlayerId = playerId;
            Api.EventAggregator.GetEvent<PlayerDamagedEvent>().Publish(damaged);
        }
    }
}
