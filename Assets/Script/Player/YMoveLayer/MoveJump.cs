using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveJump : IState
{
    private PlayerFSM manager;
    private Parameter parameter;

    public MoveJump(PlayerFSM manager)
    {
        this.manager = manager;
        this.parameter = manager.parameter;
    }

    public void OnEnter(FSMLayer layer)
    {

    }

    public void OnUpdate(FSMLayer layer)
    {
       if(parameter.jumpState == MoveState.jump)
        {
            manager.transform.Translate(0, parameter.jumpForce * Time.deltaTime, 0);
        }
        else if (parameter.groundChecker.isGround)
        {
            manager.TransitionState(FSMLayer.YMove, StateType.Null);
        }
    }

    public void OnExit(FSMLayer layer)
    {

    }
}
