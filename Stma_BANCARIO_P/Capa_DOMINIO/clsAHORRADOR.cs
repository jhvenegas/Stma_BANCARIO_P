using System;
using System.Collections;
using Stma_BANCARIO_P.Capa_SERVICIOS;

namespace Stma_BANCARIO_P.Capa_DOMINIO
{
    class clsAHORRADOR : clsOBJETO
    {
        #region 1.Atributos
        #region 1.1: Propios y Derivables
        private string atrFechaInicio = null;
        #endregion
        #region 1.2 Asociativos
        private clsPERSONA atrObjPersona;
        private clsBANCO atrObjBanco;
        private ArrayList atrColObjsAlcancias = new ArrayList();
        #endregion
        #region 1.3 Puente
        #endregion
        #region 1.4 Estado
        #endregion
        #endregion
        #region 2: Métodos
        #region 2.1: Constructor, Clonador, Comparador, Inicializador, Modificador y Destructor
        public clsAHORRADOR(clsBANCO pObjCreador1, clsPERSONA pObjCreador2, int pOID, string pFechaInicio): base(pOID,null)
        {
            this.atrFechaInicio = pFechaInicio;
            this.atrObjBanco = pObjCreador1;
            this.atrObjPersona = pObjCreador2;
        }
        new public void Modificar(string pFechaInicio)
        {
            this.SetFechaInicio(pFechaInicio);
        }
        public void Destruir()
        {
            //TODO Disociarse del banco
            clsSERVIDOR_ASOCIACIONES.DisociarObjCon(this, this.atrObjBanco.GetObjsAhorradores());
            this.atrObjBanco = null;
            //TODO Disociarse de las alcancias
            this.DisociarTodasAlcancias();
            clsSERVIDOR_ASOCIACIONES.DisociarTodosObjetosCon(this.atrColObjsAlcancias);
            //TODO Disociarse de persona
            clsSERVIDOR_ASOCIACIONES.DisociarObjCon(this, this.atrObjPersona.GetObjsAhorradores());
            this.atrObjPersona = null;
        }
        #endregion
        #region 2.2: Accesores
        #region 2.2.1: Accesores De Atributo Propio y Derivable
        #endregion
        #region 2.2.2: Accesores De Atributo Asociativo
        public ArrayList GetObjsAlcancias()
        {
            return this.atrColObjsAlcancias;
        }
        public clsPERSONA GetObjPersona()
        {
            return this.atrObjPersona;
        }
        #endregion
        #endregion
        #region 2.3: Mutadores
        #region 2.3.1: Mutadores De Atributo Propio y Derivable
        public void SetFechaInicio(string pFechaInicio)
        {
            this.atrFechaInicio = pFechaInicio;
        }
        #endregion
        #region 2.3.2: Mutadores Asociativos y Disociativos
        private void DisociarTodasAlcancias()
        {
            for (int varPosicion = 0; varPosicion < this.atrColObjsAlcancias.Count; varPosicion++)
            {
                clsALCANCIA varObjAlcancia = (clsALCANCIA)this.atrColObjsAlcancias[varPosicion];
                clsSERVIDOR_ASOCIACIONES.DisociarObjCon(this, varObjAlcancia.GetObjsAhorradores());
            }
        }
        public void DisociarRelaciones()
        {
            clsSERVIDOR_ASOCIACIONES.DisociarObjCon(this, this.atrObjPersona.GetObjsAhorradores());
        }
        public void SetObjPersona(clsPERSONA pObjeto)
        {
            this.atrObjPersona = pObjeto;
        }
        public void SetObjBanco(clsBANCO pObjeto)
        {
            this.atrObjBanco = pObjeto;
        }
        #endregion
        #endregion
        #region 2.4: Servicios CRUD
        #region 2.4.1: Registradores

        #endregion
        #region 2.4.2: Actualizadores

        #endregion
        #region 2.4.3: Eliminadores

        #endregion
        #region 2.4.4: Transacciones de Dominio

        #endregion
        #endregion
        #region 2.5: Servicios de Persistencia
        #region 2.5.1: Materializadores
        #endregion
        #region 2.5.2: Des-Materializadores
        #endregion
        #region 2.5.3: Serializadores
        #endregion
        #region 2.5.4 Des-Serializadores
        #endregion
        #endregion
        #region 2.6: Servicios de Consulta
        #endregion
        #region 2.7: Servicios de IGU
        #region 2.7.1: Servicios de Navegación
        #endregion
        #region 2.7.2: Gestión Estado de Campos y Comandos IGU
        #endregion
        #region 2.7.3: Gestión de Campos IGU
        #endregion
        #region 2.7.4: Servición de Validación
        #endregion
        #endregion
        #endregion
    }
}
