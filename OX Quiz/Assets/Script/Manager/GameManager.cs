using UnityEngine;
using UnityEngine.UI;

public enum GameState : byte
{
    None,
    Main,
    InGame,
    Result
}

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

    private GameState currentGameState;
    public static GameState CurrentGameState
    {
        get { return Instance.currentGameState; }
        set
        {
            if (Instance.currentGameState != value)
            {
                Instance.currentGameState = value;
                OnStateChange(Instance.currentGameState);
            }
        }
    }

    public delegate void StateChangeDelegate(GameState currentGameState);
    public static event StateChangeDelegate OnStateChange;

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

    private int currentQuestionCount;

    public string answer { private set; get; }

    public string isOsign { get; set; }
    public int rightAnswerCount { private set; get; }

    [Header("Sound Effects")]
    [SerializeField] private SoundGroup correctSound;
    [SerializeField] private SoundGroup incorrectSound;

    private AudioSource audioSource;

    private void Awake()
    {
        instance = this;

        CurrentGameState = GameState.None;

        audioSource = gameObject.GetComponent<AudioSource>();
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();
    }

    public void GameStart()
    {
        rightAnswerCount = 0;
        currentQuestionCount = 0;

        isOsign = "O";

        CurrentGameState = GameState.InGame;
        Timer.isStopTimer = false;

        NextQuestion();
    }

    public void GameOver()
    {
        CurrentGameState = GameState.Result;
        Timer.isStopTimer = true;
    }

    public Setting GetSetting() { return setting; }

    public void NextQuestion()
    {
        audioSource.Stop();

        RefereeAnimation();

        CheckRightAnswer();

        AiController.Instance.AnswerDiscriminate();

        if (currentQuestionCount >= setting.maxQuestionCount)
        {
            GameOver();
            return;
        }

        string[] question;

        question = QuizManager.Instance.GetQuestion(currentQuestionCount);

        questionText.text = question[0];
        answer = question[1];

        AiController.Instance.MoveAi();

        currentQuestionCount++;

        indexText.text = currentQuestionCount.ToString() + " / " + setting.maxQuestionCount.ToString();

        audioSource.Play();
    }

    private void CheckRightAnswer()
    {
        if (currentQuestionCount != 0)
        {
            if (isOsign == answer)
            {
                rightAnswerCount++;

                playerBehaviour.Win();

                SoundManager.Play(correctSound);
            }
            else
            {
                SoundManager.Play(incorrectSound);

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