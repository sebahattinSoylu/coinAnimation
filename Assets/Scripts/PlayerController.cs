using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
   private Rigidbody2D rb;

   [SerializeField] private float speed;

   private CoinManager _coinManager;
   private void Awake()
   {
      rb = GetComponent<Rigidbody2D>();
      _coinManager = FindObjectOfType<CoinManager>();
   }

   private void Update()
   {
      float h = Input.GetAxis("Horizontal");
      rb.velocity = new Vector2(h * speed, rb.velocity.y);
   }

   private void OnTriggerEnter2D(Collider2D col)
   {
      if (col.CompareTag("Coin"))
      {
         _coinManager.PuanArtir(10,col.transform.position);
         Destroy(col.gameObject);
      }
   }
}
