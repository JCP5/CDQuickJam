using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ShaderBeatEmission : MonoBehaviour
{
    public float bpm;
    public float bps;
    public float emissiveIntesity = 1;

    public float secondsPerBeat = 1;
    public float fadeOutStrength = 1;

    public TilemapRenderer tmr;
    public Material mat;

    public float beatOffset;
    public float offsetTime;

    // Start is called before the first frame update
    void Start()
    {
        bps = bpm / 60f;
        secondsPerBeat = 1 / bps;
        offsetTime = beatOffset * secondsPerBeat;

        tmr = this.GetComponent<TilemapRenderer>();
        mat = tmr.material;
        mat.SetFloat("_Frequency", 0);
    }

    private void FixedUpdate()
    {
        if (beatOffset > 0)
        {
            if (offsetTime > 0)
            {
                offsetTime -= Time.fixedDeltaTime;
            }
            else
            {
                FadeLight();
            }
        }
        else
        {
            FadeLight();
        }
    }

    void FadeLight()
    {
        if (secondsPerBeat > 0)
        {
            secondsPerBeat -= Time.fixedDeltaTime;

            float intensity = mat.GetFloat("_Frequency") - Time.fixedDeltaTime * (emissiveIntesity) * fadeOutStrength;
            mat.SetFloat("_Frequency", intensity);
        }
        else
        {
            secondsPerBeat = 1 / bps;
            mat.SetFloat("_Frequency", emissiveIntesity);
            offsetTime = beatOffset * secondsPerBeat;
        }
    }
}
