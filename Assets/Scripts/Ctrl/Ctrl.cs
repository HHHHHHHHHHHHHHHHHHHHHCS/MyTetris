using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ctrl : MonoBehaviour
{
    public Model Model { get; private set; }
    public View View { get; private set; }

	private void Awake ()
    {
        Model = GameObject.Find("Model").GetComponent<Model>();
        View = GameObject.Find("View").GetComponent<View>();
	}

}
