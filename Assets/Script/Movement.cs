using System.Collections;
using System.Collections.Generic;
using VRStandardAssets.Utils;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float m_moveSpeed = 12f;
    public float m_turnSpeed = 180f;
    public Transform m_camera;
    public Transform m_camera_asix;
    public VRInput m_VRInput;

    private Rigidbody m_rigidbody;
    private float m_MovementInputValue;
    
    void Start()
    {
        m_rigidbody = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        m_VRInput.OnLongPress += HandleLongPress;
    }

    private void OnDisable()
    {
        m_VRInput.OnLongPress -= HandleLongPress;
    }

    private void Update()
    {
        transform.forward = new Vector3(m_camera.forward.x, transform.forward.y, m_camera.forward.z);
        m_MovementInputValue = Input.GetAxis("Fire1");
        if (Input.GetKeyDown(KeyCode.K))
        {
            turn();
        }
    }

    void HandleLongPress()
    {
        Vector3 moveMent = transform.forward * m_MovementInputValue * m_moveSpeed * Time.deltaTime;
        m_rigidbody.MovePosition(m_rigidbody.position + moveMent);
        // Quaternion turnRotation = Quaternion.Euler(0f, m_camera.rotation.y, 0f);
    }

    public void turn()
    {
        Debug.Log("旋转");
        /*
        Quaternion r =  m_camera_asix.rotation;
        Vector3 angle = Vector3.zero;
        float z = 0f;
        r.ToAngleAxis(out z, out angle);
        Debug.Log("1" + angle);
        r.y = (r.y + 180) % 360;*/
        //m_camera_asix.rotation = Quaternion.Inverse(m_camera_asix.transform.rotation);
        m_camera_asix.transform.forward = -m_camera_asix.transform.forward;
        Debug.Log(m_camera_asix.transform.rotation);
    }
}
