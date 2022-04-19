using System;
using System.Linq;
using Hkmp;
using Hkmp.Api.Client;
using HKMP.CombatEvents.Events;
using HKMP.CombatEvents.Events.Interfaces;
using HKMP.CombatEvents.Events.Notifiers;
using HKMP.CombatEvents.Packets;

namespace HKMP.CombatEvents.Services
{
    internal class ClientEventingService
    {
        private readonly ILogger _logger;

        public ClientEventingService(ILogger logger)
        {
            _logger = logger;
        }

        public void Initialize(CombatEventsClientAddon addon, IClientApi api)
        {
            var sender = api.NetClient.GetNetworkSender<PacketId>(addon);

            var notifiers = new IEventNotifier[]
            {
                new PlayerDamagedNotifier(),
                new PlayerDeathNotifier(),
                new PlayerStruckByPlayerNotifier(),
            };

            foreach (var hkEventNotifier in notifiers)
            {
                hkEventNotifier.Setup(sender, api, _logger);
            }
        }
    }
}
