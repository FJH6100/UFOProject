using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AchievementSystem : MonoBehaviour
{
    int shootCount = 0;
    int ringCount = 0;
    public delegate void ShootAchievement();
    public static ShootAchievement shootAchievement;
    public delegate void RingAchievement();
    public static RingAchievement ringAchievement;
    public delegate void EnemyAchievement();
    public static EnemyAchievement enemyAchievement;
    public Text panelText;
    // Start is called before the first frame update
    void Start()
    {
        shootAchievement = IncreaseShot;
        ringAchievement = RingPass;
        enemyAchievement = DestroyEnemy;
    }

    // Update is called once per frame
    void Update()
    {
        //shootAchievement?.Invoke();
    }

    private void IncreaseShot()
    {
        shootCount++;
        Debug.Log("Shoot");
        if (shootCount == 5)
            DisplayAchievement("Shot 5 times");
        if (shootCount == 10)
            DisplayAchievement("Shot 10 times");
        if (shootCount == 20)
            DisplayAchievement("Shot 20 times");
    }
    
    private void RingPass()
    {
        ringCount++;
        Debug.Log("Ring");
        if (ringCount == 1)
            DisplayAchievement("Passed through one ring");
        if (ringCount == 3)
            DisplayAchievement("Passed through three rings");
        if (ringCount == 5)
            DisplayAchievement("Passed through five rings");
    }
    private void DestroyEnemy()
    {
        DisplayAchievement("Enemy destroyed");
    }

    private void DisplayAchievement(string s)
    {
        panelText.gameObject.SetActive(true);
        panelText.text = s;
        StartCoroutine("Wait");
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(2f);
        panelText.gameObject.SetActive(false);
    }
}
