using System;
using System.Collections;
using Stma_BANCARIO_P.Capa_DOMINIO;

namespace Stma_BANCARIO_P.Capa_SERVICIOS
{
    class clsSERVIDOR_CRUD_AHORRADOR : clsSERVIDOR_CRUD
    {
        private static clsSERVIDOR_CRUD_AHORRADOR atrInstancia = null;
        public static clsSERVIDOR_CRUD_AHORRADOR ObtenerInstancia()
        {
            if (atrInstancia == null)
            {
                atrInstancia = new clsSERVIDOR_CRUD_AHORRADOR();
            }
            return atrInstancia;
        }
        public override object Crear(object pObjCreador1, object pObjCreador2, int pOID, params object[] pParametros)
        {
            object varObjeto = new clsAHORRADOR((clsBANCO)pObjCreador1,(clsPERSONA)pObjCreador2,pOID,(string)pParametros[0]);
            return varObjeto;
        }
        public override void Modificar(object pObjeto, params object[] pParametros)
        {
            ((clsAHORRADOR)pObjeto).Modificar((string)pParametros[0]);
        }
        public override void Destruir(object pObjeto)
        {
            ((clsAHORRADOR)pObjeto).Destruir();
        }
    }
}
