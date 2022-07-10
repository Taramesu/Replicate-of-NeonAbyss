using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInputController : MonoBehaviour
{
    public float getJumpButtonMaxTimeStandard;
    public float getJumpButtonMaxTime;
    public PlayerFSM playerFSM;
    public GroundChecker groundChecker;
    private float moveDir;
    private float jumpDir;
    void Start()
    {
        getJumpButtonMaxTime = getJumpButtonMaxTimeStandard;
        playerFSM = StaticValue.player.GetComponent<PlayerFSM>();
        groundChecker = StaticValue.player.GetComponentInChildren<GroundChecker>();
    }

    void Update()
    {
        RunInput();
        JumpInput();
    }

    public void RunInput()
    {
        moveDir = Input.GetAxisRaw("Horizontal");
        if(moveDir>0)
        {
            playerFSM.parameter.runState = MoveState.right;
        }
        else if(moveDir == 0)
        {
            playerFSM.parameter.runState = MoveState.stop;
        }
        else
        {
            playerFSM.parameter.runState = MoveState.left;
        }
    }

    public void JumpInput()
    {
        jumpDir = Input.GetAxisRaw("Vertical");
        Debug.Log(jumpDir);
        //Debug.Log(groundChecker.isGround);

        if (jumpDir > 0 /*&& groundChecker.isGround */&& getJumpButtonMaxTime > 0)
        {
            playerFSM.parameter.jumpState = MoveState.jump;
            getJumpButtonMaxTime -= Time.deltaTime;
        }
        else
        {
            playerFSM.parameter.jumpState = MoveState.stop;
        }

        if(groundChecker.isGround)
        {
            getJumpButtonMaxTime = getJumpButtonMaxTimeStandard;
        }
    }
}
