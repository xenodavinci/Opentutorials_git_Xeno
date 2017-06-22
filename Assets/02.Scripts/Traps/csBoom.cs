using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class csBoom : MonoBehaviour {

    bool Explosion;

    public float TimeCount;

    void Awake()
    {
        Explosion = false;
        this.GetComponent<PointEffector2D>().enabled = false;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Explosion = true;
            Debug.Log("Player hit");

            if(Explosion)
            {
                //ExplosionBoom();
                StartCoroutine("BoomCountDown");
                Explosion = false;
            }            
        }
    }

    IEnumerator BoomCountDown()
    {
        yield return new WaitForSeconds(1.0f);

        ExplosionBoom();

        yield return new WaitForSeconds(0.2f);
        Destroy(this.gameObject);
    }

    void ExplosionBoom()
    {
        this.GetComponent<PointEffector2D>().enabled = true;
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
