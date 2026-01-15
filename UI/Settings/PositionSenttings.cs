using Gtk;
using Gdk;

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

            var label = new Label
            {
                LabelProp = "Posição da Janela:",
                Halign = Align.Start,
                Hexpand = true
            };

            var combo = new ComboBoxText();
            combo.AppendText("Canto superior direito");
            combo.AppendText("Canto superior esquerdo");
            combo.AppendText("Canto inferior esquerdo");
            combo.AppendText("Canto inferior direito");

            // 🔹 Seleciona conforme setting salvo
            combo.Active = SpotifyMiniPanel.Settings.WindowPosition switch
            {
                "Canto superior direito" => 0,
                "Canto superior esquerdo" => 1,
                "Canto inferior esquerdo" => 2,
                "Canto inferior direito" => 3,
                _ => 3
            };

            // 🔹 Salva a seleção nas settings
            combo.Changed += (sender, e) =>
            {
                var selected = combo.ActiveText;
                if (selected == null) return;

                SpotifyMiniPanel.Settings.WindowPosition = selected;
                SpotifyMiniPanel.Settings.SaveSettings();
                // 🔹 Aplica a nova posição imediatamente
                if (Toplevel is Gtk.Window toplevel)
                    ApplyWindowPosition(toplevel);
            };

            PackStart(label, true, true, 0);
            PackStart(combo, false, false, 0);

            ApplyCss();
        }
         
        // 🔹 Método para aplicar a posição da janela conforme a configuração salva
        public static void ApplyWindowPosition(Gtk.Window win)
        {
            var screen = Gdk.Screen.Default;

            int monitor = screen.PrimaryMonitor;
            var geo = screen.GetMonitorGeometry(monitor);
            
            // 🔹 Define a posição da janela com base na configuração salva
            switch (SpotifyMiniPanel.Settings.WindowPosition)
            {
                case "Canto superior direito":
                    win.Move(geo.X + geo.Width - 410, geo.Y);
                    break;

                case "Canto superior esquerdo":
                    win.Move(geo.X, geo.Y);
                    break;

                case "Canto inferior esquerdo":
                    win.Move(geo.X, geo.Y + geo.Height - 200);
                    break;

                case "Canto inferior direito":
                    win.Move( geo.X + geo.Width - 410, geo.Y + geo.Height - 200);
                    break;

                default:
                    win.Move(geo.X + geo.Width - 410, geo.Y + geo.Height - 200);
                    break;
            }
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
                Screen.Default,
                css,
                StyleProviderPriority.Application
            );
        }
    }
}
