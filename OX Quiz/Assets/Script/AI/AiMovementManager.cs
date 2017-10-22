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

    //public void MoveAi()
    //{
    //    for (int i = 0; i < aiMoveEventList.Count; ++i)
    //    {
    //        aiMoveEventList[i].Move(GetRandomPosition());
    //    }
    //}
    //private Vector3 GetRandomPosition()
    //{

    //}
}

public interface IAiMove
{
    void Move(Vector3 targetPosition);
}