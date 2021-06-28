using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody rb;
    public float forwardSpeed = 20f;
    public float horiSpeed = 10f;
    public float vertiSpeed = 10f;
    private float activeForwardSpeed, activeHoriSpeed, activeVertiSpeed;
    public float forwardAccel = 20f;
    public float horiAccel = 10f;
    public float vertiAccel = 10f;
    public float lookRotateSpeed = 90f;
    private Vector2 lookInput, screenCenter, mouseDistance;
    float xRot = 0f, yRot = 0f, zRot = 0f;
    // Start is called before the first frame update
    void Start()
    {
        rb = transform.GetComponent<Rigidbody>();
        screenCenter.x = Screen.width * .5f;
        screenCenter.y = Screen.height * .5f;
    }

    // Update is called once per frame
    void Update()
    {
        lookInput.x = Input.mousePosition.x;
        lookInput.y = Input.mousePosition.y;

        mouseDistance.x = (lookInput.x - screenCenter.x) / screenCenter.y;
        mouseDistance.y = (lookInput.y - screenCenter.y) / screenCenter.y;

        mouseDistance = Vector2.ClampMagnitude(mouseDistance, 1f);

        //xRot = Mathf.Clamp(xRot + (-mouseDistance.y * lookRotateSpeed * Time.deltaTime), -30, 30);
        //yRot += mouseDistance.x * lookRotateSpeed * Time.deltaTime;
        //zRot = Mathf.Clamp(zRot + (-mouseDistance.x * lookRotateSpeed * Time.deltaTime), -60, 60);

        //transform.eulerAngles = new Vector3(xRot, yRot, zRot);

        activeForwardSpeed = Mathf.Lerp(activeForwardSpeed, Input.GetAxisRaw("Fly") * forwardSpeed, forwardAccel * Time.deltaTime);
        activeHoriSpeed = Mathf.Lerp(activeHoriSpeed, Input.GetAxisRaw("Horizontal") * horiSpeed, horiAccel * Time.deltaTime);
        activeVertiSpeed = Mathf.Lerp(activeVertiSpeed, Input.GetAxisRaw("Vertical") * vertiSpeed, vertiAccel * Time.deltaTime);

        transform.position += transform.forward * activeForwardSpeed * Time.deltaTime;
        //transform.position += transform.up * activeVertiSpeed * Time.deltaTime;
        //transform.position += transform.right * activeHoriSpeed * Time.deltaTime;
        //rb.velocity = transform.forward * speed;
        Rotation(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }

    void Rotation(float xValue, float yValue)
    {
        xRot = Mathf.Clamp(xRot + (-yValue * lookRotateSpeed * Time.deltaTime), -30, 30);
        yRot += xValue * lookRotateSpeed * Time.deltaTime;
        zRot = Mathf.Clamp(zRot + (-xValue * lookRotateSpeed * Time.deltaTime), -60, 60);

        transform.eulerAngles = new Vector3(xRot, yRot, zRot);
    }
}
