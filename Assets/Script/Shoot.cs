using System.Collections;
using System.Collections.Generic;
using VRStandardAssets.Utils;
using UnityEngine;

public class Shoot : MonoBehaviour {

    public VRInput m_VRInput;
    public GameObject m_gun;
    public Camera m_camera;

    [SerializeField] private DoorControl m_blueDoor;
    [SerializeField] private DoorControl m_orangeDoor;

    private void Start()
    {
        Vector3 posi = m_gun.transform.position;
        posi.y += 10;
        m_blueDoor.transform.position = posi;
        m_orangeDoor.transform.position = posi;
        m_blueDoor.Hide();
        m_orangeDoor.Hide();
    }

    private void OnEnable()
    {
        m_VRInput.OnSwipe += HandleSwipe;
    }

    private void OnDisable()
    {
        m_VRInput.OnSwipe -= HandleSwipe;
    }

    void HandleSwipe(VRInput.SwipeDirection direction)
    {
        switch(direction)
        {
            case VRInput.SwipeDirection.UP:
                // m_gun.GetComponent<Renderer>().material.color = Color.red;
                m_blueDoor.Ready(m_camera.transform.position);
                m_blueDoor.Fire(m_camera.transform.forward);
                break;
            case VRInput.SwipeDirection.DOWN:
                // m_gun.GetComponent<Renderer>().material.color = Color.green;
                m_orangeDoor.Ready(m_camera.transform.position);
                m_orangeDoor.Fire(m_camera.transform.forward);
                break;
        }
    }
}
