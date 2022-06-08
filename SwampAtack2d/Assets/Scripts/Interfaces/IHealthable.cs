using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface IHealthable
{
    public event Action<int, int> HealthChanged;
}
