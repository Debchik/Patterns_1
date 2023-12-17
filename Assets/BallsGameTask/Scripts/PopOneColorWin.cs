using System.Collections.Generic;
using System.Linq;

public class PopOneColorWin : IWinConditon
{
    private List<Colors> _balls;

    public PopOneColorWin(IEnumerable<Colors> balls)
    {
        _balls = new List<Colors>(balls);
    }

    public bool CheckLooseCondition(IEnumerable<Colors> objects)
    {
        Colors first = objects.ElementAt(0);

        IEnumerable<Colors> oneColorBallsPopped = objects.Where(obj => obj == first);


        if (oneColorBallsPopped.Count() != objects.Count())
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool CheckWinCondition(IEnumerable<Colors> objects)
    {
        Colors first = objects.ElementAt(0);

        IEnumerable<Colors> oneColorBallsPopped = objects.Where(obj => obj == first);
        IEnumerable<Colors> oneColorBallsGoal = _balls.Where(obj => obj == first);


        if (oneColorBallsGoal.Count() == oneColorBallsPopped.Count())
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
