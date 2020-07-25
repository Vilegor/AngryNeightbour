namespace Code.ServerLogic.Data
{
    public struct GameActionCooldownDTO
    {
        public int total { get; }
        public int left { get; }
        public int lastPerfomedActionTs { get; }
    }
}