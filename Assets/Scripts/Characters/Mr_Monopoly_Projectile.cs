using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mr_Monopoly_Projectile : MonoBehaviour
{
    public float airTime = 3;

    private float damage = 10f;

    private void OnEnable()
    {
        StartCoroutine(Despawn());
    }

    IEnumerator Despawn()
    {
        yield return new WaitForSeconds(airTime);
        Destroy(gameObject);
    }

    public void ChangeDamage(float primaryDamage)
    {
        damage = primaryDamage;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            collision.GetComponent<Player_Health_System>().DecreaseHealth(damage);
            Destroy(gameObject);
        }
    }
}
