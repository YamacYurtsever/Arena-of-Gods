using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Controller : MonoBehaviour
{
    private void Update()
    {
        if (GameObject.FindGameObjectWithTag("Player"))
            transform.position = new Vector3(GameObject.FindGameObjectWithTag("Player").transform.position.x,
                                             GameObject.FindGameObjectWithTag("Player").transform.position.y,
                                             transform.position.z);
    }
}
