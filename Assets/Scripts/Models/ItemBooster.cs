using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBooster : MonoBehaviour
{
    [SerializeField]
    private float m_Force = 300;

    public static string GetTag()
    {
        return "ItemBooster";
    }

    public float GetForce()
    {
        return m_Force;
    }
}
