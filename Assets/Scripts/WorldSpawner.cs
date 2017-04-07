using UnityEngine;
using System.Collections;

public class WorldSpawner : MonoBehaviour
{
    private static WorldSpawner instance;
    [SerializeField] private GameObject railBlock;
    [SerializeField] private Transform[] lanePoints;
    [SerializeField] private Transform spawnZone;
    [SerializeField] private Transform destroyZone;
    [SerializeField] private int maxHeight = 0;
    [SerializeField] private int minHeight = 0;
    [SerializeField] private float spawnRate = 0.0f;

    public static WorldSpawner Instance { get { return instance; } set { instance = value; } }

    // Use this for initialization
    void Awake () {
        if (instance == null) {
            instance = this;
        }
    }

    void Start () {
        //SpawnRails();
	}
	
	// Update is called once per frame
	void Update () {   
	
	}

    public void SpawnRails() {
        for (int i = 0; i < lanePoints.Length; i++)
        {
            Instantiate(railBlock, new Vector3(lanePoints[i].position.x, minHeight, lanePoints[i].position.z), lanePoints[i].rotation);
        }
    }

    public void SpawnRail(Transform t) {
        GameObject gO = (GameObject) Instantiate(railBlock, new Vector3(t.position.x, t.position.y, t.position.z), t.rotation);
        RailBlock rB = gO.GetComponentInChildren<RailBlock>();
        rB.SetScale(2, 31);
        rB.SetLane(t);
    }
}
