using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMov : MonoBehaviour
{
    float Disp= 0.02f;
    
    Animator ani;
    AnimatorStateInfo Ani_layer0;
    
    
    bool isJump = true;
    bool isBehind = true;

    Vector3 ScreenBounds;

    Rigidbody rgb;

    public GameObject opponent;
    public GameObject player1;
   // Vector3 player1Transform;

    // Start is called before the first frame update
    void Start()
    {
       //player1Transform= GetComponentInChildren<Transform>().position;
        
        ani = GetComponentInChildren<Animator>();
        rgb = GetComponent<Rigidbody>();
       
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 PlayerPos = transform.position;
        ScreenBounds = Camera.main.WorldToScreenPoint(PlayerPos);
        Ani_layer0 = ani.GetCurrentAnimatorStateInfo(0); // to get the current animation state for layer 0 = base layer

        HorizontalMovment();

        VerticalMovement();

        // Debug.Log(transform.position.x + " , " + opponent.transform.position.x);
        /*if (transform.position.x-0.9f>opponent.transform.position.x)
        {
            
            transform.Rotate(0, -90f, 0f);
        }*/

        /*using the parent game object transform not just flips the character but also parent's axis which 
            results in opp. movemet to the desired key press direction*/

        /* Debug.Log(GetComponentInChildren<Transform>().position);*///check why not getting child

        if (transform.position.x - 0.9f > opponent.transform.position.x)
        {
            if (isBehind)

            {
                player1.transform.Rotate(0f, -180f, 0f);
                isBehind = false;
                Ani_layer0.0
            }
        }
        else if(transform.position.x + 0.9f < opponent.transform.position.x)
        {
            if(!isBehind)
            {
                player1.transform.Rotate(0f, -180f, 0f);
                isBehind = true;
            }
        }


    }

    private void HorizontalMovment()
    {
        if ((Screen.width - 20.0f >= ScreenBounds.x) && (0F + 10F <= ScreenBounds.x))
        {
           // Debug.Log(Screen.width + " ," + ScreenBounds.x);
            if (Ani_layer0.IsTag("Motion"))
            {Ani_layer0
                if (Input.GetAxis("Horizontal") > 0f)
                {
                    ani.SetBool("Forward", true);
                    transform.Translate(Disp, 0f, 0f);
                }
                else if (Input.GetAxis("Horizontal") < 0f)
                {
                    ani.SetBool("Backward", true);
                    transform.Translate(-Disp, 0f, 0f);
                }
                if (Input.GetAxis("Horizontal") == 0f)
                {
                    //If now add these player will keep on playing same animation till update is called
                    ani.SetBool("Forward", false);
                    ani.SetBool("Backward", false);
                }
            }
        }
        else
        {
            if (Screen.width - 20.0f < ScreenBounds.x)
                if (Input.GetAxis("Horizontal") < 0f)
                {
                    ani.SetBool("Backward", true);
                    transform.Translate(-Disp, 0f, 0f);
                }

            if (0F + 10F > ScreenBounds.x)
                if (Input.GetAxis("Horizontal") > 0f)
                {
                    ani.SetBool("Forward", true);
                    transform.Translate(Disp, 0f, 0f);
                }
        }
    }
    void VerticalMovement()
    {
        // if(Input.GetAxis("Vertical")>0f) Having double jump with this one
        if (Input.GetAxis("Vertical") > 0f)
        {
            if (isJump)
            {
                ani.SetTrigger("Jumping");
                isJump = false;
                StartCoroutine(JumpControl());
            }
            /* Vector3 DispJump;
             DispJump = transform.position;
             DispJump.y = DispJump.y + 1f;
             transform.position = DispJump;*/
            //transform.Translate(0f, 0.01f, 0f);
        }
        if (Input.GetAxis("Vertical") < 0f)
        {
            ani.SetBool("Crouch", true);
        }
        else if (Input.GetAxis("Vertical") == 0f)
        {
            ani.SetBool("Crouch", false);
        }
        IEnumerator JumpControl()
        {
            yield return new WaitForSeconds(1.0f);
            //yield return null; jumps twice so need to give a delay reason unknown
            isJump = true;
        }
    }

}
