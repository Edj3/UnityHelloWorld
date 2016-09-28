using UnityEngine;
using System.Collections;
using VRStandardAssets.Utils;
using DG.Tweening;

public class ExpandingInteractiveItem : VRInteractiveItem {

	// Use this for initialization
	void Start () {
		base.OnOver += HandleOver;
		base.OnOut += HandleOut;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void HandleOver(){

		this.transform.DOScaleY (3, 1);
		this.transform.DOScaleX (3, 1);
		this.transform.DOScaleZ (3, 1);
	}

	void HandleOut(){

		this.transform.DOScaleY (1, 1);
		this.transform.DOScaleX (1, 1);
		this.transform.DOScaleZ (1, 1);
	}

}
