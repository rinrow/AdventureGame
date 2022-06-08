using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToPlayerAsistantState : AsistantState
{
    private float _speed;
    private Vector2 _direction;

    private void Start()
    {
        _speed = GetComponent<Asistant>().Speed;
    }

    private void OnEnable()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();

        _direction = Player.transform.position - transform.position;

        if (_direction.x <= 0)
            spriteRenderer.flipX = true;
        else
            spriteRenderer.flipX = false;

    }

    private void Update()
    {
        MoveToPlayer();
    }

    private void MoveToPlayer()
    {
        _direction = (Player.transform.position - transform.position).normalized;

        transform.Translate(_direction * Time.deltaTime * _speed);

        if (Animator != null)
            Animator.Play("Running");
        else
            print("Animator == null");
    }
}
