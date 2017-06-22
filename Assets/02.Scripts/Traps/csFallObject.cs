using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class csFallObject : MonoBehaviour {

    public float limitTime;
    float TimeCheck;

    bool gravityOn;

    Rigidbody2D rigid;

    private void Awake()
    {
        gravityOn = false;
        TimeCheck = 0;

        rigid = this.GetComponent<Rigidbody2D>();

        rigid.constraints = RigidbodyConstraints2D.FreezeAll;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "Player")
        {
            Debug.Log("object hit");

            if(!gravityOn)
            {
                gravityOn = true;

                StartCoroutine("OnGravity");
            }            
        }
    }

    IEnumerator OnGravity()
    {
        Debug.Log("I Call");

        yield return new WaitForSeconds(1.0f);

        rigid.constraints = RigidbodyConstraints2D.None;
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
