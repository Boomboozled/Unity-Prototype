using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class DP_Detector : MonoBehaviour
{
    //note detection based off player center of mass

    GameObject player;
    Material detectorMat;

    public float detectionRadius = 10.0f;
    public float detectionAngle = 45.0f;
   



    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;

        player = GameObject.Find("Player");
        detectorMat = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {

        SearchForPlayer();
        Debug.DrawLine(gameObject.transform.position, player.transform.position, Color.white, 0.001f);

    }



    void SearchForPlayer()
    {
        Vector3 playerDirection = (player.transform.position - gameObject.transform.position);
        playerDirection.y = 0;  //our distance would be affected by the player's height

        if(playerDirection.magnitude <= detectionRadius)
        {
            Vector3 normalizedPlayerDirection = playerDirection.normalized;
            float dotProduct = Vector3.Dot(normalizedPlayerDirection, gameObject.transform.forward);

            detectorMat.color = new Color(dotProduct, dotProduct, dotProduct);
           // detectorMat.color = new Color(dotProduct , 1 , dotProduct, 1);
           // Debug.Log("Dot Product:" + dotProduct);
          //  Debug.Log("Game objects forward transform:" + gameObject.transform.forward); //its not getting the worldspace's forward so it doesnt care.
           // Debug.Log("Player Direction:" + playerDirection); //its not getting the worldspace's forward so it doesnt care.
           // Debug.Log("NORMALIZED Player Direction:" + normalizedPlayerDirection); //IT AFFECTS THE MAGNITUDE OF the vector, so its going to adjust Z based on the magnitude
            //which is why -x and x give the same resulting dot product.

            
            if (dotProduct > Mathf.Cos(detectionAngle * 0.5f * Mathf.Deg2Rad))
            {

                Debug.Log("Math" + Mathf.Cos(detectionAngle * 0.5f * Mathf.Deg2Rad));
                Debug.Log("Player detected.");


            }
            else
            {

                Debug.Log("Not detected.");

            }
        }
        else
        {
            Debug.Log("Out of Range");
        }

            
    }


    private void OnDrawGizmosSelected()
    {
        Color arcColor = new Color(0.5f, 0.0f, 0.0f, 0.5f);
        UnityEditor.Handles.color = arcColor;

        Vector3 rotatedForward = Quaternion.Euler(0, -detectionAngle * 0.5f, 0) * transform.forward; //because where angle originates
       
        UnityEditor.Handles.DrawSolidArc(transform.position, Vector3.up, rotatedForward, detectionAngle, detectionRadius);
    }

}
