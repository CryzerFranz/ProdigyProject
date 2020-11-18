using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;
using UnityEngine.Video;
using System.Linq;

public class Gifs : MonoBehaviour
{
    UnityEngine.Object[] textures;
    int CurrentFrame = 1;

    [SerializeField]
    string folderpath;

    private void Start()
    {
        textures = Resources.LoadAll(folderpath, typeof(Texture)).Cast<Texture>().ToArray();
        Debug.Log(folderpath);

        foreach(var t in textures)
        {
            Debug.Log(t.name);
        }
    }

    private void Update()
    {
        //CurrentFrame %= textures.Length;
        //CurrentFrame++;
        //GetComponent<Renderer>().material.mainTexture = textures[CurrentFrame];
    }





}
