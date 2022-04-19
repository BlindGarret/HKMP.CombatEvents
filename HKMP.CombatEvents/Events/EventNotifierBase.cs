using Hkmp;
using Hkmp.Api.Client;
using Hkmp.Api.Client.Networking;
using HKMP.CombatEvents.Events.Interfaces;
using HKMP.CombatEvents.Packets;
using Hkmp.Networking.Packet;

namespace HKMP.CombatEvents.Events
{
    internal abstract class EventNotifierBase<TPacketType> : IEventNotifier 
        where TPacketType : IPacketData
    {
        protected IClientAddonNetworkSender<PacketId> NetworkSender;
        protected IClientApi Api;
        protected ILogger Logger;
        private readonly PacketId _packetId;

        protected EventNotifierBase(PacketId packetId)
        {
            _packetId = packetId;
        }

        public void Setup(IClientAddonNetworkSender<PacketId> sender, IClientApi api, ILogger logger)
        {
            Api = api;
            NetworkSender = sender;
            Logger = logger;
            Initialize();
        }

        protected abstract void Initialize();

        protected void SendEventPayload(TPacketType payload)
        {
            NetworkSender.SendSingleData(_packetId, payload);
        }
    }
}
