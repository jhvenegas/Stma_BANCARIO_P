using System;
using System.Collections;
using Stma_BANCARIO_P.Capa_DOMINIO;
using Stma_BANCARIO_P.Capa_SERVICIOS;

namespace Stma_BANCARIO_P.Capa_COORDINACION
{
     class clsCONTROLADOR
    {
        #region 1.Atributos
        #region 1.1: Propios y Derivables

        #endregion
        #region 1.2 Asociativos
        private  clsTESORO atrObjTesoro = new clsTESORO();
        private  ArrayList atrColObjsPersonas = new ArrayList();
        private  ArrayList atrColObjsBancos = new ArrayList();
        private static clsCONTROLADOR atrInstancia = null;
        #endregion
        #region 1.3 Puente
        #endregion
        #region 1.4 Estado
        #endregion
        #endregion
        #region 2: Métodos
        #region 2.1: Constructor, Clonador, Comparador, Inicializador, Modificador y Destructor
        public static clsCONTROLADOR ObtenerInstancia()
        {
            if (atrInstancia == null)
            {
                atrInstancia = new clsCONTROLADOR();
            }
            return atrInstancia;
        }
        public clsCONTROLADOR(){}
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
        public void SetObjTesoro(clsTESORO pObjeto)
        {
            this.atrObjTesoro = pObjeto;
        }
        #endregion
        #endregion
        #region 2.4: Servicios CRUD
        #region 2.4.1: Registradores
        public void crudRegistrarObjBanco(int pOID, string pNombre, string pNIT)
        {
            clsSERVIDOR_CRUD_BANCO varInstanciaServidorCrud = clsSERVIDOR_CRUD_BANCO.ObtenerInstancia();
            varInstanciaServidorCrud.crudRegistrarObj(atrColObjsBancos, pOID, pNombre, pNIT);
        }
        public void crudRegistrarObjPersona(int pOID, string pNombre, string pApellido)
        {
            clsSERVIDOR_CRUD_PERSONA varInstanciaServidorCrud = clsSERVIDOR_CRUD_PERSONA.ObtenerInstancia();
            varInstanciaServidorCrud.crudRegistrarObj(atrColObjsPersonas, pOID, pNombre, pApellido);
        }
        public void crudRegistrarObjMoneda(int pOID, string pValorEnLetras, int pDenominacion, int pAño)
        {
            clsSERVIDOR_CRUD_MONEDA varInstanciaServidorCrud = clsSERVIDOR_CRUD_MONEDA.ObtenerInstancia();
            ArrayList varColDinero= this.atrObjTesoro.GetColDinero();
            varInstanciaServidorCrud.crudRegistrarObj(varColDinero, pOID, pValorEnLetras,pDenominacion,pAño,atrObjTesoro);
        }

        public void crudRegistrarObjBillete(int pOID, string pValorEnLetras, int pDenominacion, int pAño,int pMes, int pDia)
        {
            clsSERVIDOR_CRUD_BILLETE varInstanciaServidorCrud = clsSERVIDOR_CRUD_BILLETE.ObtenerInstancia();
            ArrayList varColDinero = this.atrObjTesoro.GetColDinero();
            varInstanciaServidorCrud.crudRegistrarObj(varColDinero, pOID, pValorEnLetras, pDenominacion, pAño,pMes,pDia,atrObjTesoro);
            this.atrObjTesoro.Rectificar_Saldo();
        }
        public void crudRegistrarObjAhorrador(int pOIDBanco, int pOIDPersona, int pOID, string pFechaInicio)
        {
            clsSERVIDOR_CRUD_AHORRADOR varInstanciaServidorCrud = clsSERVIDOR_CRUD_AHORRADOR.ObtenerInstancia();
            clsBANCO varBanco = (clsBANCO)clsSERVIDOR_ASOCIACIONES.ObtenerObjCon(pOIDBanco, this.atrColObjsBancos);
            clsPERSONA varPersona = (clsPERSONA)clsSERVIDOR_ASOCIACIONES.ObtenerObjCon(pOIDPersona, this.atrColObjsPersonas);
            ArrayList varAhorradoresPersona = varPersona.GetObjsAhorradores();
            ArrayList varAhorradoresBanco = varBanco.GetObjsAhorradores(); 
            varInstanciaServidorCrud.crudRegistrarObj(varBanco, varPersona, varAhorradoresPersona,varAhorradoresBanco, pOID, pFechaInicio);
        }
        public void crudRegistrarObjAlcancia(int pOIDBanco, int pOIDAhorrador, int pOID, string pNombre)
        {
            clsSERVIDOR_CRUD_ALCANCIA varInstanciaServidorCrud = clsSERVIDOR_CRUD_ALCANCIA.ObtenerInstancia();
            clsBANCO varBanco = (clsBANCO)clsSERVIDOR_ASOCIACIONES.ObtenerObjCon(pOIDBanco, this.atrColObjsBancos);
            clsAHORRADOR varAhorrador = (clsAHORRADOR)clsSERVIDOR_ASOCIACIONES.ObtenerObjCon(pOIDAhorrador, varBanco.GetObjsAhorradores());
            varInstanciaServidorCrud.crudRegistrarObj(varAhorrador,varBanco,varBanco.GetObjsAlcancias(),varAhorrador.GetObjsAlcancias(), pOID, pNombre);
        }
        #endregion
        #region 2.4.2: Actualizadores
        
