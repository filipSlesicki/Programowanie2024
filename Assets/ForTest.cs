
using System.Collections.Generic;
using UnityEngine;

public class ForTest : MonoBehaviour
{
    [SerializeField] private GameObject[] cubesPrefabs;
    [SerializeField] private GameObject Cube;
    [SerializeField] private GameObject Cube2;
    [SerializeField] private int widthInCubes = 5;
    [SerializeField] private int heightInCubes = 5;
    [SerializeField] private float cubeSize = 1.5f;
    private int[] numbers = new int[] {23,4234,234 };
    public GameObject[] spawnedCubes;
    List<GameObject> spawnedCubesList = new List<GameObject>();
    int cubeIndex = 0;

    [ContextMenu("Test")]
    void Start()
    {
        numbers[0] = 1;
        numbers[1] = 5;

        //int i = 0;
        //while( i < 5)
        //{
        //    Debug.Log("Cos");
        //    i++;
        //}

        spawnedCubes = new GameObject[widthInCubes * heightInCubes];
        for (int x = 0; x < widthInCubes; x++)
        {
            for(int y = 0; y < heightInCubes; y++)
            {
                //bool isOnEdge = x == 0 || y == 0|| x == widthInCubes -1 || y == heightInCubes -1;
                //bool isEven = (y + x) % 2 == 0;
                GameObject cubeToSpawn = cubesPrefabs[cubeIndex]; //cubes[Random.Range(0, cubes.Length)];
                cubeIndex = (cubeIndex + 1) % cubesPrefabs.Length;
                //cubeIndex++;
                //if(cubeIndex >= cubes.Length)
                //{
                //    cubeIndex = 0;
                //}
                //GameObject cubeToSpawn = isEven == 0 ? Cube : Cube2;
                GameObject spawnedCube = Instantiate(cubeToSpawn, new Vector3(x * cubeSize, y * cubeSize, 0), Quaternion.identity);
                spawnedCubes[heightInCubes * x + y] = spawnedCube;
                spawnedCubesList.Add(spawnedCube);
                //if (isEven)
                //{
                //    Instantiate(Cube, new Vector3(x * cubeSize, y * cubeSize, 0), Quaternion.identity);
                //}
                //else
                //{
                //    Instantiate(Cube2, new Vector3(x * cubeSize, y * cubeSize, 0), Quaternion.identity);
                //}
            }

        }
    }

    [ContextMenu("Destroy all")]
    private void DestroyAllCubes()
    {
        for (int i = 0; i < spawnedCubesList.Count; i++ )
        {
            Destroy(spawnedCubesList[i]);
        }
        spawnedCubesList.Clear();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
