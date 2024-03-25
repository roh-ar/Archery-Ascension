using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletLaser : MonoBehaviour
{
    private float bulSpeed=9.5f;
    // Start is called before the first frame update
    void Start() { }
   

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * bulSpeed * Time.deltaTime);

        if (transform.position.y > 6.9f)
        {
            Destroy(this.gameObject);
        }
    }
}
