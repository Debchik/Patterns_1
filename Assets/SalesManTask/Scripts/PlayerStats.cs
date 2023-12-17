using System;
using UnityEngine;

public class PlayerStats : MonoBehaviour, ITrading
{
    [SerializeField] private ReputationManager _reputationManager;

    [SerializeField, Range(0, 100000)] private int _money = 0;
    [SerializeField, Range(0, 100000)] private int _reputation = 0;

    public int MoneyAvailible => _money;

    public int Reputation => _reputation;

    private void Start()
    {
        _reputation = 0;
        _reputationManager.UpdateText(_reputation.ToString());  
    }

    public void IncreaseReputation(int value)
    {
        if (value < 0)
            throw new ArgumentOutOfRangeException(nameof(value));

        _reputation += value;
        _reputationManager.UpdateText(_reputation.ToString());
    }

    public void DecreaseReputation(int value)
    {
        if (value > 0)
            throw new ArgumentOutOfRangeException(nameof(value));

        _reputation -= value;
        _reputationManager.UpdateText(_reputation.ToString());
    }
}
