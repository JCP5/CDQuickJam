using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveDisplay : MonoBehaviour
{
    public static WaveDisplay instance;
    public Text text;
    public Text textWaveTimer;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {

        //text = this.GetComponent<Text>();
    }

    public void SetWave(int wave)
    {
        text.text = "Wave: " + wave.ToString();
    }

    public void SetWaveTimer(float waveTimer)
    {
        try
        {
            textWaveTimer.text = "Next Wave In: " + Mathf.Ceil(waveTimer);
        }
        catch
        {
            textWaveTimer = transform.Find("WaveCounter").GetComponent<Text>();
            textWaveTimer.text = "Next Wave In: " + Mathf.Ceil(waveTimer);
        }

    }
}
