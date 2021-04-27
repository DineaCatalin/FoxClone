using UnityEngine;

public class ArrowPool : MonoBehaviour
{
    [SerializeField]
    private int _poolSize;

    [SerializeField]
    private MoveProjectile _arrowTemplate;

    private MoveProjectile[] _arrows;
    private int _currentIndex;

    private readonly Vector3 RIGHT = new Vector3(0, 0, 0);
    private readonly Vector3 LEFT  = new Vector3(0, 0, 180);

    private void Start()
    {
        _arrows = new MoveProjectile[_poolSize];
        for (int i = 0; i < _poolSize; i++)
        {
            _arrows[i] = Instantiate(_arrowTemplate);
            _arrows[i].gameObject.SetActive(false);
        }
    }

    public void FireArrow(Vector3 origin, float direction)
    {
        var arrow = _arrows[_currentIndex];
        arrow.transform.position = origin;
        arrow.gameObject.SetActive(true);
        arrow.SetDirection(direction);

        _currentIndex = (++_currentIndex) % _poolSize;
    }
}
