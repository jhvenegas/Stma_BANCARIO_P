using System;
using System.Collections;
using Stma_BANCARIO_P.Capa_DOMINIO;

namespace Stma_BANCARIO_P.Capa_SERVICIOS
{
    class clsSERVIDOR_CRUD
    {
        #region Crear y Modificar Genericos
        public virtual object Crear(object pObjCreador, int pOID, params object[] pParametros)
        {
            return null;
        }
        public virtual object Crear(object pObjCreador1, object pObjCreador2, int pOID, params object[] pParametros)
        {
            return null;
        }
        public virtual object Crear(int pOID, params object[] pParametros)
        {
            return null;
        }
        public virtual object Crear(object pObjCreador)
        {
            return null;
        }
        public virtual void Modificar(object pObjeto, params object[] pParametros)
        {
        }
        public virtual void Destruir(object pObjeto)
        {
        }
        public virtual void Destruir(object pObjeto,ref clsTESORO pTesoroLiquidacion)
        {
        }
        #endregion
        #region Registradores Genericos

        public void crudRegistrarObj(ArrayList pColeccion, int pOID, params object[] pParametros)
        {
            //Situación muchos a uno contra el creador. No se referencia a este último
            object varObjeto = clsSERVIDOR_ASOCIACIONES.ObtenerObjCon(pOID, pColeccion);
            if (varObjeto == null)
            {
                varObjeto = Crear(pOID, pParametros);
                clsSERVIDOR_ASOCIACIONES.AsociarObjCon(varObjeto, pColeccion);
            }

        }
        public void crudRegistrarObj(object pObjCreador, ArrayList pColeccion, int pOID, params object[] pParametros)
        {
            //Situación muchos a uno contra el creador. Se referencia a este último
            object varObjeto = clsSERVIDOR_ASOCIACIONES.ObtenerObjCon(pOID, pColeccion);
            if (varObjeto == null)
            {
                varObjeto = Crear(pObjCreador, pOID, pParametros);
            }
        }
        public void crudRegistrarObj(object pObjCreador1, object pObjCreador2, ArrayList pColeccion1,ArrayList pColeccion2, int pOID, params object[] pParametros)
        {
            object varObjeto = clsSERVIDOR_ASOCIACIONES.ObtenerObjCon(pOID, pColeccion1);
            if (varObjeto == null)
            {
                varObjeto = Crear(pObjCreador1, pObjCreador2, pOID, pParametros);
                clsSERVIDOR_ASOCIACIONES.AsociarObjCon(varObjeto, pColeccion1);
                clsSERVIDOR_ASOCIACIONES.AsociarObjCon(varObjeto, pColeccion2);
                
            }
        }
        public void crudRegistrarObj(object pObjCreador, object pObjAtributo)
        {
            if (pObjAtributo == null)
            {
                object varObjeto = Crear(pObjCreador);
                pObjAtributo = varObjeto;
            }
        }
        #endregion
        #region Actualizadores Genericos
        public void crudActualizarObj(ArrayList pColeccion, int pOID, params object[] pParametros)
        {
            object varObjeto = clsSERVIDOR_ASOCIACIONES.ObtenerObjCon(pOID, pColeccion);
            if (varObjeto != null)
            {
                this.Modificar(varObjeto, pParametros);
            }
        }
        public void crudActualizarObj(ArrayList pColeccion1, ArrayList pColeccion2, int pOID, params object[] pParametros)
        {
            object varObjeto = clsSERVIDOR_ASOCIACIONES.ObtenerObjCon(pOID, pColeccion1);
            object varObjeto1 = clsSERVIDOR_ASOCIACIONES.ObtenerObjCon(pOID, pColeccion2);
            if (varObjeto != null && varObjeto1 != null)
            {
                this.Modificar(varObjeto, pParametros);
            }
        }
        #endregion
        #region Eliminadores Genericos
        public void crudEliminarObj(ArrayList pColeccion, int pOID)
        {
            //1. Buscar-Encontrar y Recuperar el Objeto a Eliminar con OID
            object varObjeto = clsSERVIDOR_ASOCIACIONES.ObtenerObjCon(pOID, pColeccion);
            if (varObjeto != null)
            {
                clsSERVIDOR_ASOCIACIONES.DisociarObjCon(varObjeto, pColeccion);
                this.Destruir(varObjeto);
                varObjeto = null;
                clsGESTOR_RECURSOS.LiberarRecursos("DotNet");
            }
        }
        public void crudEliminarObj(ArrayList pColeccion, int pOID, ref clsTESORO pTesoroLiquidacion)
        {
            //1. Buscar-Encontrar y Recuperar el Objeto a Eliminar con OID
            object varObjeto = clsSERVIDOR_ASOCIACIONES.ObtenerObjCon(pOID, pColeccion);
            if (varObjeto != null)
            {
                clsSERVIDOR_ASOCIACIONES.DisociarObjCon(varObjeto, pColeccion);
                this.Destruir(varObjeto, ref pTesoroLiquidacion);
                varObjeto = null;
                clsGESTOR_RECURSOS.LiberarRecursos("DotNet");
            }
        }
        public void crudEliminarObj(object pObjAtributo)
        {
            if (pObjAtributo != null)
            {
                this.Destruir(pObjAtributo);
                clsGESTOR_RECURSOS.LiberarRecursos("DotNet");
            }
        }
        public void crudEliminarObj(object pObjAtributo, ref clsTESORO pTesoroLiquidacion)
        {
            if (pObjAtributo != null)
            {
                this.Destruir(pObjAtributo, ref pTesoroLiquidacion);
                clsGESTOR_RECURSOS.LiberarRecursos("DotNet");
            }
        }
        public void crudEliminarTodosObjs(ArrayList pColeccion)
        {
            object varObjeto;
            foreach (object varObjPuente in pColeccion)
            {
                varObjeto = varObjPuente;
                this.Destruir(varObjeto);
                varObjeto = null;
                clsGESTOR_RECURSOS.LiberarRecursos("DotNet");
            }
        }
        #endregion
    }
}
