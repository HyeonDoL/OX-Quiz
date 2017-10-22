using UnityEngine;
using UnityEngine.UI;

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
        rightAnswerText.text = GameManager.Instance.currentQuestionCount.ToString();

        // TODO : Sheet에서 공식에 따라 도출된 값으로 ResultCommentData 시트 찾아와서 안에 들어있는 Comment 텍스트를 commentText.text에 넣어주기
    }

    public void ReStart()
    {
        // TODO : ReStart 버튼을 눌렀을 시 실행될 코드
    }

    public void ReturnMenu()
    {
        // TODO : Menu 버튼을 눌렀을 시 실행될 코드
    }
}