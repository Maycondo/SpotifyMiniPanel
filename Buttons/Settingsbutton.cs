using System;
using Gtk;
using System.Collections.Generic;



public class SettingsButton : Button
{

    private Label iconLabel;
    public string Icon { get; set; } = "\uf013"; // Unicode do ícone "settings"
    public SettingsButton() : base()
    {

        iconLabel = new Label(Icon)
        {
            Name = "settingsIcon",
            Text = Icon,
            UseMarkup = true,
            Xalign = 0.5f, // Centraliza horizontalmente
            Yalign = 0.5f // Centraliza verticalmente
        };

        Add(iconLabel);

        // Configurações do botão
        SetSizeRequest(35, 35);
        CanFocus = false;
        Relief = ReliefStyle.None;

        // Estilo do botão
        var cssProvider = new CssProvider();
        cssProvider.LoadFromData(@"
            #settingsIcon {
                    font-size: 18px;
                    border: none;
                    padding: 1px;
                    border-radius: 50%;
                    background-color: transparent;
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