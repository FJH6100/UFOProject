using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMovement : MonoBehaviour
{
    private enum State
    {
        Idle,
        Chase,
        Shoot
    }
    private float speed = 20f;
    private State state;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        state = State.Idle;
    }

    // Update is called once per frame
    void Update()
    {
        switch(state)
        {
            case State.Idle:
                Idle();
                Debug.Log("I'm idle");
                break;
            case State.Chase:
                Chase();
                Debug.Log("I'm chasing");
                break;
            case State.Shoot:
                Shoot();
                Debug.Log("I'm shooting");
                break;
        }
    }

    void Idle()
    {
        if (Vector3.Distance(transform.position, player.transform.position) <= 100)
            state = State.Chase;
    }
    void Chase()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        if (Vector3.Distance(transform.position, player.transform.position) <= 40)
            state = State.Shoot;
        if (Vector3.Distance(transform.position, player.transform.position) > 100)
            state = State.Idle;
    }
    void Shoot()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed / 2 * Time.deltaTime);
        if (Vector3.Distance(transform.position, player.transform.position) > 40)
            state = State.Chase;
    }
}
