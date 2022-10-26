using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{

    public GameObject player;
    private Vector3 positionOffset = new Vector3(0, 2, -4);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update() //before frame
    {
        if (Input.GetMouseButton(1))
        {
            rotationTest();
        }



    }

    private void LateUpdate() //after frame
    {
        //transform.position = player.transform.position + positionOffset; // having it as a child of the player, makes this useless but has other uses or applications
        //maybe test different options

    }


    private void rotationTest()
    {
        //transform.RotateAround(player.transform.position, Vector3.up, Input.GetAxis("Mouse X") * 1500* Time.deltaTime); 

    }
}
