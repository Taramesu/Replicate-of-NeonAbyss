using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponRotation : MonoBehaviour
{
    public Camera camera;
    public Vector3 mousePos;
    public Vector2 weaponDir;
    public float angle;
    void Start()
    {
        
    }

    void Update()
    {
        weaponDir = (mousePos - transform.position).normalized;
        angle = Mathf.Atan2(weaponDir.y, weaponDir.x) * Mathf.Rad2Deg;
        transform.eulerAngles = new Vector3(0, 0, angle);
    }
}
