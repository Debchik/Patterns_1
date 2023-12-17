using UnityEditor;
using UnityEngine;

public class Salesman : MonoBehaviour
{
    [SerializeField] private int _foodReputation;
    [SerializeField] private int _armourReputation;

    private ITradable _tradable;

    private void OnValidate()
    {
        if (_armourReputation < _foodReputation)
            _armourReputation = _foodReputation + 5;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out ITrading trading))
        {
            SetUpTrader(trading);

            _tradable.Trade();
        }
    }

    private void SetUpTrader(ITrading trading)
    {
        if (trading.Reputation >= _armourReputation)
        {
            _tradable = new ArmourTrades();
        }
        else if (trading.Reputation >= _foodReputation)
        {
            _tradable = new FoodTrades();
        }
        else
        {
            _tradable = new NoTrades();
        }
    }
}
