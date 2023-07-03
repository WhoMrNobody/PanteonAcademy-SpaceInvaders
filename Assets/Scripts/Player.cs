using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] GameObject _bulletPrefab;

    public float width;
    Camera _camera;
    float _speed = 3.0f;
    bool _isShooting;
    float _cooldown = 0.5f;

    void Awake()
    {
        _camera = Camera.main;
        width = ((1 / (_camera.WorldToViewportPoint(new Vector3(1, 1, 0)).x - .5f) / 2) - 0.25f);
    }
    
    void Start()
    {
        
    }

    
    void Update()
    {
#if UNITY_EDITOR
    
    if(Input.GetKey(KeyCode.A) && transform.position.x > -width){
    transform.Translate(Vector2.left * Time.deltaTime * _speed);
    }

    if(Input.GetKey(KeyCode.D) && transform.position.x < width){
    transform.Translate(Vector2.right * Time.deltaTime * _speed);
    }
    if(Input.GetKey(KeyCode.Space && !_isShooting){
    StartCoroutine(Shoot());
    }

#endif
    }

    IEnumerator Shoot()
    {
        _isShooting = true;

        Instantiate(_bulletPrefab, transform.position, Quaternion.identity);
        yield return new WaitForSecond(_cooldown);

        _isShooting= false;
    }
}
