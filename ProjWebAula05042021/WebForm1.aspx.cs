using Dal;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjWebAula05042021
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadGrid();
        }

        protected void BtnSalvar_Click(object sender, EventArgs e)
        {
            Ferramenta f1 = GetData();

            if (new FerramentaDB().Insert(f1))
            {
                LblMsg.Text = "Ferramenta inserida com sucesso!";
                TxtDescricao.Text = "";
                TxtMarca.Text = "";
                TxtTipo.Text = "";
                TxtPreco.Text = "";
                LoadGrid();
            }
            else
            {
                LblMsg.Text = "Erro ao inserir registro!";
            }
            
        }

        private Ferramenta GetData()
        {
            return new Ferramenta()
            {
                //Id = int.Parse(TxtId.Text),
                Descricao = TxtDescricao.Text,
                Marca = TxtMarca.Text,
                Tipo = TxtTipo.Text,
                Preco = TxtPreco.Text,
            };
        }

        private void LoadGrid()
        {
            GVFerramenta.DataSource = new FerramentaDB().GetAll();
            GVFerramenta.DataBind();
        }
    }
}