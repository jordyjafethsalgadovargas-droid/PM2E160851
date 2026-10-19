using System.Globalization;

namespace PM2E160851;

public partial class CalculadoraEnvios : ContentPage
{
    public CalculadoraEnvios()
    {
        InitializeComponent();
    }

    private async void OnConvertirClicked(object sender, EventArgs e)
    {
        // Evitar múltiples clicks
        if (btnConvertir != null)
            btnConvertir.IsEnabled = false;

        try
        {
            // Validar que el campo no esté vacío y sea numérico usar decimal para dinero
            var pesoText = txtPeso.Text?.Trim();

            if (string.IsNullOrWhiteSpace(txtPaquete.Text))
            {
                await DisplayAlert("Error", "Por favor ingrese el nombre o descripción del paquete.", "OK");
                return;
            }

            if (string.IsNullOrWhiteSpace(pesoText) || !decimal.TryParse(pesoText, NumberStyles.Number, CultureInfo.CurrentCulture, out decimal peso))
            {
                await DisplayAlert("Error", "Por favor ingrese un peso numérico válido (sin letras ni espacios).", "OK");
                return;
            }

            // Validar que el peso sea mayor a 0
            if (peso <= 0)
            {
                await DisplayAlert("Error", "El peso debe ser mayor a 0.", "OK");
                return;
            }

            // Validar que se haya seleccionado la zona de destino
            if (pckDestino.SelectedIndex == -1)
            {
                await DisplayAlert("Error", "Por favor seleccione la zona de destino.", "OK");
                return;
            }

            // Tarifas por zona (Lempiras por KG)
            decimal tarifaPorKg = pckDestino.SelectedIndex switch
            {
                0 => 50.00M,
                1 => 85.00M,
                2 => 150.00M,
                _ => 0.0M
            };

            // Cálculo del costo (Se agregó el operador *)
            decimal costo = peso * tarifaPorKg;

            if (chkServicioExpres.IsChecked)
            {
                costo += 100.00M; // cargo fijo por servicio exprés
            }

            // Mostrar resultado formateado
            lblCosto.Text = $"L {costo:N2}";
            lblDetalle.Text = $"Paquete: {txtPaquete.Text}\n" +
                $"Zona: {pckDestino.Items[pckDestino.SelectedIndex]}\n" +
                $"Peso: {peso} kg{(chkServicioExpres.IsChecked ? "\n" +
                "Servicio: Expres (+L100)" : string.Empty)}";
            brResultado.IsVisible = true;
        }
        finally
        {
            if (btnConvertir != null)
                btnConvertir.IsEnabled = true;
        }
    }

    private void OnLimpiarClicked(object sender, EventArgs e)
    {
        txtPaquete.Text = string.Empty;
        txtPeso.Text = string.Empty;
        pckDestino.SelectedIndex = -1;
        chkServicioExpres.IsChecked = false;
        lblCosto.Text = string.Empty;
        lblDetalle.Text = string.Empty;
        brResultado.IsVisible = false;
    }
}