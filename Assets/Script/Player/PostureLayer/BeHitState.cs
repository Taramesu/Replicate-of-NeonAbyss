using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeHitState : IState
{
    private PlayerFSM manager;
    private Parameter parameter;

    public BeHitState(PlayerFSM manager)
    {
        this.manager = manager;
        this.parameter = manager.parameter;
    }

    public void OnEnter(FSMLayer layer)
    {

    }

    public void OnUpdate(FSMLayer layer)
    {

    }

    public void OnExit(FSMLayer layer)
    {

    }
}
