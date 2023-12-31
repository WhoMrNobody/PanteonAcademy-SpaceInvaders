using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alien : MonoBehaviour
{
    [SerializeField] GameObject _explosion;
    [SerializeField] GameObject _coinPrefab, _lifePrefab, _healthPrefab;

    const int LIFE_RATE = 10;
    const int HEALTH_RATE = 50;
    const int COIN_RATE = 200;


    public int ScoreValue;
    public void Kill()
    {
        UIManager.UpdateScore(ScoreValue);
        AlienMaster._allAliens.Remove(gameObject);
        Instantiate(_explosion, transform.position, Quaternion.identity);

        if (AlienMaster._allAliens.Count == 0)
        {
            GameManager.SpawnNewWave();
        }

        int randomValue = Random.Range(0, 501);

        if(randomValue <= LIFE_RATE)
        {
            Instantiate(_lifePrefab, transform.position, Quaternion.identity);
        }
        else if(randomValue <= HEALTH_RATE)
        {
            Instantiate(_healthPrefab, transform.position, Quaternion.identity);
        }
        else if(randomValue <= COIN_RATE)
        {
            Instantiate(_coinPrefab, transform.position, Quaternion.identity);
        }

        
        
        gameObject.SetActive(false);
    }

}
