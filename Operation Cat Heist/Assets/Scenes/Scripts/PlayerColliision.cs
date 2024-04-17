using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerCollision : MonoBehaviour
{
    public SceneFader sceneFader; 

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Laser")
        {
            StartCoroutine(RestartLevel());
        }
    }

    IEnumerator RestartLevel()
    {
        float fadeTime = sceneFader.BeginFade(1);
        yield return new WaitForSeconds(fadeTime);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
