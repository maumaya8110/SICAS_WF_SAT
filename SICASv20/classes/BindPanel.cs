using System;
using System.Windows.Forms;
using System.Data;
using System.ComponentModel;
using System.Reflection;
using System.Drawing;
using System.IO;

namespace SICASv20
{
    [Bindable(true)]
    public class BindPanel : TableLayoutPanel
    {
        #region Constructors

        public BindPanel()
        {
        }

        /// <summary>
        /// Constructor de la clase BindPanel
        /// </summary>
        /// <param name="m_DataSource">La fuente de datos a la que se ligará el control</param>
        /// <param name="m_DisplayMember">El campo de la fuente de datos que se visualizará como texto</param>
        /// <param name="m_ValueMember">El campo de la fuente de datos que se guardará internamente como valor</param>
        /// <param name="m_LayoutType">El tipo de BindPanel</param>
        /// <param name="m_Height">La altura del panel</param>
        /// <param name="m_Width">El ancho del panel</param>
        /// <param name="m_ButtonHeight">La altura de los botones</param>
        /// <param name="m_ButtonWidth">La anchura de los botones</param>
        public BindPanel(object m_DataSource, string m_DisplayMember, string m_ValueMember, BindPanelLayoutType m_LayoutType,
            int m_Height, int m_Width, int m_ButtonHeight, int m_ButtonWidth)
        {
            this.DataSource = m_DataSource;
            this.DisplayMember = m_DisplayMember;
            this.ValueMember = m_ValueMember;
            this.LayoutType = m_LayoutType;
            this.Height = m_Height;
            this.Width = m_Width;
            this.ButtonHeight = m_ButtonHeight;
            this.ButtonWidth = m_ButtonWidth;

            this.Databind();
        }
        #endregion

        #region Properties

        /// <summary>
        /// Tipos de BindPanel
        /// </summary>
        public enum BindPanelLayoutType
        {
            Horizontal,
            Vertical,
            Matrix
        }

        /// <summary>
        /// La fuente de datos a la que se ligará el control
        /// </summary>        
        private object _DataSource;

        [Category("Data")]
        [Description("DataSource")]
        [DisplayName("DataSource")]
        [DefaultValue("")]
        [RefreshProperties(RefreshProperties.Repaint)]
        [AttributeProvider(typeof(IListSource))]
        public object DataSource
        {
            get { return _DataSource; }
            set { _DataSource = value; }
        }

        private BindPanelLayoutType _LayoutType;

        [Category("Layout")]
        [Description("BindPanelLayoutType")]
        [DisplayName("BindPanelLayoutType")]
        [DefaultValue(BindPanelLayoutType.Matrix)]
        [RefreshProperties(RefreshProperties.Repaint)]
        [AttributeProvider(typeof(BindPanelLayoutType))]
        public BindPanelLayoutType LayoutType
        {
            get { return _LayoutType; }
            set { _LayoutType = value; }
        }

        private int _ItemsCount;

        public int ItemsCount
        {
            get { return _ItemsCount; }
            set { _ItemsCount = value; }
        }

        private int _Sqr;

        public int Sqr
        {
            get { return _Sqr; }
            set { _Sqr = value; }
        }

        private string _DisplayMember;

        public string DisplayMember
        {
            get { return _DisplayMember; }
            set { _DisplayMember = value; }
        }

        private string _ImageMember;

        public string ImageMember
        {
            get { return _ImageMember; }
            set { _ImageMember = value; }
        }

        private string _ValueMember;

        public string ValueMember
        {
            get { return _ValueMember; }
            set { _ValueMember = value; }
        }

        private int _ButtonHeight;

        public int ButtonHeight
        {
            get { return _ButtonHeight; }
            set { _ButtonHeight = value; }
        }

        private int _ButtonWidth;

        public int ButtonWidth
        {
            get { return _ButtonWidth; }
            set { _ButtonWidth = value; }
        }

        private float _ButtonFontSize = 9;
        public float ButtonFontSize
        {
            get { return _ButtonFontSize; }
            set { _ButtonFontSize = value; }
        }

