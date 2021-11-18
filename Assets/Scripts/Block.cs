using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] GameObject blockSparklesVFX;
    [SerializeField] Sprite[] hitSprites;
    [SerializeField] int timesHit;

    // Coin reference to make instances of
    [SerializeField] Coin coin;

    Level level;

    private void Start()
    {
        level = FindObjectOfType<Level>();
    }

    private void OnMouseDown()
    {
        if (tag == "Breakable" && level.showelsAmount > 0)
        {
            HandleHit();
        }
    }

    private void HandleHit()
    {
        level.BlockShoweled();

        timesHit++;
        int maxHits = hitSprites.Length + 1;
        if (timesHit >= maxHits)
        {
            DestroyBlock();
        }
        else
        {
            ShowNextHitSprite();
        }

        // probability of coin to spawn
        //Debug.Log((float)(1.0f - (float)((float)level.coinsFound / (float)level.totalCoinsAmount)));
        if ((float)UnityEngine.Random.Range(1, 100) * 0.01f <= 1.0f - (float)((float)level.coinsFound / (float)level.totalCoinsAmount))
        {
            level.coinsFound++;
            Instantiate(coin, transform.position, Quaternion.identity);
        }
    }

    private void ShowNextHitSprite()
    {
        int spriteIndex = timesHit - 1;
        if (hitSprites[spriteIndex] != null)
        {
            GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        }
        else
        {
            Debug.LogError("Block sprite is missing from array" + gameObject.name);
        }
    }

    private void DestroyBlock()
    {
        Destroy(gameObject);
        TriggerSparklesVFX();
    }

    private void TriggerSparklesVFX()
    {
        GameObject sparkles = Instantiate(blockSparklesVFX, transform.position, transform.rotation);
        Destroy(sparkles, 1f);
    }

}
