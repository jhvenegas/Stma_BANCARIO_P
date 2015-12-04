using System;
using System.Collections;
using Stma_BANCARIO_P.Capa_DOMINIO;

namespace Stma_BANCARIO_P.Capa_SERVICIOS
{
    static class clsSERVIDOR_ASOCIACIONES
    {
        #region 1: Atributos
        #endregion
        #region 2: Métodos
        public static void AsociarObjCon(object pObjeto, ArrayList pColeccion)
        {
            pColeccion.Add(pObjeto);
        }
        public static void DisociarObjCon(object pObjeto, ArrayList pColeccion)
        {
            if (pObjeto != null && pColeccion != null)
            {
                pColeccion.Remove(pObjeto);
            }
        }
        public static object ObtenerObjCon(int pOID, ArrayList pColeccion)
        {
            object varObjetoResultado = null;
            foreach (object varObjeto in pColeccion)
            {
                if (((clsOBJETO)varObjeto).GetOID() == pOID)
                {
                    varObjetoResultado = varObjeto;
                    break;
                }
            }
            return varObjetoResultado;
        }
        public static bool ExisteObjEnColeccionCon(object pObjeto, ArrayList pColeccion)
        {
            return pColeccion.Contains(pObjeto);
        }
        public static int GenerarNuevoOID(ArrayList pColeccion)
        {
            int varOID = pColeccion.Count + 1;
            return varOID;
        }
        public static void DisociarTodosObjetosCon(ArrayList pColeccion)
        {
            for (int varPosicion = 0; varPosicion < pColeccion.Count; varPosicion++)
            {
                pColeccion.Remove(pColeccion[varPosicion]);
            }
        }
        public static void DisociarTodosObjetosCon(object pObjCreador, ArrayList pColeccion)
        {
            for (int varPosicion = 0; varPosicion < pColeccion.Count; varPosicion++)
            {
                pColeccion.Remove(pColeccion[varPosicion]);
            }
        }
        #endregion
    }
}

