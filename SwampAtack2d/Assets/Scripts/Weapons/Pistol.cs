using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : Weapon
{
    public override void Shoot(ShootPoint shootPoint)
    {
        print("Shot called");
        var projectile = Instantiate(Projectile, shootPoint.transform.position, Quaternion.identity);
        InitProjectile(projectile, shootPoint);
    }
}
