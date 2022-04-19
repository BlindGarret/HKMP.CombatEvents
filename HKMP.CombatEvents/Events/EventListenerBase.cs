using System;
using Hkmp;
using Hkmp.Api.Server;
using Hkmp.Api.Server.Networking;
using HKMP.CombatEvents.Events.Interfaces;
using HKMP.CombatEvents.Packets;
using Hkmp.Networking.Packet;

namespace HKMP.CombatEvents.Events
{
    internal abstract class EventListenerBase<TPacketType> : IEventListener
        where TPacketType : IPacketData
    {
        protected IServerApi Api;
        protected ILogger Logger;
        private readonly PacketId _packetId;

        protected EventListenerBase(PacketId packetId)
        {
            _packetId = packetId;
        }

        public void Setup(IServerAddonNetworkReceiver<PacketId> receiver, IServerApi api, ILogger logger)
        {
            Api = api;
            Logger = logger;
            Initialize();
            receiver.RegisterPacketHandler<TPacketType>(_packetId, HandlePacket);
        }

        protected abstract void Initialize();

        protected abstract void HandlePacket(ushort playerId, TPacketType packet);
    }
}
