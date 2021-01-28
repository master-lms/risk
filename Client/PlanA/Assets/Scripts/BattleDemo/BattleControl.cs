using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleControl : MonoBehaviour
{
    private static BattleControl _instance;
    public static BattleControl Instance
    {
        get
        {
            if (_instance == null)
                _instance = new BattleControl();
            
            return _instance;
        }
    }

    public void LoadScene()
    {

    }
}
