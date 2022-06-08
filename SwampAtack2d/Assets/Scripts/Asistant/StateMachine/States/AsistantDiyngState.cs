using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsistantDiyngState : AsistantState
{
    private void OnEnable()
    {
        Animator.Play("Death");

        StartCoroutine(Death());
    }

    IEnumerator Death()
    {
        yield return new WaitForSeconds(Animator.GetCurrentAnimatorStateInfo(0).length);
        Destroy(gameObject);
    }
}
