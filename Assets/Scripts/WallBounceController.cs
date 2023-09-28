using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallBounceController : MonoBehaviour
{
    [SerializeField]
    private bool m_EnableBounce = false;

    [SerializeField]
    private Vector3 m_Normal = Vector3.left;

    public bool IsBounced() { 
        return m_EnableBounce;
    }

    public Vector3 GetNormal()
    {
        return m_Normal;
    }
}
