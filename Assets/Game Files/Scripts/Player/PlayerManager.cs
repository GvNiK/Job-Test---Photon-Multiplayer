using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.IO;

public class PlayerManager : MonoBehaviour
{
    PhotonView PV;

    private void Awake() 
    {
        PV = GetComponent<PhotonView>();
    }
    
    // Start is called before the first frame update
    void Start()
    {
        if(PV.IsMine)
        {
            CreateController();
        }
    }

   void CreateController()
   {
       PhotonNetwork.Instantiate(Path.Combine("Photon Prefabs", "PlayerController"), new Vector3(0, 1, 0), Quaternion.identity);
   }
}
