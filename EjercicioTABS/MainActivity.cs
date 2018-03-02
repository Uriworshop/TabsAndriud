using Android.App;
using Android.Widget;
using Android.OS;
using System.Threading;

namespace EjercicioTABS
{
	[Activity(Label = "EjercicioTABS", MainLauncher = true, Icon = "@mipmap/icon")]
	public class MainActivity : Activity
	{
		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);
			SetContentView(Resource.Layout.Main);

			TabHost tabs = (TabHost)FindViewById(Resource.Id.TabHost01);
			tabs.Setup();

			TabHost.TabSpec spec1 = tabs.NewTabSpec("tag01");
			spec1.SetContent(Resource.Id.AnalogClock01);
			spec1.SetIndicator("Analog Clock");
			tabs.AddTab(spec1);

			TabHost.TabSpec spec2 = tabs.NewTabSpec("tag02");
			spec2.SetContent(Resource.Id.DigitalClock01);
			spec2.SetIndicator("Digital Clock");
			tabs.AddTab(spec2);

			TabHost.TabSpec spec3 = tabs.NewTabSpec("tag03");
			spec3.SetContent(Resource.Id.imagenview1);
			spec3.SetIndicator("Imagen");
			tabs.AddTab(spec3);

			TabHost.TabSpec spec4 = tabs.NewTabSpec("tag04");
			spec4.SetContent(Resource.Id.textview2);
			spec4.SetIndicator("Texto");
			tabs.AddTab(spec4);

			TabHost.TabSpec spec5 = tabs.NewTabSpec("tag05");
			spec5.SetContent(Resource.Id.btn);
			spec5.SetIndicator("Boton");
			tabs.AddTab(spec5);

			Button btn1 = FindViewById<Button>(Resource.Id.btn);

			btn1.Click += delegate {
				var progressDialog = ProgressDialog.Show(this, "Corriendo", "Espera...", true);
				new Thread(new ThreadStart(delegate
				{
					Thread.Sleep(5000);
					RunOnUiThread(() => progressDialog.Hide());
				})).Start();


			new AlertDialog.Builder(this)
						   .SetTitle("Alerta")
						   .SetMessage("Presiona Ok para Continuar")
						   .SetPositiveButton("Ok", delegate
			{
				Toast.MakeText(this, "Se presiono Aceptar", ToastLength.Short).Show();
			})
						   .SetNegativeButton("Cancel", delegate
			 {
				 Toast.MakeText(this, "Se presiono Cancelar", ToastLength.Short).Show();
			 }).Show();
			};
		}
	}
}

