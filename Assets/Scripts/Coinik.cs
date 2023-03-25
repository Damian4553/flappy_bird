using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Coinik : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameManager.Instance.UpdateScore();
        Destroy(gameObject);
    }
}
