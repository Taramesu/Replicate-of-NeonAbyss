using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInputController : MonoBehaviour
{
    public float getJumpButtonMaxTimeStandard;
    public float getJumpButtonMaxTime;
    public float getJumpButtonMinTimeStandard;
    public float getJumpButtonMinTime;
    public PlayerFSM playerFSM;
    public GroundChecker groundChecker;
    public WeaponRotation weaponRotation;
    private float moveDir;
    private float jumpDir;
    void Start()
    {
        getJumpButtonMaxTime = getJumpButtonMaxTimeStandard;
        playerFSM = StaticValue.player.GetComponent<PlayerFSM>();
        groundChecker = StaticValue.player.GetComponentInChildren<GroundChecker>();
        weaponRotation = StaticValue.player.GetComponentInChildren<WeaponRotation>();
    }

    void Update()
    {
        RunInput();
        JumpInput();
        ShootInput();
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

        if ((jumpDir > 0 && getJumpButtonMaxTime > 0) || (getJumpButtonMinTime>0 && playerFSM.parameter.jumpState == MoveState.jump) )
        {
            if(!(jumpDir > 0))
            {
                getJumpButtonMaxTime = 0;
            }
            playerFSM.parameter.jumpState = MoveState.jump;
            getJumpButtonMaxTime -= Time.deltaTime;
            getJumpButtonMinTime -= Time.deltaTime;
        }
        else if(getJumpButtonMinTime<0)
        {
            playerFSM.parameter.jumpState = MoveState.stop;
        }

        if(groundChecker.isGround)
        {
            getJumpButtonMaxTime = getJumpButtonMaxTimeStandard;
            getJumpButtonMinTime = getJumpButtonMinTimeStandard;
        }
    }

    public void ShootInput()
    {
        weaponRotation.mousePos = weaponRotation.camera.ScreenToWorldPoint(Input.mousePosition);
        //weaponRotation.mousePos = weaponRotation.camera.ScreenToWorldPoint();
    }
}
