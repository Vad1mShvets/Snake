using System;
using UnityEngine;

public class SnakeHead : MonoBehaviour
{
    public event Action<GameObject> OnAppleEat;

    public Rigidbody Rigidbody => _rigidbody;

    private Vector3 _direction;

    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        _rigidbody.velocity = 500 * Time.deltaTime * _direction;

#if UNITY_EDITOR
        if (Input.GetKeyDown(KeyCode.W))
            ChangeDirectionTo(Vector3.up);
        else if (Input.GetKeyDown(KeyCode.S))
            ChangeDirectionTo(Vector3.down);
        else if (Input.GetKeyDown(KeyCode.A))
            ChangeDirectionTo(Vector3.left);
        else if (Input.GetKeyDown(KeyCode.D))
            ChangeDirectionTo(Vector3.right);
#endif
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag(GameObjectTags.Apple))
        {
            OnAppleEat?.Invoke(collision.gameObject);
        } 
    }

    public void ChangeDirectionTo(Vector3 direction)
    {
        _direction = direction;
    }
}
