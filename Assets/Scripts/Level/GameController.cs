using System.Collections.Generic;
using System.Xml;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Level
{
    public class GameController : MonoBehaviour
    {
        [SerializeField] private int _tileSize = 10;
        [SerializeField] private List<GameObject> _tiles;
        [SerializeField] private GameObject _trap;
        [SerializeField] private GameObject _finish;
        [SerializeField] private GameObject _hero;
        
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
                    var tile = Instantiate(_tiles[(int) description.Cell]);
                    tile.transform.position = new Vector3(currentCoordinates.x, 5, currentCoordinates.y);
                    tile.transform.rotation = Quaternion.Euler(0, description.Rotation, 0);
                }
            }

            foreach (var trapCoordinate in generator.TrapCoordinates)
            {
                var currentCoordinates = new Vector2(startPos + (_tileSize*trapCoordinate.x), startPos + (_tileSize*trapCoordinate.y));
                var trap = Instantiate(_trap);
                trap.transform.position = new Vector3(currentCoordinates.x, 0.5f, currentCoordinates.y);
            }
            var exitCoordinate = new Vector2(startPos + (_tileSize*generator.ExitCoordinate.x), startPos + (_tileSize*generator.ExitCoordinate.y));
            var exit = Instantiate(_finish);
            exit.transform.position = new Vector3(exitCoordinate.x, 0.5f, exitCoordinate.y);
            var heroCoordinate = new Vector2(startPos + (_tileSize*generator.HeroCoordinate.x), startPos + (_tileSize*generator.HeroCoordinate.y));
            _hero.transform.position = new Vector3(heroCoordinate.x, 1, heroCoordinate.y);
        }

        public void RestartLevel()
        {
            SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        }
    }
}