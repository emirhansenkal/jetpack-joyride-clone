using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Character : MonoBehaviour
{
    [SerializeField]
    private Animator Animator;

    [SerializeField]
    private Rigidbody2D Rigidbody;

    [SerializeField]
    private float Power = 100;

    [SerializeField]
    private float Speed = 10;

    [SerializeField]
    private float PositionLimit = 4;

    private void Start()
    {
        CharacterController.Instance.Register(this);
    }

    public void Fly()
    {
        Animator.Play("Fly");
        
        Rigidbody.AddForce(Vector2.up * Power * Time.deltaTime);
        CheckLimits();
    }

    public void MoveForward()
    {
        transform.Translate(Vector2.right * Speed *Time.deltaTime);
    }

    public void Walk()
    {
        Animator.Play("Walk");
    }

    public void StopFlying()
    {
        Rigidbody.velocity *= 0.5f;
    }

    private void CheckLimits()
    {
        if (transform.position.y > PositionLimit)
        {
            transform.position = new Vector3(transform.position.x, PositionLimit);
            Rigidbody.velocity = Vector2.zero;
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.tag == "Obstacle")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
