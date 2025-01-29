using System;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _rotationSpeed;

    private float _coveredDistance = 0;
    
    private float _epsilon = 0.1f;

    private void Update()
    {
        Move();
        Rotate();
    }

    private void Rotate()
    {
        float rotation = Input.GetAxis("Horizontal");
        
        transform.Rotate(_rotationSpeed * rotation * Time.deltaTime * Vector3.up);
    }

    private void Move()
    {
        float direction = Input.GetAxis("Vertical");
        
        transform.Translate(direction * _moveSpeed * Time.deltaTime * Vector3.forward);
    }
}
