using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AsistantTransition : MonoBehaviour
{
    [SerializeField] private AsistantState _targetState;

    public AsistantState TargetState => _targetState;
    protected Player Player;
    protected Enemy Enemy;

    public bool NeedTransit { get; protected set; }

    private void OnEnable()
    {
        NeedTransit = false;
    }

    public void Init(Player player, Enemy enemy)
    {
        Player = player;
        Enemy = enemy;
    }
}
