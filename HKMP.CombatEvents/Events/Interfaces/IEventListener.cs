using Hkmp;
using Hkmp.Api.Server;
using Hkmp.Api.Server.Networking;
using HKMP.CombatEvents.Packets;

namespace HKMP.CombatEvents.Events.Interfaces
{
    internal interface IEventListener
    {
        void Setup(IServerAddonNetworkReceiver<PacketId> receiver, IServerApi api, ILogger logger);
    }
}
