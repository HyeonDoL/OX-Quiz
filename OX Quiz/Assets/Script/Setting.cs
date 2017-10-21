using UnityEngine;
using System.Collections.Generic;

public class Setting : MonoBehaviour
{
    public int maxQuestionCount { private set; get; }
    public int maxLimitTime { private set; get; }

    public bool isRandom { private set; get; }

    private void Awake()
    {
        string[] setting = Parser.Parse("Setting")[0];
        int temp;

        int.TryParse(setting[0], out temp);
        maxQuestionCount = temp;

        int.TryParse(setting[1], out temp);
        maxLimitTime = temp;

        isRandom = setting[2].Equals('O');

        if (isRandom)
            QuizManager.Instance.ShuffleList();
    }
}