using System;
using Gtk;
using System.Collections.Generic;



public class SettingsButton : Button
{
    public SettingsButton() : base("⚙️")
    {
        SetSizeRequest(1, 1);
        CanFocus = false;
        Relief = ReliefStyle.None;

        // Estilo do botão
        var cssProvider = new CssProvider();
        cssProvider.LoadFromData(@"
            button {
                font-size: 16px;
                border: none;
                padding: 0;
                border-radius: 5px;
                }");
        StyleContext.AddProviderForScreen(
            Gdk.Screen.Default,
            cssProvider,
            Gtk.StyleProviderPriority.Application
        );
    }

}