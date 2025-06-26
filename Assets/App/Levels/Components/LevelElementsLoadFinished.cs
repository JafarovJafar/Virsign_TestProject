namespace Virsign
{
    public class LevelElementsLoadFinished
    {
        public readonly PlayerSpawnPoint PlayerSpawnPoint;
        public readonly CubesSpawnPoint CubesSpawnPoint;

        public LevelElementsLoadFinished(PlayerSpawnPoint playerSpawnPoint, CubesSpawnPoint cubesSpawnPoint)
        {
            PlayerSpawnPoint = playerSpawnPoint;
            CubesSpawnPoint = cubesSpawnPoint;
        }
    }
}