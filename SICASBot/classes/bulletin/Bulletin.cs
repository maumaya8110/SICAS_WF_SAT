using System;
using System.Collections.Generic;
using System.Text;

namespace SICASBot.classes
{
    class Bulletin
    {
        public void DoBulletin()
        {
            //System.Reflection.Assembly frm;
            //frm = System.Reflection.Assembly.LoadFrom("");
            //Type tipo = frm.GetType("DynamicRdlcMatrix.Report");
            //object frmReport = System.Activator.CreateInstance(tipo);
            //Form reportForm = (Form)frmReport;
            //reportForm.Show();
        }
        //Dim frmExterno As System.Reflection.Assembly

        //''2- Usamos el método LoadFrom para asignar el ensamblado a nuestra variable:
        //frmExterno = System.Reflection.Assembly.LoadFrom(strloc)

        //''''

        //''''
        //''3- Declaramos una variable de tipo Type y le asignamos el formulario, para ello necesitamos indicarle el nombre "completo" de la clase, (un formulario es una clase):
        //Dim formType As Type = frmExterno.GetType("SICASMetropolitano.frmLogin")

        //''4- Usamos la clase Activator para crear una instancia del formulario:
        //Dim FormObj As Object = System.Activator.CreateInstance(formType)

        //''5- Usando una variable de tipo Form, asignamos el objeto, haciendo un cast o conversión:
        //Dim fExterno As Form = CType(FormObj, Form)

        //''6- Lo mostramos:
        //fExterno.Show()
    }
}
