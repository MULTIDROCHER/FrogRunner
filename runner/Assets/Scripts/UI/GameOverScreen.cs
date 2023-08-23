using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(CanvasGroup))]
public class GameOverScreen : MonoBehaviour
{
    [SerializeField] private Button _restartBtn;
    [SerializeField] private Button _exitBtn;
    [SerializeField] private Player _player;

    private CanvasGroup _gameOverScreen;

    private void OnEnable()
    {
        _player.Died += OnPlayerDied;
    }

    private void OnDisable()
    {
        _player.Died -= OnPlayerDied;
    }

    private void Start()
    {
        _gameOverScreen = GetComponent<CanvasGroup>();
        _restartBtn.onClick.AddListener(Restart);
        _exitBtn.onClick.AddListener(Exit);
        _gameOverScreen.alpha = 0;
    }

    private void OnPlayerDied()
    {
        _gameOverScreen.alpha = 1;
        Time.timeScale = 0;
    }

    private void Restart()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }

    private void Exit()
    {
        Application.Quit();
    }
}