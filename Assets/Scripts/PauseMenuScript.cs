using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuScript : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    public void OnCompassVisibleChanged(bool value)
    {
        GameState.isCompassVisible = value;
    }
}
