using UnityEngine;
using System.Collections;

public class DoorExplosion : MonoBehaviour {

    [SerializeField] Transform playerTrans;

    bool tick = false;
    float timer = 2.5f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
        if (tick)
        {
            timer -= Time.deltaTime;

            if (timer < 0.0f)
            {
                LevelSystem.instance.LoadNextLevel();
            }
        }

	}

    void OnMouseDown()
    {
        rigidbody.isKinematic = false;
        rigidbody.AddExplosionForce(666f, playerTrans.position, 10f);

        tick = true;
    }
}
