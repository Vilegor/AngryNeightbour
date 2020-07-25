namespace Code.ServerLogic.Data
{
    public enum GameMode
    {
        Elimination = 0,    // the one who defeated all other opponents wins
        TimeLimited = 1,    // game session is limited, the one who got max level last - wins
        FastestHouse = 2    // the one who reaches certain level first wins
    }
}