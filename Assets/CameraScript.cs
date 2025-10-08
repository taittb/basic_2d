using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{

    public Transform attachedPlayer;
    Camera thisCamera;

    // use this for initialization
    void Start()
    {
        thisCamera = GetComponent<Camera>();    
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 player = attachedPlayer.transform.position;
        Vector3 newCamPos = new Vector3(0, player.y, transform.position.z);
        transform.position = newCamPos;
    }
}
