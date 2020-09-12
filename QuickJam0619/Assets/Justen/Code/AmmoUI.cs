using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoUI : MonoBehaviour
{
    public static AmmoUI instance;

    public Sprite[] projSprites;
    public Text ammoCount;
    private Image ammoType;

    private void Awake()
    {
        InitializeAmmoUI();
        ammoCount = this.GetComponentInChildren<Text>();
        ammoType = this.GetComponent<Image>();
    }

    private void Start()
    {
       
    }

    public void ChangeAmmoType(int index)
    {
        try
        {
            ammoType.sprite = projSprites[index];
        }
        catch
        {
            Debug.Log("Sprite Not Found");
        }
    }

    public void SetAmmo(int ammo)
    {
        ammoCount.text = ammo.ToString();
    }

    public void InitializeAmmoUI()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this.gameObject);
    }
}
