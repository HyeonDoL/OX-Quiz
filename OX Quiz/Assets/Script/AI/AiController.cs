using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiController : MonoBehaviour
{
    private static AiController instance = null;
    public static AiController Instance
    {
        get
        {
            if (instance)
                return instance;
            else
                return instance = new GameObject("AiController").AddComponent<AiController>();
        }
    }

    [SerializeField]
    private DrawArea oSignSpawnArea;

    [SerializeField]
    private DrawArea xSignSpawnArea;

    private List<IAiMove> aiMoveEventList = new List<IAiMove>();

    public delegate void AnswerDiscriminateDelegate();
    public event AnswerDiscriminateDelegate answerDiscriminateEvent;

    private void Awake()
    {
        instance = this;
    }

    public void AddMoveEvent(IAiMove aiMoveEvent)
    {
        aiMoveEventList.Add(aiMoveEvent);
    }

    public void MoveAi()
    {
        for (int i = 0; i < aiMoveEventList.Count; ++i)
        {
            bool randomSign = Random.Range(0, 2) == 1;

            StartCoroutine(aiMoveEventList[i].Move(GetRandomPosition(randomSign), randomSign ? "O" : "X"));
        }
    }
    private Vector3 GetRandomPosition(bool randomSign)
    {
        DrawArea tempArea;

        if (randomSign)
            tempArea = oSignSpawnArea;

        else
            tempArea = xSignSpawnArea;

        float xMin, xMax;
        float zMin, zMax;

        xMin = tempArea.GetLeft();
        xMax = tempArea.GetRight();

        zMin = tempArea.GetBottom();
        zMax = tempArea.GetTop();

        return new Vector3(Random.Range(xMin, xMax),
                                    0,
                                    Random.Range(zMin, zMax));
    }

    public void AnswerDiscriminate()
    {
        if(answerDiscriminateEvent != null)
            answerDiscriminateEvent();
    }
}

public interface IAiMove
{
    IEnumerator Move(Vector3 targetPosition, string randomSign);
}