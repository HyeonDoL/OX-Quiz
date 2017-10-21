using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance = null;
    public static GameManager Instance
    {
        get
        {
            if (instance)
                return instance;
            else
                return instance = new GameObject("GameManager").AddComponent<GameManager>();
        }
    }

    [SerializeField]
    private Setting setting;

    private int rightAnswerCount;
    private int currentQuestionCount;

    public bool isOsign { get; set; }

    private void Awake()
    {
        rightAnswerCount = 0;
        currentQuestionCount = 0;

        isOsign = false;
    }

    public Setting GetSetting() { return setting; }

    public void NextQuestion()
    {
        QuizManager.Instance.GetQuestion(++currentQuestionCount);
    }
}