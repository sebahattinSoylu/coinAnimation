using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;
using Random = UnityEngine.Random;

public class CoinManager : MonoBehaviour
{
    [SerializeField] private Transform hedef;
    [SerializeField] private GameObject coinPrefab;

    [SerializeField] private TextMeshProUGUI coinTxt;

    private int toplamPuan;

    private Queue<GameObject> coinKuyruk = new Queue<GameObject>();

    private Vector3 hedefPos;
    private void Awake()
    {
        hedefPos = hedef.position;
    }

    private void Start()
    {
        toplamPuan = 0;
        CoinleriOlustur();
    }

    void CoinleriOlustur()
    {
        for (int i = 0; i < 10; i++)
        {
            GameObject coin = Instantiate(coinPrefab);
            coin.transform.parent = transform;
            coin.SetActive(false);
            coinKuyruk.Enqueue(coin);
        }
    }

    void CoinlereHareketVer(Vector3 toplanacakPos,int adet)
    {
        for (int i = 0; i < adet; i++)
        {
            GameObject coin = coinKuyruk.Dequeue();
            coin.transform.position = toplanacakPos;
            coin.SetActive(true);

            coin.transform.DOMove(hedefPos, Random.Range(0.5f,1.5f)).SetEase(Ease.OutBack).OnComplete(() =>
            {
                coin.SetActive(false);
                coinKuyruk.Enqueue(coin);
            });
        }
    }

    public void PuanArtir(int puan, Vector3 toplanacakPos)
    {
        toplamPuan += puan;
        coinTxt.text = toplamPuan.ToString();
        CoinlereHareketVer(toplanacakPos,10);
    }
}
