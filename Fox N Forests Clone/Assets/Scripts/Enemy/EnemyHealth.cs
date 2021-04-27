using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    private const string DIE_ANIMATION_TRIGGER = "Die";
    private const int NON_INTERACTABLE_LAYER = 12;

    [SerializeField]
    private int _HP;

    [SerializeField]
    private Animator _animator;

    [SerializeField]
    private EnemyMovement _enemyMove;


    public void Damage()
    {
        _HP--;
        if(_HP <= 0)
        {
            PrepareDeath();
        }
    }

    private void PrepareDeath()
    {
        Debug.Log("EnemyHealth Die");
        _animator.SetTrigger(DIE_ANIMATION_TRIGGER);
        _enemyMove.enabled = false;
        gameObject.layer = NON_INTERACTABLE_LAYER;
    }

    public void Die()
    {
        // In production code the enemy would come from a pull of enemies and instead of it being destroyed
        // it would be inactivated and sent back to the pull. For the simplicity of the demo we will just 
        // destroy the enemy when HP is 0
        Destroy(gameObject);
    }
}
