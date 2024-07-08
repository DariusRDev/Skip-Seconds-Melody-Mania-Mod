using System;
using System.Collections.Generic;
using UniInject;
using UnityEngine.InputSystem;
using UnityEngine;

using UnityEngine.UIElements;

// Mod interface to do something when a scene is loaded.
// Available scenes are found in the EScene enum.
public class Skip5SecondsWithArrowKeysSceneMod : ISceneMod
{
    // Get common objects from the app environment via Inject attribute.
    [Inject]
    private UIDocument uiDocument;

    [Inject]
    private SceneNavigator sceneNavigator;

    // Mod settings implement IAutoBoundMod, which makes an instance available via Inject attribute
    [Inject]
    private Skip5SecondsWithArrowKeysModSettings modSettings;

    private readonly List<IDisposable> disposables = new List<IDisposable>();

    public void OnSceneEntered(SceneEnteredContext sceneEnteredContext)
    {
        // You can do anything here, for example ...

        // ... show a message
        if (sceneEnteredContext.Scene == EScene.SingScene)
        {
            GameObject gameObject = new GameObject();

            gameObject.name = nameof(Skip5SecondsWithArrowKeysMonoBehaviour);
            Skip5SecondsWithArrowKeysMonoBehaviour behaviour = gameObject.AddComponent<Skip5SecondsWithArrowKeysMonoBehaviour>();
            behaviour.secondsToSkip = modSettings.secondsToSkip;
            sceneEnteredContext.SceneInjector.Inject(behaviour);
        }

    }
}

public class Skip5SecondsWithArrowKeysMonoBehaviour : MonoBehaviour, INeedInjection
{
    public int secondsToSkip = 5;
    [Inject]
    private SingSceneControl singSceneControl;

    // Update is called once per frame
    private void Update()
    {

        if (Keyboard.current != null
           && Keyboard.current.rightArrowKey.IsPressed())
        {

            singSceneControl.SkipToPosition
            (singSceneControl.PositionInMillis + secondsToSkip * 1000);
        }
        else if (Keyboard.current != null
            && Keyboard.current.leftArrowKey.IsPressed())
        {
            singSceneControl.SkipToPosition(singSceneControl.PositionInMillis - secondsToSkip * 1000);
        }
    }

}
