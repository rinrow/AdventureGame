using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public abstract class AsistantState : MonoBehaviour
{
    [SerializeField] private List<AsistantTransition> _asistantTransitions;

    protected Player Player;
    protected Enemy Enemy;

    protected Animator Animator;

    private void Awake()
    {
        Animator = GetComponent<Animator>();
    }

    public void Enter(Player player, Enemy enemy)
    {
        if (enabled == false)
        {
            Player = player;
            Enemy = enemy;

            enabled = true;

            foreach (var transition in _asistantTransitions)
            {
                transition.enabled = true;
                transition.Init(Player, Enemy);
            }
        }
    }

    public void Exit()
    {
        if (enabled == true)
        {
            foreach (var transition in _asistantTransitions)
                transition.enabled = false;

            enabled = false;
        }
    }

    public AsistantState GetNext()
    {
        foreach (var transition in _asistantTransitions)
        {
            if (transition.NeedTransit)
                return transition.TargetState;
        }

        return null;
    }
}
