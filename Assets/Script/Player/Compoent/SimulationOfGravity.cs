using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimulationOfGravity : MonoBehaviour
{
    public float gravityScale;
    public PlayerFSM playerFSM;
    public GroundChecker groundChecker;
    void Start()
    {
        
    }


    void Update()
    {
        if(groundChecker.isGround == false && playerFSM.parameter.jumpState != MoveState.jump)
        {
            transform.Translate(0, -gravityScale * Time.deltaTime, 0);
        }
    }
}
