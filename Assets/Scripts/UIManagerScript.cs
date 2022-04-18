using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManagerScript : MonoBehaviour
{
    //All Menu UI
    [SerializeField] private Image _menuImage;

    //Main Menu UI
    [SerializeField] private Button _playButton;
    [SerializeField] private Button _gameResultsButton;

    //Score Menu UI
    [SerializeField] private TextMeshProUGUI _highScoreText;
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private Button _backToMainMenuButton;
    [SerializeField] private TextMeshProUGUI _winLoseText;

    private readonly DataManager dataManager = new DataManager();

    public static UIManagerScript Instance { get; private set; }
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    private void Start()
    {
        Time.timeScale = 0;
    }

    public void StartGame()
    {
        SetUpDataManager();
        OnWin();
        OnDefeat(); 
        ManageUI();
        Time.timeScale = 1;
    }

    private void SetUpDataManager()
    {
        dataManager.SetUpScoreUpdater();
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
        // Or save players Vector3 startPos and teleport there
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void ShowHighScore()
    {
        ManageUI();
        _highScoreText.text = PlayerPrefs.GetFloat("HighScore").ToString();
        _menuImage.gameObject.SetActive(true);
        _highScoreText.gameObject.SetActive(true);
        _backToMainMenuButton.gameObject.SetActive(true);
    }

    public void ShowScore()
    {
        ManageUI();
        _scoreText.text = PlayerPrefs.GetFloat("Score").ToString();
        _menuImage.gameObject.SetActive(true);
        _scoreText.gameObject.SetActive(true);
        _backToMainMenuButton.gameObject.SetActive(true);
    }

    private void ManageUI()
    {
        Time.timeScale = 0;
        RemoveAllUI();
    }

    private void RemoveAllUI()
    {
        _menuImage.gameObject.SetActive(false);
        _playButton.gameObject.SetActive(false);
        _gameResultsButton.gameObject.SetActive(false);
        _scoreText.gameObject.SetActive(false);
        _backToMainMenuButton.gameObject.SetActive(false);
        _winLoseText.gameObject.SetActive(false);
        _scoreText.gameObject.SetActive(false);
    }


    public delegate void OnWinLoseEventHandler();

    //Defeat
    public void Defeat()
    {
        OnDefeat();
        ShowScore();
        _winLoseText.gameObject.SetActive(true);
        _winLoseText.text = "Вы проиграли";
    }

    public event OnWinLoseEventHandler GameLost;
    protected virtual void OnDefeat()
    {
        GameLost?.Invoke();
    }

    //Win
    public void Win()
    {
        OnWin();
        ShowScore();
        _winLoseText.gameObject.SetActive(true);
        _winLoseText.text = "Вы выиграли";
    }

    public event OnWinLoseEventHandler GameWon;
    protected virtual void OnWin()
    {
        GameWon?.Invoke();
    }
}