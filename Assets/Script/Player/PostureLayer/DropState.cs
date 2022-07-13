using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropState : IState
{
    private PlayerFSM manager;
    private Parameter parameter;

    public DropState(PlayerFSM manager)
    {
        this.manager = manager;
        this.parameter = manager.parameter;
    }

    public void OnEnter(FSMLayer layer)
    {
        if (parameter.swordState) //ÅÐ¶ÏÊÇ·ñÎª³Ö½£×´Ì¬
        {
            parameter.legAnimator.Play("drop");
            parameter.bodyAnimator.Play("sword_jump");
            parameter.armLAnimator.Play("sword_drop");
            parameter.armRAnimator.Play("sword_drop");
        }
        else
        {
            parameter.legAnimator.Play("drop");
            parameter.bodyAnimator.Play("empty_jump");
            parameter.armLAnimator.Play("empty_drop");
            parameter.armRAnimator.Play("empty_drop");
        }
    }

    public void OnUpdate(FSMLayer layer)
    {
        AnimatorStateInfo info = parameter.animator.GetCurrentAnimatorStateInfo(0);
        if(parameter.runState != MoveState.stop)
        {
            manager.TransitionState(FSMLayer.Postrue, StateType.PostureRun);
        }
        else if(info.normalizedTime>0.95f && info.IsName("drop"))
        {
            manager.TransitionState(FSMLayer.Postrue, StateType.PostureIdle);
        }
    }

    public void OnExit(FSMLayer layer)
    {

    }
}
