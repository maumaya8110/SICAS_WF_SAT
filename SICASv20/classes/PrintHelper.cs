using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;

namespace SICASv20
{
    public class PrintHelper
    {
        private int _Width = 250;
        public int Width
        {
            get { return _Width; }
            set { _Width = value; }
        }

        class PrintItems
        {
            /// <summary>
            /// Constructors
            /// </summary>
            #region Constructors
            public PrintItems()
            {

            }

            public PrintItems(ItemTypes itemtype, object item)
            {
                this.ItemType = itemtype;
                this.Item = item;
                this.x = null;
                this.y = null;
            }

            public PrintItems(ItemTypes itemtype, object item, float x, float y)
            {
                this.ItemType = itemtype;
                this.Item = item;
                this.x = x;
                this.y = y;
            }

            public PrintItems(ItemTypes itemtype, object item, string fontfamily, float x, float y)
            {
                this.ItemType = itemtype;
                this.Item = item;
                this.x = x;
                this.y = y;
                this.FontFamily = fontfamily;
            }

            #endregion

            #region Properties

            /// <summary>
            /// Tipos de objetos a imprimir
            /// </summary>
            public enum ItemTypes
            {
                Text,
                Table,
                Blankline,
                Rectangle,
                Line
            }

            // El tipo de objeto            
            private ItemTypes _ItemType;
            public ItemTypes ItemType
            {
                get { return _ItemType; }
                set { _ItemType = value; }
            }

            //  El objeto
            public object _Item;
            public object Item
            {
                get { return _Item; }
                set { _Item = value; }
            }

            //  Su coordenada X, en caso de haberla
            private float? _x;
            public float? x
            {
                get { return _x; }
                set { _x = value; }
            }

            //  Su coordenada Y, en caso de haberla
            private float? _y;
            public float? y
            {
                get { return _y; }
                set { _y = value; }
            }

            private string _FontFamily;
            public string FontFamily
            {
                get { return _FontFamily; }
                set { _FontFamily = value; }
            }


            #endregion
        }

        public enum MeasureTypes
        {
            Centimeters,
            Inches,
            Pixels
        }

        private MeasureTypes _MeasureType = MeasureTypes.Pixels;
        public MeasureTypes MeasureType
        {
            get { return _MeasureType; }
            set { _MeasureType = value; }
        }

        public PrintDocument PrintDoc;
        Font MyFont;
        Brush MyBrush;
        Pen MyPen;
        int X;
        int Y;
        List<PrintItems> Items;
        int Padding = 2;
        //int Width;
        int ColWidth;
        int RowHeight;
        int MaxWidth;

        public bool PrintToPort { get; set; }
        public string Port { get; set; }
        public bool PrintToFile { get; set; }

        public PrintHelper()
        {
            X = 0;
            Y = 0;
            MyFont = new Font("Arial", 8);
		  MyBrush = Brushes.Black;
		  MyPen = Pens.Black;
            PrintDoc = new PrintDocument();
            PrintDoc.DefaultPageSettings.Margins.Top = 0;
            PrintDoc.DefaultPageSettings.Margins.Left = 0;
            PrintDoc.DefaultPageSettings.Margins.Bottom = 0;
            PrintDoc.DefaultPageSettings.Margins.Right = 0;
            PrintDoc.DocumentName = string.Format("Document_{0:yyyyMMddHHmmss}", DateTime.Now);
            Items = new List<PrintItems>();
            //this.Width = 250;

            PrintToPort = false;
            Port = string.Empty;
            PrintToFile = false;
        }

        public void PrintText(string text)
        {
            Items.Add(new PrintItems(PrintItems.ItemTypes.Text, text));
        }

        public void PrintText(string text, params object[] args)
        {
            Items.Add(new PrintItems(PrintItems.ItemTypes.Text, string.Format(text, args)));
        }

        /// <summary>
        /// Imprime texto como dibujo, indicando su ubicación
        /// </summary>
        /// <param name="text">El texto a imprimir</param>
        /// <param name="x">La coordenada X</param>
        /// <param name="y">La coordendada Y</param>
        public void PrintText(string text, float x, float y)
        {
            Items.Add(new PrintItems(PrintItems.ItemTypes.Text, text, x, y));
        }

        /// <summary>
        /// Imprime texto como dibujo, indicando su ubicación
        /// </summary>
        /// <param name="text">El texto a imprimir</param>
        /// <param name="x">La coordenada X</param>
        /// <param name="y">La coordendada Y</param>
        public void PrintText(string text, string fontfamily, float x, float y)
        {
            Items.Add(new PrintItems(PrintItems.ItemTypes.Text, text, fontfamily, x, y));
        }

        public void PrintTable(DataTable dtable)
        {
            Items.Add(new PrintItems(PrintItems.ItemTypes.Table, dtable));
        }

        public void PrintLine()
        {
            Items.Add(new PrintItems(PrintItems.ItemTypes.Blankline, null));
        }

        public void PrintCLRF()
        {
            Items.Add(new PrintItems(PrintItems.ItemTypes.Blankline, null));
        }

