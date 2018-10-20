using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Level
{
    public class GameController : MonoBehaviour
    {
        [SerializeField] private int _size = 10;
        [SerializeField] private int _tileSize = 10;
        [SerializeField] private List<GameObject> _tiles;
        
        private void Start()
        {
            var generator = new LevelGenerator();
            generator.GenerateLevel();
            /*var startPos = 0.5f * _tileSize - (_tileSize * _size * 0.5f);
            for (var i = 0; i < _size; i++)
            {
                for (var j = 0; j < _size; j++)
                {
                    var currentCoordinates = new Vector2(startPos + (_tileSize*i), startPos + (_tileSize*j));
                    var tile = Instantiate(_tiles[(int) generator.GetByCoordinates(i, j)]);
                    tile.transform.position = new Vector3(currentCoordinates.x, 1, currentCoordinates.y);
                }
            }*/
        }

        public void RestartLevel()
        {
            SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        }
    }
}