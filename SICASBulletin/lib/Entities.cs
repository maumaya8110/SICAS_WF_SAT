using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;

namespace SICASBulletin.Entities
{
    public class Boletines
    {

        #region Constructors

        public Boletines()
        {
        }

        public Boletines(
            int boletin_id,
            string nombre)
        {
            this.Boletin_ID = boletin_id;
            this.Nombre = nombre;
        }

        #endregion

        #region Properties

        private int _Boletin_ID;
        public int Boletin_ID
        {
            get { return _Boletin_ID; }
            set { _Boletin_ID = value; }
        }

        private string _Nombre;
        public string Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }

        #endregion

        #region Methods
        public void Validate()
        {
            if (this.Boletin_ID == null) throw new Exception("Boletin_ID no puede ser nulo.");

            if (this.Nombre.Length > 50)
            {
                throw new Exception("Nombre debe tener máximo 50 carateres.");
            }


        } // End Validate

        public int Create()
        {
            Hashtable m_params = new Hashtable();
            if (!DB.IsNullOrEmpty(this.Nombre)) m_params.Add("Nombre", this.Nombre);

            return DB.InsertRow("Boletines", m_params);
        } // End Create

        public int Create(bool IsIdentityInsert)
        {
            if (!IsIdentityInsert) return Create();
            Hashtable m_params = new Hashtable();
            m_params.Add("Boletin_ID", this.Boletin_ID);
            if (!DB.IsNullOrEmpty(this.Nombre)) m_params.Add("Nombre", this.Nombre);

            return DB.IdentityInsertRow("Boletines", m_params);
        } // End Create

        public static List<Boletines> Read()
        {
            List<Boletines> list = new List<Boletines>();
            DataTable dt = DB.Select("Boletines");
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(
                    new Boletines(
                        Convert.ToInt32(dr["Boletin_ID"]),
                        Convert.ToString(dr["Nombre"])
                    )
                );
            }

