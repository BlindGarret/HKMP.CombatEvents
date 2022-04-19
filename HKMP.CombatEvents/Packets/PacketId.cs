using System;
using Hkmp;

namespace HKMP.CombatEvents.Packets
{
    internal enum PacketId
    {
        PlayerDeath,
        PlayerDamaged,
        PlayerStruckByPlayer
    }

    internal static class PacketIdExtensions {
        public static Type GetPacketType(this PacketId id)
        {
            switch (id)
            {
                case PacketId.PlayerDeath:
                    return typeof(PlayerDeathPacket);
                case PacketId.PlayerDamaged:
                    return typeof(PlayerDamagedPacket);
                case PacketId.PlayerStruckByPlayer:
                    return typeof(PlayerStruckByPlayerPacket);
                default:
                    throw new ArgumentOutOfRangeException(nameof(id), id, null);
            }
        }
    }
}
