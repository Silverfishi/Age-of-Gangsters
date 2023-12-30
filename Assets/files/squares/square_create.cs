using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class square_create : MonoBehaviour
{
    public GameObject square;
    public static List<GameObject> squares = new List<GameObject>() {};
    private int i = 0;

    void Start()
    {
        for (int x=0; x <= 30; x+=10)
        {
            for (int z = 0; z <= 30; z += 10)
            {
                squares.Add(square);
                Instantiate(squares[i], new Vector3(x, 0, z), Quaternion.identity);
                i++;
            }
        }
    }
}
