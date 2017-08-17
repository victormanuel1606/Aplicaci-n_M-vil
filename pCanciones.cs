using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace ServiceWeb
{
    class pCanciones
    {
        private EditText pedido;

        public string action { get; set; }
        public pCanciones(string idPedido)
        {
            action = ("filtrar_ubicasiones_pedido");
            idPedido = pedido.Text;
        }

        public pCanciones(EditText pedido)
        {
            this.pedido = pedido;
        }
    }

    class resultsCanciones
    {
        public int idUbicasion { get; set; }
        public string Ciudad { get; set; }
        public string Proveedor { get; set; }
        public string Fecha_llegada { get; set; }
        public int idPedido { get; set; }
        public override string ToString()
        {
            return String.Format("[{0}]: {1}: {2} ", Ciudad, Proveedor, Fecha_llegada);
        }

    }
}