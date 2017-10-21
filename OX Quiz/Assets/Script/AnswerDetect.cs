using UnityEngine;

public enum AnswerType
{
    O,
    X
}

public class AnswerDetect : MonoBehaviour
{
    [SerializeField]
    private AnswerType answer;

    private string isOsign;

    private void Awake()
    {
        isOsign = (answer == AnswerType.O) ? "O" : "X";
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
            GameManager.Instance.isOsign = isOsign;
    }
}