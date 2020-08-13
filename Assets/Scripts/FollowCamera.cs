using UnityEngine;

public class FollowCamera : MonoBehaviour
{

    public Transform target;

    private void LateUpdate()
    {

        if (target.position.y > transform.position.y)
        {
            Vector3 temp = transform.position;
            temp.y = target.position.y;
            transform.position = temp;
        }
        

    }
}
