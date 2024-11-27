using UnityEngine;

public class SpinX : MonoBehaviour
{
    public float rotationSpeed;

    public GameObject pivotObject;

   
    void Update()
    {
        transform.RotateAround(pivotObject.transform.position, new Vector3(1, 1, 0), rotationSpeed * Time.deltaTime);
    }
}
