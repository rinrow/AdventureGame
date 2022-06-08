using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandWithPlayerState : AsistantState
{
    private void Update()
    {
        Animator.Play("Idle");

        print("HeroKnight_Idle");
    }
}
