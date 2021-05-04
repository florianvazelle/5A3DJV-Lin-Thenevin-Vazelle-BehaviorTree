using UnityEngine;
using System.Collections;

public class FighterAnimationDemoFREE : MonoBehaviour {
	
	public Animator animator;

	private Transform defaultCamTransform;
	private Vector3 resetPos;
	private Quaternion resetRot;
	private GameObject cam;
	private GameObject fighter;
	private GameObject shield;

	void Start()
	{
		cam = GameObject.FindWithTag("MainCamera");
		defaultCamTransform = cam.transform;
		resetPos = defaultCamTransform.position;
		resetRot = defaultCamTransform.rotation;
		fighter = GameObject.FindWithTag("Player");
		fighter.transform.position = new Vector3(0,0,0);
		shield = setShield();
		if(shield == null){
			Debug.Log("no shield found");
			return;
		}
	}

	void OnGUI () 
	{
		if (GUI.RepeatButton (new Rect (815, 535, 100, 30), "Reset Scene")) 
		{
			defaultCamTransform.position = resetPos;
			defaultCamTransform.rotation = resetRot;
			fighter.transform.position = new Vector3(0,0,0);
			animator.Play("Idle");
		}

		if (GUI.RepeatButton (new Rect (25, 20, 100, 30), "Walk Forward")) 
		{
			animator.SetBool("Walk Forward", true);
		}
		else
		{
			animator.SetBool("Walk Forward", false);
		}

		if (GUI.RepeatButton (new Rect (25, 50, 100, 30), "Walk Backward")) 
		{
			animator.SetBool("Walk Backward", true);
		}
		else
		{
			animator.SetBool("Walk Backward", false);
		}

		if (GUI.Button (new Rect (25, 80, 100, 30), "Punch")) 
		{
			animator.SetTrigger("PunchTrigger");
		}

		if (GUI.Button (new Rect (25, 110, 100, 30), "Block")) 
		{
			shield.SetActive(true);
		}
	}

	GameObject setShield() {
		GameObject  ChildGameObject = fighter.transform.GetChild(0).gameObject;
		for (int i = 0; i < ChildGameObject.transform.childCount - 1; i++) {
			GameObject  SubChildGameObject = ChildGameObject.transform.GetChild(i).gameObject;
			if(SubChildGameObject.transform.name == "Mesh_Berserker") {
				GameObject SubSubChildGameObject = SubChildGameObject.transform.GetChild(0).gameObject;
				return SubSubChildGameObject;
			}
		}
		return null;
	}
}