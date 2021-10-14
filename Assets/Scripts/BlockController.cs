using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockController : MonoBehaviour
{
    public enum BlockClass {LeftToRight,UpAndDown,Scaling,Turning }
    public BlockClass blockClass;
    Rigidbody body;
    private BoxCollider boxCollider;
    Vector3 initialPos;
    public float margin,forcePower;
    void Start()
    {
        body = GetComponent<Rigidbody>();
        boxCollider = GetComponent<BoxCollider>();
        initialPos = transform.position;
    }

    void FixedUpdate()
    {
        switch (blockClass)
        {
            case BlockClass.LeftToRight:
                if((transform.position - initialPos).magnitude >margin)
                    body.AddForce(Vector3.left * forcePower);
                else
                    body.AddForce(Vector3.right * forcePower);
                break;
            case BlockClass.UpAndDown:
                if ((transform.position - initialPos).magnitude > margin)
                    body.AddForce(Vector3.up * forcePower);
                else
                    body.AddForce(Vector3.down * forcePower);
                break;
            case BlockClass.Scaling:
                break;
            case BlockClass.Turning:
                body.AddTorque(transform.up * forcePower);
                break;

        }
    }
}
