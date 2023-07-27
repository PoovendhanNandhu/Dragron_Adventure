using UnityEngine;
using UnityEngine.SceneManagement;
public class LoadingManager : MonoBehaviour
{
    void Update()
{

        if (Input.GetKeyDown(KeyCode.K))
            SceneManager.LoadScene(1);
    }
}
