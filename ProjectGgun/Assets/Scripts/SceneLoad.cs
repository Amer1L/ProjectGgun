using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoad : MonoBehaviour
{
    [SerializeField] private int _scene;

    private void OnCollisionEnter(Collision collision)
    {
        
        SceneManager.LoadScene(_scene);
    }
}
