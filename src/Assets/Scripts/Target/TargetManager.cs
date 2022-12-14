using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetManager : MonoBehaviour
{
    LevelManager levelManager = null;
    TargetMovement targetMovement = null;
    [SerializeField] Animator animator;
    bool dead = false;
    bool notified = false;

    void Start()
    {
        GameObject obj = GameObject.Find("LevelManager");
        if (obj != null)
        {
            levelManager = obj.GetComponent<LevelManager>();
        }
        targetMovement = GetComponent<TargetMovement>();
    }

    void Update()
    {
        if (dead)
        {
            NotifyLevelManager();
        }
    }

    public void LaserHit()
    {
        if (!notified)
        {
            StartCoroutine(Die());
        }
    }

    IEnumerator Die()
    {
        notified = true;

        animator.SetTrigger("Die");

        if (targetMovement != null)
        {
            targetMovement.Dead();
        }

        yield return new WaitForSeconds(3);

        dead = true;
    }

    void NotifyLevelManager()
    {
        if (levelManager == null)
        {
            Debug.Log("Couldn't find LevelManager");
            return;
        }

        levelManager.TargetReached();
    }
}
