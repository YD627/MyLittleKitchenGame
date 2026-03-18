using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : KitchenObjectHolder
{
    public static Player Instance {  get; private set; }
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float rotationSpeed = 10f;
    [SerializeField] private GameInput gameInput;
    [SerializeField] private LayerMask counterLayerMask;

    private bool isWalking = false;
    private ClearCounter selectedCounter;

    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        gameInput.OnInteraction += GameInput_OnInteraction;
    }
    void Update()
    {
        HandleInteraction();
    }

    private void FixedUpdate()
    {
        HandleMovement();
        
    }
    public bool IsWalking
    {
        get { return isWalking; }
    }
    private void HandleMovement()
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
    private void GameInput_OnInteraction(object sender, System.EventArgs e)
    {
        selectedCounter?.Interact();
    }
    private void HandleInteraction()
    {
        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hitinfo, 2f, counterLayerMask)) // 判断射线前方是否有物体且是counter Layer Mask图层的
        {
            if (hitinfo.transform.TryGetComponent<ClearCounter>(out ClearCounter counter)) // 尝试获取物体上的组件，如果有就创建该组件的实例
            {
                SetSelectedCounter(counter);
            }
            else
            {
                SetSelectedCounter(null);
            }
        }
        else
        {
            SetSelectedCounter(null);
        }
    }
    public void SetSelectedCounter(ClearCounter counter)
    {
        if(counter != selectedCounter)
        {
            selectedCounter?.CancelSelect();
            counter?.SelectCounter();
            this.selectedCounter = counter;
        }
    }
}
