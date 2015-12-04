using System;
using Stma_BANCARIO_P.Capa_DOMINIO;
namespace Stma_BANCARIO_P.Capa_SERVICIOS
{
    class clsSERVIDOR_CRUD_PERSONA: clsSERVIDOR_CRUD
    {
        private static clsSERVIDOR_CRUD_PERSONA atrInstancia = null;
        public static clsSERVIDOR_CRUD_PERSONA ObtenerInstancia()
        {
            if (atrInstancia == null)
            {
                atrInstancia = new clsSERVIDOR_CRUD_PERSONA();
            }
            return atrInstancia;
        }
        public override object Crear(int pOID, params object[] pParametros)
        {
            object varObjeto = new clsPERSONA(pOID, (string)pParametros[0], (string)pParametros[1]);
            return varObjeto;
        }
        public override void Modificar(object pObjeto, params object[] pParametros)
        {
            clsPERSONA varPersona = (clsPERSONA)pObjeto;
            varPersona.Modificar((string)pParametros[0],(string)pParametros[1]);
        }
    }
}
