using System.Collections;
using System.Collections.Generic;
using _UI.Scripts.UI;
using UnityEngine;

public class UIVictory : UICanvas
{
    public override void Open()
    {
        base.Open();
        GameManager.Instance.ChangeState(GameState.Victory);
    }

    
}
