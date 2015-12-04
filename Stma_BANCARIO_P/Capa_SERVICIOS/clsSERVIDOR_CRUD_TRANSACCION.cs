using System;
using Stma_BANCARIO_P.Capa_DOMINIO;

namespace Stma_BANCARIO_P.Capa_SERVICIOS
{
    class clsSERVIDOR_CRUD_TRANSACCION:clsSERVIDOR_CRUD
    {
        private static clsSERVIDOR_CRUD_TRANSACCION atrInstancia = null;
        public static clsSERVIDOR_CRUD_TRANSACCION ObtenerInstancia()
        {
            if (atrInstancia == null)
            {
                atrInstancia = new clsSERVIDOR_CRUD_TRANSACCION();
            }
            return atrInstancia;
        }
        public override object Crear(object pObjCreador1, object pObjCreador2, int pOID, params object[] pParametros)
        {
            object varObjeto = new clsTRANSACCION((clsCUENTA)pObjCreador1, (clsCUENTA)pObjCreador2, pOID, (string)pParametros[0],(clsDINERO)pParametros[1]);
            return varObjeto;
        }
        public override void Destruir(object pObjeto)
        {
            ((clsTRANSACCION)pObjeto).Destruir();
        }
    }
}
