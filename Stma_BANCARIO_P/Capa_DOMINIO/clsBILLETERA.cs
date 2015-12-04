using System;
using System.Collections.Generic;

namespace Stma_BANCARIO_P.Capa_DOMINIO
{
    class clsBILLETERA : clsCUENTA
    {
        #region 1.Atributos
        #region 1.1: Propios y Derivables

        #endregion
        #region 1.2 Asociativos
        private clsPERSONA atrObjPersona = null;
        #endregion
        #region 1.3 Puente
        #endregion
        #region 1.4 Estado
        #endregion
        #endregion
        #region 2: Métodos
        #region 2.1: Constructor, Clonador, Comparador, Inicializador, Modificador y Destructor
         public clsBILLETERA()
        {
        }
        public clsBILLETERA(clsPERSONA pObjPersona)
            : base(1, "Billetera")
        {
            this.atrObjPersona = pObjPersona;
            pObjPersona.SetObjBilletera(this);
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
