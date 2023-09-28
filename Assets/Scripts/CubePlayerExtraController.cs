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
        OnThrowCubePlayer();
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject gameObjectColladed = collision.gameObject;        
        Debug.Log($"COLISION 2 : {gameObject.name}");
        if (gameObjectColladed.CompareTag("Wall"))
        {
            WallBounceController wallBounceController = gameObjectColladed.GetComponent<WallBounceController>();
            Vector3 pointCollision = collision.contacts[0].point;
            pointCollision.y = 0; // ignorer la diff entre Y
            Vector3 directionCube = pointCollision - transform.position;
            OnCollisionWall(wallBounceController, directionCube.normalized);  
        }
    }

    private void OnCollisionWall(WallBounceController wallBounceController, Vector3 direction)
    {
        if (wallBounceController.IsBounced())
        {
            m_Direction = direction;
            OnThrowCubePlayer();
        }
    }

    private void OnThrowCubePlayer()
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
