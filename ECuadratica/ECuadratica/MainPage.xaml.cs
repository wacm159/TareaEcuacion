using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ECuadratica
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            calcularButton.Clicked += CalcularButton_Clicked;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            using (var datos = new DataAccess())
            {
                listaListView.ItemsSource = datos.GetEcuacion();
            }
        }

        private async void CalcularButton_Clicked(object sender, EventArgs e)
        {
            double a, b, c, x1, x2, temp, temp1;


            if (string.IsNullOrEmpty(valorAentry.Text))
            {
                await DisplayAlert("Error", "Debe ingresar un valor A", "Aceptar");
                valorAentry.Focus();
                return;
            }

            temp1 = Convert.ToDouble(valorAentry.Text);
            if (temp1 <= 0)
            {
                await DisplayAlert("Error", "Numero debe ser mayor que cero", "Aceptar");
                valorCentry.Focus();
                return;

            }

            if (string.IsNullOrEmpty(valorBentry.Text))
            {
                await DisplayAlert("Error", "Debe ingresar un valor B", "Aceptar");
                valorBentry.Focus();
                return;
            }

            if (string.IsNullOrEmpty(valorCentry.Text))
            {
                await DisplayAlert("Error", "Debe ingresar un valor C", "Aceptar");
                valorCentry.Focus();
                return;
            }

            a = Convert.ToDouble(valorAentry.Text);
            b = Convert.ToDouble(valorBentry.Text);
            c = Convert.ToDouble(valorCentry.Text);

            temp = Math.Pow(b, 2);
            x1 = (-b + (Math.Sqrt((temp) - (4 * a * c)))) / (2 * a);
            x2 = (-b - (Math.Sqrt((temp) - (4 * a * c)))) / (2 * a);

            result1.Text = x1.ToString();
            result2.Text = x2.ToString();

            var ecuacion = new Ecuacion
            {
                DatoA = decimal.Parse(valorAentry.Text),
                DatoB = decimal.Parse(valorBentry.Text),
                DatoC = decimal.Parse(valorCentry.Text),
                Res1 = decimal.Parse(result1.Text),
                Res2 = decimal.Parse(result2.Text)
            };

            using (var datos = new DataAccess())
            {
                datos.InsertEcuacion(ecuacion);
                listaListView.ItemsSource = datos.GetEcuacion();
            }

            valorAentry.Text = string.Empty;
            valorBentry.Text = string.Empty;
            valorCentry.Text = string.Empty;




        }
    }
}