        public void crudActualizarObjAhorrador(int pOIDBANCO,int pOIDPersona, int pOID, string pNombre, string pFechaInicio)
        {
            clsBANCO varBanco =(clsBANCO) clsSERVIDOR_ASOCIACIONES.ObtenerObjCon(pOIDBANCO, this.atrColObjsBancos);
            clsPERSONA varPersona =(clsPERSONA) clsSERVIDOR_ASOCIACIONES.ObtenerObjCon(pOIDPersona, this.atrColObjsPersonas);
            clsSERVIDOR_CRUD_AHORRADOR varInstanciaServidorCrud = clsSERVIDOR_CRUD_AHORRADOR.ObtenerInstancia();
            varInstanciaServidorCrud.crudActualizarObj(varBanco.GetObjsAhorradores(), varPersona.GetObjsAhorradores(), pOID, pNombre, pFechaInicio);
        }
        public void crudActualizarObjAlcancia(int pOIDBANCO, int pOIDPersona,int pOIDAhorrador, int pOID, string pNombre)
        {
            clsBANCO varBancos = (clsBANCO)clsSERVIDOR_ASOCIACIONES.ObtenerObjCon(pOIDBANCO, this.atrColObjsBancos);
            clsPERSONA varPersona = (clsPERSONA)clsSERVIDOR_ASOCIACIONES.ObtenerObjCon(pOIDPersona, this.atrColObjsPersonas);
            clsAHORRADOR varAhorrador=(clsAHORRADOR)clsSERVIDOR_ASOCIACIONES.ObtenerObjCon(pOIDAhorrador,varPersona.GetObjsAhorradores());
            clsSERVIDOR_CRUD_ALCANCIA varInstanciaServidorCrud = clsSERVIDOR_CRUD_ALCANCIA.ObtenerInstancia();
            varInstanciaServidorCrud.crudActualizarObj(varBancos.GetObjsAlcancias(), varAhorrador.GetObjsAlcancias(), pOID, pNombre);      
         }
         public void crudActualizarObjBanco(int pOID, string pNombre, string pNIT)
        {
            clsSERVIDOR_CRUD_BANCO varInstanciaServidorCrud = clsSERVIDOR_CRUD_BANCO.ObtenerInstancia();
            varInstanciaServidorCrud.crudActualizarObj(atrColObjsBancos, pOID, pNombre, pNIT);
        }

