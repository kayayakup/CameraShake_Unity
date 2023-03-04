using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallShaker : MonoBehaviour
{
    public Shake cameraShaker;
    public Grenade isExploded;

    [SerializeField]
    private float delay = 3f;
    float countDown;
    public bool hasExploded;
    private void Start()
    {
        countDown = delay;
    }
    private void Update()
    {
        hasExploded = isExploded.hasExploded;
        countDown -= Time.deltaTime;
        if (!hasExploded && Input.GetMouseButtonDown(0))
        {
            StartCoroutine(cameraShaker.Shaker(.15f, .4f));
            hasExploded = true;
            countDown = delay;
        }
    }
}
