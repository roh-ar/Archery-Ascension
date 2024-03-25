using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour

{
    private float eSpeed = 4.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
        if (transform.position.y < -3.53f)
        {
           

            transform.position = new Vector3(Random.Range(-9.02f, 8.99f), 5.35f, 0);
        }
        transform.Translate(new Vector3(0,0,-1)*eSpeed*Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Player pMain = other.transform.GetComponent<Player>();

            if (pMain != null)
            {
                pMain.attack();
            }
            {

            }
            Destroy(this.gameObject);
        }

        if (other.tag == "BulletLaser")
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }
}
