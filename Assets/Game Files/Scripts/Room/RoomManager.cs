using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;
using System.IO;

public class RoomManager : MonoBehaviourPunCallbacks
{
    public static RoomManager Instance;

    private void Awake() 
    {
        //We check if there is another RoomManager in the scene. If there is then Destroy it, and creat one.
        if(Instance)
        {
            Destroy(gameObject);
            return;
        }    

        DontDestroyOnLoad(gameObject);
        Instance = this;
    }

    public override void OnEnable() 
    {
        base.OnEnable();    
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    public override void OnDisable()
    {
        base.OnDisable();
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    public void OnSceneLoaded(Scene scene, LoadSceneMode loadSceneMode)
    {
        if(scene.buildIndex == 1)
        {
            PhotonNetwork.Instantiate(Path.Combine("Photon Prefabs", "PlayerManager"), Vector3.zero, Quaternion.identity);
        }
    }
}
