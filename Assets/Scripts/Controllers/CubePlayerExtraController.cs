using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubePlayerExtraController : MonoBehaviour
{
    private const int m_OptionRandom_NordEst    = 0;
    private const int m_OptionRandom_NordWest   = 1;
    private const int m_OptionRandom_SouthEst   = 2;
    private const int m_OptionRandom_SouthWest  = 3;

    [SerializeField]
    private Vector3 m_Direction;
    [SerializeField]
    private float m_Force = 800;

    Rigidbody m_Rigidbody;
    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        StartRandomDirection();
        OnThrowCubePlayer();
    }

    private void StartRandomDirection()
    {
        int optionRandom = (int) Mathf.Round(Random.Range(0, 4));

        switch (optionRandom) { 
            case m_OptionRandom_NordEst:
                m_Direction = Vector3.left + Vector3.forward;
            break;
            case m_OptionRandom_NordWest:
                m_Direction = Vector3.right + Vector3.forward;
            break;
            case m_OptionRandom_SouthEst:
                m_Direction = Vector3.left + Vector3.back;
            break;
            case m_OptionRandom_SouthWest:
            default:
                m_Direction = Vector3.right + Vector3.back;
            break;
        }
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
        Obstacle obstacle = gameObjectColladed.GetComponent<Obstacle>();
        ContactPoint contactPoint = collision.contacts[0];
        m_Direction = Vector3.Reflect(m_Direction, contactPoint.normal);

        if (obstacle.IsBounced())
        {
            obstacle.DoCollision();
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