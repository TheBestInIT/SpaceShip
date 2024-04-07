using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private bool _LeftPressed;
    private bool _RightPressed;
    [SerializeField] private GameObject _spaceShip;
    private Rigidbody2D _rb;
    private float _moveSpeed;
    private float _speed = 3;
    private float _leftBound = -4f; 
    private float _rightBound = 4f;
    private int _score;
    private int _bestScore;
    public TextMeshProUGUI textScore;
    public TextMeshProUGUI textBestScore;
    [SerializeField] private UI _ui;
    private const string BESTSCORE = "bestScore";
    [SerializeField] private SpawnMeteorite _spawnMeteorite;
    [SerializeField] private Animator _animator;
    public int Score
    {
        get { return _score; }
        set
        {
            _score = Mathf.Clamp(value, 0, 10000); // Обмеження від 0 до 10 000
            ChangeScore();
        }
    }
    void Start()
    {
        _bestScore = PlayerPrefs.GetInt(BESTSCORE,0);
        textBestScore.text = "Best record: \n "+_bestScore;
        _LeftPressed = false;
        _rb = _spaceShip.GetComponent<Rigidbody2D>();
        ChangeScore();
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.name);
        if (other.tag == "Enemy")
        {
            Time.timeScale = 0;
            if (_bestScore < _score)
            {
                _bestScore = _score;
                PlayerPrefs.SetInt(BESTSCORE, _bestScore);
                PlayerPrefs.Save();
            }

            _ui.ShowLosePanel();
        }
    }

    public void ChangeScore(int point)
    {
        _score += point;
        textScore.text = "Score: " + _score ;
        if (_bestScore > _score)
        {
            textBestScore.text = "Best record: \n "+_bestScore;

        }
        else
        {
            textBestScore.text = "New record: \n "+_score;
        }

        if (_score > 20)
        {
            _spawnMeteorite.time = 1.5f;
        }else if (_score > 100)
        {
            _spawnMeteorite.time = 1.0f;
        }else if (_score > 300)
        {
            _spawnMeteorite.time = 1.0f;
        }
    }

    public void ChangeScore()
    {
        textScore.text = "Score: " + _score ;
    }


    #region MovementR/L
    
    void FixedUpdate()
    {
        if (_LeftPressed)
        {
            Move(-_speed);
        }
        else if (_RightPressed)
        {
            Move(_speed);
        }
    }

    public void UPLeft()
    {
        _LeftPressed = false;
        _animator.Play("fromLeft");
    }

    public void DOWNLeft()
    {
        _LeftPressed = true;
        _animator.Play("left");
    }

    public void UPRight()
    {
        _RightPressed = false;
        _animator.Play("fromRight");
    }

    public void DOWNRight()
    {
        _RightPressed = true;
        _animator.Play("right");
    }

    public void Move(float speed)
    {
        float newXPosition = _rb.position.x + speed * Time.fixedDeltaTime;
        newXPosition = Mathf.Clamp(newXPosition, _leftBound, _rightBound);

        _rb.position = new Vector2(newXPosition, _rb.position.y);
    }
    #endregion
}