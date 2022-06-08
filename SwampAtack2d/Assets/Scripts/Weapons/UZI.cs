using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UZI : Weapon
{
    [SerializeField] private int _shootsNumber;
    [SerializeField] private float _shootingGup;

    public override void Shoot(ShootPoint shootPoint)
    {
        StartCoroutine(MultiplyShot(shootPoint));
    }

    private IEnumerator MultiplyShot(ShootPoint shootPoint)
    {
        WaitForSeconds wait = new WaitForSeconds(_shootingGup);

        for (int i = 0; i < _shootsNumber; i++)
        {
            var projectile = Instantiate(Projectile, shootPoint.transform.position, Quaternion.identity);
            InitProjectile(projectile, shootPoint);

            yield return wait;
        }
    }
}
