using System;
using Stma_BANCARIO_P.Capa_DOMINIO;
namespace Stma_BANCARIO_P.Capa_SERVICIOS
{
    class clsSERVIDOR_CRUD_MONEDA : clsSERVIDOR_CRUD_DINERO
    {
        private static clsSERVIDOR_CRUD_MONEDA atrInstancia = null;
        new public static clsSERVIDOR_CRUD_MONEDA ObtenerInstancia()
        {
            if (atrInstancia == null)
            {
                atrInstancia = new clsSERVIDOR_CRUD_MONEDA();
            }
            return atrInstancia;
        }
        public override object Crear(int pOID, params object[] pParametros)
        {
            object varObjeto = new clsMONEDA(pOID, (string)pParametros[0], (int)pParametros[1], (int)pParametros[2], (clsCUENTA)pParametros[3]);
            return varObjeto;
        }
        public override void Modificar(object pObjeto, params object[] pParametros)
        {
            clsMONEDA varMoneda = (clsMONEDA)pObjeto;
            varMoneda.Modificar((string)pParametros[0], (int)pParametros[1], (int)pParametros[2]);
        }
    }
}
