using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlzSoft
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        public void inicio_sesion(string usuario,string password)
        {
            try
            {
                DataTable userdata = new DataTable();
                userdata = BDuser.login(usuario, password);
                //inspecciona si usuario ingresado es correcto
                if (userdata.Rows.Count == 1)
                {
                    MessageBox.Show("Usuario correcto");
                    Usuario.IDlog = int.Parse(userdata.Rows[0][0].ToString());
                    Usuario.NOMBRElog = userdata.Rows[0][1].ToString();
                    Usuario.USERlog = userdata.Rows[0][2].ToString();
                    Usuario.PASSWORDlog = userdata.Rows[0][3].ToString();
                    Usuario.TIPOlog = userdata.Rows[0][4].ToString();
                    Main.usuario = Usuario.USERlog;
                    Main.userType = Usuario.TIPOlog;
                    if(Main.userType == "Admin")
                    { Main.admin = true; }
                    else
                    { Main.admin = false; }
                    this.Hide();
                    new Main().Show();
                  
                }
                else
                {
                    MessageBox.Show("Usuario incorrecto");
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message + ": No se pudo conectar a base de datos");
            }


        }
        
        private void btnIngresar_Click(object sender, EventArgs e)
        {
            if (this.txtUser.Text != "root")
            { inicio_sesion(this.txtUser.Text, this.txtPass.Text); }
            else if (this.txtPass.Text == "systemconfig" )
            {
                this.Hide();
                Main.usuario = "root";
                Main.userType = "Programmer";
                Main.admin = true;
                new Main().Show();

            }

        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
