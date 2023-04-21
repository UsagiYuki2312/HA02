using UnityEngine;
using Pixelplacement;
using System.Collections;
using UnityEngine.SceneManagement;

public class GamePlayState : State, IMessageHandle
{
    public AGamePlayUI GAMEPLAY_UI;
    private AGamePlayUI instanceGamePlayUI;
    public APlayer player;
    public APlayer instancePlayer;
    public const string UI_PATH = "Prefabs/UI/";
    public const string PLAYER_PATH = "Prefabs/Player/";
    void IMessageHandle.Handle(Message message)
    {
        switch (message.type)
        {
            case TeeMessageType.OnPlayerRevive:
                break;
            case TeeMessageType.OnPlayerDie:

                break;
            case TeeMessageType.OnPauseButtonClicked:
                this.SetTimeScale(0);
                break;
            case TeeMessageType.OnPauseMenuDestroyed:
                this.SetTimeScale(1);
                break;
            case TeeMessageType.OnPlayerChangeScene:
                ChangeState("GameLoadState");
                ChangeState("GamePlayState");
                break;
        }
    }

    private void Awake()
    {
        GAMEPLAY_UI = Resources.Load<AGamePlayUI>(UI_PATH + "GamePlay");
        player = Resources.Load<APlayer>(PLAYER_PATH + "Player");

        MessageManager.Instance.AddSubcriber(TeeMessageType.OnPauseButtonClicked, this);
        MessageManager.Instance.AddSubcriber(TeeMessageType.OnPauseMenuDestroyed, this);
        MessageManager.Instance.AddSubcriber(TeeMessageType.OnPlayerRevive, this);
        MessageManager.Instance.AddSubcriber(TeeMessageType.OnPlayerDie, this);
        MessageManager.Instance.AddSubcriber(TeeMessageType.OnPlayerChangeScene, this);
    }

    void OnEnable()
    {
        instanceGamePlayUI = Instantiate(GAMEPLAY_UI);
        instancePlayer = Instantiate(player);
        instancePlayer.movementComponent.CreateJoystick(instanceGamePlayUI.joystickZone);

    }

    private void OnDestroy()
    {

        MessageManager.Instance.RemoveSubcriber(TeeMessageType.OnPauseButtonClicked, this);
        MessageManager.Instance.RemoveSubcriber(TeeMessageType.OnPauseMenuDestroyed, this);
        MessageManager.Instance.RemoveSubcriber(TeeMessageType.OnPlayerRevive, this);
        MessageManager.Instance.RemoveSubcriber(TeeMessageType.OnPlayerDie, this);
        MessageManager.Instance.RemoveSubcriber(TeeMessageType.OnPlayerChangeScene, this);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            AsyncOperation operation = SceneManager.LoadSceneAsync("Mondstadt");
            MessageManager.Instance.SendMessageWithDelay(new Message(TeeMessageType.OnPlayerChangeScene), 1.51f);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            AsyncOperation operation = SceneManager.LoadSceneAsync("Liyue");
            MessageManager.Instance.SendMessageWithDelay(new Message(TeeMessageType.OnPlayerChangeScene), 1.51f);
        }
    }
}
