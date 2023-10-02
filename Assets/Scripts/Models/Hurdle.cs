using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Hurdle c'est un obstacle utilisé dans les courses.
/// </summary>
public class Hurdle : Obstacle
{

    private const string ANIMATION_KEY_DURABILITY = "durability";

    [SerializeField]
    private int m_durability = 3;

    private Animator m_animator;

    public void Start()
    {
        m_animator = GetComponent<Animator>();
        UpdateAnimation();
    }

    public override void DoCollision()
    {
        m_durability--;
        UpdateAnimation();

        if (m_durability <= 0) 
        { 
            Destroy(gameObject);
        }
    }

    private void UpdateAnimation() 
    {
        m_animator.SetInteger(ANIMATION_KEY_DURABILITY, m_durability);
    }

}
