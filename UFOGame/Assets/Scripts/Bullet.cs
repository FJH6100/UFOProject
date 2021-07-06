using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    float speed = 100f;
    Rigidbody rb;
    private void Awake()
    {
        //Destroy bullet after 3 seconds
        Destroy(gameObject, 3f);
    }
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Vector3 direction = transform.forward * speed;
        rb.velocity = new Vector3(direction.x, direction.y, direction.z);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Target")
        {
            Destroy(gameObject);
        }
    }
}
