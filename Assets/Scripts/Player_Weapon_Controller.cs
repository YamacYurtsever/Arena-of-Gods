using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Weapon_Controller : MonoBehaviour
{
    public GameObject weapon;
    public float offsetX = 0;
    public float offsetY = 0;
    public float offsetAngle = 0;
    public Vector2 direction;

    private Camera cam;
    private Transform weaponTransform;
    private Vector2 playerScale;
    private Player_Health_System playerHealthSystem;
    private int directionMultiplier = 1;

    void Start()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        weaponTransform = weapon.transform;
        playerScale = transform.localScale;
        playerHealthSystem = GetComponent<Player_Health_System>();
    }

    void Update()
    {
        direction = cam.ScreenToWorldPoint(Input.mousePosition) - transform.position;

        //flip player, but keep health bar unflipped
        if (directionMultiplier == 1 && direction.x < 0)
        {
            directionMultiplier = -1;
            playerHealthSystem.healthBar.transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        else if (directionMultiplier == -1 && direction.x > 0)
        {
            directionMultiplier = 1;
            playerHealthSystem.healthBar.transform.localScale = new Vector3(1f, 1f, 1f);
        }
        transform.localScale = new Vector2(playerScale.x * directionMultiplier, playerScale.y);

        //rotate weapon in its place
        float angle = Vector2.Angle(direction, Vector2.up);
        float newWeaponAngle = directionMultiplier * (90 - angle + offsetAngle);
        weaponTransform.eulerAngles = new Vector3(0, 0, newWeaponAngle);

        //position weapon around the player
        weaponTransform.position = (Vector2)transform.position + direction.normalized * offsetX + new Vector2(0, offsetY);
    }
}