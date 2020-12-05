namespace Resources.Script
{
    /// <summary>
    /// Possible game sates
    /// </summary>
    public enum State { Start, Play, Pause }

    /// <summary>
    /// Provide basic state machine
    /// </summary>
    public static class GameSate
    {
        public static State CurrentSate { get; set; }

        public static void Init()
        {
            CurrentSate = State.Start;
        }
    }
}