using HKMP.CombatEvents.Packets;
using HKMP.CombatEvents.Shared.Payloads;
using HutongGames.PlayMaker;
using Modding;

namespace HKMP.CombatEvents.Events.Notifiers
{
    internal class PlayerDamagedNotifier : EventNotifierBase<PlayerDamagedPacket>
    {
        public PlayerDamagedNotifier(): base(PacketId.PlayerDamaged)
        {
            
        }

        protected override void Initialize()
        {
            ModHooks.AfterTakeDamageHook += ModHooksOnAfterTakeDamageHook;
        }

        private int ModHooksOnAfterTakeDamageHook(int hazardtype, int damageamount)
        {
            if (!Api.NetClient.IsConnected)
            {
                return damageamount;
            }

            SendEventPayload(new PlayerDamagedPacket
            {
                Payload = new PlayerDamaged
                {
                    PlayerName = Api.ClientManager.Username,
                    HazardType = hazardtype,
                    Amount = damageamount
                }
            });

            return damageamount;
        }
    }
}
