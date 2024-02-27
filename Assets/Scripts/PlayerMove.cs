using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private Transform _cameraCenterTransform;
    [SerializeField] private float _torqueValue = 1.0f;
    private Rigidbody _rb;

    private void Start() {
        _rb = GetComponent<Rigidbody>();
        _rb.maxAngularVelocity = 500;
    }

    void FixedUpdate()
    {
        _rb.AddTorque(_cameraCenterTransform.right * Input.GetAxis("Vertical") * _torqueValue);
        _rb.AddTorque(-_cameraCenterTransform.forward * Input.GetAxis("Horizontal") * _torqueValue);
    }
}
