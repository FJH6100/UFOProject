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
        activeForwardSpeed = Mathf.Lerp(activeForwardSpeed, Input.GetAxis("Fly") * forwardSpeed, forwardAccel * Time.deltaTime);
        activeHoriSpeed = Mathf.Lerp(activeHoriSpeed, Input.GetAxis("Horizontal") * horiSpeed, horiAccel * Time.deltaTime);
        activeVertiSpeed = Mathf.Lerp(activeVertiSpeed, Input.GetAxis("Vertical") * vertiSpeed, vertiAccel * Time.deltaTime);

        transform.position += transform.forward * activeForwardSpeed * Time.deltaTime;
        //transform.position += transform.up * activeVertiSpeed * Time.deltaTime;
        //transform.position += transform.right * activeHoriSpeed * Time.deltaTime;

        Rotation(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        if (Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S))
        {
            StartCoroutine(LevelOutXRot());
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        {
            StartCoroutine(LevelOutZRot());
        }
    }

    IEnumerator LevelOutXRot()
    {
        if (xRot < 0)
        {
            while (xRot < 0)
            {
                xRot += .1f;
                yield return null;
            }
        }
        else if (xRot > 0)
        {
            while (xRot > 0)
            {
                xRot -= .1f;
                yield return null;
            }
        }
        xRot = 0f;
    }

    IEnumerator LevelOutZRot()
    {
        if (zRot < 0)
        {
            while (zRot < 0)
            {
                zRot += .1f;
                yield return null;
            }
        }
        else if (zRot > 0)
        {
            while (zRot > 0)
            {
                zRot -= .1f;
                yield return null;
            }
        }
        zRot = 0f;
    }

    void Rotation(float xValue, float yValue)
    {
        xRot = Mathf.Clamp(xRot + (-yValue * lookRotateSpeed * Time.deltaTime), -30, 30);
        yRot += xValue * lookRotateSpeed * Time.deltaTime;
        zRot = Mathf.Clamp(zRot + (-xValue * lookRotateSpeed * Time.deltaTime), -60, 60);

        transform.eulerAngles = new Vector3(xRot, yRot, zRot);
    }
}
