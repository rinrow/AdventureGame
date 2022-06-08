using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Asistant))]
public class AsistantStateMachine : MonoBehaviour
{
    [SerializeField] private AsistantState _firstState;

    private Enemy _currentEnemy;
    private Player _player;
    private AsistantState _currentState;

    private void Start()
    {
        Asistant asistant = GetComponent<Asistant>();

        _player = asistant.Player;

        Reset(_firstState);
    }

    private void Update()
    {
        if (_currentState == null)
            return;

        _currentEnemy = CurrentEnemy.GetCurrentEnemy();

        AsistantState next = _currentState.GetNext();

        if (next != null)
            Transition(next);
    }

    private void Transition(AsistantState nextState)
    {
        _currentState.Exit();

        _currentState = nextState;

        _currentState.Enter(_player, _currentEnemy);
    }

    private void Reset(AsistantState state)
    {
        if (state == null)
            return;

        _currentState = state;

        _currentState.Enter(_player, _currentEnemy);
    }
}
