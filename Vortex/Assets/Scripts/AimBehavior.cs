using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AimBehavior : MonoBehaviour
{

    public Texture textureNormal;
    public Texture textureOnMark;

    void Update(){

        
    }

    public void OnMark(){

        GetComponent<RawImage>().texture = textureOnMark;
    }

    public void LostAim(){

        GetComponent<RawImage>().texture = textureNormal;
    }
}
