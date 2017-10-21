using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed;
    
    [SerializeField]
    private Rigidbody playerRigid;

    public void Run(float horizontal, float vertical)
    {
        Vector3 movement = new Vector3(horizontal, 0, vertical);
        Quaternion newRotation = Quaternion.LookRotation(movement);

        playerRigid.MovePosition(transform.position + movement * moveSpeed * Time.deltaTime);
        playerRigid.rotation = newRotation;
    }
}