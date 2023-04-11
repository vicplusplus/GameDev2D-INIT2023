using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelTransition : MonoBehaviour
{
    public PlayerController Controller;
    public int NextSceneID;

    public void OnCollisionEnter2D(Collision2D col)
    {
        if(col.collider.transform == Controller.Character.transform)
        {
            SceneManager.LoadScene(NextSceneID);
        }
    }
}