        /// <summary>
        /// En caso de que la fuente de datos sea un dataset
        /// esta propiedad indica la Tabla a la que se ligará 
        /// el control
        /// </summary>
        private string _DataMember;
        public string DataMember
        {
            get { return _DataMember; }
            set { _DataMember = value; }
        }

        #endregion

        #region Methods

        public delegate void Button_Click(object sender, EventArgs e);

        private Button_Click _B_Click;

        public Button_Click B_Click
        {
            get { return _B_Click; }
            set { _B_Click = value; }
        }

        /// <summary>
        /// Configura el layout del panel, a partir de su tipo
        /// </summary>
        private void SetLayout()
        {
            int rowheight, colwidth, i;

            this.RowCount = 0;
            this.RowStyles.Clear();
            this.ColumnCount = 0;
            this.ColumnStyles.Clear();

            switch (this.LayoutType)
            {
                case BindPanelLayoutType.Matrix:

                    Sqr = Convert.ToInt32(Math.Ceiling(Math.Sqrt(this.ItemsCount)));
                    this.RowCount = Sqr;
                    this.ColumnCount = Sqr;

                    this.GrowStyle = TableLayoutPanelGrowStyle.AddRows;

                    rowheight = 100 / this.RowCount;
                    colwidth = 100 / this.ColumnCount;

                    this.ButtonHeight = Convert.ToInt32((double)this.Height * ((double)rowheight / 100D));
                    this.ButtonWidth = Convert.ToInt32((double)this.Width * ((double)colwidth / 100D));

                    for (i = 0; i <= this.RowCount - 1; i++)
                    {
                        this.RowStyles.Add(new RowStyle(SizeType.Percent, rowheight));
                    }

                    for (i = 0; i <= this.ColumnCount - 1; i++)
                    {
                        this.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, colwidth));
                    }

                    break;

                case BindPanelLayoutType.Horizontal:

                    this.RowCount = 1;
                    this.ColumnCount = this.ItemsCount;

                    this.GrowStyle = TableLayoutPanelGrowStyle.AddColumns;

                    rowheight = this.Height;
                    colwidth = 100 / this.ItemsCount;

                    this.ButtonHeight = rowheight;
                    this.ButtonWidth = Convert.ToInt32((double)this.Width * ((double)colwidth / 100D));

                    for (i = 0; i <= this.RowCount - 1; i++)
                    {
                        this.RowStyles.Add(new RowStyle(SizeType.Absolute, rowheight));
                    }

