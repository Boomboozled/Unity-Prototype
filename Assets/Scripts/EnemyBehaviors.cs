using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviors : MonoBehaviour
{
    public float speed = 1.5f;
    public float health = 100;

    private GameObject player;
    public GameObject normalProjectilePrefab;
    public GameObject normalProjectile;
    public bool canFire = true;
    private float projectileSpeed = 100;
    public float reloadSpeed = 3;
    public bool playerIsDetected = false;
    int projectileOffset = 2;
    private float oneHalf = 0.5f;
    public float detectionRadius = 10.0f;
    public float detectionAngle = 45.0f;
    private float engagementDistance = 10.0f;
    public bool showPlayerTracking = false;



    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(showPlayerTracking)
        {
            Debug.DrawLine(gameObject.transform.position, player.transform.position, Color.white, 0.001f);

        }

        SearchForPlayer();

        

        if (playerIsDetected)
        {
            MoveTowardPlayer();
            LookAtPlayer();
            ShootAtPlayer();

        }

    }


    void LookAtPlayer()
    {

        gameObject.transform.LookAt(player.transform, Vector3.up);
    }


    //could be improved with const update parameters
    void MoveTowardPlayer()
    {
        Vector3 playerDirection = (gameObject.transform.position - player.transform.position);
        float distanceFromPlayer = playerDirection.magnitude;
        if (distanceFromPlayer > engagementDistance)
        {
            speed = 3.5f;
            gameObject.transform.position += (player.transform.position - gameObject.transform.position).normalized * Time.deltaTime * speed;
        }
        if (distanceFromPlayer <= engagementDistance)
        {
            speed = 5;
            gameObject.transform.position -= (player.transform.position - gameObject.transform.position).normalized * Time.deltaTime * speed;
        }
    }

    void ShootAtPlayer()
    {

        if (canFire)
        {
            Instantiate(normalProjectilePrefab, gameObject.transform.position + projectileOffset * transform.forward, transform.rotation);

            canFire = false;
            StartCoroutine(EnemyReloadTime());
        }

    }
    IEnumerator EnemyReloadTime()
    {
        yield return new WaitForSeconds(reloadSpeed);
        canFire = true;
    }

    void SearchForPlayer()
    {
        Vector3 playerDirection = (player.transform.position - gameObject.transform.position);
        playerDirection.y = 0;  //our distance would be affected by the player's height

        if (playerDirection.magnitude <= detectionRadius)
        {
            Vector3 normalizedPlayerDirection = playerDirection.normalized;
            float dotProduct = Vector3.Dot(normalizedPlayerDirection, gameObject.transform.forward);



            if (dotProduct > Mathf.Cos(detectionAngle * oneHalf * Mathf.Deg2Rad))
            {
                playerIsDetected = true;
            }
            else
            {
                playerIsDetected = false;
            }
        }
        else
        {
            playerIsDetected = false;
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
