using UnityEngine;

public class CharacterCollider : MonoBehaviour
{
    private const string ENEMY_TAG = "Enemy";

    [SerializeField]
    private float _knockbackForce;

    [SerializeField]
    private CharacterController _controller;

    [SerializeField]
    private PlayerInvulnerability _invulnerability;

    private Vector2 knockbackRight = new Vector2(2.5f, 1f);
    private Vector2 knockbackLeft  = new Vector2(-2.5f, 1f);


    private void Start()
    {
        knockbackRight *= _knockbackForce;
        knockbackLeft *= _knockbackForce;

        if (_controller == null)
        {
            _controller = GetComponent<CharacterController>();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag.Equals(ENEMY_TAG))
        {
            // Here we would also use a component for handling player damage to damage the player but for this demo we will not do that
            //_playerHealth.Damage();

            _invulnerability.Activate();

            var forceVector = transform.position.x - collision.transform.position.x <= 0 ? knockbackLeft : knockbackRight;
            _controller.AddForce(forceVector);
        }
    }
}
