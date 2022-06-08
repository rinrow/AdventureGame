using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDyingState : State
{
    private void OnEnable()
    {
        StartCoroutine(Dying());
    }

    private IEnumerator Dying()
    {
        var animator = GetComponent<Animator>();

        animator.Play("Death");
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length * 2);
        Destroy(gameObject);
    }
}
