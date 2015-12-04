using System;
using System.Collections;
using Stma_BANCARIO_P.Capa_DOMINIO;

namespace Stma_BANCARIO_P.Capa_SERVICIOS
{
    class clsSERVIDOR_CRUD_BILLETE : clsSERVIDOR_CRUD
    {
        private static clsSERVIDOR_CRUD_BILLETE atrInstancia = null;
        public static clsSERVIDOR_CRUD_BILLETE ObtenerInstancia()
        {
            if (atrInstancia == null)
            {
                atrInstancia = new clsSERVIDOR_CRUD_BILLETE();
            }
            return atrInstancia;
        }
       public override object Crear(int pOID, params object[] pParametros)
        {
           object varObjeto = new clsBILLETE(pOID, (string)pParametros[0], (int)pParametros[1], (int)pParametros[2], (int)pParametros[3], (int)pParametros[4], (clsCUENTA)pParametros[5]);
           return varObjeto;
       }
        public override void Modificar(object pObjeto, params object[] pParametros)
        {
            clsBILLETE varBillete = (clsBILLETE)pObjeto;
            varBillete.Modificar((string) pParametros[0], (int) pParametros[1], (int) pParametros[2], (int) pParametros[3], (int) pParametros[4]);
        }
    }
}
