using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRun : IState
{
    private PlayerFSM manager;
    private Parameter parameter;

    public MoveRun(PlayerFSM manager)
    {
        this.manager = manager;
        this.parameter = manager.parameter;
    }

    public void OnEnter(FSMLayer layer)
    {

    }

    public void OnUpdate(FSMLayer layer)
    {
        if (parameter.runState == MoveState.left)
        {
            manager.transform.localScale = new Vector3(-1, 1, 1);
            manager.transform.Translate(-parameter.runSpeed * Time.deltaTime, 0, 0);
        }
        else if (parameter.runState == MoveState.right)
        {
            manager.transform.localScale = new Vector3(1, 1, 1);
            manager.transform.Translate(parameter.runSpeed * Time.deltaTime, 0, 0);
        }
        else
        {
            manager.TransitionState(FSMLayer.XMove, StateType.Null);
        }
    }

    public void OnExit(FSMLayer layer)
    {

    }
}
