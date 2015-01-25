using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HospitalRoom : MonoBehaviour {



	public GameObject Doctor;
	public GameObject Note;
	public GameObject MC;
	public Text NoteText;
	public Text DoctorMSG;
	public GameObject LogHalf1;
	public GameObject LogHalf2;
	public GameObject Saw;
	public int sawCount = 0;

	float timer = 0f;
	float gameOver = 0f;
	float speakTimer = 0f;
	// Use this for initialization
	void Start ()
	{
		DoctorMSG.text = "";
		Note.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () 
	{

		SawLog ();
		gameOver += Time.deltaTime;
		if (gameOver >= 5) 
		{
			//FUCKING GAME OVER MAN! GAME OVER!
		}

	}

	void Movement1()
	{

 	if (timer <= 3f)
		{

			Doctor.transform.position += new Vector3 (-1.425f, 0, 0) * Time.deltaTime;
		}
		if (timer >= 3f) 
		{
			LogHalf1.SetActive(false);
			LogHalf2.SetActive(false);
			if (timer <= 4f)
			{
			Doctor.transform.position += new Vector3 (0, 0, 1.25f) * Time.deltaTime;
			}
				if (timer >= 4f)
				{
					Speak ();
				}
			
		}
	}
	void ShowNote()
	{

		NoteText.text = "This message will blow up in 5 seconds";

	}
	void Speak()
	{
		speakTimer += Time.deltaTime;
		DoctorMSG.text = "Wow, I didn't think you'd be waking up from that any time soon!";
		if (speakTimer >= 3)
		{
			DoctorMSG.text = "";
			if (speakTimer >= 3.5)
			{
				DoctorMSG.text = "You had a visitor while you were out.  He/she/it left you a note.";
				if (speakTimer >= 5.5)
				{
					DoctorMSG.text = "They just so happen to write like a computer by the way.";
					if (speakTimer >= 8.5)
					{
						DoctorMSG.text = "You also snore very loud if you were wondering why I got here so fast.";
						ReadNote ();
					}
					
				}
			}
		}
	}
	void SawLog()
	{
		if (Input.GetKeyDown (KeyCode.LeftArrow)) 
		{
			if (Saw.transform.position.x < 2.8f)
			{
				Saw.transform.position += new Vector3 (.05f, -.02f, 0);
				sawCount++;
			}
			else 
			{
				Saw.transform.position = new Vector3(2.8f, Saw.transform.position.y, Saw.transform.position.z);
			}


		}
		if (Input.GetKeyDown (KeyCode.RightArrow)) 
		{
			if (Saw.transform.position.x > 1.8f)
			{
			Saw.transform.position += new Vector3 (-.05f, -.02f, 0);
			sawCount++;
			}
			else
			{
				Saw.transform.position = new Vector3(1.8f, Saw.transform.position.y, Saw.transform.position.z);
			}
		}
		if (sawCount >= 25) 
		{
			LogHalf2.transform.position += new Vector3 (-.1f, -.6f, 0) * Time.deltaTime;
			LogHalf1.transform.position += new Vector3 (-.1f, -.6f, 0) * Time.deltaTime;
			LogHalf2.transform.Rotate(Vector3.left*Time.deltaTime*18);
			LogHalf1.transform.Rotate(Vector3.right*Time.deltaTime*19);
			timer += Time.deltaTime;
			Movement1();
			Saw.SetActive(false);
			WakeUp ();
		}

	}
	void WakeUp ()
	{
		// rotate until upright
		if (MC.transform.rotation.x > 0)
		{
						MC.transform.Rotate (Vector3.forward * .9f*Time.deltaTime);
		}
	}
	void ReadNote()
	{
		Note.SetActive(true);
	}
}
