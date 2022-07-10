using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Parameter
{
    public int jumpMaxTimes;

    public bool swordState;

    public bool beHitState;

    public float runSpeed;

    public float jumpForce;

    public float fallMultiplier;

    public float lowJumpMultiplier;

    public MoveState runState;

    public MoveState jumpState;

    public GroundChecker groundChecker;

    public Rigidbody2D rigidbody;

    public Animator animator;

    public Animator legAnimator;

    public Animator bodyAnimator;

    public Animator armLAnimator;

    public Animator armRAnimator;
}


public enum StateType
{
    MoveRun, MoveJump, MoveDrop, PostureIdle, PostureRun,PostureJump,PostureDrop,PostureSlash,PickUp,BeHit,Dead,Null
}
public enum FSMLayer
{
    XMove,YMove,Postrue,Action,Flip
}

public enum MoveState
{
    stop,left,right,jump,drop
}

public class PlayerFSM : MonoBehaviour
{
    private IState[] currentState = new IState[4];
    private FSMLayer[] currentLayer = new FSMLayer[4] { FSMLayer.XMove,FSMLayer.YMove,FSMLayer.Postrue,FSMLayer.Action};
    private Dictionary<StateType, IState> states = new Dictionary<StateType, IState>();
    public Parameter parameter = new Parameter();

    void Start()
    {
        /*-----------------------------------------------------------------------------------------------*/
        states.Add(StateType.MoveRun, new MoveRun(this));
        states.Add(StateType.MoveJump, new MoveJump(this));
        states.Add(StateType.MoveDrop, new MoveDrop(this));
        states.Add(StateType.PostureIdle, new IdleState(this));
        states.Add(StateType.PostureRun, new RunState(this));
        states.Add(StateType.PostureJump, new JumpState(this));
        states.Add(StateType.PostureDrop, new DropState(this));
        states.Add(StateType.PostureSlash, new SlashState(this));
        states.Add(StateType.PickUp, new PickUpState(this));
        states.Add(StateType.BeHit, new BeHitState(this));
        states.Add(StateType.Dead, new DeadState(this));
        states.Add(StateType.Null, new NullState(this));

        /*-----------------------------------------------------------------------------------------------*/
        parameter.rigidbody = GetComponent<Rigidbody2D>();
        parameter.groundChecker = GetComponentInChildren<GroundChecker>();
        /*-----------------------------------------------------------------------------------------------*/
        TransitionState(FSMLayer.XMove, StateType.Null);
        TransitionState(FSMLayer.YMove, StateType.Null);
        TransitionState(FSMLayer.Postrue, StateType.PostureIdle);
    }

   
    void Update()
    {
        currentState[GetCurrentState(FSMLayer.XMove)].OnUpdate(FSMLayer.XMove);
        currentState[GetCurrentState(FSMLayer.YMove)].OnUpdate(FSMLayer.YMove);
        currentState[GetCurrentState(FSMLayer.Postrue)].OnUpdate(FSMLayer.Postrue);
    }

    public void TransitionState(FSMLayer layer,StateType type)
    {
        if(currentState[GetCurrentState(layer)] != null)
        {
            currentState[GetCurrentState(layer)].OnExit(layer);
        }
        currentState[GetCurrentState(layer)] = states[type];
        currentState[GetCurrentState(layer)].OnEnter(layer);
    }

    public int GetCurrentState(FSMLayer layer)
    {
        for(int i = 0;i<4;i++)
        {
            if(layer == currentLayer[i])
            {
                return i;
            }
        }
        print("there's no the layer");
        return 0;
    }
}
