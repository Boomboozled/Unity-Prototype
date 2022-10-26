using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{

    public GameObject playArea;
    // Start is called before the first frame update
    void Start()
    {
        playArea = GameObject.Find("Arena");
    }

    // Update is called once per frame
    void Update()
    {

            float distance = (gameObject.transform.position - playArea.transform.position).magnitude;
            
            if(distance > 110)
        {
            Destroy(gameObject);
        }
    }
}
