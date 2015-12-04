using System;

namespace Stma_BANCARIO_P.Capa_SERVICIOS
{
    static class clsGESTOR_RECURSOS
    {
        public static void LiberarRecursos(string pNombre)
        {
            switch (pNombre)
            {
                case "DotNet": GC.Collect();
                    break;
                case "NetBeans": //Liberar Recursos; 
                    break;
            }

        }
    }
}