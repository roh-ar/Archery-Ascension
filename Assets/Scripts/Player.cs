using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private GameObject bulletL_P;

    [SerializeField]
    private float speed = 3.5f;

    [SerializeField]
    private float firePerm = -1f;

    [SerializeField]
    private float shootingRate = 0.3f;

    private EnmySpwnMgr enmySpwnMgr;

    [SerializeField]
    private int health = 4;


    // Start is called before the first frame update
    void Start()
    {
        enmySpwnMgr = GameObject.Find("EnmySpwnMgr").GetComponent<EnmySpwnMgr>();

       
        //take the current position= new position(0,0,0)
        transform.position = new Vector3(0,0,0);

    }

    // Update is called once per frame
    void Update()
    {
        movCal();

        firing();


    }

    void firing()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > firePerm)
        {
            firePerm = Time.time + shootingRate;
            Instantiate(bulletL_P, this.transform.position + new Vector3(0, 0.67f, 0), Quaternion.identity);
        }

    }


    void movCal()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        //transform.Translate(new Vector3(1, 0, 0));
        //transform.Translate(Vector3.right*speed* horizontalInput* Time.deltaTime);
        //transform.Translate(Vector3.up * speed * verticalInput * Time.deltaTime);

        transform.Translate(new Vector3(horizontalInput, verticalInput, 0) * speed * Time.deltaTime);

        if (transform.position.y > 5.35f)
        {
            transform.position = new Vector3(transform.position.x, 5.35f, 0);
        }
        else if (transform.position.y < -3.53f)
        {
            transform.position = new Vector3(transform.position.x, -3.53f, 0);
        }

        if (transform.position.x > 8.99f)
        {
            transform.position = new Vector3(-9.02f, transform.position.y, 0);
        }
        else if (transform.position.x < -9.02f)
        {
            transform.position = new Vector3(8.99f, transform.position.y, 0);
        }
    }

    public void attack()
    {
        health -= 1;

        if (health < 1)
        {
            enmySpwnMgr.onPlayerlife();  
            Destroy(this.gameObject);
        }
    }
}
