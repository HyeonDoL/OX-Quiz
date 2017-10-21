using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class QuizManager : MonoBehaviour
{
    private static QuizManager instance = null;
    public static QuizManager Instance
    {
        get
        {
            if (instance)
                return instance;
            else
                return instance = new GameObject("QuizManager").AddComponent<QuizManager>();
        }
    }

    private List<string[]> quizList;

    private void Awake()
    {
        instance = this;

        quizList = Parser.Parse("QuizList");
    }

    public string[] GetQuestion(int index)
    {
        return quizList[index];
    }

    public void ShuffleList()
    {
        for (int i = quizList.Count - 1; i > 0; i--)
        {
            int r = Random.Range(0, i);
            string[] tmp = quizList[i];
            quizList[i] = quizList[r];
            quizList[r] = tmp;
        }
    }
}