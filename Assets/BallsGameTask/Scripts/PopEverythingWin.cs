using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class PopEverythingWin : IWinConditon
{
    private int _requiredAmount;

    public PopEverythingWin(int requiredAmount)
    {
        _requiredAmount = requiredAmount;
    }

    public bool CheckLooseCondition(IEnumerable<Colors> objects) { return false; }

    public bool CheckWinCondition(IEnumerable<Colors> objects)
    {
        if (objects.Count() == _requiredAmount)
            return true;
        else
            return false;
    }


}
