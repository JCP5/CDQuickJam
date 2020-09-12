using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float Health;
    public float MaxHealth;
    public float HealthIncreaseCap;

    //Possible behaviours of armor
    public enum ArmorBehaviour {None, Flat, Percentage, ArmorHealth, HealthFlat, HealthPercentage};

    //Armor values, which are used depends on the selected armor style
    public ArmorBehaviour ArmorStyle = ArmorBehaviour.None;
    //How much damage is reduced when a flat reduction armor style is selected.
    public float FlatArmorReduction = 0;
    public float MaxFlatArmorReduction;
    //When a percentage reduction armor style is selected, damage is multiplied by (1 - PercentageArmorReduction).
    public float PercentageArmorReduction = 0;
    public float MaxArmorPercentage = 0;
    //When armor is used as a second healthbar, this is the amount in that healthbar.
    public float ArmorHealth = 0;
    //When armor is used as a second healthbar, this is the maximum amount of armor health the player can have.
    public float MaxArmorHealth = 0;

    public delegate void deathDelegate();
    public event deathDelegate deathEvent;
    public void TakeDamage(float Damage)
    {
        switch (ArmorStyle)
        {
            // Normal no armor behaviour
            case (ArmorBehaviour.None):
            {
                Health = Health - Damage;
                break;
            }

            // Flat reduction of incoming damage
            case (ArmorBehaviour.Flat):
            {
                //Clamp so that damage doesn't end up negative and heal you.
                Health = Health - Mathf.Clamp((Damage - FlatArmorReduction), 0, Damage);
                break;
            }

            // Percentage reduction of incoming damage
            case (ArmorBehaviour.Percentage):
            {

                Health = Health - Mathf.Clamp(Damage * (1 - PercentageArmorReduction), 0, Damage);
                break;
            }

            // Armor acts as a second healthbar
            case (ArmorBehaviour.ArmorHealth):
            {
                if (ArmorHealth > 0)
                {
                    if (Damage > ArmorHealth)
                    {
                        ArmorHealth = 0;
                        Damage = Damage - ArmorHealth;
                    }
                    else
                    {
                        ArmorHealth = ArmorHealth - Mathf.Clamp(Damage, 0, Damage);
                        Damage = 0;
                    }
                }
                Health = Health - Mathf.Clamp(Damage, 0, Damage);
                break;
            }

            // Flat reduction of incoming damage AND armor acts as a second healthbar.
            // Reduction only happens when the player has remaining armor.
            case (ArmorBehaviour.HealthFlat):
            {
                if (ArmorHealth > 0)
                {
                    Damage = Mathf.Clamp(Damage - FlatArmorReduction, 0, Damage);

                    if (Damage > ArmorHealth)
                    {
                        ArmorHealth = 0;
                        Damage = Damage - ArmorHealth;
                    }
                    else
                    {
                        ArmorHealth = ArmorHealth - Damage;
                        Damage = 0;
                    }
                }
                Health = Health - Damage;
                break;
            }

            // Percentage reduction of incoming damage AND armor acts as a second healthbar.
            // Reduction only happens when the player has remaining armor.
            case (ArmorBehaviour.HealthPercentage):
            {
                if (ArmorHealth > 0)
                {
                    Damage = Mathf.Clamp(Damage * (1 - PercentageArmorReduction), 0, Damage);

                    if (Damage > ArmorHealth)
                    {
                        ArmorHealth = 0;
                        Damage = Damage - ArmorHealth;
                    }
                    else
                    {
                        ArmorHealth = ArmorHealth - Damage;
                        Damage = 0;
                    }
                }
                Health = Health - Damage;
                break;
            }

            default:break;
        }

        HealthBar.instance.SetHealthBarScale(Health / MaxHealth);
        Debug.Log("Health % " + Health / MaxHealth);

        if (Health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void AddArmorHealth(float AddedHealth)
    {
        ArmorHealth = Mathf.Clamp(ArmorHealth + AddedHealth, 0, MaxArmorHealth);
    }

    public void AddFlatArmorReduction(float AddedFlatReduction)
    {
        FlatArmorReduction = Mathf.Clamp((FlatArmorReduction + AddedFlatReduction), 0, MaxFlatArmorReduction);
        HealthBar.instance.SetArmorText(FlatArmorReduction);
    }

    public void AddPercentageArmorReduction(float AddedPercentageReduction)
    {
        PercentageArmorReduction = Mathf.Clamp((PercentageArmorReduction + AddedPercentageReduction), 0, MaxArmorPercentage);
    }

    
    public void AddMaxHealth(float MaxHealthIncrease)
    {
        MaxHealth = Mathf.Clamp(MaxHealthIncrease + MaxHealth, 0, HealthIncreaseCap);
    }
    

    public void HealCurrentHealth(float HealAmount)
    {
        Health = Mathf.Clamp(HealAmount + Health, 0, MaxHealth);
        Debug.Log("Health = " + Health);

        HealthBar.instance.SetHealthBarScale(Health / MaxHealth);
        Debug.Log("Health % " + Health / MaxHealth);
    }

    private void OnDestroy()
    {
        FindObjectOfType<Spawner>().enabled = false;
        Debug.Log("Rest In Pepperoni");

        if (deathEvent != null)
        {
            deathEvent();
        }
    }
}
