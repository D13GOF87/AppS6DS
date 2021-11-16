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
	public partial class viewActualizar : ContentPage
	{
		public viewActualizar()
		{
			InitializeComponent();
		}

		private void btnActualizarDatos_Clicked(object sender, EventArgs e)
		{
			try
			{

				WebClient cliente = new WebClient();
				var parametros = new System.Collections.Specialized.NameValueCollection();

				parametros.Add("codigo", txtCodigoActualizar.Text);
				parametros.Add("nombre", txtNombreActualizar.Text);
				parametros.Add("apellido", txtApellidoActualizar.Text);
				parametros.Add("edad", txtEdadActualizar.Text);


				cliente.UploadValues("http://192.168.1.121/moviles/post.php","PUT", parametros);

				DisplayAlert("alerta", "Datos Actualizados Correctamente", "ok");

			}
			catch (Exception ex)
			{
				DisplayAlert("alerta", "Error" + ex.Message, "ok");

			}
		}

		private void btnRegresar_Clicked(object sender, EventArgs e)
		{
			Navigation.PushAsync(new MainPage());
		}
	}
}