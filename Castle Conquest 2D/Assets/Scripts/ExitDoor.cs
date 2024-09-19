using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitDoor : MonoBehaviour
{
    [SerializeField] float loadSeconds = 2f;
    [SerializeField] AudioClip openSFX;
    [SerializeField] AudioClip closeSFX;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GetComponent<Animator>().SetTrigger("Open");
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        GetComponent<Animator>().SetTrigger("Close");
    }

    public void StartLoadingNextLevel()
    {
        GetComponent<Animator>().SetTrigger("Close");
        StartCoroutine(LoadNextLevel());
    }

    IEnumerator LoadNextLevel()
    {
        yield return new WaitForSeconds(loadSeconds);

        var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    void PlayOpenDoorSFX()
    {
        AudioSource.PlayClipAtPoint(openSFX, Camera.main.transform.position, 0.05f);
    }

    void PlayCloseDoorSFX()
    {
        AudioSource.PlayClipAtPoint(closeSFX, Camera.main.transform.position, 0.05f);
    }
}
