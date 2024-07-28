using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlatformItemHolder : MenuItemHolder
{
    public event EventHandler<PlatformGenerationArgs> generated;
    public PlatformItemHolder(MenuItemObj item, VisualTreeAsset template) : base(item, template)
    {
        button.RegisterCallback<ClickEvent>(OnClick);
    }

    public void OnClick(ClickEvent evt)
    {
        PlatformMenuItem conversion = (PlatformMenuItem)this.item;
        generated?.Invoke(this, new PlatformGenerationArgs(){type = conversion.type});
    }
}
