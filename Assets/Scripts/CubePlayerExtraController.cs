using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubePlayerExtraController : MonoBehaviour
{
    [SerializeField]
    private Vector3 m_Direction = Vector3.left + Vector3.forward;
    [SerializeField]
    private float m_Force = 800;

    /// <summary>
    /// Utilisé dans le calculs pour trouver le vector de direction de la colition
    /// </summary>
    Vector3 m_PositionLastCollision;

    Rigidbody m_Rigidbody;
    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        m_PositionLastCollision = transform.position;
        OnThrowCubePlayer();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
           OnCollisionWall(collision);
        }
    }

    private void OnCollisionWall(Collision collision)
    {
        GameObject gameObjectColladed = collision.gameObject;
        WallBounceController wallBounceController = gameObjectColladed.GetComponent<WallBounceController>();
        Vector3 pointCollision = calculMediumBetweenContactPoints(collision.contacts);
        Vector3 directionCube = calculDirection(pointCollision, m_PositionLastCollision);
        directionCube = Vector3.Reflect(directionCube, wallBounceController.GetNormal());

        OnCollisionObstacle(directionCube, wallBounceController.IsBounced());
    }

    private Vector3 calculDirection(Vector3 pointStart, Vector3 pointEnd)
    {
        return pointStart - pointEnd;
    }

    private Vector3 calculMediumBetweenContactPoints(ContactPoint[] contactPoints)
    {
        Vector3 result = Vector3.zero;
        foreach (ContactPoint contactPoint in contactPoints)
        {
            result += contactPoint.point;
        }
        result /= contactPoints.Length;
        return result;
    }

    private void OnCollisionObstacle(Vector3 directionCube, bool isBouncedObstacle)
    {
        directionCube.y = 0;
        if (isBouncedObstacle)
        {
            m_Direction = directionCube;
            OnThrowCubePlayer();
        }

        m_PositionLastCollision = transform.position;
    }

    private void OnThrowCubePlayer()
    {
        m_Rigidbody.velocity = Vector3.zero; // arreter le cube pour apliquer la nouvelle force
        m_Rigidbody.AddForce(m_Direction.normalized * m_Force);
    }
}
