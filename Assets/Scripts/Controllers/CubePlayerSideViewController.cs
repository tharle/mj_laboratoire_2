using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubePlayerSideViewController : MonoBehaviour
{
    [SerializeField]
    private Vector3 m_Direction = Vector3.left;
    
    [SerializeField]
    private float m_ThrowForce = 800;

    Rigidbody m_Rigidbody;
    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        OnThrowCubePlayer();
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject gameObjectColladed = collision.gameObject;

        if (gameObjectColladed.CompareTag(Obstacle.GetTag()))
        {
            m_Direction *= -1;
            Obstacle obstacle = gameObjectColladed.GetComponent<Obstacle>();
            OnCollisionWall(obstacle);
        }
    }

    private void OnCollisionWall(Obstacle obstacle)
    {
        if (obstacle.IsBounced())
        { 
            OnThrowCubePlayer();
        }
    }

    private void OnThrowCubePlayer()
    {
        m_Rigidbody.AddForce(Vector3.zero); // arreter le cube pour apliquer la nouvelle force
        m_Rigidbody.AddForce(m_Direction * m_ThrowForce);   
    }
}
