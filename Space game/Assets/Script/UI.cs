using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    private bool _isPause =true;
    [SerializeField] private GameObject _pausePanel;
    [SerializeField] private GameObject _losePanel;
    [SerializeField] private PlayerControl _playerControl;
    [SerializeField] private GameObject _parentMeteorite;
    
    public void Pause()
    {
        if (_isPause)
        {
            _pausePanel.SetActive(true);
            _isPause = false;
            Time.timeScale = 0;
            _parentMeteorite.SetActive(false);
        }
        else
        {
            _isPause = true;
            Resume();
        }
    }
    public void Resume()
    {
        Time.timeScale = 1;
        _pausePanel.SetActive(false);
        _isPause = true;
        _parentMeteorite.SetActive(true);
        
    }
    
    public void Restart()
    {
        SceneManager.LoadScene("Game");
        Time.timeScale = 1;
    }

    public void ShowLosePanel()
    {
        _losePanel.SetActive(true);
        //_textcurentScore.text = "You Score is: \n"+_playerControl.Score;
        _parentMeteorite.SetActive(false);
    }

    
}
