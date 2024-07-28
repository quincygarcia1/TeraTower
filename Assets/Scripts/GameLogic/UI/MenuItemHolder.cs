using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MenuItemHolder
{
    public Button button;
    public MenuItemObj item;
    public MenuItemHolder(MenuItemObj item, VisualTreeAsset template)
    {
        TemplateContainer newPlatformButtonContainer = template.Instantiate();
        this.item = item;
        button = newPlatformButtonContainer.Q<Button>();
        
    }
}
