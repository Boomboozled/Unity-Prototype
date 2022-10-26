using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BerserkPowerup : MonoBehaviour
{

    public GameObject bzrkPrefab;
    public PlayerController playerScript;
    private Vector3 scaleChange = new Vector3(2, 2, 2);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            playerScript = other.gameObject.GetComponent<PlayerController>();
            playerScript.movementSpeed = 20;
            playerScript.gameObject.transform.localScale += scaleChange;
            playerScript.isManEater = true;
        }
        Destroy(gameObject);
    }
}