        public Bitmap PrintToBitmap()
        {
            Bitmap bmp = null, newbmp = null;
            Graphics g = null;

            try
            {
                bmp = new Bitmap(500, 500);
                g = Graphics.FromImage(bmp);
                g.FillRectangle(Brushes.White, new Rectangle(new Point(0, 0), new Size(500, 500)));
                DrawItems(ref g);
                newbmp = new Bitmap(MaxWidth + Padding * 4, Y + Padding * 4);
                g = Graphics.FromImage(newbmp);
                g.DrawImage(bmp, new Point(Padding * 2, Padding * 2));
                return newbmp;
            }
            finally
            {
                if (g != null) g.Dispose();
                if (bmp != null) bmp.Dispose();
            }
        }

        public void Print()
        {
            PrintDoc.PrintPage += this.PrintPage;            
            PrintDoc.PrinterSettings.PrintToFile = PrintToFile;

            string filename = System.IO.Path.GetTempFileName();
            if (PrintToPort)
            {
                PrintDoc.PrinterSettings.PrintFileName = filename;
            }

            PrintDoc.Print();

            if (PrintToPort &&
                !string.IsNullOrEmpty(Port))
            {
                System.IO.File.Copy(filename, Port);
            }
        }

        /// <summary>
        /// Convierte centímetros a pixeles
        /// </summary>
        /// <param name="cm">Los centímetros a convertir</param>
        /// <returns>float</returns>
        public float CentimetersToPixels(float cm)
        {
            return cm * 37.795F;
        }

        private void DrawItems(ref Graphics g)
        {
            foreach (PrintItems item in this.Items)
            {
                switch (item.ItemType.ToString())
                {
                    case "Blankline":

                        g.DrawString("", MyFont, MyBrush, new Point(X, Y));
                        Y += Convert.ToInt32(g.MeasureString("ABCDE", MyFont).Height) + Padding;
                        MaxWidth = X;
                        break;

                    case "Text":

                        string text = item.Item.ToString();
                        Font font;

                        if (!string.IsNullOrEmpty(item.FontFamily))
                        {
                            font = new Font(item.FontFamily, MyFont.Size);
                        }
                        else
                        {
                            font = MyFont;
                        }

                        if (item.x == null || item.y == null)
                        {                   
                            if (AppHelper.IsNumeric(item.Item))
                            {
                                text = string.Format("{0:N2}", item.Item);
                            }

                            g.DrawString(text, font, MyBrush, new Point(X, Y));

                            Y += Convert.ToInt32(g.MeasureString(item.Item.ToString(), MyFont).Height) + Padding;
                            MaxWidth = X + Convert.ToInt32(g.MeasureString(item.Item.ToString(), MyFont).Width) + Padding;
                        }
                        else
                        {
                            if (this.MeasureType == MeasureTypes.Centimeters)
                            {
                                item.x = this.CentimetersToPixels(item.x.Value);
                                item.y = this.CentimetersToPixels(item.y.Value);
                            }

                            g.DrawString(text, font, MyBrush, new PointF(item.x.Value, item.y.Value));
                        }
                        break;

                    case "Table":

                        DataTable dt = (DataTable)item.Item;

                        if (dt.Rows.Count > 0)
                        {
                            ColWidth = Width / dt.Columns.Count;
                            RowHeight = Convert.ToInt32(g.MeasureString("ABCDF", MyFont).Height);

                            //  Headers
                            foreach (DataColumn col in dt.Columns)
                            {
                                //  DrawString
                                StringFormat sf = new StringFormat();
                                sf.Alignment = StringAlignment.Center;
                                int leftmargin = (dt.Columns.IndexOf(col)) * ColWidth;
                                g.DrawString(col.ColumnName, MyFont, MyBrush, new RectangleF(leftmargin, Y, ColWidth, RowHeight));

                            }
                            Y += RowHeight + Padding;
                            MaxWidth = dt.Columns.Count * ColWidth + Padding;
                            //  DrawLine
                            g.DrawLine(MyPen, new Point(X, Y), new Point(Width, Y));

                            //  Values
                            foreach (DataRow dr in dt.Rows)
                            {
                                foreach (DataColumn dc in dt.Columns)
                                {
                                    //  DrawString
                                    string val;
                                    int leftmargin = (dt.Columns.IndexOf(dc)) * ColWidth;

                                    if (AppHelper.IsNumeric(dr[dc.ColumnName]))
                                    {
                                        StringFormat sf = new StringFormat();
                                        sf.Alignment = StringAlignment.Center;
                                        val = string.Format("{0:N2}", dr[dc.ColumnName]);
                                        g.DrawString(val, MyFont, MyBrush, new RectangleF(leftmargin, Y, ColWidth, RowHeight), sf);
                                    }
                                    else
                                    {
                                        //  DrawString
                                        StringFormat sf = new StringFormat();
                                        sf.Alignment = StringAlignment.Center;
                                        val = dr[dc.ColumnName].ToString();
                                        g.DrawString(val, MyFont, MyBrush, new RectangleF(leftmargin, Y, ColWidth, RowHeight), sf);
                                    }

                                    //  DrawRectangle
                                }
                                Y += RowHeight + Padding;
                            }
                        }

                        break;
                } // End switch
            } // End foreach
        }

        private void PrintPage(object sender, PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;
            DrawItems(ref g);
        } // End void
    } // End class
} // End namespace
