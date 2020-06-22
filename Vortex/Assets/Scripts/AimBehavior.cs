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

    public void onMark(){

        GetComponent<RawImage>().texture = textureOnMark;
    }

    public void LostAim(){

        GetComponent<RawImage>().texture = textureNormal;
    }
}
