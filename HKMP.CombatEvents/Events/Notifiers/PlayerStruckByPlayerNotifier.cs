using System;
using System.Threading.Tasks;
using HKMP.CombatEvents.Packets;
using HKMP.CombatEvents.Shared.Payloads;
using Hkmp.Concurrency;
using HutongGames.PlayMaker;
using HutongGames.PlayMaker.Actions;
using Modding;
using UnityEngine;

namespace HKMP.CombatEvents.Events.Notifiers
{
    internal class PlayerStruckByPlayerNotifier: EventNotifierBase<PlayerStruckByPlayerPacket>
    {
        // Todo: This is hack but I've been unable to figure out how to unique the events so far so it stays until we manage that.
        private readonly ConcurrentDictionary<ushort, byte> _cooldownTable = new ConcurrentDictionary<ushort, byte>();

        public PlayerStruckByPlayerNotifier() : base(PacketId.PlayerStruckByPlayer)
        {
        }

        protected override void Initialize()
        {
            ModHooks.HitInstanceHook += ModHooksOnHitInstanceHook;
        }

        private HitInstance ModHooksOnHitInstanceHook(Fsm owner, HitInstance hit)
        {
            if (!Api.NetClient.IsConnected)
            {
                return hit;
            }

            Logger.Info(this, $"{owner.ActiveState.ActiveAction.GetType()}");
            if (owner.ActiveState.ActiveAction is TakeDamage takeDamageAction
                && takeDamageAction.Target.RawValue is GameObject targetObject
                && targetObject.name.StartsWith("Player Container")
                && ushort.TryParse(targetObject.name.Substring("Player Container".Length), out var playerId)
                && !_cooldownTable.TryGetValue(playerId, out var _))
            {
                _cooldownTable[playerId] = byte.MinValue;
                Task.Run(async () =>
                {
                    // Half a second cooldown on hit claims
                    await Task.Delay(TimeSpan.FromMilliseconds(500));
                    _cooldownTable.Remove(playerId);
                });

                SendEventPayload(new PlayerStruckByPlayerPacket
                {
                    Payload = new PlayerStruckByPlayer
                    {
                        StrikingPlayerName = Api.ClientManager.Username,
                        PlayerHitId = playerId,
                        Damage = hit.DamageDealt
                    }
                });
            }

            return hit;
        }
    }
}
