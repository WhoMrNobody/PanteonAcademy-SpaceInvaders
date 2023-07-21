using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alien : MonoBehaviour
{
    [SerializeField] GameObject _explosion;
   

    public int ScoreValue;
    public void Kill()
    {
        UIManager.UpdateScore(ScoreValue);

        if(AlienMaster._allAliens.Count <= 0)
        {
            GameManager.SpawnNewWave();
        }

        AlienMaster._allAliens.Remove(gameObject);
        Instantiate(_explosion, transform.position, Quaternion.identity);
        gameObject.SetActive(false);
    }

}
