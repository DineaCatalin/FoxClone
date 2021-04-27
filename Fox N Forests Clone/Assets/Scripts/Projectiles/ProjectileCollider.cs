using UnityEngine;

public class ProjectileCollider : MonoBehaviour
{
    private const string EMENY_TAG = "Enemy";

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == EMENY_TAG)
        {
            var enemyHealth = collision.gameObject.GetComponent<EnemyHealth>();
            enemyHealth.Damage();
        }

        gameObject.SetActive(false);
    }
}
