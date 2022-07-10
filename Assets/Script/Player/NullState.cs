using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NullState : IState
{
    private PlayerFSM manager;
    private Parameter parameter;

    public NullState (PlayerFSM manager)
    {
        this.manager = manager;
        this.parameter = manager.parameter;
    }
    public void OnEnter(FSMLayer layer)
    {

    }

    public void OnUpdate(FSMLayer layer)
    {
        if (layer == FSMLayer.XMove)
        {
            if (parameter.runState != MoveState.stop)
            {
                manager.TransitionState(FSMLayer.XMove, StateType.MoveRun);
            }
        }
        else if (layer == FSMLayer.YMove)
        {
            if (parameter.jumpState == MoveState.jump)
            {
                manager.TransitionState(FSMLayer.YMove, StateType.MoveJump);
            }
        }
    }

    public void OnExit(FSMLayer layer)
    {

    }
}
