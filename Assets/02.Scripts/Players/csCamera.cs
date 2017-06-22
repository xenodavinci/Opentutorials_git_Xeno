using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class csCamera : MonoBehaviour {

    [SerializeField]
    private float xMin;

    [SerializeField]
    private float yMin;

    [SerializeField]
    private float xMax;

    [SerializeField]
    private float yMax;

    private Transform Target;

	// Use this for initialization
	void Start () {

        Target = GameObject.Find("Character").GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {

        this.transform.position = new Vector3(Mathf.Clamp(Target.position.x, xMin, xMax), Mathf.Clamp(Target.position.y, yMin, yMax), this.transform.position.z);
	}
}
