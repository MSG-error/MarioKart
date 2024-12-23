using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MainMenu : MonoBehaviour
{
    [SerializeField] UIDocument mainMenuDocument;

    private Button settingsButton;
    private Button achievementsButton;
    private Button playButton;

    private void Awake()
    {
        VisualElement root = mainMenuDocument.rootVisualElement;

        settingsButton = root.Q<Button>("START");
        achievementsButton = root.Q<Button>("Settings");
        playButton = root.Q<Button>("Exit");

        settingsButton.clicked += ShowSettingsMenu;
        achievementsButton.clicked += ShowAchievementsMenu;
        playButton.clicked += PlayGame;
    }

    private void ShowSettingsMenu()
    {
        print("Showing settings menu");
    }

    private void ShowAchievementsMenu()
    {
        print("Showing achievements menu");
    }

    private void PlayGame()
    {
        // التأكد من اسم المشهد
        print("Loading GameScene...");
        
        SceneManager.LoadScene("GameScene"); // تأكد من أن هذا هو اسم المشهد الصحيح
    }
}
