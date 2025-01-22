using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    public GameObject pauseWindow;
    public bool isGamePaused;
    
    void Start()
    {
        pauseWindow.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            isGamePaused = !isGamePaused;
            pauseWindow.SetActive(isGamePaused);
            Time.timeScale = isGamePaused ? 0 : 1;
        }
    }

    public void BackToMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}
