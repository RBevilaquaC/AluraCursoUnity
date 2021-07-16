using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region Parameter

    private Rigidbody rig;
    private Animator anim;
    private Vector3 dir;
    private float eixoX;
    private float eixoZ;
    public float speed;

    #endregion

    private void Start()
    {
        rig = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        eixoX = Input.GetAxisRaw("Horizontal");
        eixoZ = Input.GetAxisRaw("Vertical");
        dir = new Vector3(eixoX, 0, eixoZ).normalized;

        if (dir != Vector3.zero)
        {
            anim.Play("Run");
        }
        else
        {
            anim.Play("Idle");
        }
    }

    private void FixedUpdate()
    {
        rig.velocity = new Vector3(dir.x * speed,rig.velocity.y, dir.z * speed);
    }
}
