using CoffeeShopApplication.Model;
using Dapper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoffeeShopApplication
{
    public partial class DodajZaposlenika : Form
    {
        public DodajZaposlenika()
        {
            InitializeComponent();
        }

        DbConnection db = new SqlConnection(@"Server=(LocalDB)\MSSQLLocalDB;Initial Catalog=CoffeeShopApplication;     
                                                            Integrated Security=True");

        private void btnIzlistajPopisZaposlenika_Click(object sender, EventArgs e)
        {
            List<Login> listaZaposlenika = ReadAll();

            if (listaZaposlenika.Count == 5)
            {
                txtOne.Text = listaZaposlenika[0].UserName;
                txtTwo.Text = listaZaposlenika[1].UserName;
                txtThree.Text = listaZaposlenika[2].UserName;
                txtFour.Text = listaZaposlenika[3].UserName;
                txtFive.Text = listaZaposlenika[4].UserName;
            }
            else if (listaZaposlenika.Count == 4)
            {
                txtOne.Text = listaZaposlenika[0].UserName;
                txtTwo.Text = listaZaposlenika[1].UserName;
                txtThree.Text = listaZaposlenika[2].UserName;
                txtFour.Text = listaZaposlenika[3].UserName;
            }
            else if (listaZaposlenika.Count == 3)
            {
                txtOne.Text = listaZaposlenika[0].UserName;
                txtTwo.Text = listaZaposlenika[1].UserName;
                txtThree.Text = listaZaposlenika[2].UserName;
            }
            else if (listaZaposlenika.Count == 2)
            {
                txtOne.Text = listaZaposlenika[0].UserName;
                txtTwo.Text = listaZaposlenika[1].UserName;
            }
            else if (listaZaposlenika.Count == 1)
            {
                txtOne.Text = listaZaposlenika[0].UserName;
            }
            db.Close();
        }

        public List<Login> ReadAll()
        {
            DbConnection drb = new SqlConnection(@"Server=(LocalDB)\MSSQLLocalDB;Initial Catalog=CoffeeShopApplication;     
                                                            Integrated Security=True");
            using (drb)
            {
                return drb.Query<Login>
                ("Select * From Login").ToList();
            }
        }

        private void btnDodajZaposlenika_Click(object sender, EventArgs e)
        {
            List<Login> listaZaposlenika = ReadAll();

            Login lg = new Login();
            lg.UserName = txtKorisnickoIme.Text;
            lg.Password = txtLozinka.Text;
            int insertID = listaZaposlenika.Count() + 1;

            int lgn = InsertInto(insertID, lg.UserName, lg.Password);
            var str = string.Format("Uspješno si kreirao zaposlenika {0}", lg.UserName);
            MessageBox.Show(str);
            db.Close();
        }

        public int InsertInto(int id, string username, string password)
        {
            DbConnection dzb = new SqlConnection(@"Server=(LocalDB)\MSSQLLocalDB;Initial Catalog=CoffeeShopApplication;     
                                                            Integrated Security=True");
            using (dzb)
            {
                return dzb.Execute("insert into Login values (@ID, @username, @password)", new { id, username, password });
            }
        }

        private void btnObrisiZaposlenika_Click(object sender, EventArgs e)
        {
            Login lg = new Login();
            lg.UserName = txtKorisnickoIme.Text;

            int lgn = DeleteUser(lg.UserName);
            var str = string.Format("Uspješno si obrisao zaposlenika {0}", lg.UserName);
            MessageBox.Show(str);
            db.Close();
        }

        public int DeleteUser(string username)
        {
            DbConnection dub = new SqlConnection(@"Server=(LocalDB)\MSSQLLocalDB;Initial Catalog=CoffeeShopApplication;     
                                                            Integrated Security=True");
            using (dub)
            {
                return dub.Execute("Delete from Login where username=(@username)", new { username });
            }
        }

        private void btnVratiSe_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
