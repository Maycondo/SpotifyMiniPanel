using System;
using Gtk;
using Gdk;


class NextSongButton : Button
{
    private Label iconLabel;
    public string Icon { get; set; } = "\uf051"; // Unicode do ícone "next"
    public NextSongButton() : base()
    {

        iconLabel = new Label(Icon)
        {
            Name = "nextSongIcon",
            Text = Icon,
            UseMarkup = true,
            Xalign = 0.5f, // Centraliza horizontalmente
            Yalign = 0.5f // Centraliza verticalmente
        };

        Add(iconLabel);

        // Configurações do botão
        SetSizeRequest(30, 30);
        CanFocus = false;
        Relief = ReliefStyle.None;

        // Estilo do botão 
        var cssProvider = new CssProvider();
        cssProvider.LoadFromData(@"
            #nextSongIcon {
                font-size: 18px;
                border: none;
                padding: 5px;
                border-radius: 50%;
                background-color: transparent;
                color: white; }"
        );
        Gtk.StyleContext.AddProviderForScreen(
            Gdk.Screen.Default,
            cssProvider,
            Gtk.StyleProviderPriority.Application
        );
    }
}