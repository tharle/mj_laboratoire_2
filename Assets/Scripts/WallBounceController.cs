using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallBounceController : MonoBehaviour
{
    [SerializeField]
    private bool m_EnableBounce = true;

    public bool GetIsBounce() { 
        return m_EnableBounce;
    }
}