using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : Bar
{
    [SerializeField] private GameObject _healthableObject;

    private IHealthable _healthable;

    private void Awake()
    {
        _healthable = _healthableObject.GetComponent<IHealthable>();

        if (_healthable == null)
            print("_healthable = null");
    }

    private void OnEnable()
    {
        _healthable.HealthChanged += OnValueCanged;
    }

    private void OnDisable()
    {
        _healthable.HealthChanged -= OnValueCanged;
    }
}