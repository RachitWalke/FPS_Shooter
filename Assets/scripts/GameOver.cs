using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOver : MonoBehaviour
{

    [SerializeField] private TMP_Text killText;
    [SerializeField] private TMP_Text HkillText;
    [SerializeField] private TMP_Text WaveText;
    [SerializeField] private TMP_Text HWaveText;

    // Start is called before the first frame update
    void Start()
    {
        killText.text = "Kills : " + UImanager.killCount.ToString();
        WaveText.text = "Wave Reached : " + UImanager.waveCount.ToString();

        HkillText.text = "Highest Kills : " + PlayerPrefs.GetInt("HighScore", 0);
        HWaveText.text = "Highest Wave : " + PlayerPrefs.GetInt("HighestWave", 0);
    }

    public void Restart()
    {
        SceneManager.LoadScene("SampleScene");
    }

}
