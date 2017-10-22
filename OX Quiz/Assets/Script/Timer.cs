using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField]
    private TextMesh timeText;

    private float maxTime;
    private float currentTime;

    public static bool isStopTimer { set; get; }

    private void Start()
    {
        maxTime = GameManager.Instance.GetSetting().maxLimitTime;

        currentTime = 0f;

        timeText.text = ((int)(maxTime - currentTime)).ToString();

        isStopTimer = false;
    }

    private void Update()
    {
        if (isStopTimer)
            return;

        currentTime += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space))
            currentTime = maxTime;

        if(currentTime >= maxTime)
        {
            GameManager.Instance.NextQuestion();

            currentTime = 0f;
        }

        timeText.text = ((int)(maxTime - currentTime)).ToString();
    }
}