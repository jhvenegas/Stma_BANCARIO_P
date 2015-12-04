using System;
using System.Collections;
using Stma_BANCARIO_P.Capa_SERVICIOS;

namespace Stma_BANCARIO_P.Capa_DOMINIO
{
    class clsTRANSACCION : clsOBJETO
    {
        #region 1.Atributos
        #region 1.1: Propios y Derivables
        private string atrFecha = null;
        #endregion
        #region 1.2 Asociativos
        private clsCUENTA atrObjCuentaOrigen = null;
        private clsCUENTA atrObjCuentaDestino = null;
        private clsDINERO atrObjDinero = null;
        #endregion
        #region 1.3 Puente
        #endregion
        #region 1.4 Estado
        #endregion
        #endregion
        #region 2: Métodos
        #region 2.1: Constructor, Clonador, Comparador, Inicializador, Modificador y Destructor
        public clsTRANSACCION()
        {
        }
        public clsTRANSACCION(clsCUENTA pObjCuentaOrigen,clsCUENTA pObjCuentaDestino , int pOID, string pNombre, string pFecha,clsDINERO pObjDinero)
            : base(pOID, pNombre)
        {
            this.atrFecha = pFecha;

            this.atrObjCuentaOrigen = pObjCuentaOrigen;
            clsSERVIDOR_ASOCIACIONES.AsociarObjCon(this, pObjCuentaOrigen.GetColObjsTransacciones());

            this.atrObjCuentaDestino = pObjCuentaDestino;
            clsSERVIDOR_ASOCIACIONES.AsociarObjCon(this, pObjCuentaDestino.GetColObjsTransacciones());

            this.atrObjDinero= pObjDinero;
            clsSERVIDOR_ASOCIACIONES.AsociarObjCon(this,(ArrayList) pObjDinero.GetColObjsTransacciones());
        }
        public void Modificar(string pNombre, string pfecha) 
        {
            base.Modificar(pNombre);
            this.SetFecha(pfecha);
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
        private void SetFecha(string pFecha) 
        {
            this.atrFecha = pFecha;
        }
        #endregion
        #region 2.3.2: Mutadores Asociativos y Disociativos
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
