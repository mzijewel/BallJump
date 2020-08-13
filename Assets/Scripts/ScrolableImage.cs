using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrolableImage : MonoBehaviour
{
    public float speed = 10f;

    MeshRenderer renderer;

    private void Start()
    {
        renderer = GetComponent<MeshRenderer>();
    }
    private void Update()
    {
        if (GameController.i.IsCamMoving())
        {
            Vector2 offset = renderer.sharedMaterial.GetTextureOffset("_MainTex");
            offset.y += speed * Time.deltaTime;
            renderer.sharedMaterial.SetTextureOffset("_MainTex", offset);
        }
        
    }
}
