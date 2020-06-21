using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponStats : MonoBehaviour
{
    [SerializeField]
    public float damage = 30f;
    [SerializeField]
    public float range = 500f;
    [SerializeField]
    public float damageFallOff = 1f;
}
