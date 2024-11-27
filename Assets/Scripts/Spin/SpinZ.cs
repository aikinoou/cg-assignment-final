using UnityEngine;

public class SpinZ : MonoBehaviour
{
    public float rotationSpeed;

    public GameObject pivotObject;

   
    void Update()
    {
        transform.RotateAround(pivotObject.transform.position, new Vector3(1, 0, 1), rotationSpeed * Time.deltaTime);
    }
}
