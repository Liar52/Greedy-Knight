using System.Collections;
using UnityEngine;

public class SegmentGenerate : MonoBehaviour
{
    public GameObject[] segmen;

    [SerializeField] int zPos = 50;
    [SerializeField] bool creatingSegments = false;
    [SerializeField] int segmentNum = 50;

    void Update()
    {
        if (creatingSegments == false)
        {
            creatingSegments = true;
            StartCoroutine(SegmentGeneration());
        }
    }

    IEnumerator SegmentGeneration()
    {
        segmentNum = Random.Range(0, segmen.Length);
        Instantiate(segmen[segmentNum], new Vector3(0, 0, zPos), Quaternion.identity);
        zPos += 50;
        yield return new WaitForSeconds(3);
        creatingSegments = false;
    }
}