using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class APlayer : MonoBehaviour
{
    public APlayerMovement movementComponent;
    public Rigidbody2D playerRigid;
    void Awake()
    {
        movementComponent = GetComponent<APlayerMovement>();
        playerRigid = GetComponent<Rigidbody2D>();
    }

}
