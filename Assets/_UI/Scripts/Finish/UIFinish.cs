using System.Collections;
using System.Collections.Generic;
using _UI.Scripts.UI;
using TMPro;
using UnityEngine;

public class UIFinish : UICanvas
{
    private int coin;
    [SerializeField] private TextMeshProUGUI cointText;
    [SerializeField] private RectTransform x3Point;
    [SerializeField] private RectTransform continuePoint;
    
    public override void Open()
    {
        base.Open();
        GameManager.Instance.ChangeState(GameState.Finish);
    }

    public void x3PointButton()
    {
        GameManager.Instance.ChangeState(GameState.MainMenu);
        
    }
}
