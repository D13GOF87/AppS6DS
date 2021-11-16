using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppS6DS
{
	public partial class MainPage : ContentPage
	{
		private const string Url = "http://192.168.1.121/moviles/post.php";
		private readonly HttpClient client = new HttpClient();
		private ObservableCollection<Ws.Datos> _post; 

		public MainPage()
		{
			InitializeComponent();
			get();
		}

		public async void get()
		{
			try
			{
				var content = await client.GetStringAsync(Url);
				List<Ws.Datos> posts = JsonConvert.DeserializeObject<List<Ws.Datos>>(content);
				_post = new ObservableCollection<Ws.Datos>(posts);

				MyListView.ItemsSource = _post;
			}
			catch(Exception ex)
			{
				await DisplayAlert("Error", "Error" + ex.Message, "OK");
			}
		}

		private async void btnGet_Clicked(object sender, EventArgs e)
		{
			var content = await client.GetStringAsync(Url);
			List<Ws.Datos> posts = JsonConvert.DeserializeObject<List<Ws.Datos>>(content);
			_post = new ObservableCollection<Ws.Datos>(posts);

			MyListView.ItemsSource = _post;
		}

		private async void btnInsertar_Clicked(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new viewInsertar());
		}

		private void btnActualizar_Clicked(object sender, EventArgs e)
		{

		}

		private void btnEliminar_Clicked(object sender, EventArgs e)
		{

		}
	}
}
