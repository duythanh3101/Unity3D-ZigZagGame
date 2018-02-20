using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    [SerializeField]
    private float speed;

    [SerializeField]
    private GameObject PickupParticleSystem;

    [SerializeField]
    private GameObject restartButton;

    private Vector3 direction;

    private bool isDead;

    private Rigidbody rb;

	// Use this for initialization
	private void Start ()
    {
        direction = Vector3.zero;

        isDead = false;

        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if (Input.GetMouseButtonDown(0) && !isDead)
        {
            if (direction == Vector3.forward)
            {
                direction = Vector3.left;
            }
            else
            {
                direction = Vector3.forward;
            }
        }

        rb.velocity = direction * speed;

        if (!Physics.Raycast(transform.position, Vector3.down, 1f))
        {
            isDead = true;
            rb.velocity = new Vector3(0, -(speed * 2), 0);

            Camera.main.GetComponent<AutoFollowPlayer>().enabled = false;
            restartButton.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Pickup")
        {
            other.gameObject.SetActive(false);
            Instantiate(PickupParticleSystem, transform.position, Quaternion.identity);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Tile")
        {
            //RaycastHit hit;

            //Ray downRay = new Ray(transform.position, -Vector3.up);

            //if (!Physics.Raycast(transform.position, Vector3.down, 1f))
            //{
            //    isDead = true;
            //    GetComponent<Rigidbody>().velocity = new Vector3(0, -(speed * 3), 0);
            //    //transform.GetChild(0).transform.parent = null;
            //    //Destroy(GetComponent<AutoFollowPlayer>());
            //    restartButton.SetActive(true);
            //    Camera.main.GetComponent<AutoFollowPlayer>().enabled = false;
            //}
        }
    }

}