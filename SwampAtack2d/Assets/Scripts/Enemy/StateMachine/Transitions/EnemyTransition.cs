using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyTransition : MonoBehaviour
{
    //Transition - проверка(проверяльщик)

    //Следуещее состояние а не то которое сейчас
    [SerializeField] private State _targetState;

    public Player Target { get; protected set; }
    public State TargetState => _targetState;

    public bool NeedTransit { get; protected set; }

    public void Init(Player target)
    {
        Target = target;
    }

    private void OnEnable()
    {
        NeedTransit = false;
    }
}
