using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetProfile : MonoBehaviour
{
    public enum PlanetProfileEnum
    {
        name,
        width,
        height,
        noiseScale,
        octaves,
        persistance,
        lacunarity,
        seed,
        offset
    }
    public class PlanetProfileUI : MonoBehaviour
    {
        [SerializeField]
        public class PlanetProfile
        {
            public string name;
            public int mapWidth;
            public int mapHeight;
            public float noiseScale;
            public int octaves;
            [Range(0,1)]public float persistance;
            public float lacunarity;
            public int seed;
            public Vector2 offset;
       
            public bool autoUpdate;
   
            public TerrainType[] regions;
        }
    }
}
