using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class QuizManager : MonoBehaviour
{
    [SerializeField]
    private Text questionText;

    const int question = 0;
    const int answer = 1;

    private int questionCount;
    private List<string[]> quizList;

    private void Awake()
    {
        quizList = Parser.Parse("QuizList");

        questionCount = 0;

        questionText.text = quizList[questionCount][question];
    }
}