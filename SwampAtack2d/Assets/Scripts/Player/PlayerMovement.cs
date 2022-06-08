using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;

    private SpriteRenderer _spriteRenderer;

    public event Action<Vector2> PlayerTurned;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        Move();
    }

    private void Move()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");

        transform.Translate(Vector2.right * horizontal * Time.deltaTime * _speed);

        if (horizontal < 0)
        {
            _spriteRenderer.flipX = true;
            PlayerTurned?.Invoke(Vector2.left);
        }
        else if (horizontal > 0)
        {
            _spriteRenderer.flipX = false;
            PlayerTurned?.Invoke(Vector2.right);
        }
    }

    private void Jump()
    {
        //сдклать прыжок
    }
}
