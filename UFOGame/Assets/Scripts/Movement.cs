using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float forwardSpeed = 20f;
    public float horiSpeed = 10f;
    public float vertiSpeed = 10f;
    private float activeForwardSpeed, activeHoriSpeed, activeVertiSpeed;
    public float forwardAccel = 20f;
    public float horiAccel = 10f;
    public float vertiAccel = 10f;
    public float lookRotateSpeed = 90f;
    float xRot = 0f, yRot = 0f, zRot = 0f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        activeForwardSpeed = Mathf.Lerp(activeForwardSpeed, Input.GetAxisRaw("Fly") * forwardSpeed, forwardAccel * Time.deltaTime);
        activeHoriSpeed = Mathf.Lerp(activeHoriSpeed, Input.GetAxisRaw("Horizontal") * horiSpeed, horiAccel * Time.deltaTime);
        activeVertiSpeed = Mathf.Lerp(activeVertiSpeed, Input.GetAxisRaw("Vertical") * vertiSpeed, vertiAccel * Time.deltaTime);

        transform.position += transform.forward * activeForwardSpeed * Time.deltaTime;
        //transform.position += transform.up * activeVertiSpeed * Time.deltaTime;
        //transform.position += transform.right * activeHoriSpeed * Time.deltaTime;

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
