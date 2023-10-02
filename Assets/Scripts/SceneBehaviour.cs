using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneBehaviour : MonoBehaviour
{
    void Start()
    {
        Button Button = this.GetComponent<Button>();
        Button.onClick.AddListener(Reset);
    }

    public void Reset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
