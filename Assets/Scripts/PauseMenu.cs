
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    [SerializeField] private GameObject _pauseMenu;
    [SerializeField] private GameObject _gameUI;
    [SerializeField] private MonoBehaviour[] _additionalDisables;
    public static bool _paused = false;

    private float _prevTimeScale = 1.0f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            TogglePause();
        }
    }

    public void TogglePause()
    {
        _paused = !_paused;
        _gameUI.SetActive(!_paused);
        foreach (MonoBehaviour mb in _additionalDisables) {
            mb.enabled = !_paused;
        }
        _pauseMenu.SetActive(_paused);

        if (_paused) {
            // Pause-specific logic
            _prevTimeScale = Time.timeScale;
            Time.timeScale = 0.0f;
            // The FPS Controller does mouse lock logic, if we disable it then we have to clean up a bit.
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

        } else {
            // Unpause-specific logic
            Time.timeScale = _prevTimeScale;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    public void RestartLevel()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitGame()
    {
        Debug.Log("Game Quit requested!");
        Application.Quit();
    }
}
