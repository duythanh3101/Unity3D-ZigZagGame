using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileScript : MonoBehaviour {

    private float fallDelayTime = 1.5f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            TileManager.Instance.SpawnTile();
            StartCoroutine(FallDownTile());
        }
    }

    private IEnumerator FallDownTile()
    {
        yield return new WaitForSeconds(fallDelayTime);

        GetComponent<Rigidbody>().isKinematic = false;

        yield return new WaitForSeconds(2f);

        switch (gameObject.name)
        {
            case "LeftTile":
                TileManager.Instance.LeftTiles.Push(gameObject);
                gameObject.GetComponent<Rigidbody>().isKinematic = true;
                gameObject.SetActive(false);
                break;

            case "TopTile":
                TileManager.Instance.TopTiles.Push(gameObject);
                gameObject.GetComponent<Rigidbody>().isKinematic = true;
                gameObject.SetActive(false);
                break;
        }
    }
}
