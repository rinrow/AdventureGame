using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : Projectile
{
    protected override void Flight()
    {
        transform.Translate(Direction * Speed * Time.deltaTime);
    }

    protected override void Hit(GameObject hittedObject)
    {
        if (hittedObject.TryGetComponent<Enemy>(out Enemy enemy))
        {
            enemy.ApplyDamage(Damage);
            Destroy(gameObject);
        }
    }
}
