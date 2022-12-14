using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManage : MonoBehaviour
{
    
    public void SceneLoad(int n)
    {
        SceneManager.LoadScene(n);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void ToastMessage()
    {
        SSTools.ShowMessage("Loading...", SSTools.Position.top, SSTools.Time.oneSecond);
    }
}
