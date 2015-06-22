using UnityEngine;
using System.Collections;

public class TouchLayerObject : MonoBehaviour
{
    #region Properties

    private SpriteRenderer sprite;

    #endregion Properties

    #region Methods

    void Start () { sprite = GetComponent<SpriteRenderer> (); }
	
	void OnTriggerEnter2D (Collider2D coll) { sprite.sortingOrder = 3; }

	void OnTriggerExit2D (Collider2D coll){ sprite.sortingOrder = 1; }

    #endregion Methods
}
