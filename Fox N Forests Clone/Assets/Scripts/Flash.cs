using UnityEngine;

public class Flash : MonoBehaviour
{
    private const float FLASH_ALPHA = 0.35f;
    private const float MAX_ALPHA   = 1f;

    [SerializeField]
    private float _flashDuration;

    [SerializeField]
    private float _flashRepeatStepDuration;

    [SerializeField]
    private SpriteRenderer _spriteRenderer;

    private void Start()
    {
        if (_spriteRenderer == null)
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }
    }

    public void StartFlash()
    {
        Debug.Log("StartFlash");
        SetAlpha(FLASH_ALPHA);
        Invoke("SetMaxAlpha", _flashDuration);
    }

    public void StartFlashRepeat()
    {
        InvokeRepeating("SetFlashAlpha", 0f, _flashRepeatStepDuration * 2);
        InvokeRepeating("SetMaxAlpha", _flashRepeatStepDuration, _flashRepeatStepDuration * 2);
    }

    public void StopFlashRepeat()
    {
        CancelInvoke();
        SetMaxAlpha();
    }

    private void SetAlpha(float alpha)
    {

        var color = _spriteRenderer.color;
        Debug.Log($"SetAlpha before {color.a}");

        color.a = alpha;
        _spriteRenderer.color = color;
        Debug.Log($"SetAlpha after {color.a}");

    }

    private void SetMaxAlpha()
    {
        SetAlpha(MAX_ALPHA);
    }

    private void SetFlashAlpha()
    {
        SetAlpha(FLASH_ALPHA);
    }
}
