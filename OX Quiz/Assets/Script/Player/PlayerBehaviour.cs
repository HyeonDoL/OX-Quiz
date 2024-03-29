﻿using UnityEngine;

public enum PlayerState
{
    Idle,
    Run
}

public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField]
    private float winTime;

    [SerializeField]
    private PlayerMove move;

    [SerializeField]
    private Animator ani;

    private float horizontal, vertical;

    private PlayerState state;

    private void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        state = PlayerState.Idle;

        if (horizontal != 0 || vertical != 0)
            state = PlayerState.Run;
    }

    private void FixedUpdate()
    {
        Idle();
        Run();
    }

    private void Idle()
    {
        if (state != PlayerState.Idle)
            return;

        ani.SetBool("isMove", false);
    }

    private void Run()
    {
        if (horizontal == 0 && vertical == 0)
            return;

        move.Run(horizontal, vertical);

        if (state != PlayerState.Run)
            return;

        ani.SetBool("isMove", true);
    }

    public void Win()
    {
        ani.SetBool("isWin", true);

        Invoke("DisableWin", winTime);
    }
    private void DisableWin()
    {
        ani.SetBool("isWin", false);
    }
}