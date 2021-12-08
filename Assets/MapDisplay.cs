using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapDisplay : MonoBehaviour
{
    public Renderer Ankira;
    public Renderer Zorthan;
    public Renderer Soprina;
    public Planet planet;
    public Renderer textureRender;

    public enum Planet
    {
        Ankira,
        Zorthan,
        Soprina
    };
    
    
    private void OnValidate()
    {
        if (planet == Planet.Ankira)
        {
            textureRender = Ankira.GetComponent<SpriteRenderer>();
        }
        if (planet == Planet.Zorthan)
        {
            textureRender = Zorthan.GetComponent<SpriteRenderer>();
        }
        if (planet == Planet.Soprina)
        {
            textureRender = Soprina.GetComponent<SpriteRenderer>();
        }
    }


    public void DrawTexture(Texture2D texture)
    {
        textureRender.sharedMaterial.mainTexture = texture;

        //textureRender.transform.localScale = new Vector3(texture.width, texture.height, 1);
    }
}
