using UnityEngine;
using System.Collections;

public class WalkingToBody : MonoBehaviour {

    public GameObject Player;
    public GameObject Clothes;
    public Animator ClothesAnim;
    public GameObject Trigger2;
    public Camera Camera1;
    public Camera Camera2;
    public Camera Camera3;
    public Camera Camera4;
    public Camera Camera5;

    public GameObject Limb1;
    public GameObject Limb2;
    public GameObject Limb3;
    public GameObject Limb4;

    public bool WalkedToBody;
    public bool RemovedClothes;
    public int TakeOffClothes;

    public bool Limb1Clicked;
    public bool Limb2Clicked;
    public bool Limb3Clicked;
    public bool Limb4Clicked;

    public bool NoteRead;

    public bool BombClicked;
    
    // Use this for initialization
	void Start () 
    {
        Camera1 = Camera.main;
        Limb1.renderer.material.color = Color.green;
        Limb2.renderer.material.color = Color.green;
        Limb3.renderer.material.color = Color.green;
        Limb4.renderer.material.color = Color.green;
        TakeOffClothes = 0;
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (!WalkedToBody)
            MovePlayerToBody();

        if (!RemovedClothes && WalkedToBody)
            RemoveBodyClothes();

        if (RemovedClothes && WalkedToBody)
            ExamineBody();

        if (Limb1Clicked && Limb2Clicked && Limb3Clicked && Limb4Clicked && !NoteRead)
            ReadNote();

        if (NoteRead)
            DefuseBomb();

	}

    void MovePlayerToBody()
    {
        if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow))
        {
            Player.transform.position += Player.transform.forward * 0.5f;
            //Clothes.transform.position = new Vector3(33.702f, 1.6879f, -10.198f);
            //Clothes.transform.rotation = new Quaternion(356.355f, 260.7715f, 283.1791f, 0f);
        }
    }

    public void ChangeCamera()
    {
        Camera1.gameObject.SetActive(false);
        Camera2.enabled = true;
    }

    public void ChangeCamera2()
    {
        Camera2.gameObject.SetActive(false);
        Camera3.enabled = true;
    }

    public void ChangeCamera3()
    {
        Camera3.gameObject.SetActive(false);
        Camera4.enabled = true;
    }

    public void ChangeCamera4()
    {
        Camera4.gameObject.SetActive(false);
        Camera5.enabled = true;
    }

    void RemoveBodyClothes()
    {
        if (Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.DownArrow))
        {
            TakeOffClothes++;
            ClothesAnim.SetTrigger("Move");
        }
        ClothesAnim.SetTrigger("Stop");

        if (TakeOffClothes >= 25)
        {
            RemovedClothes = true;
            ChangeCamera2();
        }
    }

    void ExamineBody()
    {
        if (Limb1Clicked)
            Limb1.renderer.material.color = Color.red;

        if (Limb2Clicked)
            Limb2.renderer.material.color = Color.red;

        if (Limb3Clicked)
            Limb3.renderer.material.color = Color.red;

        if (Limb4Clicked)
            Limb4.renderer.material.color = Color.red;
    }

    void ReadNote()
    {
        ChangeCamera3();
    }

    void DefuseBomb()
    {
        ChangeCamera4();
    }
}
