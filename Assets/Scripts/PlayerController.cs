using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float health = 100;
    private Rigidbody playerRb;
    private float jumpForce = 5;
    public float movementSpeed = 10.0f;
    bool canJump;
    bool isMissileOnCooldown;
    public bool isManEater = false;
    private Vector3 cameraPositioning = new Vector3(0, 0, 0.1f);
    public float maxHeight = 0; //1.724 off the ground. We can jump 1.724 meters!
    public GameObject missilePrefab;
    Vector3 missileOffset = new Vector3(0, 0.75f, -0.4f);
    Vector3 missileOffset2 = new Vector3(-3f, 3f, 3f);
    Vector3 missileOffset3 = new Vector3(0, 3f, 3f);
    Vector3 missileOffset4 = new Vector3(3, 3f, 3f);



    private float hSens;

    public GameObject cameraThing;

    // Start is called before the first frame update
    void Start()
    {
        canJump = true;
        playerRb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        MovementControls();

        MouseControl();

        GetMaxHeight();



    }

    private void MovementControls()
    {
        if (Input.GetKey("w"))
        {
            MovePlayer(gameObject.transform.forward);
        }
        if (Input.GetKey("a"))
        {
            MovePlayer(-gameObject.transform.right);

        }
        if (Input.GetKey("s"))
        {
            MovePlayer(-gameObject.transform.forward);

        }
        if (Input.GetKey("d"))
        {
            MovePlayer(gameObject.transform.right);

        }

        if (Input.GetKeyDown("space") && canJump)
        {
            playerRb.AddForce(Vector3.up * jumpForce * playerRb.mass, ForceMode.Impulse);
            canJump = false;
        }

        if (Input.GetMouseButton(0) && !isMissileOnCooldown)
        {
            FireMissile();

        }

        if(Input.GetKey("up"))
        {
            gameObject.GetComponentsInChildren<Transform>();
            cameraThing.transform.Rotate(0.1F, 0, 0);
        }
        if (Input.GetKey("down"))
        {
            gameObject.GetComponentsInChildren<Transform>();
            cameraThing.transform.Rotate(-0.1F, 0, 0);
        }
        if (Input.GetKey("right"))
        {
            gameObject.GetComponentsInChildren<Transform>();
            cameraThing.transform.position = transform.position + cameraPositioning;

        }
        if (Input.GetKey("left"))
        {
            gameObject.GetComponentsInChildren<Transform>();
            cameraThing.transform.position = transform.position - cameraPositioning;
        }
    }

    private void MovePlayer(Vector3 direction)
    {


        transform.position += (Time.deltaTime * movementSpeed * direction);

    }

    private void MouseControl()
    {
        if (Input.GetMouseButton(1))
        {
            hSens = 1000.0f * Input.GetAxis("Mouse X") * Time.deltaTime; 
            transform.Rotate(0, hSens, 0);
        }
    }

    public void GetMaxHeight()
    {

        if (gameObject.transform.position.y > maxHeight)
        {
            maxHeight = gameObject.transform.position.y;

        }
    }

    

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            canJump = true;
        }
        if(collision.gameObject.CompareTag("Enemy") && isManEater == true)
        {
            Destroy(collision.gameObject);
        }
    }


    private void FireMissile()
    {
        //Instantiate(missilePrefab, transform.position + missileOffset, missilePrefab.gameObject.transform.rotation); //original missile

        /*
        Instantiate(missilePrefab, transform.position + missileOffset2,transform.rotation);
        Instantiate(missilePrefab, transform.position + missileOffset3, transform.rotation);
        Instantiate(missilePrefab, transform.position + missileOffset4, transform.rotation);
        */
        Instantiate(missilePrefab, transform.TransformPoint(transform.forward + missileOffset2),transform.rotation);
        Instantiate(missilePrefab, transform.TransformPoint(transform.forward + missileOffset3), transform.rotation);
        Instantiate(missilePrefab, transform.TransformPoint(transform.forward + missileOffset4), transform.rotation);

        isMissileOnCooldown = true;
        StartCoroutine(MissileCooldown());
    }

    IEnumerator MissileCooldown()
    {
        yield return new WaitForSeconds(0.5f);
        isMissileOnCooldown = false;
    }
}
