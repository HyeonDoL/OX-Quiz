using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField]
    private Text timeText;

    private float maxTime;
    private float currentTime;

    private void Start()
    {
        maxTime = GameManager.Instance.GetSetting().maxLimitTime;

        currentTime = 0f;
    }

    private void Update()
    {
        currentTime += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space))
            currentTime = maxTime;

        if(currentTime >= maxTime)
        {
            GameManager.Instance.NextQuestion();

            currentTime = 0f;
        }

        timeText.text = (maxTime - currentTime).ToString();
    }
}