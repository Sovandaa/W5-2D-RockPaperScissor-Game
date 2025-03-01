using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScene : MonoBehaviour
{
    // Load the Game Scene
    public void LoadGameScene()
    {
        SceneManager.LoadScene("GameScene");
    }

    // Load the Menu Scene
    public void LoadStartScene()
    {
        SceneManager.LoadScene("StartScene");
    }
}
