using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int waveAmount = 16;
    
    //Implement if wanting a singleton pattern but only doing one level for a basic game
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RegisterKill(int kill)
    {
        waveAmount -= kill;
        if(waveAmount == 0)
        {
            StartCoroutine(WaitToEndGame());
        }
    }

    public void LoadGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void GameOver()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        SceneManager.LoadScene("Lose Game");
    }

    public void WinGame()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        SceneManager.LoadScene("Win Game");
    }

    public void ReplayGame()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    IEnumerator WaitToEndGame()
    {
        yield return new WaitForSeconds(3);
        WinGame();
    }
}
