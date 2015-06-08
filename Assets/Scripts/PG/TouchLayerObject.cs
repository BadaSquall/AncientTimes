using UnityEngine;
using System.Collections;


public class TouchLayerObject : MonoBehaviour {
	
	private SpriteRenderer sprite;
	
	// Use this for initialization
	void Start () {
		sprite = GetComponent<SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnTriggerEnter2D (Collider2D coll){
		sprite.sortingOrder = 3;
	}

	void OnTriggerExit2D (Collider2D coll){
		sprite.sortingOrder = 1;
	}
}
