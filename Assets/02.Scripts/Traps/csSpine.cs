using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class csSpine : MonoBehaviour {

    private void Awake()
    {
        Transform SpineObj = this.transform.parent.GetChild(0);
        GameObject Spine = SpineObj.gameObject;

        Spine.SetActive(false);

        Debug.Log(SpineObj.name);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            StartCoroutine("SpineActive");
        }
    }

    IEnumerator SpineActive()
    {
        Transform SpineObj = this.transform.parent.GetChild(0);
        GameObject Spine = SpineObj.gameObject;

        Spine.SetActive(true);

        yield return new WaitForSeconds(1.5f);

        Spine.SetActive(false);
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
