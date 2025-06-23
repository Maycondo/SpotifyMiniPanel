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
            Text = Icon,
            UseMarkup = true,
            Xalign = 0.5f, // Centraliza horizontalmente
            Yalign = 0.5f // Centraliza verticalmente
        };

        Add(iconLabel);

        // Configurações do botão
        SetSizeRequest(50, 50);
        CanFocus = false;
        Relief = ReliefStyle.Normal;

        // Estilo do botão
        var cssProvider = new CssProvider();
        cssProvider.LoadFromData(@"
            button {
                font-size: 18px;
                border: none;
                padding: 5px;
                border-radius: 50%;
                color: white; 
                }");
        Gtk.StyleContext.AddProviderForScreen(
            Gdk.Screen.Default,
            cssProvider,
            Gtk.StyleProviderPriority.Application
        );}

}