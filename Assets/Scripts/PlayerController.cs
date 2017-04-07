using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float jumpDist = 0.0f;
    [SerializeField] private float gravityStrength = 0.0f;
    [SerializeField] private float groundHeight = 0.0f;
    [SerializeField] private float slideDuration = 0.0f;
    [SerializeField] private float standingHeight = 0.0f;
    [SerializeField] private float slideHeight= 0.0f;
    [SerializeField] private Vector3 standingRotation = Vector3.zero;
    [SerializeField] private Vector3 slideRotation = Vector3.zero;
    [SerializeField] private List<Transform> lanes;
    [SerializeField] private int currentLaneIndex = 0;

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        CheckInput();
	}

    void FixedUpdate()
    {
        ApplyGravity();
    }

    void CheckInput()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            Debug.Log("Jump!");
            Jump();
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("Move Lane Left!");
            SwitchLane(-1);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            Debug.Log("Slide!");
            StartCoroutine(Slide());
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            Debug.Log("Move Lane Right!");
            SwitchLane(1);
        }
    }

    void Jump()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y + jumpDist, transform.position.z);
    }
    
    void ApplyGravity()
    {
        float step = gravityStrength * Time.fixedDeltaTime;
        if (transform.position.y - step >= groundHeight)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - step, transform.position.z);
        }
    }

    void SwitchLane(int numToJump)
    {
        if (currentLaneIndex + numToJump < 0)
        {
            currentLaneIndex = 0;
        }
        else if (currentLaneIndex + numToJump >= lanes.Count - 1)
        {
            currentLaneIndex = lanes.Count - 1;
        }
        else
        {
            currentLaneIndex += numToJump;
        }
        transform.position = new Vector3(lanes[currentLaneIndex].position.x, transform.position.y, transform.position.z);
    }

    IEnumerator Slide()
    {
        transform.rotation = Quaternion.Euler(slideRotation);
        transform.position = new Vector3(transform.position.x, slideHeight, transform.position.z);
        yield return new WaitForSeconds(slideDuration);
        transform.rotation = Quaternion.Euler(standingRotation);
        transform.position = new Vector3(transform.position.x, standingHeight, transform.position.z);
        yield break;
    }
}