                    for (i = 0; i <= this.ColumnCount - 1; i++)
                    {
                        this.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, colwidth));
                    }

                    break;

                case BindPanelLayoutType.Vertical:

                    this.RowCount = this.ItemsCount;
                    this.ColumnCount = 1;

                    this.GrowStyle = TableLayoutPanelGrowStyle.AddRows;

                    rowheight = 100 / this.ItemsCount;
                    colwidth = this.Width;

                    this.ButtonHeight = Convert.ToInt32((double)this.Height * ((double)rowheight / 100D));
                    this.ButtonWidth = colwidth;

                    for (i = 0; i <= this.RowCount - 1; i++)
                    {
                        this.RowStyles.Add(new RowStyle(SizeType.Percent, rowheight));
                    }

                    for (i = 0; i <= this.ColumnCount - 1; i++)
                    {
                        this.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, colwidth));
                    }
                    break;
            }
        }

        /// <summary>
        /// Liga el control a una fuente de datos tipo DataTable
        /// </summary>
        private void DoBindDataTable()
        {
            DataTable dt = (DataTable)this.DataSource;
            this.ItemsCount = dt.Rows.Count;

            SetLayout();

            foreach (DataRow dr in dt.Rows)
            {
                Button btn = new Button();
                btn.Name = "btn" + dr[this.DisplayMember].ToString();
                btn.Tag = dr[this.ValueMember];
                btn.Height = this.ButtonHeight;
                btn.Width = this.ButtonWidth;
                btn.Cursor = Cursors.Hand;
                btn.Dock = DockStyle.Fill;
                btn.Font = new System.Drawing.Font(btn.Font.FontFamily, this.ButtonFontSize);

                if (!string.IsNullOrEmpty(ImageMember))
                {
                    btn.Text = "";
                    btn.BackgroundImageLayout = ImageLayout.Stretch;
                    btn.BackgroundImage = new Bitmap(
                                    new Bitmap(dr[this.ImageMember].ToString()),
                                    btn.Width,
                                    btn.Height
                                );
                }
                else
                {
                    btn.Text = dr[this.DisplayMember].ToString();
                }

                btn.Click += new EventHandler(btn_Click);
                this.Controls.Add(btn);
            }
        }

        void btn_Click(object sender, EventArgs e)
        {
            B_Click(sender, e);
        }

        /// <summary>
        /// Liga el control a una fuente de datos tipo BindingSource
        /// </summary>
        private void DoBindBindingSource()
        {
            BindingSource bs = (BindingSource)this.DataSource;
            this.ItemsCount = bs.Count;
            SetLayout();

            bs.MoveFirst();

            int limit = bs.Count;
            for (int i = 0; i < limit; i++)
            {
                PropertyInfo piV = bs.Current.GetType().GetProperty(this.ValueMember);
                PropertyInfo piD = bs.Current.GetType().GetProperty(this.DisplayMember);

                Button btn = new Button();
                btn.Name = "btn" + piD.GetValue(bs.Current, null).ToString();
                btn.Tag = piV.GetValue(bs.Current, null);
                btn.Height = this.ButtonHeight;
                btn.Width = this.ButtonWidth;
                btn.Cursor = Cursors.Hand;
                btn.Dock = DockStyle.Fill;
                btn.Font = new System.Drawing.Font(btn.Font.FontFamily, this.ButtonFontSize);

                if (!string.IsNullOrEmpty(ImageMember))
                {
                    PropertyInfo piI = bs.Current.GetType().GetProperty(this.ImageMember);
                    string imgFile = piI.GetValue(bs.Current, null).ToString();

                    if (string.IsNullOrEmpty(imgFile))
                    {
                        btn.Text = piD.GetValue(bs.Current, null).ToString();
                    }
                    else
                    {
                        btn.Text = "";
                        btn.BackgroundImageLayout = ImageLayout.Stretch;

                        if (!File.Exists(imgFile))
                            imgFile = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) +
                                @"\RealSimplePOS\ProductImages\Default.jpg";

                        Bitmap img = new Bitmap(imgFile);
                        img = new Bitmap(img, btn.Width, btn.Height);

                        btn.BackgroundImage = img;
                    }
                }
                else
                {
                    btn.Text = piD.GetValue(bs.Current, null).ToString();
                }

                btn.Click += new EventHandler(btn_Click);
                this.Controls.Add(btn);

                bs.MoveNext();
            }
        }

        private void DoBindDataSet()
        {
            DataSet ds = (DataSet)this.DataSource;
            this.DataSource = ds.Tables[this.DataMember];
            DoBindDataTable();
        }

        private void DoBindList()
        {
            throw new NotImplementedException("Procedimiento no implementado");
        }

        private void DoBindIEnumerable()
        {
            throw new NotImplementedException("Procedimiento no implementado");
        }

        /// <summary>
        /// Liga la fuente de datos al control
        /// </summary>
        public void Databind()
        {
            this.Controls.Clear();
            Type dstype;
            dstype = this.DataSource.GetType();
            string type = dstype.ToString();

            switch (type)
            {
                case "System.Data.DataTable":
                    DoBindDataTable();
                    break;

                case "System.Windows.Forms.BindingSource":
                    DoBindBindingSource();
                    break;

                case "System.Data.DataSet":
                    DoBindDataSet();
                    break;

                default:
                    if (type.Contains("System.Collections.Generic.List"))
                    {
                        DoBindList();
                    }
                    else
                    {
                        throw new Exception("Not supported");
                    }
                    break;
            }
        }

        #endregion
    } // End cLass
}
