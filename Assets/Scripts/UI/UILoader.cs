using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UILoader : MonoBehaviour
{
    private const string SceneName = "HUD";
    
    void OnEnable()
    {
        SceneManager.LoadSceneAsync(SceneName, LoadSceneMode.Additive);
    }

    private void OnDisable()
    {
        SceneManager.UnloadSceneAsync(SceneName);
    }
}
