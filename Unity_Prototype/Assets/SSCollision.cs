using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SSCollision : MonoBehaviour {

    void OnCollisionEnter(Collision col)
    {

        //Destroy(gameObject);
        Debug.Log("Hit the space station!");
        SceneManager.LoadScene("Congrats");
    }
}
