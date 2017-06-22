using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class csCharacterController : MonoBehaviour {

    public GameObject JumpButton;
    public GameObject InteractionButton;

    public float MoveSpeed;
    public float JumpHeight;

    private bool Landing;
    private bool Attach;

    bool leftMove;
    bool rightMove;
    bool Jumping;

    void Awake()
    {
        JumpButton.SetActive(true);
        InteractionButton.SetActive(false);

        Attach = false;

        // movement members
        leftMove = false;
        rightMove = false;
        Jumping = false;
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        // 두 개 모두 눌렸을 경우 무시
        if(leftMove && rightMove)
        {
            return;
        }

        if(leftMove && !rightMove)
        {
            //Debug.Log("left moving");
            this.transform.Translate(Vector3.left * MoveSpeed * Time.deltaTime);
        }
        else if(rightMove && !leftMove)
        {
            //Debug.Log("right moving");
            this.transform.Translate(Vector3.right * MoveSpeed * Time.deltaTime);
        }
    }

    // Character Movement's callback functions
    // LeftDown(), LeftUp(), RightDown(), RightUp(), Jump(), ActiveInteraction()
    public void LeftDown()
    {
        //Debug.Log("Left Down");
        leftMove = true;
    }

    public void LeftUp()
    {
        //Debug.Log("Left Up");
        leftMove = false;
    }

    public void RightDown()
    {
        //Debug.Log("Right Down");
        rightMove = true;
    }

    public void RightUp()
    {
        //Debug.Log("Right Up");
        rightMove = false;
    }

    public void Jump()
    {
        Debug.Log("I Call");

        if(Landing)
        {
            Debug.Log("Jump Call");
            this.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 400);
        }
    }

    public void ActiveInteraction()
    {
        Debug.Log("you call me?");
    }

    // Collider
    void OnCollisionEnter2D(Collision2D collision)
    {
        Landing = true;
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        Landing = false;
    }

    // Trigger
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "ActiveTrap")
        {
            Debug.Log("Active");

            JumpButton.SetActive(false);
            InteractionButton.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "ActiveTrap")
        {
            Debug.Log("reActive");
            JumpButton.SetActive(true);
            InteractionButton.SetActive(false);
        }
    }
}
