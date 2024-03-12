using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinManager : MonoBehaviour
{
    public GameObject CoinPrefab;
    public List<Coin> CoinsList = new();
    [SerializeField] private TextMeshProUGUI _coinsText;
    [SerializeField] private int _coinsCount = 10;
    [Tooltip("Монеты генерируются в квадрате (-fieldSize, fieldSize)")]
    [SerializeField] private float _fieldSize = 10.0f;

    void Start()
    {
        for (int i = 0; i < _coinsCount; ++i)
        {
            Vector3 position = new Vector3(Random.Range(-_fieldSize, _fieldSize), 0.5f, Random.Range(-_fieldSize, _fieldSize));
            GameObject newCoin = Instantiate(CoinPrefab, position, Quaternion.identity);
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
