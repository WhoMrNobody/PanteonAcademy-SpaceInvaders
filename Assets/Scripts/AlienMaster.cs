using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienMaster : MonoBehaviour
{
    [SerializeField] GameObject _bulletPrefab;

    Vector3 _hMoveDistance = new Vector3(0.05f, 0, 0);
    Vector3 _vMoveDistance = new Vector3(0, 0.15f, 0);

    const float MAX_LEFT = -2.8f;
    const float MAX_RIGHT = 2.8f;
    const float MAX_MOVE_SPEED = 0.0001f;

    public static List<GameObject> _allAliens = new List<GameObject>();

    bool _movingRight;
    float _moveTimer = 0.01f;
    float _moveTime = 0.005f;
    void Start()
    {
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Alien"))
        {
            _allAliens.Add(obj);
        }
    }

    
    void Update()
    {
        if (_moveTimer <= 0)
        {
            MoveEnemies();
        }

        _moveTimer -= Time.deltaTime;
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

            if (_allAliens[i].transform.position.x > MAX_RIGHT || _allAliens[i].transform.position.x < MAX_LEFT)
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
}
