using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GasProjectile : Projectile
{
    [SerializeField] private float _lifeTime;
    private float _runningTime;

    private void Start()
    {
        if (Direction != Vector2.right)
            return;

        ParticleSystem particleSystem = GetComponent<ParticleSystem>();

        var shape = particleSystem.shape;

        shape.rotation = new Vector3(0, -90);
    }

    protected override void Flight()
    {
        //Сделать партикл который следует за таргетом
        transform.Translate(Direction * Speed * Time.deltaTime);

        _runningTime += Time.deltaTime;

        if (_runningTime >= _lifeTime)
            Destroy(gameObject);
    }

    protected override void Hit(GameObject hittedObject)
    {
        if (hittedObject.TryGetComponent<Enemy>(out Enemy enemy))
        {
            enemy.ApplyDamage(Damage);
        }
    }
}
