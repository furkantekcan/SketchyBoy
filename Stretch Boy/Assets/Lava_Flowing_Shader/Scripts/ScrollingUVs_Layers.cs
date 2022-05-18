using UnityEngine;
using System.Collections;

public class ScrollingUVs_Layers : MonoBehaviour 
{
	//public int materialIndex = 0;
	public Vector2 uvAnimationRate = new Vector2( 1.0f, 0.0f );
	public string textureName = "_MainTex";

	public float lavaSpeed = 1.0f;// has to be same with camera speed

	
	Vector2 uvOffset = Vector2.zero;

    private void FixedUpdate()
    {
		transform.position += transform.up * lavaSpeed * Time.fixedDeltaTime;
	}

    void LateUpdate() 
	{
		uvOffset += ( uvAnimationRate * Time.deltaTime );
		if( GetComponent<Renderer>().enabled )
		{
			GetComponent<Renderer>().sharedMaterial.SetTextureOffset( textureName, uvOffset );
		}
	}
}