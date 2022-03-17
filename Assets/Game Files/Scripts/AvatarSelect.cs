using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using Photon.Pun;
using PhotonHashtable = ExitGames.Client.Photon.Hashtable;

public class AvatarSelect : MonoBehaviour
{
    public static AvatarSelect Instance;
    [SerializeField] Image img;
    [SerializeField] List<Sprite> skins = new List<Sprite>();
    [SerializeField] List<Material> materials = new List<Material>();
    [SerializeField] List<string> materialNames = new List<string>();
    public static List<Material> Materials;
    public int matIndex;
    public string currentMaterialName;
    public int selectedSkin = 0;
    public GameObject player;
    private PhotonHashtable hash = new PhotonHashtable();

    private void Start() 
    {
        Instance = this;
        Materials = materials;
        foreach(Material mat in materials)
        {
            materialNames.Add(mat.name);
        }
        SetColor(selectedSkin);
    }
    public void NextAvatar()
    {
        selectedSkin++;
        if(selectedSkin == skins.Count)
        {
            selectedSkin = 0;
        }

        img.sprite = skins[selectedSkin];
        //mat = materials[selectedSkin];
    }

    public void PreviousAvatar()
    {
        selectedSkin--;
        if(selectedSkin < 0)
        {
            selectedSkin = skins.Count - 1;
        }

        img.sprite = skins[selectedSkin];
        //mat = materials[selectedSkin];
    }

    // public void PlayGame()
    // {
    //     //PrefabUtility.SaveAsPrefabAsset()
    //     PlayerPrefs.SetInt("selectedSkin", selectedSkin);
    //     player.GetComponent<Renderer>().material = materials[selectedSkin];
    // }

    public void SetColor(int index)
    {
        // selectedSkin = index;
        // currentMaterialName = materialNames[index];

        // if(PhotonNetwork.IsConnected)
        // {
        //     SetHash();
        // }
    }

    public void SetHash()
    {
        hash["Material"] = currentMaterialName;
        PhotonNetwork.LocalPlayer.SetCustomProperties(hash);
    }

}
