using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubePlayerTopViewController : MonoBehaviour
{

    [SerializeField] 
    private float m_Speed = 20.0f;

    Rigidbody m_Rigidbody;

    private void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        OnMoveCubePlayer();
    }

    private void OnMoveCubePlayer()
    {
        float axisHorizontal = Input.GetAxis("Horizontal");
        float axisVertical = Input.GetAxis("Vertical");
        Vector3 vectorVelocity = m_Rigidbody.velocity;

        vectorVelocity.x = axisHorizontal * m_Speed;
        vectorVelocity.z = axisVertical * m_Speed;
        m_Rigidbody.velocity = vectorVelocity;
    }
}
