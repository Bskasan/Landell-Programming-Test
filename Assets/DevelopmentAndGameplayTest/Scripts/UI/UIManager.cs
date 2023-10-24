using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] private string _levelName;
    [SerializeField] private GameObject _uiPanel;

    public string LevelName => _levelName;

    public void LoadLevel()
    {
        SceneManager.LoadScene(_levelName);
    }


    public void OpenRestartMenu()
    {
        _uiPanel.SetActive(true);
    }
}
