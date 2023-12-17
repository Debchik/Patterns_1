using UnityEngine;

public class NoTrades : ITradable
{
    public void Trade()
    {
        Debug.Log("I do not trade anything for guys like you. Improve your reputation and come back");
    }
}
