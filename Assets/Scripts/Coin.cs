using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    Level level;
    private void Start()
    {
        level = FindObjectOfType<Level>();
    }

    private void OnMouseDown()
    {
        level.coinsPicked++;
        Destroy(gameObject);
    }
}
