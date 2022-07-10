using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    public bool isGround;
    public float checkRadius;
    public LayerMask whatIsGround;
    void Start()
    {
        
    }

    void Update()
    {
        isGround = Physics2D.OverlapCircle(gameObject.transform.position, checkRadius, whatIsGround);
    }
}
