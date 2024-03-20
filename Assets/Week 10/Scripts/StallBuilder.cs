using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StallBuilder : MonoBehaviour
{
    public Transform BuildTransform;

    public StallBuilder NextPart;
    public Vector3 StartScale; 
    public Vector3 EndScale;

    public float BuildSpeed = 1;

    public AnimationCurve BuildCurve;
    float BuildInterp = 0;
    // Start is called before the first frame update

    void Start()
    {
        BuildTransform.localScale = StartScale;
    }

    public void BeginBuilding()
    {
        StartCoroutine(Build());
    }
    IEnumerator Build()
    {
        Debug.Log(BuildInterp);
        while (BuildInterp < 1)
        {
            BuildInterp += BuildSpeed * Time.deltaTime;
            BuildTransform.localScale = Vector3.LerpUnclamped(StartScale, EndScale, BuildCurve.Evaluate(BuildInterp));
            yield return null;
        }
        if (NextPart != null)
        {
            StartCoroutine(NextPart.Build());
        }
    }
}
