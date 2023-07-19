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
        foreach (Image item in Instance._lifeSprites)
        {
            item.color = Instance._inactive;
        }

        for (int i = 0; i < l; i++)
        {
            Instance._lifeSprites[i].color = Instance._active;
        }
    }

    public static void UpdateScore(int s)
    {
        Instance._score += s;
        Instance._scoreText.text = Instance._score.ToString("000,000");
    }

    public static void UpdateHighScore()
    {

    }

    public static void UpdateWave()
    {
        Instance._wave++;
        Instance._waveText.text = Instance._wave.ToString();
    }

    public static void UpdateCoins()
    {

    }

    public static void UpdateHealthBar(int h)
    {
        Instance._healthBar.sprite = Instance._healthBars[h];
    }
   
}
