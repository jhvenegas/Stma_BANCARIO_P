using System;
using Stma_BANCARIO_P.Capa_DOMINIO;

namespace Stma_BANCARIO_P.Capa_SERVICIOS
{
    class clsSERVIDOR_CRUD_BANCO : clsSERVIDOR_CRUD
    {
        private static clsSERVIDOR_CRUD_BANCO atrInstancia = null;
        public static clsSERVIDOR_CRUD_BANCO ObtenerInstancia()
        {
            if (atrInstancia == null)
            {
                atrInstancia = new clsSERVIDOR_CRUD_BANCO();
            }
            return atrInstancia;
        }
        public override object Crear(int pOID, params object[] pParametros)
        {
            object varObjeto = new clsBANCO(pOID, (string)pParametros[0],(string)pParametros[1]);
            return varObjeto;
        }
        public override void Modificar(object pObjeto, params object[] pParametros)
        {
            ((clsBANCO)pObjeto).Modificar((string)pParametros[0],(string)pParametros[1]);
        }
        public override void Destruir(object pObjeto,ref clsCUENTA pCuentaLiquidacion)
        {
            ((clsBANCO)pObjeto).Destruir(ref pCuentaLiquidacion);
        }
    }
}
