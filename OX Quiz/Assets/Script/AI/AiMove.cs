using UnityEngine;
using System.Collections;
using System;

public class AiMove : MonoBehaviour, IAiMove
{
    [SerializeField]
    private float moveTime;

    [SerializeField]
    private Rigidbody rigidbody;

    [SerializeField]
    private AnimationCurve curve = AnimationCurve.EaseInOut(0, 0, 1, 1);

    private void Start()
    {
        AiMovementManager.Instance.AddMoveEvent(this);
    }

    public IEnumerator Move(Vector3 targetPosition)
    {
        float t = 0f;

        Vector3 startPosition = transform.position;

        transform.LookAt(targetPosition);

        while(t < 1f)
        {
            t += Time.deltaTime / moveTime;

            rigidbody.MovePosition(Vector3.Lerp(startPosition, targetPosition, curve.Evaluate(t)));

            yield return null;
        }
    }

    void IAiMove.Move(Vector3 targetPosition)
    {
        StartCoroutine(Move(targetPosition));
    }
}