namespace HKMP.CombatEvents.Shared.Payloads
{
    public class PlayerStruckByPlayer
    {
        public ushort StrikingPlayerId { get; set; }
        public string StrikingPlayerName { get; set; }
        public ushort PlayerHitId { get; set; }
        public int Damage { get; set; }
    }
}
