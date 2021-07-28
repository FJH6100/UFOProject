using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    public Text score;
    public GameObject player;
    public GameObject bullet;
    float fireTimer = 0f;
    // Start is called before the first frame update
    void Start()
    {
        state = State.Idle;
    }

    // Update is called once per frame
    void Update()
    {
        // Determine which direction to rotate towards
        Vector3 targetDirection = player.transform.position - transform.position;

        // The step size is equal to speed times frame time.
        float singleStep = .5f * Time.deltaTime;

        // Rotate the forward vector towards the target direction by one step
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 0.0f);

        // Calculate a rotation a step closer to the target and applies rotation to this object
        transform.rotation = Quaternion.LookRotation(newDirection);
        switch (state)
        {
            case State.Idle:
                Idle();
                break;
            case State.Chase:
                Chase();
                break;
            case State.Shoot:
                Shoot();
                break;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            int myScore = System.Convert.ToInt32(score.text) + 10;
            score.text = myScore.ToString();
            AchievementSystem.enemyAchievement.Invoke();
            Destroy(gameObject);
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
        fireTimer += Time.deltaTime;
        if (fireTimer >= 1f)
        {
            //Instantiate(bullet, transform.position, transform.rotation * Quaternion.Euler(0, transform.rotation.y, 0));
            fireTimer = 0f;
        }
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed / 2 * Time.deltaTime);
        if (Vector3.Distance(transform.position, player.transform.position) > 40)
            state = State.Chase;
    }
}
