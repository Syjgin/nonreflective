using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Level
{
    public class GameController : MonoBehaviour
    {
        [SerializeField] private int _tileSize = 10;
        [SerializeField] private List<GameObject> _tiles;
        
        private void Start()
        {
            var generator = new LevelGenerator();
            generator.GenerateLevel();
            var startPos = 0.5f * _tileSize - (_tileSize * LevelGenerator.Side * 0.5f);
            for (var i = 0; i < LevelGenerator.Side; i++)
            {
                for (var j = 0; j < LevelGenerator.Side; j++)
                {
                    var currentCoordinates = new Vector2(startPos + (_tileSize*i), startPos + (_tileSize*j));
                    var description = generator.GetByCoordinates(i, j);
                    if (description != null)
                    {
                        var tile = Instantiate(_tiles[(int) description.Cell]);
                        tile.transform.position = new Vector3(currentCoordinates.x, 5, currentCoordinates.y);
                        tile.transform.rotation = Quaternion.Euler(0, description.Rotation, 0);   
                    }
                }
            }
        }

        public void RestartLevel()
        {
            SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        }
    }
}