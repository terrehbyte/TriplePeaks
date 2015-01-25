using UnityEngine;
using System.Collections;

public class PlayerCarControl : MonoBehaviour {

	public Transform  playerTransform;
    public Transform playerCamTrans;
	public float speed;

    public Collider CarGameEndTrigger;

    [SerializeField]
    private MiniGameRotator rotator;
	
    // Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

		//currentPosition.position = playerTransform.position;

		if (Input.GetKey (KeyCode.LeftArrow)) {
			if (playerTransform.position.x <= 4)
						playerTransform.Translate (new Vector3 (speed * Time.deltaTime, 0, 0));
				}

		if (Input.GetKey (KeyCode.RightArrow)) {
			if (playerTransform.position.x >= -4)
				playerTransform.Translate (new Vector3 (-speed * Time.deltaTime, 0, 0));
				}
		//nextPosition.position.x = currentPosition.position.x + moveX;
		//playerTransform.position = nextPosition.position;

        playerTransform.Translate(0f, 0f, -20f * Time.deltaTime);

        playerCamTrans.position = new Vector3(playerCamTrans.position.x, playerCamTrans.position.y, playerTransform.position.z);

	}

    void OnTriggerEnter(Collider trigger)
    {
        if (trigger == CarGameEndTrigger)
        {
            rotator.NextMinigame();
        }
    }
}
