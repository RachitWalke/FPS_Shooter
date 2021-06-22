using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UImanager : MonoBehaviour
{

    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text waveText;
     public static int killCount;
     public static int waveCount = 1;

    // Start is called before the first frame update
    void Start()
    {
        killCount = 0;
        scoreText.text = "Kills : " + killCount.ToString();
        waveText.text = "Wave : " + waveCount.ToString();
    }

    public void UpdateScore(int kills)
    {
        killCount += kills;
        scoreText.text = "Kills : " + killCount.ToString();

        if(killCount > PlayerPrefs.GetInt("HighScore",0))
        {
            PlayerPrefs.SetInt("HighScore", killCount);
        }
    }

    public void UpdateWaveCount(int waveno)
    {
        waveCount = waveno + 2;
        waveText.text = "Wave : " + waveCount.ToString();

        if (waveCount > PlayerPrefs.GetInt("HighestWave", 0))
        {
            PlayerPrefs.SetInt("HighestWave", waveCount);
        }
    }
}
