using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotherShipMovement : MonoBehaviour
{
    [SerializeField] int _scoreValue;
    [SerializeField] float _movementSpeed = 2f;

    const float MAX_LEFT = -8f;

    void Update()
    {
        transform.Translate(Vector2.left * Time.deltaTime * _movementSpeed);

        if(transform.position.x <= MAX_LEFT)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("FriendlyBullet"))
        {
            UIManager.UpdateScore(_scoreValue);
            collision.gameObject.SetActive(false);
            gameObject.SetActive(false);

        }
    }
}
