using HKMP.CombatEvents.Packets;
using HKMP.CombatEvents.Shared.Payloads;
using JetBrains.Annotations;
using Modding;

namespace HKMP.CombatEvents.Events.Notifiers
{
    [UsedImplicitly]
    internal class PlayerDeathNotifier : EventNotifierBase<PlayerDeathPacket>
    {
        public PlayerDeathNotifier(): base(PacketId.PlayerDeath)
        {
            
        }

        protected override void Initialize()
        {
            ModHooks.BeforePlayerDeadHook += ModHooksOnBeforePlayerDeadHook;
        }

        private void ModHooksOnBeforePlayerDeadHook()
        {
            if (!Api.NetClient.IsConnected)
            {
                return;
            }
            
            SendEventPayload(new PlayerDeathPacket
            {
                Payload = new PlayerDeath
                {
                    PlayerName = Api.ClientManager.Username
                }
            });
        }
    }
}
