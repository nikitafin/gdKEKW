namespace Resources.Script
{
	public enum State { Start, Play }
	public static class GameSate
	{
		public static State CurrentSate { get; set; }

		public static void Init()
		{
			CurrentSate = State.Start;
		}
	}
}