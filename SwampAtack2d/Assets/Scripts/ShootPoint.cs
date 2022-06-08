using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootPoint : MonoBehaviour
{
    [SerializeField] private PlayerMovement _playerMovement;

    public Vector2 PlayerDirection { get; private set; } = Vector2.right;

    private void OnEnable()
    {
        _playerMovement.PlayerTurned += ChangeShootPosition;
    }

    private void OnDisable()
    {
        _playerMovement.PlayerTurned -= ChangeShootPosition;
    }

    private void ChangeShootPosition(Vector2 playerDirection)
    {
        Vector3 deltaPosition = new Vector3(playerDirection.x, 0.5f, 0);
        transform.position = _playerMovement.transform.position + deltaPosition;

        PlayerDirection = playerDirection;
    }
}
