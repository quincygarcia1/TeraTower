using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class NewPlatformUIController : MonoBehaviour
{
    private UIDocument uiMenu;
    public VisualTreeAsset menuButtonTemplate;
    public List<PlatformMenuItem> items;
    private void OnEnable()
    {
        uiMenu = GetComponent<UIDocument>();

        foreach (var item in items)
        {
            PlatformItemHolder menuItem = new PlatformItemHolder(item, menuButtonTemplate);
            menuItem.generated += PlatformOption_Selected;
                uiMenu.rootVisualElement.Q("BtnList").Add(menuItem.button);

        }
    }

    private void PlatformOption_Selected(object sender, PlatformGenerationArgs args)
    {
        float createdY = TotalGarden.Instance.CreateNewPlatform(args.type, DirtType.Standard);
    }
}
