using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private Rigidbody _playerRigidBody;

    private List<Vector3> _velocitiesList = new();

    private void Start()
    {
        for (int i = 0; i < 10; ++i) {
            _velocitiesList.Add(Vector3.zero);
        }
    }

    private void FixedUpdate() {
        _velocitiesList.Add(_playerRigidBody.velocity);
        _velocitiesList.RemoveAt(0);
    }

    void Update()
    {
        Vector3 sum = Vector3.zero;

        for (int i = 0; i < _velocitiesList.Count; ++i)
        {
            sum += _velocitiesList[i];
        }
        transform.position = _playerTransform.position;
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(sum), Time.deltaTime * 10.0f);
    }
}
