using System;
using Gtk;
using Gdk;


class PlayAndPauseButton : Button
{
    private Label iconLabel;
    public string PlayIcon = "\uf04b"; //🔹 Unicode do ícone "play"
    public string PauseIcon = "\uf04c"; //🔹 Unicode do ícone "pause"

    public bool IsPlaying { get; private set; } = false; //🔹 Estado do botão

    public PlayAndPauseButton()
    {

        iconLabel = new Label(PauseIcon)
        {
            Name = "playPauseIcon",
            UseMarkup = true,
            Xalign = 0.5f, // Centraliza horizontalmente
            Yalign = 0.6f // Centraliza verticalmente
        };
        iconLabel.UseUnderline = false; //🔹 Permite o uso de sublinhado para ícones

        Add(iconLabel);

        // Configurações do botão
        SetSizeRequest(45, 35);
        CanFocus = false;
        Relief = ReliefStyle.None;


        // Estilo do botão
        var cssProvider = new CssProvider();
        cssProvider.LoadFromData(@"
            #playPauseIcon {
                font-family: 'FontAwesome';
                font-size: 12px; /* Tamanho do ícone */
                border: none;
                padding: 14px;
                border-radius: 50%;
                color:rgb(0, 0, 0);
                background-color: white;
            }
            #playPauseIcon:hover {
                border-radius: 50%;
            }
        ");

        Gtk.StyleContext.AddProviderForScreen(
            Gdk.Screen.Default,
            cssProvider,
            Gtk.StyleProviderPriority.Application
        );
    }

    public void TogglePlayPause()
    {
        IsPlaying = !IsPlaying;
        iconLabel.Text = IsPlaying ? PauseIcon : PlayIcon; // Alterna entre ícones de play e pause
        iconLabel.UseMarkup = true; // Garante que o texto seja interpretado como markup
        iconLabel.UseUnderline = false; // Garante que o sublinhado não seja aplicado
    }
}