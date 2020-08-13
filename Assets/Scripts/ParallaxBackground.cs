using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*  
 * https://www.youtube.com/watch?v=wBol2xzxCOU
 */
public class ParallaxBackground : MonoBehaviour
{

    [SerializeField] float parllaxMultiplier = 0.1f;
    Transform camTrans;
    Vector3 camLastPos;
    float textureUnitSizeY;

    private void Start()
    {
        camTrans = Camera.main.transform;
        camLastPos = camTrans.position;
        Sprite sprite = GetComponent<SpriteRenderer>().sprite;
        Texture2D texture = sprite.texture;
        textureUnitSizeY = texture.height / sprite.pixelsPerUnit;

        print(textureUnitSizeY);
    }
    private void LateUpdate()
    {
        Vector3 deltaMovement = camTrans.position - camLastPos;
        transform.position += new Vector3(deltaMovement.x, deltaMovement.y * parllaxMultiplier, deltaMovement.z);
        camLastPos = camTrans.position;

        if (Mathf.Abs(camTrans.position.y - transform.position.y) >= textureUnitSizeY)
        {
            float offsetPosY = (camTrans.position.y - transform.position.y) % textureUnitSizeY;
            transform.position = new Vector3(transform.position.x, camTrans.position.y + offsetPosY, transform.position.z);
        }
    }
}
