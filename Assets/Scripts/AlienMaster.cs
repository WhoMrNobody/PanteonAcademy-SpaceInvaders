using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienMaster : MonoBehaviour
{
    [SerializeField] ObjectPooling _pooling = null;
    [SerializeField] ObjectPooling _motherShipObjectPool = null;
    [SerializeField] GameObject _bulletPrefab;
    [SerializeField] GameObject _motherShipPrefab;

    Vector3 _hMoveDistance = new Vector3(0.08f, 0, 0);
    Vector3 _vMoveDistance = new Vector3(0, 0.40f, 0);
    Vector3 _motherShipSpawnPos = new Vector3(6f, 5.7f, 0);

    //const float MAX_LEFT = -2.8f;
    //const float MAX_RIGHT = 2.8f;
    const float MAX_MOVE_SPEED = 0.0001f;

    public static List<GameObject> _allAliens = new List<GameObject>();

    bool _movingRight;
    float _moveTimer = 0.01f;
    float _moveTime = 0.05f;
    float _width;
    float _shootTimer = 3f;
    const float ShootTime = 3f;

    const float MOTHERSHIP_MIN = 15f;
    const float MOTHERSHIP_MAX = 60f;
    const float START_Y = 1.7f;
    float _motherShipTimer = 30f;
    bool _entering = true;

    Player _player;

    void Awake()
    {
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }
    void Start()
    {
        _width = _player.width - 0.15f;

        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Alien"))
        {
            _allAliens.Add(obj);
        }
    }

    
    void Update()
    {   
        if(_entering)
        {
            transform.Translate(Vector2.down * Time.deltaTime * 10);

            if(transform.position.y <= START_Y)
            {
                _entering = false;
            }

        }
        else
        {
            if (_moveTimer <= 0)
            {
                MoveEnemies();
            }

            if (_shootTimer <= 0)
            {
                Shoot();
            }

            if (_motherShipTimer <= 0)
            {
                SpawnMotherShip();
            }

            _motherShipTimer -= Time.deltaTime;
            _shootTimer -= Time.deltaTime;
            _moveTimer -= Time.deltaTime;
        }

       
    }

    void MoveEnemies()
    {   
        int hitMax = 0;

        for (int i = 0; i < _allAliens.Count; i++)
        {
            if (_movingRight)
            {
                _allAliens[i].transform.position += _hMoveDistance;
            }
            else
            {
                _allAliens[i].transform.position -= _hMoveDistance;
            }

            if (_allAliens[i].transform.position.x > _width || _allAliens[i].transform.position.x < -_width)
            {
                hitMax++;
            }
        }

        if(hitMax > 0)
        {
            for (int i = 0; i < _allAliens.Count; i++)
            {
                _allAliens[i].transform.position -= _vMoveDistance;
            }
            _movingRight = !_movingRight;
        }
        _moveTimer = GetMoveSpeed();
    }

    float GetMoveSpeed()
    {
        float f = _allAliens.Count * _moveTime;

        if(f < MAX_MOVE_SPEED)
        {
            return MAX_MOVE_SPEED;
        }
        else
        {
            return f;
        }

    }
    void Shoot()
    {
        Vector2 pos = _allAliens[Random.Range(0, _allAliens.Count)].transform.position;

        GameObject obj = _pooling.GetPooledObject();
        obj.transform.position = pos;

        _shootTimer = ShootTime;
    }

    void SpawnMotherShip()
    {
        GameObject obj = _motherShipObjectPool.GetPooledObject();
        obj.transform.position = _motherShipSpawnPos;
        _motherShipTimer = Random.Range(MOTHERSHIP_MIN, MOTHERSHIP_MAX);

    }
}
