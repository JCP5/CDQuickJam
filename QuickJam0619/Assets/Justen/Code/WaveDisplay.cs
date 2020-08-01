using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveDisplay : MonoBehaviour
{
    public static WaveDisplay instance;
    Text text;

    private void Start()
    {
        instance = this;
        text = this.GetComponent<Text>();
    }

    public void SetWave(int wave)
    {
        text.text = "Wave: " + wave.ToString();
    }
}
