using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] GameObject _bulletPrefab;
    [SerializeField] ObjectPooling _objectPooling = null;

    [HideInInspector] public float width;

    public ShipStats shipStats;

    Camera _camera;
    bool _isShooting;
    Vector2 _offScreenPos = new Vector2(0, -20);
    Vector2 _startPos = new Vector2(0, -6);

    void Awake()
    {
        _camera = Camera.main;
        width = ((1 / (_camera.WorldToViewportPoint(new Vector3(1, 1, 0)).x - .5f) / 2) - 0.25f);
    }

    void Start()
    {
        shipStats.CurrentHealth = shipStats.MaxHealth;
        shipStats.CurrentLifes = shipStats.MaxLifes;
        transform.position = _startPos;
    }

    void Update()
    {
#if UNITY_EDITOR
    
    if(Input.GetKey(KeyCode.A) && transform.position.x > -width){
    transform.Translate(Vector2.left * Time.deltaTime * shipStats.ShipSpeed);
    }

    if(Input.GetKey(KeyCode.D) && transform.position.x < width){
    transform.Translate(Vector2.right * Time.deltaTime * shipStats.ShipSpeed);
    }
    if(Input.GetKey(KeyCode.Space) && !_isShooting){
    StartCoroutine(Shoot());
    }

#endif
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("EnemyBullet"))
        {   
            collision.gameObject.SetActive(false);
            TakeDamege();
        }
    }

    IEnumerator Shoot()
    {
        _isShooting = true;

        //Instantiate(_bulletPrefab, transform.position, Quaternion.identity);
        GameObject obj = _objectPooling.GetPooledObject();
        obj.transform.position = gameObject.transform.position; 
        yield return new WaitForSeconds(shipStats.FireRate);

        _isShooting= false;
    }

    IEnumerator Respawn()
    {
        transform.position = _offScreenPos;

        yield return new WaitForSeconds(2f);

        shipStats.CurrentHealth = shipStats.MaxHealth;

        transform.position = _startPos;
    }

    public void TakeDamege()
    {
        shipStats.CurrentLifes--;

        if(shipStats.CurrentLifes <= 0)
        {
            shipStats.CurrentLifes--;

            if(shipStats.CurrentLifes <= 0)
            {

            }
            else
            {
                StartCoroutine(Respawn());
            }
        }
    }
}
