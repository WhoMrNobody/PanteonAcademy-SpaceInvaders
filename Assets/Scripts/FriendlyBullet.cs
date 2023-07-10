using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendlyBullet : MonoBehaviour
{
    private float _speed = 10f;
    void Update()
    {
        transform.Translate(Vector2.up * Time.deltaTime * _speed);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Alien"))
        {
            collision.gameObject.GetComponent<Alien>().Kill();
            gameObject.SetActive(false);

        }
    }
}
