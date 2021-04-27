using UnityEngine;
using Cysharp.Threading.Tasks;

public class PlayerShooting : MonoBehaviour
{
    private const string SHOOT_BUTTON = "Shoot";
    private const string SHOOT_ANIMATION_TRIGGER = "IsShooting";

    [SerializeField]
    private float _shootCooldown;

    [SerializeField]
    private float _shootDelay = 1f;

    [SerializeField]
    private ArrowPool _arrowPool;

    [SerializeField]
    private Animator _animator;

    [SerializeField]
    private CharacterController _controller;

    private int _shootDelayMS;
    private float _activeShootCooldown;

    private void Start()
    {
        _shootDelayMS = (int)_shootDelay * 1000;
        _activeShootCooldown = _shootCooldown;

        if (_arrowPool == null)
        {
            _arrowPool = GameObject.Find("ArrowPool").GetComponent<ArrowPool>();
        }
    }

    private void Update()
    {
        _activeShootCooldown -= Time.deltaTime;

        if (Input.GetButtonDown(SHOOT_BUTTON) && _controller.CanShoot() && _activeShootCooldown < 0)
        {
            _arrowPool.FireArrow(transform.position, transform.localScale.x);
            _animator.SetBool(SHOOT_ANIMATION_TRIGGER, true);
            ExitShoot().Forget();

            _activeShootCooldown = _shootCooldown;
        }
    }

    private async UniTask ExitShoot()
    {
        await UniTask.Delay(_shootDelayMS);
        _animator.SetBool(SHOOT_ANIMATION_TRIGGER, false);
    }
}
