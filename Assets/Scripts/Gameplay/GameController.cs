using Patterns.Singleton;
using UnityEngine.SceneManagement;

namespace Gameplay
{
    public class GameController : Singleton<GameController>
    {
        private const string GameScene = "Game";
        
        public void Restart()
        {
            SceneManager.LoadScene(GameScene);
        }
    }
}
