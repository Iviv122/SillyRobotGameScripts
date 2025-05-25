using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField] public Transform Target;
    void Update()
    {
        transform.position = new Vector3(Target.position.x,Target.position.y,-1);
    }
}
