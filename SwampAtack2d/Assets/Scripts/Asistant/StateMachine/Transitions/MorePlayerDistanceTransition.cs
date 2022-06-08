using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MorePlayerDistanceTransition : AsistantTransition
{
    [SerializeField] private float _distance;

    private void Update()
    {
        if (Vector2.Distance(transform.position, Player.transform.position) >= 6)
            NeedTransit = true;
    }
}
