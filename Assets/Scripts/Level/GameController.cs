using UnityEngine;
using UnityEngine.SceneManagement;

namespace Level
{
    public class GameController : MonoBehaviour
    {
        private void Start()
        {
            var generator = new LevelGenerator();
            var generatedLevel = generator.GenerateLevel(5);
            foreach (var cellType in generatedLevel)
            {
                Debug.Log(cellType);
            }
        }

        public void RestartLevel()
        {
            SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        }
    }
}