using Hkmp;
using Hkmp.Api.Client;
using Hkmp.Api.Client.Networking;
using HKMP.CombatEvents.Packets;

namespace HKMP.CombatEvents.Events.Interfaces
{
    internal interface IEventNotifier
    {
        void Setup(IClientAddonNetworkSender<PacketId> sender, IClientApi api, ILogger logger);
    }
}
