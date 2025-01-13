using Platformer.Mechanics;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Platformer.Gameplay;
using static Platformer.Core.Simulation;
using JetBrains.Annotations;
using System;

public class Bullet : MonoBehaviour
{
    public int damageAmount = 1;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("enemy"))
        {
            var enemy = collision.gameObject.GetComponent<EnemyController>();
            enemy.TakeDamage(damageAmount);
            Destroy(gameObject);
        }
    }

    public static implicit operator Bullet(GameObject v)
    {
        throw new NotImplementedException();
    }
}
