using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script : MonoBehaviour
{
    [SerializeField] Animator _animation;
    public int speed;
    private bool facingRight = true;
    public Rigidbody2D rb;
    float time;
    public BoxCollider2D box;

    public ParticleSystem attackParticles;
    //// Start is called before the first frame update
    //void Start()
    //{

    //}

    //// Update is called once per frame
    void Update()
    {

        time = Input.GetAxisRaw("Horizontal") * 4;
        run();

        if (!box.IsTouchingLayers(LayerMask.GetMask("ground")))
        {
            //_animation.SetBool("jump", false);
            return;

        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _animation.SetBool("jump", true);
            transform.Translate(Vector2.up * 3);

        }
        else
        {
            _animation.SetBool("jump", false);

        }


        if (Input.GetKeyDown(KeyCode.X))
        {
            _animation.SetBool("shot", true);
        }
        else
        {
            _animation.SetBool("shot", false);
        }



        if (time > 0 && !facingRight)
        {
            flip(time);
        }

        else if (time < 0 && facingRight)
        {
            flip(time);
        }
    }

    private void run()
    {
        _animation.SetFloat("run", Math.Abs(time));

        rb.velocity = new Vector2(time * speed, rb.velocity.y);
    }

    void flip(float time)
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    public void AttackEvent()
    {
        attackParticles.Emit(50);
    }
}