         public void crudActualizarObjPersona(int pOID, string pNombre, string pApellido) 
         {
             clsSERVIDOR_CRUD_PERSONA varInstanciaServidorCrud = clsSERVIDOR_CRUD_PERSONA.ObtenerInstancia();
             varInstanciaServidorCrud.crudActualizarObj(atrColObjsPersonas, pOID, pNombre, pApellido);
         }
        #endregion
        #region 2.4.3: Eliminadores
        public void crudEliminarObjBanco(int pOID, ref clsTESORO atrObjTesoro)
         {
             clsSERVIDOR_CRUD_BANCO varInstanciaServidorCrud = clsSERVIDOR_CRUD_BANCO.ObtenerInstancia();
             varInstanciaServidorCrud.crudEliminarObj(this.atrColObjsBancos, pOID, ref atrObjTesoro);
         }
        public void crudEliminarObjPersona(int pOID)
         {
             clsSERVIDOR_CRUD_PERSONA varInstanciaServidorCrud = clsSERVIDOR_CRUD_PERSONA.ObtenerInstancia();
             varInstanciaServidorCrud.crudEliminarObj(this.atrColObjsPersonas, pOID);
         }
        #endregion
        #region 2.4.4: Transacciones de Dominio
        public void TransferenciaTesoroBoveda(int pOIDBancoDestino,Type pTipo, int pDenominacion)
        {
            clsBANCO varBanco = (clsBANCO)clsSERVIDOR_ASOCIACIONES.ObtenerObjCon(pOIDBancoDestino, this.atrColObjsBancos);
            clsCUENTA varBoveda=varBanco.GetObjBoveda();
            this.atrObjTesoro.Transferencia(varBoveda,pTipo, pDenominacion);
        }
        public void TransferenciaBovedaTesoro(int pOIDBancoOrigen, Type pTipo, int pDenominacion)
        {
            clsBANCO varBanco = (clsBANCO)clsSERVIDOR_ASOCIACIONES.ObtenerObjCon(pOIDBancoOrigen, this.atrColObjsBancos);
            varBanco.GetObjBoveda().Transferencia(this.atrObjTesoro, pTipo, pDenominacion);
        }
        public void TransferenciaBovedaAlcanciaMismoBanco(int pOIDBanco, int pOIDAlcanciaDestino, Type pTipo, int pDenominacion)
        {
            clsBANCO varBanco = (clsBANCO)clsSERVIDOR_ASOCIACIONES.ObtenerObjCon(pOIDBanco, this.atrColObjsBancos);
            clsALCANCIA varAlcancia = varBanco.GetObjAlcancia(pOIDAlcanciaDestino);
            varBanco.GetObjBoveda().Transferencia(varAlcancia, pTipo, pDenominacion);
        }
        public void TransferenciaTesoroBilletera(int pOIDPersona, Type pTipo, int pDenominacion)
        {
            clsPERSONA varPersona = (clsPERSONA)clsSERVIDOR_ASOCIACIONES.ObtenerObjCon(pOIDPersona, this.atrColObjsPersonas);
            this.atrObjTesoro.Transferencia(varPersona.GetObjBilletera(), pTipo, pDenominacion);
        }
        public void TransferenciaEntreAlcanciasMismosBancos(int pOIDBanco, int pOIDAlcanciaOrigen, int pOIDAlcanciaDestino, Type pTipo, int pDenominacion)
        {
            clsBANCO varObjetoBanco = (clsBANCO)clsSERVIDOR_ASOCIACIONES.ObtenerObjCon(pOIDBanco, this.atrColObjsBancos);
            clsALCANCIA varObjetoAlcanciaOrigen = (clsALCANCIA)clsSERVIDOR_ASOCIACIONES.ObtenerObjCon(pOIDAlcanciaOrigen, varObjetoBanco.GetObjsAlcancias());
            clsALCANCIA varObjetoAlcanciaDestino = (clsALCANCIA)clsSERVIDOR_ASOCIACIONES.ObtenerObjCon(pOIDAlcanciaDestino, varObjetoBanco.GetObjsAlcancias());
            varObjetoAlcanciaOrigen.Transferencia(varObjetoAlcanciaDestino, pTipo, pDenominacion);

        }
        public void TransferenciaEntreAlcanciasDistintosBancos(int pOIDBancoOrigen, int pOIDBancoDestino, int pOIDAlcanciaOrigen, int pOIDAlcanciaDestino, Type pTipo, int pDenominacion)
        {
            clsBANCO varObjetoBancoOrigen = (clsBANCO)clsSERVIDOR_ASOCIACIONES.ObtenerObjCon(pOIDBancoOrigen, this.atrColObjsBancos);
            clsBANCO varObjetoBancoDestino = (clsBANCO)clsSERVIDOR_ASOCIACIONES.ObtenerObjCon(pOIDBancoDestino, this.atrColObjsBancos);
            clsALCANCIA varObjetoAlcanciaOrigen = (clsALCANCIA)clsSERVIDOR_ASOCIACIONES.ObtenerObjCon(pOIDAlcanciaOrigen, varObjetoBancoOrigen.GetObjsAlcancias());
            clsALCANCIA varObjetoAlcanciaDestino = (clsALCANCIA)clsSERVIDOR_ASOCIACIONES.ObtenerObjCon(pOIDAlcanciaDestino, varObjetoBancoDestino.GetObjsAlcancias());
            varObjetoAlcanciaOrigen.Transferencia(varObjetoAlcanciaDestino, pTipo, pDenominacion);
        }
        public void TransferenciaEntreBilleteras(int pOIDPersonaOrigen, int pOIDPersonaDestino, Type pTipo, int pDenominacion)
        {
            clsPERSONA varObjetoPersonaOrigen = (clsPERSONA)clsSERVIDOR_ASOCIACIONES.ObtenerObjCon(pOIDPersonaOrigen, this.atrColObjsPersonas);
            clsPERSONA varObjetoPersonaDestino = (clsPERSONA)clsSERVIDOR_ASOCIACIONES.ObtenerObjCon(pOIDPersonaDestino, this.atrColObjsPersonas);
            clsBILLETERA varBilleteraOrigen = varObjetoPersonaOrigen.GetObjBilletera();
            clsBILLETERA varBilleteraDestino = varObjetoPersonaDestino.GetObjBilletera();
            varBilleteraOrigen.Transferencia(varBilleteraDestino, pTipo, pDenominacion);
        }
        public void TransferenciaBilleteraTesoro(int pOIDPersonaOrigen, Type pTipo, int pDenominacion)
        {
            clsPERSONA varObjetoPersonaOrigen = (clsPERSONA)clsSERVIDOR_ASOCIACIONES.ObtenerObjCon(pOIDPersonaOrigen, this.atrColObjsPersonas);
            clsBILLETERA varObjetoBilletera = varObjetoPersonaOrigen.GetObjBilletera();
            varObjetoBilletera.Transferencia(this.atrObjTesoro, pTipo, pDenominacion);
        }
        public void TransferenciaAlcanciaBovedaMismoBanco(int pOIDBanco, int pOIDAlcanciaOrigen, Type pTipo, int pDenominacion)
        {
            clsBANCO varObjetoBanco = (clsBANCO)clsSERVIDOR_ASOCIACIONES.ObtenerObjCon(pOIDBanco, this.atrColObjsBancos);
            varObjetoBanco.GetObjAlcancia(pOIDAlcanciaOrigen).Transferencia(varObjetoBanco.GetObjBoveda(), pTipo, pDenominacion);
        }
        public void TransferenciaBovedaAlcanciaDistintoBanco(int pOIDBancoOrigen, int pOIDBancoDestino, Type pTipo, int pDenominacion)
        {
            clsBANCO varObjetoBancoOrigen = (clsBANCO)clsSERVIDOR_ASOCIACIONES.ObtenerObjCon(pOIDBancoOrigen, this.atrColObjsBancos);
            clsBANCO varObjetoBancoDestino = (clsBANCO)clsSERVIDOR_ASOCIACIONES.ObtenerObjCon(pOIDBancoDestino, this.atrColObjsBancos);
            varObjetoBancoOrigen.GetObjBoveda().Transferencia(varObjetoBancoDestino.GetObjBoveda(), pTipo, pDenominacion);
        }
        public void TransferenciaBovedaAlcanciaDistintoBanco(int pOIDBancoOrigen, int pOIDBancoDestino, int pOIDAlcanciaDestino, Type pTipo, int pDenominacion)
        {
            clsBANCO varObjetoBancoOrigen = (clsBANCO)clsSERVIDOR_ASOCIACIONES.ObtenerObjCon(pOIDBancoOrigen, this.atrColObjsBancos);
            clsBANCO varObjetoBancoDestino = (clsBANCO)clsSERVIDOR_ASOCIACIONES.ObtenerObjCon(pOIDBancoDestino, this.atrColObjsBancos);
            varObjetoBancoOrigen.GetObjBoveda().Transferencia(varObjetoBancoDestino.GetObjAlcancia(pOIDAlcanciaDestino), pTipo, pDenominacion);
        }
        public void TransferenciaAlcanciaBovedaDistintoBanco(int pOIDBancoOrigen, int pOIDBancoDestino, int pOIDAlcanciaOrigen, Type pTipo, int pDenominacion)
        {
            clsBANCO varObjetoBancoOrigen = (clsBANCO)clsSERVIDOR_ASOCIACIONES.ObtenerObjCon(pOIDBancoOrigen, this.atrColObjsBancos);
            clsBANCO varObjetoBancoDestino = (clsBANCO)clsSERVIDOR_ASOCIACIONES.ObtenerObjCon(pOIDBancoDestino, this.atrColObjsBancos);
            varObjetoBancoOrigen.GetObjAlcancia(pOIDAlcanciaOrigen).Transferencia(varObjetoBancoDestino.GetObjBoveda(), pTipo, pDenominacion);
        }
        public void TransferenciaTesoroAlcancia(int pOIDBanco, int pOIDAlcanciaDestino, Type pTipo, int pDenominacion)
        {
            clsBANCO varObjetoBanco = (clsBANCO)clsSERVIDOR_ASOCIACIONES.ObtenerObjCon(pOIDBanco, this.atrColObjsBancos);
            this.atrObjTesoro.Transferencia(varObjetoBanco.GetObjAlcancia(pOIDAlcanciaDestino), pTipo, pDenominacion);
        }
        public void TransferenciaAlcanciaTesoro(int pOIDBanco, int pOIDAlcanciaOrigen, Type pTipo, int pDenominacion)
        {
            clsBANCO varObjetoBanco = (clsBANCO)clsSERVIDOR_ASOCIACIONES.ObtenerObjCon(pOIDBanco, this.atrColObjsBancos);
            varObjetoBanco.GetObjAlcancia(pOIDAlcanciaOrigen).Transferencia(this.atrObjTesoro, pTipo, pDenominacion);
        }
        public void TransferenciaBovedaBilletera(int pOIDBanco, int pOIDPersona, Type pTipo, int pDenominacion)
        {
            clsBANCO varObjetoBancoOrigen = (clsBANCO)clsSERVIDOR_ASOCIACIONES.ObtenerObjCon(pOIDBanco, this.atrColObjsBancos);
            clsPERSONA varObjetoPersonaDestino = (clsPERSONA)clsSERVIDOR_ASOCIACIONES.ObtenerObjCon(pOIDPersona, this.atrColObjsPersonas);
            varObjetoBancoOrigen.GetObjBoveda().Transferencia(varObjetoPersonaDestino.GetObjBilletera(), pTipo, pDenominacion);
        }
        public void TransferenciaBilleteraBoveda(int pOIDBanco, int pOIDPersona, Type pTipo, int pDenominacion)
        {
            clsBANCO varObjetoBancoDestino = (clsBANCO)clsSERVIDOR_ASOCIACIONES.ObtenerObjCon(pOIDBanco, this.atrColObjsBancos);
            clsPERSONA varObjetoPersonaOrigen = (clsPERSONA)clsSERVIDOR_ASOCIACIONES.ObtenerObjCon(pOIDPersona, this.atrColObjsPersonas);
            varObjetoPersonaOrigen.GetObjBilletera().Transferencia(varObjetoBancoDestino.GetObjBoveda(), pTipo, pDenominacion);
        }
        public void TransferenciaAlcanciaBilletera(int pOIDBanco, int pOIDPersona, int pOIDAlcanciaOrigen, Type pTipo, int pDenominacion)
        {
            clsBANCO varObjetoBancoOrigen = (clsBANCO)clsSERVIDOR_ASOCIACIONES.ObtenerObjCon(pOIDBanco, this.atrColObjsBancos);
            clsPERSONA varObjetoPersonaDestino = (clsPERSONA)clsSERVIDOR_ASOCIACIONES.ObtenerObjCon(pOIDPersona, this.atrColObjsPersonas);
            varObjetoBancoOrigen.GetObjAlcancia(pOIDAlcanciaOrigen).Transferencia(varObjetoPersonaDestino.GetObjBilletera(), pTipo, pDenominacion);
        }
        public void TransferenciaBilleteraAlcancia(int pOIDBanco, int pOIDPersona, int pOIDAlcanciaDestino, Type pTipo, int pDenominacion)
        {
            clsBANCO varObjetoBancoDestino = (clsBANCO)clsSERVIDOR_ASOCIACIONES.ObtenerObjCon(pOIDBanco, this.atrColObjsBancos);
            clsPERSONA varObjetoPersonaOrigen = (clsPERSONA)clsSERVIDOR_ASOCIACIONES.ObtenerObjCon(pOIDPersona, this.atrColObjsPersonas);
            varObjetoPersonaOrigen.GetObjBilletera().Transferencia(varObjetoBancoDestino.GetObjAlcancia(pOIDAlcanciaDestino), pTipo, pDenominacion);
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
