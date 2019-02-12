using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObjectCollision : MonoBehaviour {

    void OnCollisionEnter(Collision col)
    {

        //Destroy(gameObject);
        Debug.Log("Hit a random object!");
        SceneManager.LoadScene("TryAgain");
    }
}
