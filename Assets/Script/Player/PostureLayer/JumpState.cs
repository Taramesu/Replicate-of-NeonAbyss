using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpState : IState
{
    private PlayerFSM manager;
    private Parameter parameter;

    public JumpState(PlayerFSM manager)
    {
        this.manager = manager;
        this.parameter = manager.parameter;
    }

    public void OnEnter(FSMLayer layer)
    {
        if (parameter.swordState) //ÅÐ¶ÏÊÇ·ñÎª³Ö½£×´Ì¬
        {
            parameter.legAnimator.Play("jump");
            parameter.bodyAnimator.Play("sword_jump");
            parameter.armLAnimator.Play("sword_jump");
            parameter.armRAnimator.Play("sword_jump");
        }
        else
        {
            parameter.legAnimator.Play("jump");
            parameter.bodyAnimator.Play("empty_jump");
            parameter.armLAnimator.Play("empty_jump");
            parameter.armRAnimator.Play("empty_jump");
        }
    }

    public void OnUpdate(FSMLayer layer)
    {
        if(parameter.groundChecker.isGround && parameter.jumpState == MoveState.stop)
        {
            manager.TransitionState(FSMLayer.Postrue, StateType.PostureDrop);
        }
    }

    public void OnExit(FSMLayer layer)
    {

    }
}
