using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMov : MonoBehaviour
{
    float Disp= 0.02f;
    Animator ani;
    // Start is called before the first frame update
    void Start()
    {
        ani = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetAxis("Horizontal")>0f)
        {
            ani.SetBool("Forward", true);
            transform.Translate(Disp, 0f, 0f);

        }
        else if(Input.GetAxis("Horizontal")<0f)
        {
            ani.SetBool("Backward", true);
            transform.Translate(-Disp, 0f, 0f);

        }
        else if(Input.GetAxis("Horizontal")==0f)
        {
            //If now add these player will keep on playing same animation till update is called
            ani.SetBool("Forward", false);
            ani.SetBool("Backward", false);
        }
       // if(Input.GetAxis("Vertical")>0f) Having double jump with this one
        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            ani.SetTrigger("Jumping");
            /* Vector3 DispJump;
             DispJump = transform.position;
             DispJump.y = DispJump.y + 1f;
             transform.position = DispJump;*/
            transform.Translate(0f, 0.01f, 0f);
        }
        if (Input.GetAxis("Vertical") < 0f)
        {
            ani.SetBool("Crouch", true);
        }
        else if(Input.GetAxis("Vertical") == 0f)
        {
            ani.SetBool("Crouch", false);
        }


    }
}
