using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SICASBulletin
{
    class Program
    {
        static void Main(string[] args)
        {
            Bulletin bulletin = new Bulletin();
            //bulletin.ReporteConcentradoFlotilla();
            bulletin.ReporteKilometrajesMantenimientos_Diario();

        } // end Main

    } // end class Program

} // end namespace SICASBulletin
