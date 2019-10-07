using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject bananaPrefab = null;
    [SerializeField] GameObject bombPrefab = null;
    [SerializeField] float chanceBananaDrop = 70f;
    [SerializeField] float timeBetweenDrops = 2f;
    [SerializeField] float offset = 0f;

    private float minX = 0f;
    private float maxX = 0f;
    private float yPos = 0f;
    private float timeSinceDrop = 0f;
    Transform myTransform;

    private void Awake()
    {
        yPos = transform.position.y;
    }

    private void Start()
    {
        CheckScreenBorders();
    }

    void Update()
    {
       if(timeSinceDrop>timeBetweenDrops)
        {
            Drop();
            timeSinceDrop = 0f;
        }
        timeSinceDrop += Time.deltaTime;
    }

    private void CheckScreenBorders()
    {
        Camera cam = Camera.main;
        minX = cam.ViewportToWorldPoint(Vector3.zero).x+offset;
        maxX = cam.ViewportToWorldPoint(Vector3.right).x-offset;
    }

    private void Drop()
    {
        int rand = Random.Range(0, 100);

        if(rand<chanceBananaDrop)
        {
            Instantiate(bananaPrefab, PlaceToDrop(), Quaternion.identity);
        }
        else
        {
            Instantiate(bombPrefab, PlaceToDrop(), Quaternion.identity);
        }
    }

    private Vector2 PlaceToDrop()
    {
        float xPos = Random.Range(minX, maxX);

        return new Vector2(xPos, yPos);
    }
}
