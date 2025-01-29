using UnityEngine;

public class Zombie : MonoBehaviour
{
    private const string Horizontal = "Horizontal";
    private const string Vertical = "Vertical";
    
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _rotationSpeed;

    private void Update()
    {
        Move();
        Rotate();
    }

    private void Rotate()
    {
        float rotation = Input.GetAxis(Horizontal);
        
        transform.Rotate(_rotationSpeed * rotation * Time.deltaTime * Vector3.up);
    }

    private void Move()
    {
        float direction = Input.GetAxis(Vertical);
        
        transform.Translate(direction * _moveSpeed * Time.deltaTime * Vector3.forward);
    }
}
