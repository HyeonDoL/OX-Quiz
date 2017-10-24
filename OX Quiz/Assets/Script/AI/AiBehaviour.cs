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

    private string isOsign;

    private void Start()
    {
        AiController.Instance.AddMoveEvent(this);
        AiController.Instance.answerDiscriminateEvent += AnswerDiscriminate;
    }

    IEnumerator IAiMove.Move(Vector3 targetPosition, string randomSign)
    {
        isOsign = randomSign;

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

    public void AnswerDiscriminate()
    {
        if (isOsign == GameManager.Instance.answer)
            Win();

        else
            Lose();
    }

    private void Win()
    {
        aiAni.SetBool("isWin", true);

        Invoke("DisableWin", winTime);
    }
    private void DisableWin()
    {
        aiAni.SetBool("isWin", false);
    }

    private void Lose()
    {
        // TODO : Ai가 X에 있을 때 일어날 일들 구현
    }
}