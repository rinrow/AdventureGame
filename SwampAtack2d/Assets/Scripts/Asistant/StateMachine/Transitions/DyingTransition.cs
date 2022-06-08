using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DyingTransition : AsistantTransition
{
    [SerializeField] private Asistant _asistant;

    private void Update()
    {
        if (_asistant.IsDied)
            NeedTransit = true; 
    }
}
