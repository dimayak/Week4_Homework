using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinManager : MonoBehaviour
{
    public GameObject CoinPrefab;
    public List<Coin> CoinsList = new();
    [SerializeField] private TextMeshProUGUI _coinsText;

    void Start()
    {
        for (int i = 0; i < 50; ++i)
        {
            Vector3 position = new Vector3(Random.Range(-20.0f, 20.0f), 0.5f, Random.Range(-20.0f, 20.0f));
            var newCoin = Instantiate(CoinPrefab, position, Quaternion.identity);
            CoinsList.Add(newCoin.GetComponent<Coin>());
        }

        UpdateText();
    }

    public void CollectCoin(Coin coin)
    {
        CoinsList.Remove(coin);
        Destroy(coin.gameObject);
        UpdateText();
    }

    private void UpdateText()
    {
        _coinsText.text = "Осталось собрать " + CoinsList.Count.ToString();
    }

    public Coin GetClosest(Vector3 point)
    {
        float minDistance = Mathf.Infinity;
        Coin closestCoin = null;
        for (int i = 0; i < CoinsList.Count; ++i)
        {
            float distance = Vector3.Distance(point, CoinsList[i].transform.position);

            if (distance < minDistance)
            {
                minDistance = distance;
                closestCoin = CoinsList[i];
            }
        }

        return closestCoin;
    }
}
