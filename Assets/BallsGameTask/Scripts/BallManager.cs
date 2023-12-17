using System.Collections.Generic;
using UnityEngine;

public enum Colors { RED, GREEN, WHITE}
public class BallManager : MonoBehaviour
{
    [SerializeField] private Colors[] _allColors;

    [SerializeField] private List<Colors> _poppedBalls;
    [SerializeField] private List<Colors> _allBalls;
    [SerializeField] private Ball _ballPrefab;
    [SerializeField] private int _ballCount;

    [SerializeField, Range(0, 10000)] private int _maxWidthPosition;
    [SerializeField, Range(0, 10000)] private int _maxHeightPosition;

    [SerializeField] private GameObject _winWindow;
    [SerializeField] private GameObject _looseWindow;

    private IWinConditon _winConditon;

    public int BallCount => _ballCount;

    public IEnumerable<Colors> AllBalls => _allBalls;

    private void Awake()
    {
        SpawnBalls();
    }

    public void Initialize(IWinConditon winConditon)
    {
        _winConditon = winConditon;
    }

    public void SpawnBalls()
    {
        for (int i = 0; i < _ballCount; i++)
        {
            int randomX = Random.Range(-_maxWidthPosition, _maxWidthPosition);
            int randomY = Random.Range(-_maxHeightPosition, _maxHeightPosition);

            Vector3 spawnPos = new Vector3(randomX, randomY, 0);
            int randomIndex = Random.Range(0, _allColors.Length);

            Ball ball = Instantiate(_ballPrefab, spawnPos, Quaternion.identity);
            ball.Initialize(this, _allColors[randomIndex]);
            _allBalls.Add(ball.BallColor);
        }
    }

    private void CheckWinOrLoose()
    {
        bool loose = _winConditon.CheckLooseCondition(_poppedBalls);
        if (loose)
        {
            Loose();
            return;
        }

        bool win = _winConditon.CheckWinCondition(_poppedBalls);
        if (win)
        {
            Win();
        }
    }

    public void AddPoppedBall(Colors ball)
    {
        _poppedBalls.Add(ball);
        CheckWinOrLoose();
    }

    private void Loose()
    {
        _looseWindow.SetActive(true);
    }

    private void Win()
    {
        _winWindow.SetActive(true);
    }
}
