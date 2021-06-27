using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody rb;
    float speed = 20f;
    private float timeCount = 0.0f;
    private float yRot = 0f, xRot = 0f, zRot = 0f;
    // Start is called before the first frame update
    void Start()
    {
        rb = transform.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float xMov = Input.GetAxisRaw("Horizontal");
        float yMov = Input.GetAxisRaw("Vertical");
        float zMov = Input.GetAxisRaw("Fly");

        transform.position += transform.forward * speed * zMov * Time.deltaTime;
        transform.position += transform.up * speed * yMov * Time.deltaTime;
        //transform.position += transform.right * speed * xMov * Time.deltaTime;
        //rb.velocity = transform.forward * speed;
        Rotation(yMov,xMov);
    }

    void Rotation(float pitch, float roll)
    {
        //float xRot = Mathf.LerpAngle(0, -(pitch * 30), 30 * Time.deltaTime);
        //float zRot = Mathf.Clamp(Mathf.LerpAngle(0, -(roll * 60), 30 * Time.deltaTime),-60,60);
        //pitch = Mathf.Clamp(pitch, -30, 30);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(-(pitch * 30), 0, -(roll * 60)), 30 * Time.deltaTime);
        //yRot += roll * .1f;
        //transform.eulerAngles = new Vector3(0, yRot, 0);
        //transform.localEulerAngles = new Vector3(-(pitch * 15), 0, -(roll * 15));
        //transform.eulerAngles = new Vector3(-(pitch * 30), 0, -(roll * 60));
    }
}
