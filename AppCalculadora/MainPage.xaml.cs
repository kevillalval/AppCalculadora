using System;
//Utilizamos la libreria de NCalc para realizar multiples operaciones.
using NCalc;
using Xamarin.Forms;

namespace AppCalculadora
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void BtnAccionar_Clicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            if (lblResultado.Text == "0")
            {
                lblResultado.Text = button.Text;
            }
            else
            {
                lblResultado.Text += button.Text;
            }
        }

        private void BtnBorrar_Clicked(object sender, EventArgs e)
        {
            string numero = lblResultado.Text;
            if (numero != "0")
            {
                numero = numero.Remove(numero.Length - 1, 1);
                if (string.IsNullOrEmpty(numero))
                {
                    lblResultado.Text = "0";
                }
                else
                {
                    lblResultado.Text = numero;
                }
            }
        }

        private void BtnLimpiar_Clicked(object sender, EventArgs e)
        {
            lblResultado.Text = "0";
        }

        private void BtnOperaciones_Clicked(object sender, EventArgs e)
        {
            var boton = sender as Button;
            lblResultado.Text += " " + boton.Text + " ";
        }

        private async void BtnPorcentaje_Clicked(object sender, EventArgs e)
        {
            try
            {
                string numero = lblResultado.Text;
                if (numero != "0")
                {
                    decimal convertir = Convert.ToDecimal(numero);
                    string resultado = (convertir / 100).ToString("0.##");
                    lblResultado.Text = resultado;
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error, operación inválida", ex.Message, "OK");
            }
        }

        private void BtnResultadofinal_Clicked(object sender, EventArgs e)
        {
            try
            {
                string expresion = lblResultado.Text;
                Expression expression = new Expression(expresion);
                object resultado = expression.Evaluate();
                lblResultado.Text = resultado.ToString();
            }
            catch (Exception ex)
            {
                DisplayAlert("Error", ex.Message, "OK");
            }
        }

       /* private decimal EvaluarExpresion(string expresion)
        {
            expresion = expresion.Replace(" ", "");

            string[] componentes = expresion.Split(new[] { '+', '-', '*', '/' });

            decimal resultado = decimal.Parse(componentes[0]);

            for (int i = 1; i < componentes.Length; i++)
            {
                decimal numero = decimal.Parse(componentes[i]);
                char operador = expresion[expresion.IndexOf(componentes[i]) - 1];

                if (operador == '+')
                {
                    resultado += numero;
                }
                else if (operador == '-')
                {
                    resultado -= numero;
                }
                else if (operador == '*')
                {
                    resultado *= numero;
                }
                else if (operador == '/')
                {
                    resultado /= numero;
                }
            }

            return resultado;
        }
       */
    }
}
