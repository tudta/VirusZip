using UnityEngine;
using System.Collections;

public class RailBlock : MonoBehaviour
{
    [SerializeField] private Transform lane;
    [SerializeField] private float moveSpeed;

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.back * moveSpeed * Time.deltaTime);
	}

    public void SetScale(int minLength, int maxLength) {
        transform.parent.localScale = new Vector3(0.5f, 1.0f, Random.Range(minLength, maxLength));
    }

    public void SetLane(Transform t)
    {
        lane = t;
    }

    void OnTriggerExit(Collider other) {
        if (other.name == "DestroyZone") {
            gameObject.SetActive(false);
        }
        else if (other.name == "SpawnZone") {
            WorldSpawner.Instance.SpawnRail(lane);
        }
    }
}
