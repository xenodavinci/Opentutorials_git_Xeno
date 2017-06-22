using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class csTurret : MonoBehaviour {

    public GameObject Target;
    public GameObject Bullet;

    public Transform[] PatrolPoints;

    bool Targetting;
    bool arrivePatrol;

    public float FireCoolTime;

    int curPatrolPoint;

    private void Awake()
    {
        Targetting = false;
        curPatrolPoint = 0;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Debug.Log("Turret Trigger hit");

            Targetting = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Debug.Log("Target Out");

            Targetting = false;
        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
        // See Target
        if(Targetting)
        {
            Vector2 targetPosition = Target.transform.position;
            Vector2 myPosition = this.transform.position;

            float distance = Vector2.Distance(myPosition, targetPosition);

            if(distance <= 3.0f)
            {
                //Debug.Log("Lock on Target");

                Vector2 diff = targetPosition - myPosition;

                float angle_in_radians = Mathf.Atan2(diff.y, diff.x);   // 
                float angle_in_degrees = angle_in_radians * Mathf.Rad2Deg;  //

                //Debug.Log(angle_in_radians);
                //Debug.Log(angle_in_degrees);

                transform.rotation = Quaternion.Euler(0.0f, 0.0f, angle_in_degrees);
            }
        }
        // can not to see player / Patrol
        else
        {
            if (curPatrolPoint == 0 && curPatrolPoint != PatrolPoints.Length)
            {      
                if (this.transform.position == PatrolPoints[1].position)
                {
                    curPatrolPoint = 1;
                }
            }
            else
            {
                if (this.transform.position == PatrolPoints[0].position)
                {
                    curPatrolPoint = 0;
                }
            }
        }
    }
}
