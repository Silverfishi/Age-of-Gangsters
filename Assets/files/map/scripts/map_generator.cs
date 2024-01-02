using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grid_generator : MonoBehaviour
{
    [SerializeField] private Vector2Int grid_size;
    [SerializeField] private GameObject prefab;

    [ContextMenu("Generate grid")]
    private void generate_grid ()
    {
        for (int x = 0; x < grid_size.x; x++)
        {
            for (int y = 0; y < grid_size.y; y++)
            {
                var position = new Vector3(x * 20, 0, y * 20);
                var cell = Instantiate(prefab, position, Quaternion.identity);
                cell.name = $"square X:{x} Y:{y}";
            }
        }
    }

}
