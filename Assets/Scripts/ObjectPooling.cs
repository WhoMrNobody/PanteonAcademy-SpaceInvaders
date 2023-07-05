using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooling : MonoBehaviour
{
    [SerializeField] GameObject _objectPrefab;
    [SerializeField] int _poolSize;

    Queue<GameObject> pooledObjects;
   
    void Awake()
    {
        pooledObjects = new Queue<GameObject>();

        for (int i = 0; i < _poolSize; i++)
        {
            GameObject obj = Instantiate(_objectPrefab);
            obj.SetActive(false);
            pooledObjects.Enqueue(obj);
        }
        
    }
    
    public GameObject GetPooledObject()
    {
        GameObject obj = pooledObjects.Dequeue();
        obj.SetActive(true);
        pooledObjects.Enqueue(obj);
        return obj;
    }
}
