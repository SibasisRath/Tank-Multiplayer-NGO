using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NameSelection : MonoBehaviour
{
    [SerializeField] private TMP_InputField playerName;
    [SerializeField] private int minNameLength = 1;
    [SerializeField] private int maxNameLength = 12;
    [SerializeField] private Button connectButton;

    public const string playerNameKey = "playerName";

    // Start is called before the first frame update
    void Start()
    {
        if (SystemInfo.graphicsDeviceType == UnityEngine.Rendering.GraphicsDeviceType.Null)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            return;
        }
        playerName.text = PlayerPrefs.GetString(playerNameKey, string.Empty);
        HandelNameChanged();
    }

    public void HandelNameChanged()
    {
        connectButton.interactable = 
            playerName.text.Length >= minNameLength && 
            playerName.text.Length <= maxNameLength;
    }

    public void Connect()
    {
        PlayerPrefs.SetString(playerNameKey, playerName.text);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
}
