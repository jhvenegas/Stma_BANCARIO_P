using System;
using System.Collections;
using Stma_BANCARIO_P.Capa_SERVICIOS;

namespace Stma_BANCARIO_P.Capa_DOMINIO
{
    class clsCUENTA : clsOBJETO
    {
        #region 1.Atributos
        #region 1.1: Propios y Derivables
        protected int atrSaldo = -1;
        protected ArrayList atrColDenominacionesMonedas = new ArrayList() { 20, 50, 100, 200, 500, 1000 };
        protected ArrayList atrColdenominacionsBilletes = new ArrayList() { 1000, 2000, 5000, 10000, 20000, 50000 };
        protected ArrayList atrColMonedasDisponiblesPorDenominacion = new ArrayList() { 0, 0, 0, 0, 0, 0 };
        protected ArrayList atrColBilletesDisponiblesPorDenominacion = new ArrayList() { 0, 0, 0, 0, 0, 0 };
        #endregion
        #region 1.2 Asociativos
        protected ArrayList atrColObjsDineros = new ArrayList();
        protected ArrayList atrColObjsTransacciones = new ArrayList();
        #endregion
        #region 1.3 Puente
        #endregion
        #region 1.4 Estado
        #endregion
        #endregion
        #region 2: Métodos
        #region 2.1: Constructor, Clonador, Comparador, Inicializador, Modificador y Destructor
        public clsCUENTA() { }
        public clsCUENTA(int pOID, string pNombre): base(pOID, pNombre)
        { }
        new protected internal void Modificar(string pNombre) 
        {
            base.Modificar(pNombre);

        }
        protected internal void Destruir()
        {
            //TO DO: Eliminar Todas las transacciones.
            this.crudEliminarTodasTransacciones();
        }
        #endregion
        #region 2.2: Accesores
        #region 2.2.1: Accesores De Atributo Propio y Derivable
        #endregion
        #region 2.2.2: Accesores De Atributo Asociativo
        public ArrayList GetColObjsTransacciones()
        {
            return this.atrColObjsTransacciones;
        }
        #endregion
        #endregion
        #region 2.3: Mutadores
        #region 2.3.1: Mutadores De Atributo Propio y Derivable
        #endregion
        #region 2.3.2: Mutadores Asociativos y Disociativos
        #endregion
        #endregion
        #region 2.4: Servicios CRUD
        #region 2.4.1: Registradores
        public void crudRegistrarTransaccion(clsCUENTA pObjetoCreador, int pOID, string pFecha,clsDINERO pDinero)
        {
            clsSERVIDOR_CRUD_TRANSACCION VarInstancia = clsSERVIDOR_CRUD_TRANSACCION.ObtenerInstancia();
            VarInstancia.crudRegistrarObj(pObjetoCreador,this,pObjetoCreador.GetColObjsTransacciones(),this.atrColObjsTransacciones, pOID, pFecha,pDinero);
        }
        #endregion
        #region 2.4.2: Actualizadores
        protected internal void Rectificar_Saldo() 
        {
            this.atrSaldo=0;
            foreach(clsDINERO varDinero in this.atrColObjsDineros)
            {
                atrSaldo += varDinero.GetDenominacion();
            }
        }
        #endregion
        #region 2.4.3: Eliminadores
        public void crudEliminarTodasTransacciones()
        {
            clsSERVIDOR_CRUD_TRANSACCION varInstanciaServidorCrud = clsSERVIDOR_CRUD_TRANSACCION.ObtenerInstancia();
            varInstanciaServidorCrud.crudEliminarTodosObjs(this.atrColObjsTransacciones);
        }

        #endregion
        #region 2.4.4: Transacciones de Dominio
        protected internal bool Deposito(clsDINERO pObjeto,clsCUENTA pCuentaDestino)
        {
            bool varResultado = false;
            if (this.Comprobardinero(pObjeto))
            {
                bool varNoEstaDepositadoDineroEnCuenta = !clsSERVIDOR_ASOCIACIONES.ExisteObjEnColeccionCon(pObjeto, this.atrColObjsDineros);
                if (varNoEstaDepositadoDineroEnCuenta)
                {
                    int VarNuevoOID = clsSERVIDOR_ASOCIACIONES.GenerarNuevoOID(this.atrColObjsTransacciones);
                    this.crudRegistrarTransaccion(pCuentaDestino,VarNuevoOID, "Hoy",pObjeto);
 
                    clsSERVIDOR_ASOCIACIONES.AsociarObjCon(pObjeto, this.atrColObjsDineros);
                    varResultado = true;
                }
            }
            this.Rectificar_Saldo();
            return varResultado;
        }
        protected internal clsDINERO Retirar(Type pTipo, int pDenominacion)
        {
            clsDINERO varObjDineroResultado = null;

            if (this.atrSaldo >= pDenominacion)
            {
                clsDINERO varObjDinero = this.ObtenerObjDineroCon(pTipo, pDenominacion);
                if (varObjDinero != null)
                {
                    int varNuevoOID = clsSERVIDOR_ASOCIACIONES.GenerarNuevoOID(this.atrColObjsTransacciones);
                    this.atrSaldo -= pDenominacion;
                    clsSERVIDOR_ASOCIACIONES.DisociarObjCon(varObjDinero, this.atrColObjsDineros);
                    //varObjDinero.SetCuenta(null);
                    varObjDineroResultado = varObjDinero;
                }
            }
            this.Rectificar_Saldo();
            return varObjDineroResultado;
        }
        protected internal void Transferencia(clsCUENTA pObjCuentaDestino, Type pTipo, int pDenominacion)
        {

            clsDINERO varObjDinero = this.Retirar(pTipo, pDenominacion);
            pObjCuentaDestino.Deposito(varObjDinero,pObjCuentaDestino);
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
        protected internal bool Comprobardinero(object pObjeto)
        {
            bool varResultado = false;
            bool varObjetoNoNulo = (pObjeto != null);
            int varPosicion = 0;
            if (varObjetoNoNulo)
            {
                bool varEsMoneda = (pObjeto.GetType() == typeof(clsMONEDA));
                bool varEsBillete = (pObjeto.GetType() == typeof(clsBILLETE));
                ArrayList varColDenominaciones = new ArrayList();
                if (varEsMoneda) { varColDenominaciones = this.atrColDenominacionesMonedas; }
                if (varEsBillete) { varColDenominaciones = this.atrColdenominacionsBilletes; }
                for (varPosicion = 0; varPosicion < varColDenominaciones.Count; varPosicion++)
                {
                    varResultado = varResultado ||
                    (((clsDINERO)pObjeto).GetDenominacion() == (int)varColDenominaciones[varPosicion]);
                }
            }
            return varResultado;
        }

        protected internal clsDINERO ObtenerObjDineroCon(Type pTipo, int pDenominacion)
        {
            clsDINERO varObjResultado = null;
            foreach (clsDINERO varObjDinero in this.atrColObjsDineros)
            {
                bool varCoincideTipo = (varObjDinero.GetType() == pTipo);
                bool varCoincideDenominacion = (varObjDinero.GetDenominacion() == pDenominacion);
                if (varCoincideDenominacion && varCoincideTipo)
                {
                    varObjResultado = varObjDinero;
                }
            }
            return varObjResultado;
        }
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
