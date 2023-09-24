using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubePlayerExtraController : MonoBehaviour
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
        var gameObjectColladed = collision.gameObject;
        WallBounceController wallBounceController = gameObjectColladed.GetComponent<WallBounceController>();
        if (wallBounceController != null && wallBounceController.GetIsBounce())
        {
            var directionCube = gameObjectColladed.transform.position - transform.position;
            // OnChangeDirection(directionCube);
            Debug.Log($"ON COLLISION ENTER : {directionCube}");
            m_Direction = directionCube;
            OnThrowCube();
        }
    }

    private void OnThrowCube()
    {
        m_Rigidbody.AddForce(Vector3.zero); // arreter le cube pour apliquer la nouvelle force
        m_Rigidbody.AddForce(m_Direction * m_Force);
    }

    private void OnChangeDirection(Vector3 directionCube)
    {
        m_Direction = Vector3.zero;
        if (directionCube.x > 0)
            m_Direction += Vector3.right;
        else if (directionCube.x < 0)
            m_Direction += Vector3.left;

        if (directionCube.y > 0)
            m_Direction += Vector3.forward;
        else if (directionCube.y < 0)
            m_Direction += Vector3.back;
    }
}
