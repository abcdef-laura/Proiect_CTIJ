using Platformer.Mechanics;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    public int damageAmount = 2;
    public float explosionRadius = 2;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("enemy"))
        {
            var enemy = collision.gameObject.GetComponent<EnemyController>();
            enemy.TakeDamage(damageAmount);
            Destroy(gameObject);
        }

    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
}
