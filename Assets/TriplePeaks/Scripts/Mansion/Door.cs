using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour {

	// Use this for initialization
	void Start () 
    {

	}
	
	// Update is called once per frame
	void Update () 
    {

	}

    void OnMouseDown()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hits;
        if (Physics.Raycast(ray, out hits))
        {
            Collider[] hit = Physics.OverlapSphere(hits.point, 5.0f);
            for (var i = 0; i < hit.Length; i++)
            {
                hit[i].gameObject.GetComponent<Rigidbody>().AddExplosionForce(10.0f, hits.point, 10.0f, 1.0f, ForceMode.Impulse);
            }
        }
    }
}
