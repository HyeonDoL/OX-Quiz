using System.Collections.Generic;
using UnityEngine;

public class AiMovementManager : MonoBehaviour
{
    private static AiMovementManager instance = null;
    public static AiMovementManager Instance
    {
        get
        {
            if (instance)
                return instance;
            else
                return instance = new GameObject("AiMovementManager").AddComponent<AiMovementManager>();
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
}

public interface IAiMove
{
    void Move(Vector3 targetPosition);
}