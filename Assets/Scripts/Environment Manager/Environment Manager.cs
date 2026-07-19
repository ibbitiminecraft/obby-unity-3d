using UnityEngine;
using System.Collections.Generic;
public class EnvironmentManager : MonoBehaviour
{
     [Header("Setup")]
    [Tooltip("Drag your track segment prefabs here (can be 1 or many variants)")]
    public GameObject[] segmentPrefabs;
 
    [Tooltip("Your player transform")]
    public Transform player;
 
    [Header("Settings")]
    [Tooltip("Length of one segment along Z (measure your prefab!)")]
    public float segmentLength = 5f;
 
    [Tooltip("How many segments exist at once")]
    public int segmentsOnScreen = 6;
 
    [Tooltip("How far behind the player a segment can be before recycling")]
    public float despawnDistanceBehind = 15f;
 
    // Internal
    private readonly Queue<GameObject> activeSegments = new Queue<GameObject>();
    private float nextSpawnZ = 3f;
 
    void Start()
    {
        // Spawn the initial chain of segments
        for (int i = 0; i < segmentsOnScreen; i++)
        {
            SpawnSegment();
        }
    }
 
    void Update()
    {
        // Check the oldest segment (front of queue = furthest behind)
        if (activeSegments.Count == 0) return;
 
        GameObject oldest = activeSegments.Peek();
        float segmentEndZ = oldest.transform.position.z + segmentLength;
 
        // If the player has fully passed it (plus a buffer), recycle it
        if (player.position.z - segmentEndZ > despawnDistanceBehind)
        {
            RecycleSegment();
        }
    }
 
    void SpawnSegment()
    {
        // Pick a random variant for visual variety
        GameObject prefab = segmentPrefabs[Random.Range(0, segmentPrefabs.Length)];
        GameObject segment = Instantiate(prefab, new Vector3(-3.935421f, 1.375441f, nextSpawnZ), Quaternion.identity, transform);
 
        activeSegments.Enqueue(segment);
        nextSpawnZ += segmentLength;
    }
 
    void RecycleSegment()
    {
        // Take the oldest segment and move it to the front of the line
        GameObject segment = activeSegments.Dequeue();
 
        segment.transform.position = new Vector3(0, 0, nextSpawnZ);
        nextSpawnZ += segmentLength;
 
        // Optional: re-randomize obstacles/coins on this segment here.
        // e.g. segment.GetComponent<SegmentContent>()?.Randomize();
 
        activeSegments.Enqueue(segment);
    }
}
