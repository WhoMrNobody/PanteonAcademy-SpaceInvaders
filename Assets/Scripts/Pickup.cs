using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Pickup : MonoBehaviour
{
    [SerializeField] float _fallSpeed;

    void Update()
    {
        transform.Translate(Vector2.down * Time.deltaTime * _fallSpeed);
    }

    public abstract void PickMeUp();

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PickMeUp ();
        }
    }
}
