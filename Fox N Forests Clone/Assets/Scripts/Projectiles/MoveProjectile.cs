using Cysharp.Threading.Tasks;
using UnityEngine;

public class MoveProjectile : MonoBehaviour
{
    private readonly Vector3 DIRECTION_RIGHT = new Vector3(1 , 0, 0);
    private readonly Vector3 DIRECTION_LEFT  = new Vector3(-1, 0, 0);
    private readonly Vector3 GRAPHICS_RIGHT  = new Vector3(0 , 0, 0);
    private readonly Vector3 GRAPHICS_LEFT   = new Vector3(0 , 0, 180);

    [SerializeField]
    private float _projectileSpeed;

    private Vector3 _direction;

    public void SetDirection(float direction)
    {
        _direction = direction == 1 ? DIRECTION_RIGHT : DIRECTION_LEFT;
        transform.eulerAngles = direction == 1 ? GRAPHICS_RIGHT : GRAPHICS_LEFT;
    }

    private void Update()
    {
        transform.position += _projectileSpeed * Time.deltaTime * _direction;
    }
}
