using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField] float _bulletSpeed;

    void Update()
    {
        transform.Translate(Vector2.down * Time.deltaTime * _bulletSpeed);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        
    }
}
