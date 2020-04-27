using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class visible : MonoBehaviour
{
    public Renderer m_Renderer;
    // Use this for initialization
    void Start()
    {
        m_Renderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public bool isVisible()
    {
        if (m_Renderer.isVisible)
        {
            return true;
        }
        return false;

    }
}