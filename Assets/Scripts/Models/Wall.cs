using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : Obstacle
{
    [SerializeField]
    private Vector3 m_Normal = Vector3.left;

    public override Vector3 GetNormal()
    {
        return m_Normal;
    }
}
