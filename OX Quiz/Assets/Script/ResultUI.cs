using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ResultUI : MonoBehaviour
{
    [SerializeField]
    private Text rightAnswerText;

    [SerializeField]
    private Text commentText;

    [SerializeField]
    private ResultCommentSheet commentSheet;

    private void OnEnable()
    {
        rightAnswerText.text = GameManager.Instance.rightAnswerCount.ToString();

        commentText.text = GetComment(GameManager.Instance.GetSetting().maxQuestionCount, GameManager.Instance.rightAnswerCount);
    }

    public void ReStart()
    {
        GameManager.Instance.GameStart(); // Restart the Game
    }

    public void ReturnMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Restart Current Scene
    }

    private string GetComment(float questionCount, float rightAnswerCount)
    {
        float percentage = rightAnswerCount / questionCount * 100;

        for(int i = 0; i < commentSheet.Count; ++i)
        {
            ResultCommentData commentData = commentSheet.m_data[i];

            if (commentData.percentage <= percentage)
                return commentData.comment;
        }

        return "더 열심히 공부합시다";
    }
}