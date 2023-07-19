using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotherShipMovement : MonoBehaviour
{
    [SerializeField] int _scoreValue;

    const float MAX_LEFT = -6f;

    float _movementSpeed = 5f;
    
    void Update()
    {
        transform.Translate(Vector2.left * Time.deltaTime * _movementSpeed);

        if(transform.position.x <= MAX_LEFT)
        {
            gameObject.SetActive(false);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("FriendlyBullet"))
        {
            UIManager.UpdateScore(_scoreValue);
            collision.gameObject.SetActive(false);
            gameObject.SetActive(false);

        }
    }
}