            return list;
        } // End Read

        public static Boletines Read(int boletin_id)
        {
            Hashtable w_params = new Hashtable();
            w_params.Add("Boletin_ID", boletin_id);
            DataTable dt = DB.Select("Boletines", w_params);
            if (dt.Rows.Count == 0)
            {
                throw new Exception("No existe Boletines con los criterios de búsqueda especificados.");
            }
            DataRow dr = dt.Rows[0];
            return new Boletines(
                Convert.ToInt32(dr["Boletin_ID"]),
                        Convert.ToString(dr["Nombre"])
                    );
        } // End Read

        public static Boletines Read(params KeyValuePair<string, object>[] args)
        {
            DataTable dt = DB.Read("Boletines", args);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            DataRow dr = dt.Rows[0];
            return new Boletines(
                Convert.ToInt32(dr["Boletin_ID"]),
                        Convert.ToString(dr["Nombre"])
                    );
        } // End Read

        public static bool Read(
            out Boletines boletines,
            int top,
            string filter,
            string sort,
            params KeyValuePair<string, object>[] args)
        {
            DataTable dt = DB.Read("Boletines", top, filter, sort, args);
            if (dt.Rows.Count == 0)
            {
                boletines = null;
                return false;
            }
            DataRow dr = dt.Rows[0];
            boletines = new Boletines(
                Convert.ToInt32(dr["Boletin_ID"]),
                        Convert.ToString(dr["Nombre"])
                    );
            return true;
        } // End Read

        public static DataTable ReadDataTable()
        {
            return DB.Select("Boletines");
        } // End Read

        public static DataTable ReadDataTable(int boletin_id)
        {
            Hashtable w_params = new Hashtable();
            w_params.Add("Boletin_ID", boletin_id);
            return DB.Select("Boletines", w_params);
        } // End Read

        public int Update()
        {
            Hashtable m_params = new Hashtable();
            Hashtable w_params = new Hashtable();
            w_params.Add("Boletin_ID", this.Boletin_ID);
            if (!DB.IsNullOrEmpty(this.Nombre)) m_params.Add("Nombre", this.Nombre);

            return DB.UpdateRow("Boletines", m_params, w_params);
        } // End Update

        public int Delete()
        {
            Hashtable w_params = new Hashtable();
            w_params.Add("Boletin_ID", this.Boletin_ID);

            return DB.DeleteRow("Boletines", w_params);
        } // End Delete


        #endregion
    } //End Class Boletines

    public class Boletines_Usuarios
    {

        #region Constructors

        public Boletines_Usuarios()
        {
        }

        public Boletines_Usuarios(
            int boletin_id,
            string usuario_id)
        {
            this.Boletin_ID = boletin_id;
            this.Usuario_ID = usuario_id;
        }

        #endregion

        #region Properties

        private int _Boletin_ID;
        public int Boletin_ID
        {
            get { return _Boletin_ID; }
            set { _Boletin_ID = value; }
        }

        private string _Usuario_ID;
        public string Usuario_ID
        {
            get { return _Usuario_ID; }
            set { _Usuario_ID = value; }
        }

        #endregion

        #region Methods
        public void Validate()
        {
            if (this.Boletin_ID == null) throw new Exception("Boletin_ID no puede ser nulo.");

            if (this.Usuario_ID == null) throw new Exception("Usuario_ID no puede ser nulo.");

            if (this.Usuario_ID.Length > 30)
            {
                throw new Exception("Usuario_ID debe tener máximo 30 carateres.");
            }


        } // End Validate

        public int Create()
        {
            Hashtable m_params = new Hashtable();
            m_params.Add("Boletin_ID", this.Boletin_ID);
            m_params.Add("Usuario_ID", this.Usuario_ID);

            return DB.InsertRow("Boletines_Usuarios", m_params);
        } // End Create

        public static List<Boletines_Usuarios> Read()
        {
            List<Boletines_Usuarios> list = new List<Boletines_Usuarios>();
            DataTable dt = DB.Select("Boletines_Usuarios");
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(
                    new Boletines_Usuarios(
                        Convert.ToInt32(dr["Boletin_ID"]),
                        Convert.ToString(dr["Usuario_ID"])
                    )
                );
            }

            return list;
        } // End Read



        public static Boletines_Usuarios Read(int boletin_id, string usuario_id)
        {
            Hashtable w_params = new Hashtable();
            w_params.Add("Boletin_ID", boletin_id);
            w_params.Add("Usuario_ID", usuario_id);

            DataTable dt = DB.Select("Boletines_Usuarios", w_params);
            if (dt.Rows.Count == 0)
            {
                throw new Exception("No existe Boletines_Usuarios con los criterios de búsqueda especificados.");
            }
            DataRow dr = dt.Rows[0];
            return new Boletines_Usuarios(
                Convert.ToInt32(dr["Boletin_ID"]),
                        Convert.ToString(dr["Usuario_ID"])
                    );
        } // End Read

        public static Boletines_Usuarios Read(params KeyValuePair<string, object>[] args)
        {
            DataTable dt = DB.Read("Boletines_Usuarios", args);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            DataRow dr = dt.Rows[0];
            return new Boletines_Usuarios(
                Convert.ToInt32(dr["Boletin_ID"]),
                        Convert.ToString(dr["Usuario_ID"])
                    );
        } // End Read

        public static bool Read(
            out Boletines_Usuarios boletines_usuarios,
            int top,
            string filter,
            string sort,
            params KeyValuePair<string, object>[] args)
        {
            DataTable dt = DB.Read("Boletines_Usuarios", top, filter, sort, args);
            if (dt.Rows.Count == 0)
            {
                boletines_usuarios = null;
                return false;
            }
            DataRow dr = dt.Rows[0];
            boletines_usuarios = new Boletines_Usuarios(
                Convert.ToInt32(dr["Boletin_ID"]),
                        Convert.ToString(dr["Usuario_ID"])
                    );
            return true;
        } // End Read

        public static DataTable ReadDataTable()
        {
            return DB.Select("Boletines_Usuarios");
        } // End Read

        public static DataTable ReadDataTable(int boletin_id, string usuario_id)
        {
            Hashtable w_params = new Hashtable();
            w_params.Add("Boletin_ID", boletin_id);
            w_params.Add("Usuario_ID", usuario_id);
            return DB.Select("Boletines_Usuarios", w_params);
        } // End Read

        public int Update()
        {
            Hashtable m_params = new Hashtable();
            Hashtable w_params = new Hashtable();
            m_params.Add("Boletin_ID", this.Boletin_ID);
            m_params.Add("Usuario_ID", this.Usuario_ID);

            return DB.UpdateRow("Boletines_Usuarios", m_params, w_params);
        } // End Update

        public int Delete()
        {
            Hashtable w_params = new Hashtable();

            return DB.DeleteRow("Boletines_Usuarios", w_params);
        } // End Delete


        #endregion
    } //End Class Boletines_Usuarios

} // End Namespace
