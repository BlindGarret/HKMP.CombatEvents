using Hkmp.Api.Eventing;
using HKMP.CombatEvents.Shared.Payloads;

namespace HKMP.CombatEvents.Shared.Events
{
    public class PlayerDeathEvent: PubSubEvent<PlayerDeath>
    {
    }
}
