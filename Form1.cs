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
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }
        DbConnection db = new SqlConnection(@"Server=(LocalDB)\MSSQLLocalDB;Initial Catalog=CoffeeShopApplication;     
                                                            Integrated Security=True");


        private static List<Artikl> ReadAllArticles()
        {
            DbConnection dtb = new SqlConnection(@"Server=(LocalDB)\MSSQLLocalDB;Initial Catalog=CoffeeShopApplication;     
                                                            Integrated Security=True");
            using (dtb)
            {
                return dtb.Query<Artikl>
                ("Select * From Login").ToList();
            }
        }

        private void btnUlogirajse_Click(object sender, EventArgs e)
        {
            Login lg = new Login();
            lg.UserName = txtKorisnickoIme.Text;
            lg.Password = txtLozinka.Text;

            string time = string.Format("{0:yyyy:MM:dd-HH:mm:ss tt}", DateTime.Now);

            List<Login> canUserLogin = ReadAll();
            List<Artikl> listaArtikala = ReadAllArticles();

            for (int i = 0; i < canUserLogin.Count; i++)
            {
                if (lg.UserName == canUserLogin[i].UserName && lg.Password == canUserLogin[i].Password)
                {
                    List<LoginInfo> li = ReadAllFromLoginInfo();
                    InsertIntoLoginInfo(li.Count + 1, time, canUserLogin[i].Id);

                    ShopForm shopForm = new ShopForm(listaArtikala);
                    var msg = string.Format("Pozdrav {0}. Uspješno si ulogiran.", lg.UserName);
                    MessageBox.Show(msg);
                    shopForm.Show();
                }
            }
        }

        public int InsertIntoLoginInfo(int id, string time, int username)
        {
            DbConnection dzb = new SqlConnection(@"Server=(LocalDB)\MSSQLLocalDB;Initial Catalog=CoffeeShopApplication;     
                                                            Integrated Security=True");
            using (dzb)
            {
                return dzb.Execute("insert into LoginInfo values (@ID, @DateAndTimeOfLogin, @usernameID)", new { ID = id, DateAndTimeOfLogin = time, usernameID = username });
            }
        }

        public List<Login> ReadAll()
        {
            DbConnection dtb = new SqlConnection(@"Server=(LocalDB)\MSSQLLocalDB;Initial Catalog=CoffeeShopApplication;     
                                                            Integrated Security=True");

            using (dtb)
            {
                return dtb.Query<Login>
                ("Select * From Login").ToList();
            }
        }

        public List<LoginInfo> ReadAllFromLoginInfo()
        {
            DbConnection dlb = new SqlConnection(@"Server=(LocalDB)\MSSQLLocalDB;Initial Catalog=CoffeeShopApplication;     
                                                            Integrated Security=True");

            using (dlb)
            {
                return dlb.Query<LoginInfo>
                ("Select * From LoginInfo").ToList();
            }
        }

        private void btnDodajZaposlenika_Click(object sender, EventArgs e)
        {
            DodajZaposlenika dz = new DodajZaposlenika();
            dz.Show();
        }
    }
}
