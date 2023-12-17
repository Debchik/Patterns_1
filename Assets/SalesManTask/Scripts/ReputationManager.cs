using TMPro;
using UnityEngine;

public class ReputationManager : MonoBehaviour
{
    [SerializeField] private TMP_Text _reputationText;

    public void UpdateText(string value)
    {
        _reputationText.text = "Reputation: " + value;
    }

}
