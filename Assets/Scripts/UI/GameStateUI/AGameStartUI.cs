using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using Pixelplacement;

public class AGameStartUI : MonoBehaviour
{
    public Button playButton;

    // Start is called before the first frame update
    void Start()
    {
        playButton.onClick.AddListener(StartPlaying);
    }

    private void StartPlaying()
    {
        TriggerTransitionAndPLay();
    }

    private void TriggerTransitionAndPLay()
    {
        MessageManager.Instance.SendMessageWithDelay(new Message(TeeMessageType.OnPlayButtonClicked), 1.51f);
    }
}
