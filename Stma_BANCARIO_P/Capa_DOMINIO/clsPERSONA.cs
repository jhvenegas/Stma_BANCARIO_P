using System;
using System.Collections;
using Stma_BANCARIO_P.Capa_SERVICIOS;

namespace Stma_BANCARIO_P.Capa_DOMINIO
{
    class clsPERSONA : clsOBJETO
    {
        #region 1.Atributos
        #region 1.1: Propios y Derivables
        private string atrApellidos = null;
        #endregion
        #region 1.2 Asociativos
        private ArrayList atrColObjsAhorradores = new ArrayList();
        private clsBILLETERA atrObjBilletera = null;
        #endregion
        #region 1.3 Puente
        #endregion
        #region 1.4 Estado
        #endregion
        #endregion
        #region 2: Métodos
        #region 2.1: Constructor, Clonador, Comparador, Inicializador, Modificador y Destructor
        public clsPERSONA() { }
        public clsPERSONA(int pOID, string pNombre, string pApellido): base (pOID,pNombre)
        {
            this.crudRegistrarObjBilletera();
            this.atrApellidos = pApellido;
        }
        public void Modificar(string pNombre, string pApellido) 
        {
            base.Modificar(pNombre);
            this.SetApellido(pApellido);
        }
        public void Destruir()
        {
            //TODO Eliminar la Billetera
            this.crudEliminarObjBilletera();
            //TODO Eliminar los Ahorradores
            this.crudEliminarTodosObjsAhorradores();
        }
        #endregion
        #region 2.2: Accesores
        #region 2.2.1: Accesores De Atributo Propio y Derivable
        #endregion
        #region 2.2.2: Accesores De Atributo Asociativo
        public ArrayList GetObjsAhorradores()
        {
            return this.atrColObjsAhorradores;
        }
        public clsBILLETERA GetObjBilletera()
        {
            return this.atrObjBilletera;
        }
        #endregion
        #endregion
        #region 2.3: Mutadores
        #region 2.3.1: Mutadores De Atributo Propio y Derivable
        private void SetApellido(string pApellido) 
        {
            this.atrApellidos = pApellido;
        }
        #endregion
        #region 2.3.2: Mutadores Asociativos y Disociativos
        public void SetObjBilletera(clsBILLETERA pObjeto)
        {
            this.atrObjBilletera = pObjeto;
        }
        #endregion
        #endregion
        #region 2.4: Servicios CRUD
        #region 2.4.1: Registradores
        public void crudRegistrarObjBilletera()
        {
            clsSERVIDOR_CRUD_BILLETERA varInstanciaServidorCrud = clsSERVIDOR_CRUD_BILLETERA.ObtenerInstancia();
            varInstanciaServidorCrud.crudRegistrarObj(this, this.atrObjBilletera);
        }
        #endregion
        #region 2.4.2: Actualizadores

        #endregion
        #region 2.4.3: Eliminadores
        public void crudEliminarObjBilletera()
        {
            clsSERVIDOR_CRUD_BILLETERA varInstanciaServidorCrud = clsSERVIDOR_CRUD_BILLETERA.ObtenerInstancia();
            varInstanciaServidorCrud.crudEliminarObj(this.atrObjBilletera);
        }
        public void crudEliminarTodosObjsAhorradores()
        {
            clsSERVIDOR_CRUD_AHORRADOR varInstanciaServidorCrud = clsSERVIDOR_CRUD_AHORRADOR.ObtenerInstancia();
            varInstanciaServidorCrud.crudEliminarTodosObjs(this.atrColObjsAhorradores);
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
