using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorCollision : MonoBehaviour {

    [SerializeField] DoorControl self;

	// Use this for initialization
	void Start () {	}
	
	// Update is called once per frame
	void Update () { }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && self.isOpen)
        {
            self.Go();
        }
    }
}
