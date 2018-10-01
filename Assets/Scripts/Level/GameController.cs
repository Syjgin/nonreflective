using UnityEngine;
using UnityEngine.SceneManagement;

namespace Level
{
    public class GameController : MonoBehaviour
    {
        public void RestartLevel()
        {
            SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        }
    }
}