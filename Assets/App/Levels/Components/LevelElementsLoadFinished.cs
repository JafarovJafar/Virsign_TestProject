namespace Virsign
{
    public class LevelElementsLoadFinished
    {
        public readonly PlayerSpawnPoint PlayerSpawnPoint;
        public readonly GoalPoint GoalPoint;

        public LevelElementsLoadFinished(PlayerSpawnPoint playerSpawnPoint, GoalPoint goalPoint)
        {
            PlayerSpawnPoint = playerSpawnPoint;
            GoalPoint = goalPoint;
        }
    }
}