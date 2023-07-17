using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{   
    private static UIManager Instance;

    [SerializeField] TextMeshProUGUI _scoreText, _highScoreText, _coinText, _waveText;
    [SerializeField] Image[] _lifeSprites;
    [SerializeField] Image _healthBar;
    [SerializeField] Sprite[] _healthBars;

    Color32 _active = new Color(1,1,1,1);
    Color32 _inactive = new Color(1, 1, 1, 0.25f);

    int _score;
    int _highScore;
    int _wave;

    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(Instance);
        }
    }

    public static void UpdateLives(int l)
    {

    }

    public static void UpdateScore(int s)
    {

    }

    public static void UpdateHighScore()
    {

    }

    public static void UpdateWave()
    {

    }

    public static void UpdateCoins()
    {

    }
   
}
