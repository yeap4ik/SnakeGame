using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour

{
public GameObject Settings;
public IncrementObjectMover mover;

public bool paused = false;
float delay_bckp;
    public void StartGame()
    {
        Invoke ("StartGame2", 0.5f);
    }

    public void StartGame2(){
        SceneManager.LoadScene("SampleScene");
    }



     public void RestartGame()
    {
        Invoke ("RestartGame2", 0.5f);
    }

    public void RestartGame2()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


    public void QuitGame()
    {
        Invoke ("QuitGame2", 0.5f);
    }

    public void QuitGame2()
    {
        Application.Quit();
    }


    public void MainMenu(){
        Invoke ("MainMenu2", 0.5f);
    }
    public void MainMenu2()
    {
        SceneManager.LoadScene("GameMenu");
    }

    public void OpenSettings()
    {
        Settings.SetActive(true);
        paused = true;
        //delay_bckp = mover._delay;
        //mover._delay = 10f;


    }

    public void CloseSettings()
    {
        Settings.SetActive(false);
        paused = false;
        //mover._delay = delay_bckp;
    }

    

}
