using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    [SerializeField] Sprite[] _sprites;
    int _health;
    SpriteRenderer _spRenderer;

    void Start()
    {
        _health = 4;
        _spRenderer = GetComponent<SpriteRenderer>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("EnemyBullet") || collision.gameObject.CompareTag("FriendlyBullet"))
        {
            collision.gameObject.SetActive(false);
            _health--;

            if(_health <= 0)
            {
                Destroy(gameObject);
            }
            else
            {
                _spRenderer.sprite = _sprites[_health - 1]; 
            }
        }
    }

}
