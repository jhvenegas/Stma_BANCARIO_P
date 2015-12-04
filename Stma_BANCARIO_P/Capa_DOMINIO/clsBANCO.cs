using System;
using System.Collections;
using Stma_BANCARIO_P.Capa_SERVICIOS;

namespace Stma_BANCARIO_P.Capa_DOMINIO
{
    class clsBANCO : clsOBJETO
    {
        #region 1.Atributos
        #region 1.1: Propios y Derivables
        private string atrNIT = null;
        #endregion
        #region 1.2 Asociativos
        private ArrayList atrColObjsAhorradores = new ArrayList();
        private ArrayList atrColObjsAlcancias = new ArrayList();
        private clsBOVEDA atrObjBoveda;
        #endregion
        #region 1.3 Puente
        #endregion
        #region 1.4 Estado
        #endregion
        #endregion
        #region 2: Métodos
        #region 2.1: Constructor, Clonador, Comparador, Inicializador, Modificador y Destructor
        public clsBANCO(int pOID, string pNombre, string pNIT): base(pOID, pNombre)
        {
            this.crudRegistrarObjBoveda();
            this.atrNIT = pNIT;
        }
       
        public void Modificar(string pNombre, string pNIT)
        {
            base.Modificar(pNombre);
            this.SetObjNIT(pNIT);
        } 
        public void Destruir(ref clsCUENTA pTesoroLiquidacion)
        {
            //TODO Eliminar La Boveda
            
            //TODO Eliminar Las Alcancias
            this.crudEliminarTodosObjsAlcancias();
            //TODO Disociarse de los Ahorradores
            this.DisociarTodosAhorradores();
            this.crudEliminarObjBoveda(ref pTesoroLiquidacion);
        }
        #endregion
        #region 2.2: Accesores
        #region 2.2.1: Accesores De Atributo Propio y Derivable
        #endregion
        #region 2.2.2: Accesores De Atributo Asociativo
        public clsBOVEDA GetObjBoveda()
        {
            return this.atrObjBoveda;
        }
        public ArrayList GetObjsAlcancias()
        {
            return this.atrColObjsAlcancias;
        }
        public clsALCANCIA GetObjAlcancia(int pOID)
        {
            clsALCANCIA varObjeto = (clsALCANCIA)clsSERVIDOR_ASOCIACIONES.ObtenerObjCon(pOID, this.atrColObjsAlcancias);
            return varObjeto;
        }
        public ArrayList GetObjsAhorradores()
        {
            return this.atrColObjsAhorradores;
        }
        #endregion
        #endregion
        #region 2.3: Mutadores
        #region 2.3.1: Mutadores De Atributo Propio y Derivable
        private void SetObjNIT(string pNit)
        {
            this.atrNIT = pNit;
        }
        #endregion
        #region 2.3.2: Mutadores Asociativos y Disociativos
        public void SetObjBoveda(clsBOVEDA pObjeto)
        {
            this.atrObjBoveda = pObjeto;
        }
        private void DisociarTodosAhorradores()
        {
            for (int varPosicion = 0; varPosicion < this.atrColObjsAhorradores.Count; varPosicion++)
            {
                clsAHORRADOR varObjAhorrador = (clsAHORRADOR)this.atrColObjsAhorradores[varPosicion];
                varObjAhorrador.DisociarRelaciones();
                varObjAhorrador.SetObjBanco(null);
                varObjAhorrador.SetObjPersona(null);
            }
        }
        #endregion
        #endregion
        #region 2.4: Servicios CRUD
        #region 2.4.1: Registradores
        public void crudRegistrarObjBoveda()
        {
            clsSERVIDOR_CRUD_BOVEDA varInstanciaServidorCrud = clsSERVIDOR_CRUD_BOVEDA.ObtenerInstancia();
            varInstanciaServidorCrud.crudRegistrarObj(this, this.atrObjBoveda);
            //TODO Utilizar estrategia de Servidores CRUD para registrar Boveda
        }
        #endregion
        #region 2.4.2: Actualizadores
        #endregion
        #region 2.4.3: Eliminadores

        public void crudEliminarObjBoveda(ref clsCUENTA pTesoroLiquidacion)
        {
            clsSERVIDOR_CRUD_BOVEDA varInstanciaServidorCrud = clsSERVIDOR_CRUD_BOVEDA.ObtenerInstancia();
            varInstanciaServidorCrud.crudEliminarObj(this.atrObjBoveda, ref pTesoroLiquidacion);
        }
        public void crudEliminarTodosObjsAlcancias()
        {
            clsSERVIDOR_CRUD_ALCANCIA varInstanciaServidorCrud = clsSERVIDOR_CRUD_ALCANCIA.ObtenerInstancia();
            varInstanciaServidorCrud.crudEliminarTodosObjs(this.atrColObjsAlcancias);
        }
        public void crudEliminarUnaObjAlcancia(int pOIDAlcancia)
        {
            clsSERVIDOR_CRUD_ALCANCIA varInstanciaServidorCrud = clsSERVIDOR_CRUD_ALCANCIA.ObtenerInstancia();
            varInstanciaServidorCrud.crudEliminarObj(this.atrColObjsAlcancias, pOIDAlcancia);
        }
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
