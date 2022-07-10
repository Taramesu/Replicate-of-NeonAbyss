using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface  IState
{
    void OnEnter(FSMLayer layer);

    void OnUpdate(FSMLayer layer);

    void OnExit(FSMLayer layer);

}
