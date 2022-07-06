using System.Collections.Generic;
using UnityEngine;

/// Enemy generic behavior
public class EnemyScript : MonoBehaviour
{
    private WeaponScript[] weapon;

    private void Awake()
    {
        // Получить оружие только один раз
        weapon = GetComponentsInChildren<WeaponScript>();
    }

    void Update()
    {
        foreach (WeaponScript weapon in weapon)
        {
            // автоматическая стрельба
            if (weapon != null && weapon.CanAttack&&transform.position.x<29)
            {
                weapon.Attack(true);
            }
        }
    }
}
