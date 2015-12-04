using System;
using Stma_BANCARIO_P.Capa_DOMINIO;

namespace Stma_BANCARIO_P.Capa_SERVICIOS
{
    class clsSERVIDOR_CRUD_DINERO:clsSERVIDOR_CRUD
    {
           private static clsSERVIDOR_CRUD_DINERO atrInstancia = null;
        public static clsSERVIDOR_CRUD_DINERO ObtenerInstancia()
        {
            if (atrInstancia == null)
            {
                atrInstancia = new clsSERVIDOR_CRUD_DINERO();
            }
            return atrInstancia;
        }
    }
}
