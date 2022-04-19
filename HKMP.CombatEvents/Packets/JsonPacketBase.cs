using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HKMP.CombatEvents.Shared.Payloads;
using Hkmp.Networking.Packet;
using Newtonsoft.Json;

namespace HKMP.CombatEvents.Packets
{
    internal class JsonPacketBase<TPayload>: IPacketData
    {
        public bool IsReliable => true;

        public bool DropReliableDataIfNewerExists => false;

        public TPayload Payload { get; set; }

        public void WriteData(IPacket packet)
        {
            packet.Write(JsonConvert.SerializeObject(Payload));
        }

        public void ReadData(IPacket packet)
        {
            Payload = JsonConvert.DeserializeObject<TPayload>(packet.ReadString());
        }

    }
}
