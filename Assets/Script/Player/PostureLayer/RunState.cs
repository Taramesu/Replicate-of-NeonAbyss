using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunState : IState
{
    private PlayerFSM manager;
    private Parameter parameter;

    public RunState(PlayerFSM manager)
    {
        this.manager = manager;
        this.parameter = manager.parameter;
    }

    public void OnEnter(FSMLayer layer)
    {
        if (parameter.swordState) //ÅÐ¶ÏÊÇ·ñÎª³Ö½£×´Ì¬
        {
            parameter.legAnimator.Play("run");
            parameter.bodyAnimator.Play("sword_run");
            parameter.armLAnimator.Play("sword_run");
            parameter.armRAnimator.Play("sword_run");
        }
        else
        {
            parameter.legAnimator.Play("run");
            parameter.bodyAnimator.Play("empty_run");
            parameter.armLAnimator.Play("empty_run");
            parameter.armRAnimator.Play("empty_run");
        }
    }

    public void OnUpdate(FSMLayer layer)
    {
        if(parameter.jumpState == MoveState.jump)
        {
            manager.TransitionState(FSMLayer.Postrue, StateType.PostureJump);
        }
        if(parameter.runState == MoveState.stop)
        {
            manager.TransitionState(FSMLayer.Postrue, StateType.PostureIdle);
        }
    }

    public void OnExit(FSMLayer layer)
    {

    }
}
