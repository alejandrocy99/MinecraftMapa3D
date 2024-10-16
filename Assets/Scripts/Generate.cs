using System.Collections;
using System.Collections.Generic;
using System.IO.Compression;
using UnityEngine;

public class Generate : MonoBehaviour
{
    public int x;
    public int y;
    public int z;
    public int baseSize;

    public int steps;
    public GameObject cubo;
    private GameObject[,] map; // Declarar el array de GameObjects

    // Start is called before the first frame update
    void Start()
    {
        // Inicializar el array con el tamaño adecuado
        map = new GameObject[x, y];
        //GenerateMap();
       //GeneratePyramid();
       GenerateLadder();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GenerateMap()
    {
        for (int i = 0; i < x; i++)
        {
            for (int j = 0; j < y; j++)
            {
                map[i, j] = Instantiate(cubo, new Vector3(i, 0, j), Quaternion.identity);
                Generate cuboComponent = map[i, j].GetComponent<Generate>();
                if (cuboComponent != null)
                {
                    cuboComponent.x = i;
                    cuboComponent.y = j;
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
                    Instantiate(cubo, position, Quaternion.identity);
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
                    Vector3 position = new Vector3(y, x, z);
                Instantiate(cubo, position, Quaternion.identity);
                
                
                
            }
        }
    }
    
}
