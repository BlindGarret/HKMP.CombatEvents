using HKMP.CombatEvents.Packets;
using HKMP.CombatEvents.Shared.Events;

namespace HKMP.CombatEvents.Events.Listeners
{
    internal class PlayerStruckByPlayerListener : EventListenerBase<PlayerStruckByPlayerPacket>
    {
        public PlayerStruckByPlayerListener() : base(PacketId.PlayerStruckByPlayer)
        {
        }

        protected override void Initialize()
        {
        }

        protected override void HandlePacket(ushort playerId, PlayerStruckByPlayerPacket packet)
        {
            var strike = packet.Payload;
            strike.StrikingPlayerId = playerId;
            Api.EventAggregator.GetEvent<PlayerStruckByPlayerEvent>().Publish(strike);
        }
    }
}
