using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Noise_Test : MonoBehaviour
{
    public int width = 256;
    public int height = 256;
    [Range(0,100)]public float scale = 100f;
    public float offsetX = 100f;
    public float offsetY = 100f;
    //private Renderer renderer;
    
    void start()
    {
        
    }
    void Update()
    {
        Renderer renderer = GetComponent<Renderer>();
        renderer.material.mainTexture = GenerateTexture();
       // GenerateTexture();
    }
    
    Texture2D GenerateTexture()
    {
        Texture2D texture = new Texture2D(width, height);
        //GENERATE PERLIN NOISE FOR TEXTURE
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                Color color = CalculateColor(x, y);
                texture.SetPixel(x,y, color);
            }
        }
            
        texture.Apply();
        return texture;
    }
    
    Color CalculateColor(int x, int y)
    {
        float xCoord = (float)x / width * scale + offsetX;
        float yCoord = (float)y / height * scale + offsetY;
        
        float sample = Mathf.PerlinNoise(xCoord, yCoord);
        return new Color(sample, sample, sample);
    }
}