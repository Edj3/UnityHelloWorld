using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using DG.DemiLib;

public class Grid : MonoBehaviour {

	public int cardsCount = 5;
	List<GameObject> cards = new List<GameObject> ();

	// Use this for initialization
	void Start () {
		
		CreatePlanes ();
		Debug.Log(cards.Count);
		foreach (GameObject obj in cards) {
			StartCoroutine(loadImage (obj));	
		}
	}

	public string url = "https://upload.wikimedia.org/wikipedia/en/9/92/Halo_4_box_artwork.png";



	IEnumerator loadImage(GameObject obj) {
		string url = "https://upload.wikimedia.org/wikipedia/en/9/92/Halo_4_box_artwork.png";
		WWW www = new WWW(url);

		// Wait for download to complete
		yield return www;

		// assign texture
		Texture2D tex = new Texture2D(www.texture.width, www.texture.height, TextureFormat.DXT1, true);

		obj.GetComponent<Renderer> ().material.mainTexture = tex;
		www.LoadImageIntoTexture(tex);

		www.Dispose();
		www = null;

		foreach (GameObject card in cards) {
			card.transform.DOScaleY(3, 1);
		}


	}

	// Update is called once per frame
	void Update () {
		
	}

	private void CreatePlanes(){
		float boundsX = 0;
		for (int i = 0; i < cardsCount; i++) {
			GameObject plane = CreatePlane (1f, 1f);
			plane.transform.parent = this.gameObject.transform;
			cards.Add (plane);
			plane.transform.localPosition = new Vector3 (boundsX, 0 , 0);                              
			Bounds bounds = plane.GetComponent<MeshFilter> ().mesh.bounds;
			boundsX = boundsX + bounds.size.x + 0.2F;

		}
	}

	private GameObject CreatePlaneBasic(float width, float height){
		return GameObject.CreatePrimitive (PrimitiveType.Plane);
	}

	private GameObject CreatePlane(float width, float height){
		GameObject plane = new GameObject("Plane");
		MeshFilter meshFilter = (MeshFilter)plane.AddComponent(typeof(MeshFilter));
		meshFilter.mesh = CreateMesh(width, height);
		MeshRenderer renderer = plane.AddComponent(typeof(MeshRenderer)) as MeshRenderer;
		renderer.material.shader = Shader.Find ("Particles/Additive");
		Texture2D tex = new Texture2D(1, 1);
		tex.SetPixel(0, 0, Color.green);
		tex.Apply();
		renderer.material.mainTexture = tex;
		renderer.material.color = Color.blue;
		return plane;
	}

	Mesh CreateMesh(float width, float height)
	{
		Mesh m = new Mesh();
		m.name = "ScriptedMesh";
		m.vertices = new Vector3[] {
			new Vector3(-width/2, -height/2, 0.01f),
			new Vector3(-width/2, height/2, 0.01f),
			new Vector3(width/2, height/2, 0.01f),
			new Vector3(width/2, -height/2, 0.01f)

		};
		m.uv = new Vector2[] {
			new Vector2 (0, 0),
			new Vector2 (0, 1),
			new Vector2(1, 1),
			new Vector2 (1, 0)
		};
		m.triangles = new int[] { 0, 1, 2, 0, 2, 3};
		m.RecalculateNormals();

		return m;
	}

}
