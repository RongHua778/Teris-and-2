using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameEvents : Singleton<GameEvents>
{
    // public event Action<int> onEventName;
    // public void EventName(int para)
    // {
    //     if (onEventName != null)
    //         onEventName(para);
    // }

    public event Action<int> onTetrominosFalled;
    public void TetrominosFalled(int terisID)
    {
        if (onTetrominosFalled != null)
            onTetrominosFalled(terisID);
    }

    
}
