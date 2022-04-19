using Hkmp.Api.Client;
using HKMP.CombatEvents.Services;

namespace HKMP.CombatEvents
{
    public class CombatEventsClientAddon : ClientAddon
    {
        public override void Initialize(IClientApi clientApi)
        {
            Logger.Info(this, "Combat events client initializing");
            var eventingService = new ClientEventingService(Logger);
            eventingService.Initialize(this, clientApi);
        }

        /// <inheritdoc />
        protected override string Name => ModInfo.Name;

        /// <inheritdoc />
        protected override string Version => ModInfo.Version;

        /// <inheritdoc />
        public override bool NeedsNetwork => true;
    }
}
