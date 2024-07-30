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
    private List<PlatformItemHolder> _itemHolders;

    private void Awake()
    {
        _itemHolders = new List<PlatformItemHolder>();
        uiMenu = GetComponent<UIDocument>();
        uiMenu.rootVisualElement.style.display = DisplayStyle.None;
        Actions.OpenUI += ChangeDisplay;
        enabled = false;
    }

    private void OnEnable()
    {
        uiMenu.rootVisualElement.style.display = DisplayStyle.Flex;

        foreach (var item in items)
        {
            PlatformItemHolder menuItem = new PlatformItemHolder(item, menuButtonTemplate);
            menuItem.generated += PlatformOption_Selected;
            uiMenu.rootVisualElement.Q("BtnList").Add(menuItem.button);
            _itemHolders.Add(menuItem);
        }
    }

    private void OnDisable()
    {
        if (uiMenu != null)
        {
            uiMenu.rootVisualElement.style.display = DisplayStyle.None;
            uiMenu.rootVisualElement.Q("BtnList").Clear();
        }

        if (_itemHolders != null)
        {
            foreach (var holder in _itemHolders)
            {
                holder.generated -= PlatformOption_Selected;
            }
            _itemHolders.Clear();
        }
    }

    private void PlatformOption_Selected(object sender, PlatformGenerationArgs args)
    {
        float createdY = TotalGarden.Instance.CreateNewPlatform(args.type, DirtType.Standard);
        Actions.ComponentYChange?.Invoke(createdY);
    }

    private void ChangeDisplay(bool status)
    {
        Debug.Log(status);
        this.enabled = status;
    }
}
