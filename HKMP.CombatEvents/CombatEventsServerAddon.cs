using Hkmp.Api.Server;
using HKMP.CombatEvents.Services;
using HKMP.CombatEvents.Shared.Events;

namespace HKMP.CombatEvents
{
    public class CombatEventsServerAddon : ServerAddon
    {
        public override void Initialize(IServerApi serverApi)
        {
            serverApi.EventAggregator.GetEvent<PlayerDeathEvent>().Subscribe(e =>
            {
                Logger.Info(this, $"EE Event: Player {e.PlayerId}|{e.PlayerName} is dead.");
            });
            serverApi.EventAggregator.GetEvent<PlayerDamagedEvent>().Subscribe(e =>
            {
                Logger.Info(this, $"EE Event: Player {e.PlayerId}|{e.PlayerName} is was damaged. Type: {e.HazardType}, Amount: {e.Amount}");
            });
            serverApi.EventAggregator.GetEvent<PlayerStruckByPlayerEvent>().Subscribe(e =>
            {
                Logger.Info(this,
                    $"EE Event: Player {e.StrikingPlayerId}|{e.StrikingPlayerName} has attacked Player {e.PlayerHitId}|{serverApi.ServerManager.GetPlayer(e.PlayerHitId).Username} for {e.Damage} damage!");
            });
            Logger.Info(this, "Combat events server initializing");
            var eventingService = new ServerListenerService(Logger);
            eventingService.Initialize(this, serverApi);
        }


        /// <inheritdoc />
        protected override string Name => ModInfo.Name;

        /// <inheritdoc />
        protected override string Version => ModInfo.Version;

        /// <inheritdoc />
        public override bool NeedsNetwork => true;
    }
}
