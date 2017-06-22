using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class csBtnActive : MonoBehaviour {

    Button ActiveButton;

	// Use this for initialization
	void Start () {
        ActiveButton = this.GetComponent<Button>();
	}

    public void ActiveSet(bool ac_para)
    {
        if(ac_para)
        {
            Debug.Log("off");
            this.ActiveButton.onClick.SetPersistentListenerState(0, UnityEngine.Events.UnityEventCallState.Off);
        }
        else
        {
            Debug.Log("on");
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
