using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubePlayerSideViewController : MonoBehaviour
{
    [SerializeField]
    private Vector3 m_Direction = Vector3.left;
    
    [SerializeField]
    private float m_Force = 800;

    Rigidbody m_Rigidbody;
    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        OnThrowCube();
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log($"ON COLLISION ENTER : {collision.gameObject.name}");
        var gameObjectColladed = collision.gameObject;
        WallBounceController wallBounceController = gameObjectColladed.GetComponent<WallBounceController>();
        if (wallBounceController != null && wallBounceController.GetIsBounce())
        {
            //var directionCube = transform.position - gameObjectColladed.transform.position;
            //velocity.z *= -1;
            //Debug.Log($"velocity apres : {directionCube * m_Force}");

            m_Direction *= -1;
            OnThrowCube();
        }
    }

    private void OnThrowCube()
    {
        m_Rigidbody.AddForce(Vector3.zero);
        m_Rigidbody.AddForce(m_Direction * m_Force);
        
    }
}
