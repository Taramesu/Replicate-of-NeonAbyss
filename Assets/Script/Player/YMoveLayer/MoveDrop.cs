using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDrop : IState
{
    private PlayerFSM manager;
    private Parameter parameter;

    public MoveDrop(PlayerFSM manager)
    {
        this.manager = manager;
        this.parameter = manager.parameter;
    }

    public void OnEnter(FSMLayer layer)
    {

    }

    public void OnUpdate(FSMLayer layer)
    {
        Debug.Log("droping");

        
        //if (parameter.groundChecker.isGround)
        //{
        //    parameter.jumpState = MoveState.land;
        //}
        //if (parameter.rigidbody.velocity.y == 0)
        //{
        //    manager.TransitionState(FSMLayer.YMove, StateType.Null);
        //}
    }

    public void OnExit(FSMLayer layer)
    {

    }
}