using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelDoor : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        var player = other.GetComponent<PlayerOnMoveManager>();
        if (player != null)
        {
            var _uiManager = FindObjectOfType<UIManager>();
            _uiManager.OpenRestartMenu();
        }

        return;
            
    }
}
