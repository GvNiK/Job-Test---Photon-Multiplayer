using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerController : MonoBehaviour
{
    //[SerializeField] GameObject player;
    [SerializeField] float speed, jumpForce;
    bool grounded;
    PhotonView PV;
    Rigidbody rb;
    Material currentMaterial;
    [SerializeField] List<Material> colorMats;
    public string matName;
    private PlayerInputs playerInputs;
    private PlayerInputCallbacks callbacks;
    private PlayerControls playerControls;
    private Vector2 movementVector;
    private bool jumpPressed;

    private void Awake() 
    {
        rb = GetComponentInChildren<Rigidbody>();
        PV = GetComponent<PhotonView>();
        currentMaterial = GetComponentInChildren<Renderer>().material;
        Debug.Log(currentMaterial);

        //colorMats = AvatarSelect.Materials;
        //matName = (string)PV.Owner.CustomProperties["Material"];

        // foreach(Material mat in colorMats)
        // {
        //     currentMaterial = mat;
        //     Debug.Log("New Material : " + currentMaterial);
        //     break;
        // }

        //PV.RPC("SetAvatar", RpcTarget.MasterClient);
        //PV.Owner.SetCustomProperties()
    }

    private void Start() 
    {
        if(!PV.IsMine)
        {
            Destroy(GetComponentInChildren<Camera>().gameObject);
            Destroy(rb);
        }  

        callbacks = new PlayerInputCallbacks();
        playerControls = new PlayerControls();
        playerInputs = new PlayerInputs(playerControls, callbacks);  

        playerControls.Enable();
        callbacks.OnPlayerMoved += Move;
        callbacks.OnPlayerJumpPressed += Jump;
    }

    // Update is called once per frame
    void Update()
    {
        if(!PV.IsMine)
            return;

        Move(movementVector);
        Jump(jumpPressed);
    }

    void Move(Vector2 movementVector)
    {
        this.movementVector = movementVector;   

        float movementX = movementVector.x;
        float movementY = movementVector.y;

        Vector3 newMovement = new Vector3(movementX, 0f, movementY);
        newMovement.Normalize();

        transform.Translate(newMovement * speed * Time.deltaTime, Space.Self);

        transform.Rotate(0, newMovement.x, newMovement.y);
    }

    void Jump(bool jumpPressed)
    {
        this.jumpPressed = jumpPressed;

        if(jumpPressed && grounded)
        {
            rb.AddForce(transform.up * jumpForce);
        }
    }

    public void SetAvatarColor()
    {
        if(!PV.IsMine)
            return;

        int index = 0; //PlayerPrefs.GetInt("selectedSkin");
        //PlayerPrefs.GetInt("selectedSkin");
        index = AvatarSelect.Instance.selectedSkin;

        currentMaterial = colorMats[index];
    }

    public void SetGroundState(bool grounded)
    {
        this.grounded = grounded;
    }

    private void OnDisable() 
    {
        callbacks.OnPlayerMoved -= Move;
        callbacks.OnPlayerJumpPressed -= Jump;
    }

    private void OnDestroy() 
    {
        callbacks.OnPlayerMoved -= Move;
        callbacks.OnPlayerJumpPressed -= Jump;
    }
}
