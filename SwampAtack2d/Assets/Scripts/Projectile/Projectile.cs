using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Projectile : MonoBehaviour
{
    [SerializeField] protected int Damage;
    [SerializeField] protected float Speed;

    protected Vector2 Direction;

    private void Update()
    {
        Flight();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Hit(collision.gameObject);
    }

    public void Init(Vector2 direction)
    {
        Direction = direction;
    }

    protected abstract void Hit(GameObject hittedObject);
    protected abstract void Flight();
}
