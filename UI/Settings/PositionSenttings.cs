using Gtk;

namespace SpotifyMiniPanel.UI.Settings
{
    public class PositionSettings : Box
    {
        public PositionSettings() : base(Orientation.Horizontal, 12)
        {
            MarginTop = 12;
            MarginBottom = 12;
            MarginStart = 12;
            MarginEnd = 12;

            // Label esquerda
            var label = new Label
            {
                LabelProp = "Posição da Janela:",
                Halign = Align.Start,
                Hexpand = true
            };

            // Combo estilo botão
            var combo = new ComboBoxText();
            combo.AppendText("Canto superior direito");
            combo.AppendText("Canto superior esquerdo");
            combo.AppendText("Canto inferior esquerdo");
            combo.AppendText("Canto inferior direito");
            combo.Active = 0;

            combo.Changed += (_, __) =>
            {
                System.Console.WriteLine(combo.ActiveText);
                
            };

            // Layout GTK3
            PackStart(label, true, true, 0);   // expande à esquerda
            PackStart(combo, false, false, 0); // fica à direita

            ApplyCss();
        }

        private void ApplyCss()
        {
            var css = new CssProvider();
            css.LoadFromData(@"
                combobox {
                    background-color: #2f2f2f;
                    border-radius: 16px;
                    padding: 6px 12px;
                }

                combobox button {
                    background-color: #2f2f2f;
                    border-radius: 16px;
                }
            ");

            StyleContext.AddProviderForScreen(
                Gdk.Screen.Default,
                css,
                StyleProviderPriority.Application
            );
        }
    }
}
