using System;
using System.Collections;
using System.Collections.Generic;
using _Framework.Pool.Scripts;
using _Game.Camera;
using _Game.Scripts.Manager.Level;
using _UI.Scripts.UI;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace _Game.UI.Scripts.Gameplay
{
    public class TargetIndicator : GameUnit
{
    [SerializeField] private RectTransform rect;
    [SerializeField] private RectTransform arrow;
    [SerializeField] private Image imageTxt;
    [SerializeField] private TextMeshProUGUI nameTxt;
    [SerializeField] private TextMeshProUGUI scoreTxt;
    
    [SerializeField] private CanvasGroup canvasGroup;

    private Transform target;
    
    Vector3 screenHalf = new Vector2(Screen.width, Screen.height) / 2; 

    Vector3 viewPoint;

    Vector2 viewPointX = new Vector2(0.075f, 0.925f);
    Vector2 viewPointY = new Vector2(0.05f, 0.85f);
    
    Vector2 viewPointInCameraX = new Vector2(0.07f, 0.92f);
    Vector2 viewPointInCameraY = new Vector2(0.05f, 0.95f);
    
    private UnityEngine.Camera Camera => CameraFollow.Instance.Camera;
    private bool IsInCamera => viewPoint.x > viewPointInCameraX.x && viewPoint.x < viewPointInCameraX.y && viewPoint.y > viewPointInCameraY.x && viewPoint.y < viewPointInCameraY.y;

    public void OnInit()
    {
        SetScore(0);
        SetColor(new Color(UnityEngine.Random.value, UnityEngine.Random.value, UnityEngine.Random.value, 1));
        SetAlpha(GameManager.Instance.IsState(GameState.Gameplay) ? 1 : 0);
    }

    public void SetTarget(Transform target)
    {
        this.target = target;
        OnInit();
    }
    
    public void SetAlpha(float alpha)
    {
        canvasGroup.alpha = alpha;
    }
    
    public void SetColor(Color color)
    {
        imageTxt.color = color;
        nameTxt.color = color;
    }
    
    public void SetScore(int score)
    {
        scoreTxt.SetText(score.ToString());
    }
    
    private void LateUpdate()
    {
        viewPoint = Camera.WorldToViewportPoint(target.position);
        arrow.gameObject.SetActive(!IsInCamera);
        nameTxt.gameObject.SetActive(IsInCamera);

        viewPoint.x = Mathf.Clamp(viewPoint.x, viewPointX.x, viewPointX.y);
        viewPoint.y = Mathf.Clamp(viewPoint.y, viewPointY.x, viewPointY.y);

        Vector3 targetSPoint = Camera.ViewportToScreenPoint(viewPoint) - screenHalf;
        Vector3 playerSPoint = Camera.WorldToScreenPoint(LevelManager.Instance.player.TF.position) - screenHalf;      
        rect.anchoredPosition = targetSPoint;

        arrow.up = (targetSPoint - playerSPoint).normalized;
    }
}
}

