using UnityEngine;
using UnityEngine.UI;

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

    [SerializeField]
    private Text questionText;

    [SerializeField]
    private Text indexText;

    [SerializeField]
    private Animator refereeAni;

    [SerializeField]
    private PlayerBehaviour playerBehaviour;

    private int rightAnswerCount;
    private int currentQuestionCount;

    private string answer;

    public string isOsign { get; set; }

    private void Awake()
    {
        instance = this;

        rightAnswerCount = 0;
        currentQuestionCount = 0;

        isOsign = "O";

        NextQuestion();
    }

    public Setting GetSetting() { return setting; }

    public void NextQuestion()
    {
        RefereeAnimation();

        CheckRightAnswer();

        if (currentQuestionCount >= setting.maxQuestionCount)
        {
            // TODO : 결과창 만들기
            return;
        }

        string[] question;

        question = QuizManager.Instance.GetQuestion(currentQuestionCount);

        questionText.text = question[0];
        answer = question[1];

        currentQuestionCount++;

        indexText.text = currentQuestionCount.ToString() + " / " + setting.maxQuestionCount.ToString();
    }

    private void CheckRightAnswer()
    {
        if (currentQuestionCount != 0)
        {
            if (isOsign == answer)
            {
                rightAnswerCount++;

                playerBehaviour.Win();
            }
            else
            {
                // TODO : 틀렸을 때 상황
            }
        }
    }
    private void RefereeAnimation()
    {
        if (currentQuestionCount != 0)
        {
            if (answer == "O")
                refereeAni.SetTrigger("HandUp_Right");

            else
                refereeAni.SetTrigger("HandUp_Left");
        }
    }
}