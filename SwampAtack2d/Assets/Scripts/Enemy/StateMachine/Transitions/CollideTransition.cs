using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollideTransition : EnemyTransition
{
    public Collider2D Collision { get; private set; }
    public IDamagable Damagable { get; private set; }
    public GameObject CollidedObject { get; private set; }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<IDamagable>(out IDamagable damagable) &&
            !collision.TryGetComponent<Enemy>(out Enemy enemy))
        {
            Collision = collision;
            Damagable = damagable;
            CollidedObject = collision.gameObject;

            print("Collide with IDamagable");

            NeedTransit = true;
        }
    }
}
