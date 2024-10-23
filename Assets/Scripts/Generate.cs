using System.Collections;
using System.Collections.Generic;
using System.IO.Compression;
using UnityEditor;
using UnityEngine;

public class Generate : MonoBehaviour
{

    public int baseSize;

    public int steps;
    private GameObject[,] map; // Declarar el array de GameObjects

    public GameObject cube;
    public int with, height, large;
    public float detail;
    public int seed;

    // Start is called before the first frame update
    void Start()
    {
        // Inicializar el array con el tamaño adecuado
        seed = Random.Range(100000, 900000);
        GenerateMap();
        //GeneratePyramid();
        //GenerateLadder();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void GenerateMap()
    {
        // Iterar sobre las coordenadas x, z (horizontalmente en el plano)
        for (int x = 0; x < with; x++)
        {
            for (int z = 0; z < large; z++)
            {
                // Calcular la altura usando PerlinNoise, pero sin modificar height
                height = (int)(Mathf.PerlinNoise((x / 2 + seed) / detail, (z / 2 + seed) / detail) * detail);
                for (int y = 0; y < height; y++)
                {
                    // Instanciar el cubo en la posición (x, y, z), con y representando la altura
                    Instantiate(cube, new Vector3(x, y, z), Quaternion.identity);
                }

            }
        }
    }



    public void GeneratePyramid()
    {
        // Para cada nivel de la pirámide
        for (int y = 0; y < baseSize; y++)
        {
            // El tamaño del nivel en X y Z disminuye conforme subimos  levelsize determina el numero de cubos que hay en ese nivel 
            int levelSize = baseSize - y;

            // Calcular el offset para centrar el nivel en la base
            float offset = (baseSize - levelSize) / 2.0f;

            // Generar una cuadrícula en el nivel y
            for (int x = 0; x < levelSize; x++)
            {
                for (int z = 0; z < levelSize; z++)
                {
                    // Instanciar el cubo en la posición (x, y, z) con el offset calculado para centrar
                    Vector3 position = new Vector3(x + offset, y, z + offset);
                    Instantiate(cube, position, Quaternion.identity);
                }
            }
        }
    }



    public void GenerateLadder()
    {
        // Para cada nivel de escalón
        for (int y = 0; y < steps; y++)
        {
            // Generar los cubos desde el suelo hasta la altura del escalón actual
            for (int x = 0; x <= y; x++)
            {

                // Colocar el cubo en la posición (x = y, y = height, z = 0)
                Vector3 position = new Vector3(y, x, large);
                Instantiate(cube, position, Quaternion.identity);



            }
        }
    }

    public void MapGenerate()
    {


    }
}
