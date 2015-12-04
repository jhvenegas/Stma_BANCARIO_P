using System;
using Stma_BANCARIO_P.Capa_DOMINIO;

namespace Stma_BANCARIO_P.Capa_SERVICIOS
{
    class clsSERVIDOR_CRUD_ALCANCIA : clsSERVIDOR_CRUD
    {
        private static clsSERVIDOR_CRUD_ALCANCIA atrInstancia = null;
        public static clsSERVIDOR_CRUD_ALCANCIA ObtenerInstancia()
        {
            if (atrInstancia == null)
            {
                atrInstancia = new clsSERVIDOR_CRUD_ALCANCIA();
            }
            return atrInstancia;
        }
        public override object Crear(object pObjCreador1, object pObjCreador2, int pOID, params object[] pParametros)
        {
            object varObjeto = new clsALCANCIA(pObjCreador1, pObjCreador2, pOID, (string)pParametros[0]);
            return varObjeto;
        }
        public override void Modificar(object pObjeto, params object[] pParametros)
        {
            ((clsALCANCIA)pObjeto).Modificar_Whit((string)pParametros[0]);
        }
        //public override void Destruir(object pObjeto, ref object pTesoroLiquidacion)
        //{
        //    ((clsALCANCIA)pObjeto).Destruir();
        //}
    }
}
