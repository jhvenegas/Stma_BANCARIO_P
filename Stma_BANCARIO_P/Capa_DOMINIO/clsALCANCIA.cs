using System;
using System.Collections;
using Stma_BANCARIO_P.Capa_SERVICIOS;

namespace Stma_BANCARIO_P.Capa_DOMINIO
{
    class clsALCANCIA : clsCUENTA
    {
        #region 1.Atributos
        #region 1.1: Propios y Derivables

        #endregion
        #region 1.2 Asociativos
        private clsBANCO atrObjBanco;
        private ArrayList atrColObjsAhorradores = new ArrayList();
        #endregion
        #region 1.3 Puente
        #endregion
        #region 1.4 Estado
        #endregion
        #endregion
        #region 2: Métodos
        #region 2.1: Constructor, Clonador, Comparador, Inicializador, Modificador y Destructor
        public clsALCANCIA() { }
        public clsALCANCIA(object pObjCreador1, object pObjCreador2, int pOID, string pNombre):base(pOID, pNombre)
        {
            this.atrObjBanco = (clsBANCO)pObjCreador1;
            clsSERVIDOR_ASOCIACIONES.AsociarObjCon(pObjCreador2, this.atrColObjsAhorradores);
        }
        public void Modificar_Whit(string pNombre)
        {
            base.Modificar(pNombre);
        }
        new public void Destruir()
        {
            base.Destruir();
            //TODO Mirar que pasa con los dineros de alcancia (Se los lleva hacia la billetera del primer ahorrador)
            this.Liquidar();
            //clsSERVIDOR_ASOCIACIONES.DisociarObjCon(this, this.atrObjBanco.GetObjsAlcancias());
            this.DisociarTodosAhorradores();
            clsSERVIDOR_ASOCIACIONES.DisociarTodosObjetosCon(this.atrColObjsAhorradores);
            this.atrObjBanco = null;

        }
        #endregion
        #region 2.2: Accesores
        #region 2.2.1: Accesores De Atributo Propio y Derivable
        #endregion
        #region 2.2.2: Accesores De Atributo Asociativo
        #endregion
        #endregion
        #region 2.3: Mutadores
        #region 2.3.1: Mutadores De Atributo Propio y Derivable
        #endregion
        #region 2.3.2: Mutadores Asociativos y Disociativos
        public ArrayList GetObjsAhorradores()
        {
            return this.atrColObjsAhorradores;
        }
        private void DisociarTodosAhorradores()
        {
            for (int varPosicion = 0; varPosicion < this.atrColObjsAhorradores.Count; varPosicion++)
            {
                clsAHORRADOR varObjAhorrador = (clsAHORRADOR)this.atrColObjsAhorradores[varPosicion];
                clsSERVIDOR_ASOCIACIONES.DisociarObjCon(this, varObjAhorrador.GetObjsAlcancias());
            }
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
        public void Liquidar()
        {
            clsAHORRADOR varAhorrador = (clsAHORRADOR)this.atrColObjsAhorradores[0];
            clsCUENTA varBilleteraPrimerAhorrador = (clsCUENTA)varAhorrador.GetObjPersona().GetObjBilletera();
            base.Liquidar(ref varBilleteraPrimerAhorrador);
        }
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
