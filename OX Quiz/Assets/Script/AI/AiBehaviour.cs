using UnityEngine;
using System.Collections;

public class AiBehaviour : MonoBehaviour, IAiMove
{
    [SerializeField]
    private float moveSpeed;

    [SerializeField]
    private float winTime;

    [SerializeField]
    private Rigidbody rigidbody;

    [SerializeField]
    private AnimationCurve moveCurve = AnimationCurve.EaseInOut(0, 0, 1, 1);

    [SerializeField]
    private Animator aiAni;

    private void Start()
    {
        AiController.Instance.AddMoveEvent(this);
        AiController.Instance.winEvent += Win;
    }

    public IEnumerator Move(Vector3 targetPosition)
    {
        aiAni.SetBool("isMove", true);

        float t = 0f;

        Vector3 startPosition = transform.position;

        targetPosition.y = startPosition.y;

        while(t < 1f)
        {
            if(t < 0.5f)
                transform.LookAt(targetPosition);

            t += Time.deltaTime / moveSpeed;

            rigidbody.MovePosition(Vector3.Lerp(startPosition, targetPosition, moveCurve.Evaluate(t)));

            yield return null;
        }

        aiAni.SetBool("isMove", false);
    }

    void IAiMove.Move(Vector3 targetPosition)
    {
        StartCoroutine(Move(targetPosition));
    }

    public void Win()
    {
        aiAni.SetBool("isWin", true);

        Invoke("DisableWin", winTime);
    }
    private void DisableWin()
    {
        aiAni.SetBool("isWin", false);
    }
}