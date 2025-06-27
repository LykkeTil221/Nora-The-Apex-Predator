using UnityEngine;
using UnityEngine.SceneManagement;
public class ResetScene : MonoBehaviour
{
    public void ResetTheScene()
    {
        SceneManager.LoadScene(0);
    }
}
