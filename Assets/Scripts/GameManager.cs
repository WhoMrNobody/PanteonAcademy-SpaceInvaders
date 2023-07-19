using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{   
    public static GameManager Instance;

    [SerializeField] GameObject[] _allAliensSet;

    GameObject _currentSet;
    Vector2 _spawnPos = new Vector2(0, 10);

    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        SpawnWave();
    }

    public static void SpawnNewWave()
    {
        Instance.StartCoroutine(Instance.SpawnWave());
    }

    IEnumerator SpawnWave()
    {

        if(_currentSet != null)
        {
            Destroy(_currentSet);
        }

        yield return new WaitForSeconds(3f);

        _currentSet = Instantiate(_allAliensSet[Random.Range(0, _allAliensSet.Length)], _spawnPos, Quaternion.identity );

        UIManager.UpdateWave();
    }
}
