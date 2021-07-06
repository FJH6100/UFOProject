using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Target : MonoBehaviour
{
    public Text score;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            int myScore = System.Convert.ToInt32(score.text) + 5;
            score.text = myScore.ToString();
            Destroy(gameObject);
        }
    }
}
