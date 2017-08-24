using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableDoors : MonoBehaviour {

    public GameObject blue;
    public GameObject orange;

	// Use this for initialization
	void Start () {
        blue.SetActive(false);
        orange.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
