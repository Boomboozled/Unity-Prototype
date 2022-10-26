using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float speed = 1;
    private Rigidbody bulletRb;
    private PlayerController playerControllerScript;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        bulletRb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        bulletRb.AddForce(transform.forward * speed, ForceMode.Impulse);
        
    }


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {

            playerControllerScript = collision.gameObject.GetComponent<PlayerController>();
            playerControllerScript.health -= 1;
        }


        Destroy(gameObject);

    }
}
