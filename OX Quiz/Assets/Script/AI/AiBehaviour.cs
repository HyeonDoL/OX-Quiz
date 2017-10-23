using UnityEngine;
using System.Collections;

public class AiBehaviour : MonoBehaviour, IAiMove
{
    [SerializeField]
    private float moveSpeed;

    [SerializeField]
    private float winTime;

    [SerializeField]
    private float stopDistance = 1.5f;

    [SerializeField]
    private Rigidbody rigidbody;

    [SerializeField]
    private Animator aiAni;

    private void Start()
    {
        AiController.Instance.AddMoveEvent(this);
        AiController.Instance.winEvent += Win;
    }

    IEnumerator IAiMove.Move(Vector3 targetPosition)
    {
        aiAni.SetBool("isMove", true);

        Vector3 startPosition = transform.position;

        targetPosition.y = startPosition.y;

        Vector3 direction = (targetPosition - startPosition).normalized;

        transform.LookAt(targetPosition);

        while (Vector3.Distance(transform.position, targetPosition) > stopDistance)
        {
            transform.LookAt(targetPosition);

            rigidbody.MovePosition(transform.position + direction * moveSpeed * Time.deltaTime);

            yield return null;
        }

        aiAni.SetBool("isMove", false);
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