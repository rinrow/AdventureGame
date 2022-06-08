using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamagable
{
    public bool IsDied { get;  set; }

    public void ApplyDamage(int damage);
}
