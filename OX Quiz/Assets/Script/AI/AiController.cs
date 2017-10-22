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
    
    [System.Serializable]
    public struct Rect
    {
        public Transform Left;
        public Transform Right;
        public Transform Top;
        public Transform Bottom;
    }

    [SerializeField]
    public Rect xSignRect;

    [SerializeField]
    public Rect oSignRect;

    private List<IAiMove> aiMoveEventList;

    public delegate void WinDelegate();
    public event WinDelegate winEvent;

    public void AddMoveEvent(IAiMove aiMoveEvent)
    {
        aiMoveEventList.Add(aiMoveEvent);
    }

    public void MoveAi()
    {
        for (int i = 0; i < aiMoveEventList.Count; ++i)
        {
            aiMoveEventList[i].Move(GetRandomPosition());
        }
    }
    private Vector3 GetRandomPosition()
    {
        bool randomSign = Random.Range(0, 2) == 1;

        Rect tempRect;

        if (randomSign)
            tempRect = oSignRect;

        else
            tempRect = xSignRect;

        float xMin, xMax;
        float zMin, zMax;

        xMin = tempRect.Left.position.x;
        xMax = tempRect.Right.position.x;

        zMin = tempRect.Bottom.position.z;
        zMax = tempRect.Top.position.z;

        return new Vector3(Random.Range(xMin, xMax),
                                    tempRect.Left.position.y,
                                    Random.Range(zMin, zMax));
    }

    public void WinAi()
    {
        winEvent();
    }
}

public interface IAiMove
{
    void Move(Vector3 targetPosition);
}