using Hkmp.Api.Client;
using Hkmp.Api.Server;
using Modding;

namespace HKMP.CombatEvents
{
    public class CombatEventsHkMod: Mod
    {
        public CombatEventsHkMod() : base(ModInfo.Name)
        {
        }

        public override void Initialize()
        {
            ClientAddon.RegisterAddon(new CombatEventsClientAddon());
            ServerAddon.RegisterAddon(new CombatEventsServerAddon());
            base.Initialize();
        }

        public override string GetVersion()
        {
            return ModInfo.Version;
        }
    }
}
