using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class staronlinegame : MonoBehaviour
{
    // Start is called before the first frame update
    public void Clickstartgame ()
    {
       SceneManager.LoadScene("loading");
    }

}