using Cysharp.Threading.Tasks;
using UnityEngine;

public class HideProjectile : MonoBehaviour
{
    [SerializeField]
    private float _autoDestructionTime;

    private int _autoDestructionTimeMS;

    private void Awake()
    {
        _autoDestructionTimeMS = (int)_autoDestructionTime * 1000;
    }

    private void OnEnable()
    {
        //DeactivateAsync().Forget();
        Invoke("Deactivate", _autoDestructionTime);
    }

    public void Deactivate()
    {
        gameObject.SetActive(false);
    }

    private async UniTask DeactivateAsync()
    {
        await UniTask.Delay(_autoDestructionTimeMS);

        Deactivate();
    }

}
