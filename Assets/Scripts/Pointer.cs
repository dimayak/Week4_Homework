using UnityEngine;

public class Pointer : MonoBehaviour
{
    [SerializeField] private CoinManager _coinManager;
    [SerializeField] private Transform _playerTransform;
    private Coin _closestCoin;
    readonly private float _rotationSpeed = 10.0f;

    private void Update()
    {
        transform.position = new Vector3(_playerTransform.position.x, 1.25f, _playerTransform.position.z);
        _closestCoin = _coinManager.GetClosest(transform.position);

        Vector3 toTarget = Vector3.zero;
        if (_closestCoin != null)
        {
            toTarget = _closestCoin.transform.position - transform.position;
        }
        Vector3 toTargetXZ = new Vector3(toTarget.x, 0.0f, toTarget.z);
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(toTargetXZ), Time.deltaTime * _rotationSpeed);
    }
}
