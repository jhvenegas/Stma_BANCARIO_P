using System;
using Stma_BANCARIO_P.Capa_DOMINIO;

namespace Stma_BANCARIO_P.Capa_SERVICIOS
{
    class clsSERVIDOR_CRUD_BOVEDA : clsSERVIDOR_CRUD
    {
        private static clsSERVIDOR_CRUD_BOVEDA atrInstancia = null;
        public static clsSERVIDOR_CRUD_BOVEDA ObtenerInstancia()
        {
            if (atrInstancia == null)
            {
                atrInstancia = new clsSERVIDOR_CRUD_BOVEDA();
            }
            return atrInstancia;
        }
        public override object  Crear(object pObjCreador)
        {
            object varObjeto = new clsBOVEDA((clsBANCO)pObjCreador);
            return varObjeto;
        }
        public override void Destruir(object pObjeto, ref clsCUENTA pCuentaLiquidacion)
        {
            ((clsBOVEDA)pObjeto).Destruir(ref pCuentaLiquidacion);
        }
    }
}
