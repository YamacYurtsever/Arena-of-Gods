using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sprite_Order : MonoBehaviour
{
    public float orderChanger = 0;

    private SpriteRenderer sr;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        sr.sortingOrder = (int)(100 * (orderChanger - transform.position.y));
    }
}
