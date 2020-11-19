using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gif_Maker : MonoBehaviour
{
    // Start is called before the first frame update
    private Texture[] textures;
    int framesPerSecond = 10;
    void Start()
    {
        textures = Resources.LoadAll<Texture>("Glitched_01") ;
    }

    // Update is called once per frame
    void Update()
    {
        int index = Convert.ToInt32(Time.time * framesPerSecond);
        index = index % textures.Length;
        GetComponent<Renderer>().material.mainTexture = textures[index];
    }

}
