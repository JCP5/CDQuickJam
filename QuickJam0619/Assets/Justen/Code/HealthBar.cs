using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public static HealthBar instance;
    public Text armorText;

    private void Start()
    {
        InitializeHealthBar();
    }

    void InitializeHealthBar()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
            Destroy(this.gameObject);
    }

    public void SetArmorText(float armor)
    {
        armorText.text = "Armour: " + armor;
    }

    public void SetHealthBarScale(float health)
    {
        this.gameObject.transform.localScale = new Vector3 (Mathf.Clamp(health, 0, 0.9f), transform.localScale.y, transform.localScale.z);
        /*xScale = Mathf.Clamp01(health);
        RectTransform rect = this.GetComponent<RectTransform>();
        rect.localScale = new Vector3(xScale, rect.localScale.y, rect.localScale.z);*/
        //Debug.Log(new Vector3(Mathf.Clamp01(health), rect.localScale.y, rect.localScale.z));
    }
}
