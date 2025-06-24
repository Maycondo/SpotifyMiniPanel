using System;
using Gtk;
using Gdk;


class PreviosMusicButton : Button
{

    private Label iconLabel;
    public string Icon { get; set; } = "\uf048"; // Unicode do ícone "previ a música"

    public PreviosMusicButton() : base()
    {
        iconLabel = new Label(Icon)
        {
            Name = "previousMusicIcon",
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
            #previousMusicIcon {
                font-size: 18px;
                border: none;
                padding: 5px;
                border-radius: 50%;
                background-color: transparent;
                color: white; 
                }");
        Gtk.StyleContext.AddProviderForScreen(
            Gdk.Screen.Default,
            cssProvider,
            Gtk.StyleProviderPriority.Application
        );}

}