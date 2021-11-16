using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppS6DS
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class viewInsertar : ContentPage
	{
		public viewInsertar()
		{
			InitializeComponent();
		}

		private void btnInsertar_Clicked(object sender, EventArgs e)
		{
			try
			{
				WebClient cliente = new WebClient();
				
				//Creo variable parametros para manejar objeto
				var parametros = new System.Collections.Specialized.NameValueCollection();

				//Agrego valores al objeto
				parametros.Add("codigo", txtCodigo.Text);
				parametros.Add("nombre", txtNombre.Text);
				parametros.Add("apellido", txtApellido.Text);
				parametros.Add("edad", txtEdad.Text);

				cliente.UploadValues("http://192.168.1.121/moviles/post.php","POST", parametros);
				DisplayAlert("Mensaje", "Ingreso corecto de información", "OK");
			}
			catch (Exception ex) 
			{
				DisplayAlert("Mensaje", "Error: " + ex.Message, "OK");
			}
		}

		private async void btnRegresar_Clicked(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new MainPage());
		}
	}
}