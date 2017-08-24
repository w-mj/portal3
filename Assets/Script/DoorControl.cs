using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorControl : MonoBehaviour {

    [SerializeField] private GameObject expend;
    [SerializeField] private GameObject bullet;
     public DoorControl another;
    [SerializeField] private Movement player;
    [SerializeField] private Texture opening;
    [SerializeField] private Texture closed;

    public bool isExpend = false;
    public bool isOpen = false;
    private Rigidbody m_rb;

    private bool m_flying = false;
    private Vector3 m_forward;
    [SerializeField] private float m_speed;

    private void Start()
    {
        m_rb = GetComponent<Rigidbody>();
    }

    public void Ready(Vector3 where)
    {
        transform.position = where;
        expend.SetActive(false);
        bullet.SetActive(true);
        another.Close();
    }

    public void Hide()
    {
        isOpen = false;
        isExpend = false;
        another.Close();
        expend.SetActive(false);
        bullet.SetActive(false);
    }

    private void Update()
    {
        if (m_flying)
        {
            m_rb.MovePosition(m_rb.position + m_forward * m_speed * Time.deltaTime);
            // transform.position += m_forward * m_speed * Time.deltaTime;
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            if (isOpen)
                Close();
            else
                Open();
        }
    }

    public void Fire(Vector3 forward)
    {
        m_flying = true;
        m_forward = forward;
        transform.forward = forward;
    }

    public void Expend(Quaternion surface)
    {
        
        isExpend = true;
        m_flying = false;
        expend.SetActive(true);
        bullet.SetActive(false);
        expend.transform.rotation = surface;
        if (another.isExpend)
        {
            Open();
            another.Open();
        } else
        {
            Close();
        }
    }

    public void Open()
    {
        if (isExpend)
        {
            expend.GetComponent<Renderer>().material.SetTexture("_MainTex", opening);
            isOpen = true;
        }
    }

    public void Close()
    {
        if (isExpend)
        {
            expend.GetComponent<Renderer>().material.SetTexture("_MainTex", closed);
            isOpen = false;
        }
    }

    public void Go()
    {
        player.transform.position = another.transform.position + (-another.transform.forward) * 1;
        player.turn();
    }
}
