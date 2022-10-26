using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class missileScript : MonoBehaviour
{
    Vector3 newPosition = new Vector3(0, 15.0f, 0);
    private Rigidbody missileRb;
    private GameObject[] enemies;  //remember C# does type[]=
    public EnemyBehaviors enemyScript;
    public float missileDamage = 100.0f;
    private float launchForce = 10;
    private float targetForce = 26;
    private float enemyHitForce = 5;




    // Start is called before the first frame update
    void Start()
    {
        missileRb = GetComponent<Rigidbody>(); //gets rigid body of the object on the script
        missileRb.AddForce(Vector3.up * launchForce, ForceMode.Impulse);
        StartCoroutine(RocketLockOn());

    }

    // Update is called once per frame
    void Update()
    {
        

    }

    public GameObject FindClosestEnemy()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        if(enemies.Length == 0)
        {
            Debug.Log("null - no enemies");
            return null;
        }
        GameObject closestGameObject = null;
        float distance = Mathf.Infinity;
        Vector3 originalPosition = transform.position;
        foreach (GameObject element in enemies)
        {
            Vector3 positionDifference = originalPosition - element.transform.position;
            float currentDistance = positionDifference.sqrMagnitude;
            if( (currentDistance) < distance)
            {
                closestGameObject = element;
                distance = currentDistance;
            }

        }

        // Debug.Log(closestGameObject.name);

        return closestGameObject;
    }
    
    IEnumerator RocketLockOn()
    {
        yield return new WaitForSeconds(1.0f);
        
        if(FindClosestEnemy() != null)
        {
            Vector3 targetDirection = (FindClosestEnemy().transform.position - transform.position).normalized;
            targetDirection += new Vector3(0, 0.1f, 0); 
            missileRb.AddForce(targetDirection * targetForce, ForceMode.Impulse);
        }

    }


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Ground") )
        {
            
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            enemyScript = collision.gameObject.GetComponent<EnemyBehaviors>();
            enemyScript.health -= 50.0f;  //seems script can communicate one way, but not the other meaning with numbers, but not numbers from THIS script
            Debug.Log("Enemy hit");
            Debug.Log("Enemy health:" + enemyScript.health);
            collision.rigidbody.AddForce(Vector3.up * enemyHitForce, ForceMode.Impulse);

            if (enemyScript.health <= 0)
            {
                Destroy(collision.gameObject);
            }

        }
        else if (collision.gameObject.CompareTag("Ground"))
        {
            Debug.Log("Missed");
        }
        
    }

}
