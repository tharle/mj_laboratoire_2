using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class  Obstacle : MonoBehaviour
{
    [SerializeField]
    private bool m_EnableBounce = false;

    public bool IsBounced() { 
        return m_EnableBounce;
    }

    public static string GetTag()
    {
        return "Obstacle";
    }

    public abstract void DoCollision();
}
