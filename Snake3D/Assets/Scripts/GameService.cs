using System.Collections.Generic;
using UnityEngine;

public class GameService : MonoBehaviour
{
    public static GameService Instance { get; private set; }

    public SnakeHead SnakeHead => _snakeHead;

    [SerializeField] private GameConfig _gameConfig;

    [SerializeField] private SnakeHead _snakeHead;

    private List<Rigidbody> _tails = new List<Rigidbody>();

    private List<Vector3> _positions = new List<Vector3>();

    private const int _positionsCount = 100;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        _snakeHead.OnAppleEat += EatApple;

        _tails.Add(_snakeHead.Rigidbody);

        _positions.AddRange(new Vector3[_positionsCount]);

        SpawnApple();
    }

    private void FixedUpdate()
    {
        _positions[0] = _snakeHead.transform.position;

        if (Vector3.Distance(_positions[0], _positions[1]) > _gameConfig.DistanceBetweenTails)
        {
            _positions.Insert(0, _positions[0]);

            _positions.RemoveAt(_positions.Count - 1);
        }

        if (_tails.Count > 1)
        {
            for (int i = 1; i < _tails.Count; i++)
            {
                _tails[i].velocity = (_positions[i - 1] - _tails[i].position) * _gameConfig.TailSpeed;
            }
        }
    }

    private void EatApple(GameObject eatenApple)
    {
        Destroy(eatenApple);

        SpawnTail();

        SpawnApple();
    }

    private void SpawnTail()
    {
        _tails.Add(Instantiate(_gameConfig.TailPrefab, _tails[_tails.Count - 1].position, Quaternion.identity).GetComponent<Rigidbody>());
    }

    private void SpawnApple()
    {
        Instantiate(_gameConfig.ApplePrefab, new Vector3(Random.Range(-2, 2), Random.Range(-2, 2), 0), Quaternion.identity);
    }
}
