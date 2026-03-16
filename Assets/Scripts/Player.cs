using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float rotationSpeed = 10f;
    [SerializeField] private GameInput gameInput;
    private bool isWalking = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = gameInput.GetMovementDirectionNormalized();
        if (direction != Vector3.zero) isWalking = true;
        else isWalking = false;

        transform.position += direction * Time.deltaTime * moveSpeed;

        if (direction != Vector3.zero)
        {
            transform.forward = Vector3.Slerp(transform.forward, direction, Time.deltaTime * rotationSpeed);//Spherical Interpolation球面线性插值
        }
    }
    public bool IsWalking
    {
        get { return isWalking; }
    }
}
