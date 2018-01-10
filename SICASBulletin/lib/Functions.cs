using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SICASBulletin
{
    /// <summary>
    /// Contiene funciones para obtener datos directos de la base de datos
    /// </summary>
    public static class Functions
    {
        /// <summary>
        /// Obtiene el total de la flotilla
        /// </summary>
        /// <returns></returns>
        public static int Get_TotalFlotilla()
        {
            string sql = @"SELECT	COUNT(*) TotalFlotilla
FROM	Unidades
WHERE	EstatusUnidad_ID <> 5
AND		Empresa_ID IN (2,3,5,601)";

            return Convert.ToInt32(DB.QueryScalar(sql));

        } // end Get_TotalFlotilla

        /// <summary>
        /// Obtiene el total de unidades inactivas
        /// </summary>
        /// <returns></returns>
        public static int Get_TotalInactivas()
        {
            string sql = @"SELECT   COUNT(*) TotalInactivas
FROM	Unidades
WHERE	EstatusUnidad_ID = 6
AND		Empresa_ID IN (2,3,5,601)";

            return Convert.ToInt32(DB.QueryScalar(sql));

        } // end Get_TotalFlotilla

    } // end class

} // end namespace
