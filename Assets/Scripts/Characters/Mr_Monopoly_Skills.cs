using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mr_Monopoly_Skills : MonoBehaviour
{
    public GameObject weapon;
    private Vector2 direction;

    [Header("Primary")]
    public GameObject primaryProjectile;
    public float primaryProjectileDamage = 10f;
    public float primaryProjectileSpeed = 12.5f;
    public float primaryCooldown = 0.75f;
    public Sprite primaryImage;
    private GameObject primarySlot;
    private float primaryTimer = 0f;

    [Header("Secondary")]
    public float secondaryCooldown = 2f;
    public Sprite secondaryImage;
    private GameObject secondarySlot;
    private float secondaryTimer = 0f;

    [Header("Special")]
    public float specialCooldown = 5f;
    public Sprite specialImage;
    private GameObject specialSlot;
    private float specialTimer = 0f;

    private void OnEnable()
    {
        primarySlot = GameObject.FindGameObjectWithTag("Primary Slot");
        primarySlot.transform.GetChild(0).GetComponent<Image>().sprite = primaryImage;
        primarySlot.GetComponent<Slot_Cooldown>().SetCooldown(primaryCooldown);
        primaryTimer = -primaryCooldown;

        secondarySlot = GameObject.FindGameObjectWithTag("Secondary Slot");
        secondarySlot.transform.GetChild(0).GetComponent<Image>().sprite = secondaryImage;
        secondarySlot.GetComponent<Slot_Cooldown>().SetCooldown(secondaryCooldown);
        secondaryTimer = -secondaryCooldown;

        specialSlot = GameObject.FindGameObjectWithTag("Special Slot");
        specialSlot.transform.GetChild(0).GetComponent<Image>().sprite = specialImage;
        specialSlot.GetComponent<Slot_Cooldown>().SetCooldown(specialCooldown);
        specialTimer = -specialCooldown;
    }

    private void Update()
    {
        direction = GetComponent<Player_Weapon_Controller>().direction;

        Primary();
        Secondary();
        Special();
    }

    private void Primary()
    {
        if (Input.GetButton("Fire1") && Time.time > primaryTimer + primaryCooldown)
        {
            GameObject primary = Instantiate(primaryProjectile, (Vector2)weapon.transform.position, weapon.transform.rotation);
            primary.GetComponent<Mr_Monopoly_Projectile>().ChangeDamage(primaryProjectileDamage);
            primary.GetComponent<Rigidbody2D>().velocity = primaryProjectileSpeed * direction.normalized;
            primaryTimer = Time.time;
        }
        primarySlot.GetComponent<Slot_Cooldown>().SetTime(primaryCooldown - (Time.time - primaryTimer));
    }

    private void Secondary()
    {
        if (Input.GetButton("Fire2") && Time.time > secondaryTimer + secondaryCooldown)
        {
            secondaryTimer = Time.time;
        }
        secondarySlot.GetComponent<Slot_Cooldown>().SetTime(secondaryCooldown - (Time.time - secondaryTimer));
    }

    private void Special()
    {
        if (Input.GetButton("Jump") && Time.time > specialTimer + specialCooldown)
        {
            specialTimer = Time.time;
        }
        specialSlot.GetComponent<Slot_Cooldown>().SetTime(specialCooldown - (Time.time - specialTimer));
    }
}
