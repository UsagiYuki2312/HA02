using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pixelplacement;

public class GameStartState : State, IMessageHandle
{
    private AGameStartUI GAMESTART_UI;
    private AGameStartUI instanceGameStartUI;
    public const string UI_PATH = "Prefabs/UI/";

    void IMessageHandle.Handle(Message message)
    {
        switch (message.type)
        {
            case TeeMessageType.OnPlayButtonClicked:
                Destroy(instanceGameStartUI.gameObject);
                Next();
                break;

        }
    }

    private void Awake()
    {
        GAMESTART_UI = Resources.Load<AGameStartUI>(UI_PATH + "GameStart");
        MessageManager.Instance.AddSubcriber(TeeMessageType.OnPlayButtonClicked, this);
    }


    void OnEnable()
    {
        instanceGameStartUI = Instantiate(GAMESTART_UI);
    }

    private void OnDestroy()
    {
        MessageManager.Instance.RemoveSubcriber(TeeMessageType.OnPlayButtonClicked, this);

    }

}
