using TMPro;
using UnityEngine;

public class DistanceView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _distanceText;

    public void SetDistance(float distance)
    {
        _distanceText.text = $"Distance: {distance:F2}";
    }
}