using System;
using System.Windows.Forms;
using Stma_BANCARIO_P.Capa_COORDINACION;
using Stma_BANCARIO_P.Capa_DOMINIO;
using Stma_BANCARIO_P.Capa_SERVICIOS;

namespace Stma_BANCARIO_P
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //NO HAGAN NINGUNA MODIFICACION HASTA QUE ME DESPIERTE MAS RATO 2:29 AM
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            #region Creación Instancia de Controlador
            clsCONTROLADOR varInstanciaControlador = clsCONTROLADOR.ObtenerInstancia();
            #endregion
            #region Registro de Objetos
            #region Registro de Personas
            varInstanciaControlador.crudRegistrarObjPersona(1, "Pepito", "Pérez");
            varInstanciaControlador.crudRegistrarObjPersona(2, "Menganito", "Martínez");
            varInstanciaControlador.crudRegistrarObjPersona(3, "Fulanito", "Pabón");
            #endregion
            #region Registro de Bancos
            varInstanciaControlador.crudRegistrarObjBanco(496, "Banco de Bogotá", "n5A2");
            varInstanciaControlador.crudRegistrarObjBanco(974, "Banco Davivienda","DDD");
            varInstanciaControlador.crudRegistrarObjBanco(567, "BanColombia","LS58A");
            #endregion
            #region Registro de Dinero
            varInstanciaControlador.crudRegistrarObjMoneda(1, "Veinte Pesos", 20, 1991);
            varInstanciaControlador.crudRegistrarObjMoneda(2, "Cincuenta Pesos", 50, 1994);
            varInstanciaControlador.crudRegistrarObjMoneda(3, "Cien Pesos", 100, 1990);
            varInstanciaControlador.crudRegistrarObjMoneda(4, "Doscientos Pesos", 200, 1995);
            varInstanciaControlador.crudRegistrarObjMoneda(5, "Quinientos Pesos", 500, 1998);
            varInstanciaControlador.crudRegistrarObjMoneda(6, "Mil Pesos", 1000, 2000);

            varInstanciaControlador.crudRegistrarObjBillete(7, "Mil Pesos", 1000, 1998, 12, 13);
            varInstanciaControlador.crudRegistrarObjBillete(8, "Dos Mil Pesos", 2000, 1999, 11, 13);
            varInstanciaControlador.crudRegistrarObjBillete(9, "Cinco Mil Pesos", 5000, 2005, 03, 04);
            varInstanciaControlador.crudRegistrarObjBillete(10, "Diez Mil Pesos", 10000, 1997, 24, 06);
            varInstanciaControlador.crudRegistrarObjBillete(11, "Veinte Mil Pesos", 20000, 2006, 23, 07);
            varInstanciaControlador.crudRegistrarObjBillete(12, "Cincuenta Mil Pesos", 50000, 2006, 23, 07);
            #endregion
            #region Registro de Ahorradores

            varInstanciaControlador.crudRegistrarObjAhorrador(496, 1, 1, "25-11-2015");
            varInstanciaControlador.crudRegistrarObjAhorrador(974, 1, 1, "25-11-2015");
            varInstanciaControlador.crudRegistrarObjAhorrador(567, 1, 1, "25-11-2015");
            varInstanciaControlador.crudRegistrarObjAhorrador(974, 2, 2, "25-11-2015");
            varInstanciaControlador.crudRegistrarObjAhorrador(567, 2, 2, "25-11-2015");
            varInstanciaControlador.crudRegistrarObjAhorrador(567, 3, 3, "25-11-2015");
            #endregion
            #region Registro de Alcancías
            varInstanciaControlador.crudRegistrarObjAlcancia(496, 1, 1, "Mis Ahorritos");
            varInstanciaControlador.crudRegistrarObjAlcancia(496, 1, 2, "Mis Dineritos");
            varInstanciaControlador.crudRegistrarObjAlcancia(496, 1, 3, "Mis Guardados");
            varInstanciaControlador.crudRegistrarObjAlcancia(974, 1, 1, "Mis Reservas");
            varInstanciaControlador.crudRegistrarObjAlcancia(974, 2, 2, "Mis Dineritos Ahorrados");
            varInstanciaControlador.crudRegistrarObjAlcancia(567, 3, 1, "Mi Guaca");
            #endregion
            #region Registro de Actualizar
            varInstanciaControlador.crudActualizarObjAhorrador(496, 1, 1, "22-11-2015");
            varInstanciaControlador.crudActualizarObjAlcancia(567, 3, 1, "Mio :D");
            varInstanciaControlador.crudActualizarObjBanco(974, "Banco Pichincha", ".w.");
            varInstanciaControlador.crudActualizarObjBillete(7, "Mil Pesos", 1000, 1999, 12, 17);
            varInstanciaControlador.crudActualizarObjMoneda(2, "Cincuenta Pesos", 50, 1995);
            varInstanciaControlador.crudActualizarObjPersona(1, "Pepito", "Puto");
            #endregion
            #region Transferencias

            varInstanciaControlador.TransferenciaTesoroBoveda(496, typeof(clsMONEDA), 20);
            varInstanciaControlador.TransferenciaTesoroBoveda(496, typeof(clsMONEDA), 50);
            varInstanciaControlador.TransferenciaTesoroBoveda(496, typeof(clsBILLETE), 1000);
            varInstanciaControlador.TransferenciaTesoroBoveda(496, typeof(clsBILLETE), 2000);

            varInstanciaControlador.TransferenciaTesoroBoveda(974, typeof(clsMONEDA), 100);
            varInstanciaControlador.TransferenciaTesoroBoveda(974, typeof(clsMONEDA), 200);
            varInstanciaControlador.TransferenciaTesoroBoveda(974, typeof(clsBILLETE), 5000);
            varInstanciaControlador.TransferenciaTesoroBoveda(974, typeof(clsBILLETE), 10000);

            varInstanciaControlador.TransferenciaTesoroBoveda(567, typeof(clsMONEDA), 500);
            varInstanciaControlador.TransferenciaTesoroBoveda(567, typeof(clsMONEDA), 1000);
            varInstanciaControlador.TransferenciaTesoroBoveda(567, typeof(clsBILLETE), 20000);
            varInstanciaControlador.TransferenciaTesoroBoveda(567, typeof(clsBILLETE), 50000);

            varInstanciaControlador.TransferenciaBovedaTesoro(496, typeof(clsMONEDA), 20);
            varInstanciaControlador.TransferenciaBovedaTesoro(974, typeof(clsMONEDA), 100);
            varInstanciaControlador.TransferenciaBovedaTesoro(567, typeof(clsMONEDA), 500);

         //   varInstanciaControlador.TransferenciaBovedaAlcanciaMismoBanco(496, 1, typeof(clsMONEDA), 50);
         //   varInstanciaControlador.TransferenciaBovedaAlcanciaMismoBanco(496, 2, typeof(clsBILLETE), 1000);
            varInstanciaControlador.TransferenciaBovedaAlcanciaMismoBanco(974, 1, typeof(clsMONEDA), 200);
            varInstanciaControlador.TransferenciaBovedaAlcanciaMismoBanco(567, 1, typeof(clsMONEDA), 1000);

            varInstanciaControlador.TransferenciaTesoroBilletera(1, typeof(clsMONEDA), 20);
            varInstanciaControlador.TransferenciaTesoroBilletera(2, typeof(clsMONEDA), 100);
            varInstanciaControlador.TransferenciaTesoroBilletera(3, typeof(clsMONEDA), 500);
            #endregion
            #endregion 
            #region Eliminación
            varInstanciaControlador.crudEliminarObjBanco(496);
            #endregion
        }
    }
}
