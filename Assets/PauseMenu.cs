
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    private const float TOGGLE_COOLDOWN_TIME = 0.1f;

    [SerializeField] private GameObject _pauseMenu;
    [SerializeField] private GameObject _gameUI;
    [SerializeField] private MonoBehaviour[] _additionalDisables;
    private bool _paused = false;

    private float _prevTimeScale = 1.0f;

    private float _timeUntilToggleUnlock = 0.0f;

    void Update()
    {
        if (_timeUntilToggleUnlock <= 0.0f) {
            if (Input.GetKeyUp(KeyCode.Escape)) {
                TogglePause();
                _timeUntilToggleUnlock = TOGGLE_COOLDOWN_TIME;
            }
        } else {
            _timeUntilToggleUnlock -= Time.unscaledDeltaTime;
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
