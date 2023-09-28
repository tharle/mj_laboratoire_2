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

    Rigidbody m_Rigidbody;
    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        OnThrowCubePlayer();
    }

    private void OnTriggerEnter(Collider collider)
    {
        GameObject gameObjectColladed = collider.gameObject;
        if (gameObjectColladed.CompareTag(ItemBooster.GetTag()))
        {
            OnConsumeItem(gameObjectColladed);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(Obstacle.GetTag()))
        {
            OnCollisionObstacle(collision);
        }
    }

    private void OnCollisionObstacle(Collision collision)
    {
        GameObject gameObjectColladed = collision.gameObject;
        Obstacle Obstacle = gameObjectColladed.GetComponent<Obstacle>();
        m_Direction = Vector3.Reflect(m_Direction, Obstacle.GetNormal());

        if (Obstacle.IsBounced())
        {
            OnThrowCubePlayer();
        }
    }

    private void OnThrowCubePlayer()
    {
        OnThrowCubePlayer(m_Force);
    }

    private void OnThrowCubePlayer(float force, bool restartVelocity = true)
    {
        if(restartVelocity) m_Rigidbody.velocity = Vector3.zero; // arreter le cube pour apliquer la nouvelle force
        m_Rigidbody.AddForce(m_Direction.normalized * force);
    }

    private void OnConsumeItem(GameObject itemGameObject)
    {
        ItemBooster itemBooster = itemGameObject.GetComponent<ItemBooster>();
        m_Force += itemBooster.GetForce(); // maj de la force pour chaque collision
        OnThrowCubePlayer(itemBooster.GetForce(), false); // ajoute la force acutel dans la meme direction
        Destroy(itemGameObject);
    }
}