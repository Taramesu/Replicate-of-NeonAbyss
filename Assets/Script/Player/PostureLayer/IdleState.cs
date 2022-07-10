using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : IState
{
    private PlayerFSM manager;
    private Parameter parameter;

    public IdleState(PlayerFSM manager)
    {
        this.manager = manager;
        this.parameter = manager.parameter;
    }

    public void OnEnter(FSMLayer layer)
    {
        if(parameter.swordState) //ÅÐ¶ÏÊÇ·ñÎª³Ö½£×´Ì¬
        {
            parameter.legAnimator.Play("idle");
            parameter.bodyAnimator.Play("sword_idle");
            parameter.armLAnimator.Play("sword_idle");
            parameter.armRAnimator.Play("sword_idle");
        }
        else
        {
            parameter.legAnimator.Play("idle");
            parameter.bodyAnimator.Play("empty_idle");
            parameter.armLAnimator.Play("empty_idle");
            parameter.armRAnimator.Play("empty_idle");
        }
    }

    public void OnUpdate(FSMLayer layer)
    {
        if(parameter.jumpState == MoveState.jump)
        {
            manager.TransitionState(FSMLayer.Postrue, StateType.PostureJump);
        }
        else if(parameter.runState != MoveState.stop)
        {
            manager.TransitionState(FSMLayer.Postrue, StateType.PostureRun);
        }
        //if (parameter.beHitState == true)
        //{
        //    manager.TransitionState(FSMLayer.Postrue,StateType.BeHit);
        //}
        //if (parameter.jumpState == MoveState.jump)
        //{
        //    manager.TransitionState(FSMLayer.YMove,StateType.MoveJump);
        //    manager.TransitionState(FSMLayer.Postrue,StateType.PostureJump);
        //}
        //if (parameter.runState != MoveState.stop)
        //{
        //    manager.TransitionState(FSMLayer.XMove, StateType.MoveRun);
        //    manager.TransitionState(FSMLayer.Postrue,StateType.PostureRun);
        //}
    }

    public void OnExit(FSMLayer layer)
    {
        
    }
}
