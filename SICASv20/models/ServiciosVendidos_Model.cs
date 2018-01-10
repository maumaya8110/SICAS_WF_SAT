using System;
using System.Collections.Generic;
using System.Text;

namespace SICASv20
{
    #region Model

    /// <summary>
    /// Lógica de negocios para el reporte
    /// de servicios vendidos
    /// </summary>
    class ServiciosVendidos_Model
    {
        /// <summary>
        /// El número económico de la unidad
        /// a consultar los servicios
        /// </summary>
        public int? NumeroEconomico
        {
            get { return _NumeroEconomico; }
            set { _NumeroEconomico = value; }
        }
        private int? _NumeroEconomico;

        
        /// <summary>
        /// El nombre del conductor a consultar
        /// los servicios
        /// </summary>
        public string NombreConductor
        {
            get { return _NombreConductor; }
            set { _NombreConductor = value; }
        }
        private string _NombreConductor;

        /// <summary>
        /// El nombre de la zona a consultar
        /// en los servicios
        /// </summary>
        public string NombreZona
        {
            get { return _NombreZona; }
            set { _NombreZona = value; }
        }
        private string _NombreZona;

        /// <summary>
        /// El tipo de servicio a consultar en los servicios
        /// </summary>
        public int? TipoServicio_ID
        {
            get { return _TipoServicio_ID; }
            set { _TipoServicio_ID = value; }
        }
        private int? _TipoServicio_ID;

        /// <summary>
        /// La clase de servicio a consultar en los servicios
        /// </summary>
        public int? ClaseServicio_ID
        {
            get { return _ClaseServicio_ID; }
            set { _ClaseServicio_ID = value; }
        }
        private int? _ClaseServicio_ID;

        /// <summary>
        /// La moneda o forma de pago a consultar en los servicios
        /// </summary>
        public int? Moneda_ID
        {
            get { return _Moneda_ID; }
            set { _Moneda_ID = value; }
        }
        private int? _Moneda_ID;

        /// <summary>
        /// La fecha inicial a consultar en los servicios
        /// </summary>
        public DateTime? FechaInicial
        {
            get { return _FechaInicial; }
            set { _FechaInicial = value; }
        }
        private DateTime? _FechaInicial;

        /// <summary>
        /// La fecha final a consultar en los servicios
        /// </summary>
        public DateTime? FechaFinal
        {
            get { return _FechaFinal; }
            set { _FechaFinal = value; }
        }
        private DateTime? _FechaFinal;

        /// <summary>
        /// El listado de servicios
        /// </summary>
        public List<Entities.Vista_Servicios> Servicios
        {
            get { return _Servicios; }
            set { _Servicios = value; }
        }
        private List<Entities.Vista_Servicios> _Servicios;

        /// <summary>
        /// El listado de tipo de servicios
        /// </summary>
        public List<Entities.SelectTiposServicios> TiposServicios
        {
            get { return _TiposServicios; }
            set { _TiposServicios = value; }
        }
        private List<Entities.SelectTiposServicios> _TiposServicios;

        /// <summary>
        /// El listado de clases de servicios
        /// </summary>
        public List<Entities.SelectClasesServicios> ClasesServicios
        {
            get { return _ClasesServicios; }
            set { _ClasesServicios = value; }
        }
        private List<Entities.SelectClasesServicios> _ClasesServicios;

        /// <summary>
        /// El listado de monedas
        /// </summary>
        public List<Entities.SelectMonedas> Monedas
        {
            get { return _Monedas; }
            set { _Monedas = value; }
        }
        private List<Entities.SelectMonedas> _Monedas;

        /// <summary>
        /// Realiza la consulta de los catálogos vase
        /// </summary>
        public void ConsultarCatalogos()
        {
            this.TiposServicios = Entities.SelectTiposServicios.Get();
            this.ClasesServicios = Entities.SelectClasesServicios.Get();
            this.Monedas = Entities.SelectMonedas.Get();
        }

        /// <summary>
        /// Realiza la consulta de servicios
        /// </summary>
        public void Consultar()
        {
            this.Servicios = Entities.Vista_Servicios.Get(this.NombreZona,
                this.ClaseServicio_ID,
                this.TipoServicio_ID,
                this.Moneda_ID,
                this.NumeroEconomico,
                this.NombreConductor,
                this.FechaInicial,
                this.FechaFinal
                );

        } // End void Consultar

    } //    End Class Model

    #endregion

} // end namespace
