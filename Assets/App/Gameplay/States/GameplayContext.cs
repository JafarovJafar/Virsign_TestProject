using Shafir.EventBus;

namespace Virsign
{
    public class GameplayContext
    {
        public SceneLoader SceneLoader;
        public ForkLift ForkLift;
        public ForkLiftKeyboardInputAdapter InputAdapter;
        public LoadingScreen LoadingScreen;
        public GameplayCamera Camera;
        public ShafirEventBus EventBus;

        public PlayerSpawnPoint PlayerSpawnPoint;
        public CubesSpawnPoint CubesSpawnPoint;
        public CubesCollector CubesCollector;
    }
}