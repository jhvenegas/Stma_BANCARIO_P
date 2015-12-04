using System;
using System.Collections;
using Stma_BANCARIO_P.Capa_DOMINIO;

namespace Stma_BANCARIO_P.Capa_SERVICIOS
{
    class clsSERVIDOR_CRUD_BILLETERA : clsSERVIDOR_CRUD
    {
        private static clsSERVIDOR_CRUD_BILLETERA atrInstancia = null;
        public static clsSERVIDOR_CRUD_BILLETERA ObtenerInstancia()
        {
            if (atrInstancia == null)
            {
                atrInstancia = new clsSERVIDOR_CRUD_BILLETERA();
            }
            return atrInstancia;
        }
        public override object Crear(object pObjCreador)
        {
            object varObjeto = new clsBILLETERA((clsPERSONA)pObjCreador);
            return base.Crear(pObjCreador);
        }
        public override void Destruir(object pObjeto)
        {
            ((clsBILLETERA)pObjeto).Destruir();
        }
        
        
    }
}
