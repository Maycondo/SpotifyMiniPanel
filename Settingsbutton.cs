using System;
using Gtk;
using System.Collections.Generic;



public class SettingsButton : Button
{
    public SettingsButton() : base("⚙️")
    {
        Name = "settings-button";
        SetSizeRequest(20, 20);
        CanFocus = false;
        Relief = ReliefStyle.None;

        // Estilo do botão
        var cssProvider = new CssProvider();
        cssProvider.LoadFromData(@"
            button {
                    font-size: 16px;
                    border: none;
                    padding: 1px;
                    border-radius: 5px;
                    background: transparent;
                    color: white;
                }");
        StyleContext.AddProviderForScreen(
            Gdk.Screen.Default,
            cssProvider,
            Gtk.StyleProviderPriority.Application
        );
    }


    public Fixed GetFixedLayout(int x = 310, int y = 10)
    {
        Fixed fixedLayout = new Fixed();
        fixedLayout.Put(this, x, y);
        return fixedLayout;
    }

}