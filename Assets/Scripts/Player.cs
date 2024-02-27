using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private CoinManager _coinManager;

    private void OnTriggerEnter(Collider other)
    {
        var coin = other.GetComponent<Coin>();
        if (coin != null)
        {
            _coinManager.CollectCoin(coin);
        }
    }
}
