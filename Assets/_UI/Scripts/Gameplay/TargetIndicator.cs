using _Framework.Pool.Scripts;
using _Game.Camera;
using _Game.Scripts.Manager.Level;
using _UI.Scripts.UI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _Game.UI.Scripts.Gameplay
{
    public class TargetIndicator : GameUnit
{
    [SerializeField] private RectTransform rect;
    [SerializeField] private Image arrow;
    [SerializeField] private Image imgIcon;
    [SerializeField] private RectTransform direct;
    [SerializeField] private TextMeshProUGUI nameTxt;
    [SerializeField] private TextMeshProUGUI scoreTxt;
    
    [SerializeField] private CanvasGroup canvasGroup;

    private Transform target;
    
    Vector3 screenHalf = new Vector2(Screen.width, Screen.height) / 2; 

    Vector3 viewPoint;

    Vector2 viewPointX = new Vector2(0.075f, 0.925f);
    Vector2 viewPointY = new Vector2(0.05f, 0.85f);
    
    Vector2 viewPointInCameraX = new Vector2(0.075f, 0.925f);
    Vector2 viewPointInCameraY = new Vector2(0.05f, 0.95f);

    UnityEngine.Camera Camera => CameraFollow.Instance.Camera;

    private bool IsInCamera => viewPoint.x > viewPointInCameraX.x && viewPoint.x < viewPointInCameraX.y && viewPoint.y > viewPointInCameraY.x && viewPoint.y < viewPointInCameraY.y;

    public string Name => nameTxt.text;

    private void LateUpdate()
    {
        viewPoint = Camera.WorldToViewportPoint(target.position);
        arrow.gameObject.SetActive(!IsInCamera);
        nameTxt.gameObject.SetActive(IsInCamera);

        if (viewPoint.z < 0)
        {
            viewPoint *= -1;
        }

        viewPoint.x = Mathf.Clamp(viewPoint.x, viewPointX.x, viewPointX.y);
        viewPoint.y = Mathf.Clamp(viewPoint.y, viewPointY.x, viewPointY.y);

        Vector3 targetSPoint = Camera.ViewportToScreenPoint(viewPoint) - screenHalf;
        Vector3 playerSPoint = Camera.WorldToScreenPoint(LevelManager.Instance.Player.TF.position) - screenHalf;
        rect.anchoredPosition = targetSPoint;

        SetMoveDirect(targetSPoint, playerSPoint, !IsInCamera);
    }
    
    private void SetMoveDirect(Vector3 targetSPoint, Vector3 playerSPoint, bool isMove)
    {
        direct.up = (targetSPoint - playerSPoint).normalized * (isMove ? 1 : 0);
    }

    private void OnInit()
    {
        //SetScore(0);
        SetColor(new Color(Random.value, Random.value, Random.value, 1));
        SetAlpha(GameManager.Instance.IsState(GameState.Gameplay) ? 1 : 0);
    }

    #region SetComponent
    public void SetTarget(Transform target)
    {
        this.target = target;
        OnInit();
    }

    public void SetScore(int score)
    {
        scoreTxt.text = score.ToString();
    }

    public void SetName(string name)
    {
        nameTxt.text = name;
    }

    private void SetColor(Color color)
    {
        imgIcon.color = color;
        nameTxt.color = color;
    }

    public void SetAlpha(float alpha)
    {
        canvasGroup.alpha = alpha;
    }
    #endregion
}
}

