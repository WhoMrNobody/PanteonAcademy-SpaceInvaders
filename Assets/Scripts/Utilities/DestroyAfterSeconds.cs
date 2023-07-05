using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterSeconds : MonoBehaviour
{
    [SerializeField] float _second;
    // Start is called before the first frame update
    void Start()
    {
        //Destroy(gameObject, _second);
    }

    void Update()
    {
        if(transform.position.y > 7f)
        {
            gameObject.SetActive(false);
        }
    }
}
