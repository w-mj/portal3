using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollision : MonoBehaviour {

    public DoorControl door;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Wall")
        {
            door.Expend(other.transform.rotation);
        }
        if (other.tag == "Door")
        {
            door.another.Hide();
        }
    }
    /*
    void OnCollisionEnter(Collision other)
    {
        if (other.collider.tag == "Wall")
        {
            door.Expend(other.transform.rotation);
        }
    }*/
}

