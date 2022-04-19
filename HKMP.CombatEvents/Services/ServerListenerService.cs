using System;
using System.Linq;
using Hkmp;
using Hkmp.Api.Server;
using HKMP.CombatEvents.Events.Interfaces;
using HKMP.CombatEvents.Events.Listeners;
using HKMP.CombatEvents.Packets;
using Hkmp.Networking.Packet;

namespace HKMP.CombatEvents.Services
{
    internal class ServerListenerService
    {
        private readonly ILogger _logger;

        public ServerListenerService(ILogger logger)
        {
            _logger = logger;
        }

        public void Initialize(CombatEventsServerAddon addon, IServerApi api)
        {
            var receiver = api.NetServer.GetNetworkReceiver<PacketId>(addon, (t) => (IPacketData)Activator.CreateInstance(t.GetPacketType()));

            // Originally reflected, had to change to static as Server in EXE mode always pitches a fit when I try to reflect the types from ExecutingAssembly.
            var listeners = new IEventListener[]
            {
                new PlayerDamagedListener(),
                new PlayerDeathListener(),
                new PlayerStruckByPlayerListener()
            };

            foreach (var listener in listeners)
            {
                listener.Setup(receiver, api, _logger);
            }
        }
    }
}
