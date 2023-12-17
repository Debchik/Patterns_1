using UnityEngine;
using UnityEngine.EventSystems;

public class Ball : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private BallManager _ballManager;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private Colors _ballColor;

    public Colors BallColor => _ballColor;

    public void Initialize(BallManager ballManager, Colors ballColor)
    {
        _ballManager = ballManager;
        _ballColor = ballColor; 
        
        switch (ballColor)
        {
            case Colors.WHITE:
                _spriteRenderer.color = Color.white;
                break;
            case Colors.RED:
                _spriteRenderer.color = Color.red;
                break;
            case Colors.GREEN:
                _spriteRenderer.color = Color.green;
                break;

            default: break;
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Clicked");
        _ballManager.AddPoppedBall(_ballColor);
        Destroy(gameObject);
    }
}
