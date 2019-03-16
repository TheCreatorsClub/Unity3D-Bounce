using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMovement : MonoBehaviour
{
    public GameObject player;
    public GameObject cam;
    public Vector3 offset = new Vector3(0, 0, 10);

    private void Update()
    {
        cam.transform.position = player.transform.position - offset; 
    }

}
