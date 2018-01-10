using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Drawing2D;

namespace SICASv20.forms.empresas.documentos
{
	public partial class Digitalizados : baseForm
	{
		string baseDirectory = "";
		string directoryInfoBase = "";
		Matrix matrix = new Matrix();

		public Digitalizados()
		{
			InitializeComponent();
			baseDirectory = (string)Entities.VariablesNegocio.Read("PathDocumentos").Valor;
		}

		private void BuscaContenido(TreeNode treeNode, string directoryInfo, string sbusca)
		{
			try
			{
				DirectoryInfo di = new DirectoryInfo(directoryInfo);
				DirectoryInfo[] directorios = di.GetDirectories();
				if (directorios.Length > 0)
				{
					foreach (DirectoryInfo d in directorios)
					{
						TreeNode node = treeNode.Nodes.Add(d.Name);
						node.ImageIndex = 1;
						node.SelectedImageIndex = 1;
						BuscaContenido(node, d.FullName, sbusca);
						FileInfo[] lfiles = d.GetFiles();
						foreach (FileInfo f in lfiles)
						{
							if (f.Exists)
							{
								TreeNode nodef = node.Nodes.Add(f.Name);
								nodef.Tag = f.FullName;
								nodef.ImageIndex = 2;
								nodef.SelectedImageIndex = 2;
							}
						}
					}
				}
			}
			catch (Exception ex)
			{
				AppHelper.Error(ex.Message);
			}
		}

		private void cmdBuscar_Click(object sender, EventArgs e)
		{
			tvItems.Nodes[0].Nodes.Clear();
			if (txtTextoABuscar.Text.Trim().Length > 0)
				BuscaArchivo(tvItems.Nodes[0], directoryInfoBase, txtTextoABuscar.Text.Trim());
			else
				BuscaContenido(tvItems.Nodes[0], directoryInfoBase, "");
			//EliminaDirectoriosvacios(tvItems.Nodes[0]);
		}

		private void EliminaDirectoriosvacios(TreeNode treeNode)
		{
			int idx = 0;
			while (idx < treeNode.Nodes.Count)
			{
				TreeNode node = treeNode.Nodes[idx];
				if (node.Tag == null && node.Nodes.Count == 0)
					treeNode.Nodes.Remove(node);
				else
				{
					EliminaDirectoriosvacios(node);
					idx++;
				}
			}
		}

		private void BuscaArchivo(TreeNode treeNode, string directoryInfoBase, string sbusca)
		{
			try
			{
				DirectoryInfo di = new DirectoryInfo(directoryInfoBase);
				DirectoryInfo[] directorios = di.GetDirectories();
				if (directorios.Length > 0)
				{
					foreach (DirectoryInfo d in directorios)
					{
						BuscaArchivo(treeNode, d.FullName, sbusca);
						FileInfo[] lfiles = d.GetFiles();
						foreach (FileInfo f in lfiles)
						{
							if (f.Exists && f.FullName.Contains(sbusca))
							{
								TreeNode nodef = treeNode.Nodes.Add(f.Name);
								nodef.Tag = f.FullName;
								nodef.ImageIndex = 2;
								nodef.SelectedImageIndex = 2;
							}
						}
					}
				}
			}
			catch (Exception ex)
			{
				AppHelper.Error(ex.Message);
			}
		}

		private void txtTextoABuscar_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)Keys.Enter)
			{
				cmdBuscar_Click(null, null);
			}
		}

		private void tvItems_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
		{
			AppHelper.DoMethod(delegate { MuestraArchivo(e.Node); }, this);
		}

		private void MuestraArchivo(TreeNode naux)
		{
			//TreeNode naux = e.Node;
			if (naux.Tag != null)
			{
				pdfFile.Visible = false;
				pnlImagen.Visible = false;

				string spath = (string)naux.Tag;
				FileInfo ff = new FileInfo(spath);
				if (ff.Extension == ".pdf")
				{
					pdfFile.Visible = true;
					pdfFile.src = spath;
					pdfFile.Show();
				}
				if (ff.Extension == ".jpg")
				{
					pnlImagen.Visible = true;
					pbArchivo.SizeMode = PictureBoxSizeMode.AutoSize;
					pbArchivo.Image = new System.Drawing.Bitmap(spath);
					pbArchivo.Show();
				}
			}
		}

		private void Digitalizados_Shown(object sender, EventArgs e)
		{
			string dirbase = this.Name;
			directoryInfoBase = baseDirectory + @"\" + dirbase;
			if (Directory.Exists(directoryInfoBase))
			{
				BuscaContenido(tvItems.Nodes[0], directoryInfoBase, "");
			}
			this.tvItems.Nodes[0].Text = this.Name;
			pdfFile.setShowToolbar(false);
		}
	}
}
