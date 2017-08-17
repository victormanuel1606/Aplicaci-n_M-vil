using Android.App;
using Android.Widget;
using Android.OS;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace ServiceWeb
{
    [Activity(Label = "ServiceWeb", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        Button btnCanciones;
        ListView lbResultados;
        EditText pedido;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView (Resource.Layout.Main);
            btnCanciones = FindViewById<Button>(Resource.Id.btnCanciones);
            pedido = FindViewById<EditText>(Resource.Id.textView1);
            lbResultados = FindViewById<ListView>(Resource.Id.lbResultado);
            btnCanciones.Click += BtnCanciones_Click;


        }

        private void BtnCanciones_Click(object sender, System.EventArgs e)
        {
            List<string> lista = new List<string>();
            Servicio miServicio = new Servicio();
            pCanciones parametros = new pCanciones(pedido);
            string body = JsonConvert.SerializeObject(parametros);
            string resultadoSucioalv = miServicio.llamarServicio(body);
            string resultados = limpiar(resultadoSucioalv);
            var canciones = JsonConvert.DeserializeObject<List<resultsCanciones>>(resultados);
            int contador = 1;
            foreach (resultsCanciones cancion in canciones)
            {
                lista.Add(cancion.ToString());
                contador++;
            }
            lbResultados.Adapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleListItemActivated1, lista);
        }

        private string limpiar(string strResSucio)
        {
            bool leer = false;
            string result = "";
            foreach (char letra in strResSucio)
            {
                if (letra == '[')
                    leer = true;
                if (leer)
                    result += letra;
            }
            return result;
        }
    }
}

