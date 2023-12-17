using UnityEngine;

public class WinConditionBootstrap : MonoBehaviour
{
    [SerializeField] private BallManager _ballManager;

    public void AllBallsCondition()
    {
        IWinConditon winConditon = new PopEverythingWin(_ballManager.BallCount);
        _ballManager.Initialize(winConditon);
    }

    public void OneColorBallsCondition()
    {
        IWinConditon winConditon = new PopOneColorWin(_ballManager.AllBalls);
        _ballManager.Initialize(winConditon);
    }
}
