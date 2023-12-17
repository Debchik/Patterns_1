using System.Collections.Generic;

public interface IWinConditon
{
    bool CheckWinCondition(IEnumerable<Colors> objects);

    bool CheckLooseCondition(IEnumerable<Colors> objects);
}
