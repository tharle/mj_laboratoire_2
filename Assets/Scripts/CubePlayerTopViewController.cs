using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubePlayerTopViewController : MonoBehaviour
{

    [SerializeField] 
    private float m_Speed = 20f;

    Rigidbody m_Rigidbody;

    private void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        OnBougeCube();
    }

    private void OnBougeCube()
    {
        var axisHorizontal = Input.GetAxis("Horizontal");
        var axisVertical = Input.GetAxis("Vertical");

        Debug.Log($" axisHorizontal {axisHorizontal}");
        Debug.Log($" axisVertical {axisVertical}");
        var vectorVelocity = m_Rigidbody.velocity;

        vectorVelocity.x = axisHorizontal * m_Speed;
        vectorVelocity.z = axisVertical * m_Speed;
        m_Rigidbody.velocity = vectorVelocity;
    }
}
