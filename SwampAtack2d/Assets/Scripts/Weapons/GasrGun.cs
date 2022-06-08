using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GasrGun : Weapon
{
    public override void Shoot(ShootPoint shootPoint)
    {
        var projectile = Instantiate(Projectile, shootPoint.transform.position, Projectile.transform.rotation);
        InitProjectile(projectile, shootPoint);
    }
}
