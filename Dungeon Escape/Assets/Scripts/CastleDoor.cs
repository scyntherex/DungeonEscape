using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CastleDoor : MonoBehaviour {
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            if(GameManager.Instance.HasKeyToCastle == true)
            {
                SceneManager.LoadScene("Main_Menu");
            }
        }
    }
}
