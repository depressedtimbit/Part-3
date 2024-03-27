using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Growing : MonoBehaviour
{
    public GameObject square;
    public GameObject triangle;
    public GameObject circle;
    public TextMeshProUGUI squareTMP;
    public TextMeshProUGUI triangleTMP;
    public TextMeshProUGUI circleTMP;
    public TextMeshProUGUI crTMP;
    public int running;
    Coroutine coroutine;

    void Start()
    {
        StartCoroutine(growingShapes());
    }

    void Update()
    {
        crTMP.text = "Coroutines:" + running.ToString();
    }

    IEnumerator growingShapes()
    {
        running++;
        StartCoroutine(Square());
        yield return new WaitForSeconds(1);
        coroutine = StartCoroutine(Triangle());
        StartCoroutine(CircleGrow());
        yield return coroutine;
        running--;
    }

    IEnumerator Square()
    {
        running++;
        float size = 0;
        while (size < 5)
        {
            size += Time.deltaTime;
            Vector3 scale = new Vector3(size, size, size);
            square.transform.localScale = scale;
            squareTMP.text = "Square: " + scale;
            yield return null;
        }
        running--;
    }
    IEnumerator Triangle()
    {
        running++;
        float size = 0;
        while (size < 5)
        {
            size += Time.deltaTime;
            Vector3 scale = new Vector3(size, size, size);
            triangle.transform.localScale = scale;
            triangleTMP.text = "Triangle: " + scale;
            yield return null;
        }
        running--;
    }
    IEnumerator CircleGrow()
    {
        float size = 0;
        while (size < 5)
        {
            size += Time.deltaTime;
            Vector3 scale = new Vector3(size, size, size);
            circle.transform.localScale = scale;
            circleTMP.text = "Cirlce: " + scale;
            yield return null;
        }
        StartCoroutine(CircleShrink());
    }
    IEnumerator CircleShrink()
    {
        float size = 5;
        while (size > 0)
        {
            size -= Time.deltaTime;
            Vector3 scale = new Vector3(size, size, size);
            circle.transform.localScale = scale;
            circleTMP.text = "Cirlce: " + scale;
            yield return null;
        }
        StartCoroutine(CircleGrow());
    }
}   