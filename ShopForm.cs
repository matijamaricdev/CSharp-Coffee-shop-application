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
    public partial class ShopForm : Form
    {
        public ShopForm()
        {
            InitializeComponent();
        }

        IList<Artikl> artikli;
        IList<object> idevi = new List<object>();
        IList<string> imena = new List<string>() { "Kava", "Kava s mlijekom", "Čaj" };
        
        public ShopForm(IList<Artikl> listaArtikala)
        {
            artikli = listaArtikala;
            InitializeComponent();
            idevi.Add(1 + "-" + imena[0]);
            idevi.Add(2 + "-" + imena[1]);
            idevi.Add(3 + "-" + imena[2]);
            this.comboBox1.DataSource = idevi;
            this.comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        DbConnection db = new SqlConnection(@"Server=(LocalDB)\MSSQLLocalDB;Initial Catalog=CoffeeShopApplication;     
                                                            Integrated Security=True");

        private void btnNastavi_Click(object sender, EventArgs e)
        {
            var artikl = comboBox1.Text;
            int kolicina = Convert.ToInt32(txtKolicina.Text);
            Calculate(artikl, kolicina);
        }

        private void Calculate(string art, int kol)
        {
            int number = Convert.ToInt32(art.Split('-')[0]);

            if (!string.IsNullOrEmpty(lbl2kom.Text))
            {
                if (kol == 1)
                { // ako je sifra artikla 1
                    if (number == 1)
                    {
                        PrviArtiklTreciBroj(art, kol);
                    } //ako je sifra artikla 2
                    else if (number == 2)
                    {
                        int cijena = 10;
                        int konacnaCijena = cijena * kol;
                        int finalCost = Convert.ToInt32(lbl1iznos.Text.Split(' ')[0]) + Convert.ToInt32(lbl2iznos.Text.Split(' ')[0]) + konacnaCijena;
                        lbl3kom.Text = kol.ToString();
                        lbl3artikl.Text = art.Split('-')[1];
                        lbl3cijena.Text = cijena + " kn";
                        lbl3iznos.Text = (cijena * kol).ToString() + " kn";
                        lblKodIznosa.Text = finalCost.ToString() + "kn";
                    } // ako je sifra artikla 3
                    else if (number == 3)
                    {
                        int cijena = 10;
                        int konacnaCijena = cijena * kol;
                        int finalCost = Convert.ToInt32(lbl1iznos.Text.Split(' ')[0]) + Convert.ToInt32(lbl2iznos.Text.Split(' ')[0]) + konacnaCijena;
                        lbl3kom.Text = kol.ToString();
                        lbl3artikl.Text = art.Split('-')[1];
                        lbl3cijena.Text = cijena + " kn";
                        lbl3iznos.Text = (cijena * kol).ToString() + " kn";
                        lblKodIznosa.Text = finalCost.ToString() + "kn";
                    } 
                } // ako je kolicina drugog artikla 2
                else if (kol == 2)
                { // ako je sifra artikla 1
                    if (number == 1)
                    {
                        PrviArtikl(art, kol);
                    } // ako je sifra artikla 2
                    else if (number == 2)
                    {
                        int cijena = 10;
                        int konacnaCijena = cijena * kol;
                        int finalCost = Convert.ToInt32(lbl1iznos.Text.Split(' ')[0]) + konacnaCijena;
                        lbl2kom.Text = kol.ToString();
                        lbl2artikl.Text = art.Split('-')[1];
                        lbl2cijena.Text = cijena + " kn";
                        lbl2iznos.Text = (cijena * kol).ToString() + " kn";
                        lblKodIznosa.Text = finalCost.ToString() + "kn";
                    }
                    else if (number == 3)
                    {
                        int cijena = 10;
                        int konacnaCijena = cijena * kol;
                        int finalCost = Convert.ToInt32(lbl1iznos.Text.Split(' ')[0]) + Convert.ToInt32(lbl2iznos.Text.Split(' ')[0]) + konacnaCijena;
                        lbl3kom.Text = kol.ToString();
                        lbl3artikl.Text = art.Split('-')[1];
                        lbl3cijena.Text = cijena + " kn";
                        lbl3iznos.Text = (cijena * kol).ToString() + " kn";
                        lblKodIznosa.Text = finalCost.ToString() + "kn";
                    }
                }
            } 
            else if (!string.IsNullOrEmpty(lbl1kom.Text))
            { //ako je kolicina drugog artikla 1
                if (kol == 1)
                { // ako je sifra artikla 1
                    if (number == 1)
                    {
                        PrviArtikl(art, kol);
                    } //ako je sifra artikla 2
                    else if (number == 2)
                    {
                        int cijena = 10;
                        int konacnaCijena = cijena * kol;
                        int finalCost = Convert.ToInt32(lbl1iznos.Text.Split(' ')[0]) + konacnaCijena;
                        lbl2kom.Text = kol.ToString();
                        lbl2artikl.Text = art.Split('-')[1];
                        lbl2cijena.Text = cijena + " kn";
                        lbl2iznos.Text = (cijena * kol).ToString() + " kn";
                        lblKodIznosa.Text = finalCost.ToString() + "kn";
                    } // ako je sifra artikla 3
                    else if (number == 3)
                    {
                        int cijena = 10;
                        int konacnaCijena = cijena * kol;
                        int finalCost = Convert.ToInt32(lbl1iznos.Text.Split(' ')[0]) + konacnaCijena;
                        lbl2kom.Text = kol.ToString();
                        lbl2artikl.Text = art.Split('-')[1];
                        lbl2cijena.Text = cijena + " kn";
                        lbl2iznos.Text = (cijena * kol).ToString() + " kn";
                        lblKodIznosa.Text = finalCost.ToString() + "kn";
                    }
                } // ako je kolicina drugog artikla 2
                else if (kol == 2)
                { // ako je sifra artikla 1
                    if (number == 1)
                    {
                        PrviArtikl(art, kol);
                    } // ako je sifra artikla 2
                    else if (number == 2)
                    {
                        int cijena = 10;
                        int konacnaCijena = cijena * kol;
                        int finalCost = Convert.ToInt32(lbl1iznos.Text.Split(' ')[0]) + konacnaCijena;
                        lbl2kom.Text = kol.ToString();
                        lbl2artikl.Text = art.Split('-')[1];
                        lbl2cijena.Text = cijena + " kn";
                        lbl2iznos.Text = (cijena * kol).ToString() + " kn";
                        lblKodIznosa.Text = finalCost.ToString() + "kn";
                    }
                    else if (number == 3)
                    {
                        int cijena = 10;
                        int konacnaCijena = cijena * kol;
                        int finalCost = Convert.ToInt32(lbl1iznos.Text.Split(' ')[0]) + konacnaCijena;
                        lbl2kom.Text = kol.ToString();
                        lbl2artikl.Text = art.Split('-')[1];
                        lbl2cijena.Text = cijena + " kn";
                        lbl2iznos.Text = (cijena * kol).ToString() + " kn";
                        lblKodIznosa.Text = finalCost.ToString() + "kn";
                    }
                }
            }
            else
            {
                if (number == 1)
                {
                    int cijena = 8;
                    lbl1kom.Text = kol.ToString();
                    lbl1artikl.Text = art.Split('-')[1];
                    lbl1cijena.Text = cijena + " kn";
                    lbl1iznos.Text = (cijena * kol).ToString() + " kn";
                    lblKodIznosa.Text = lbl1iznos.Text;
                }
                else if (number == 2)
                {
                    int cijena = 10;
                    lbl1kom.Text = kol.ToString();
                    lbl1artikl.Text = art.Split('-')[1];
                    lbl1cijena.Text = cijena + " kn";
                    lbl1iznos.Text = (cijena * kol).ToString() + " kn";
                    lblKodIznosa.Text = lbl1iznos.Text;
                }
                else if (number == 3)
                {
                    int cijena = 10;
                    lbl1kom.Text = kol.ToString();
                    lbl1artikl.Text = art.Split('-')[1];
                    lbl1cijena.Text = cijena + " kn";
                    lbl1iznos.Text = (cijena * kol).ToString() + " kn";
                    lblKodIznosa.Text = lbl1iznos.Text;
                }
            }
        }

        private void PrviArtikl(string art, int kol)
        {
            int cijena = 8;
            int konacnaCijena = cijena * kol;
            int finalCost = Convert.ToInt32(lbl1iznos.Text.Split(' ')[0]) + konacnaCijena;
            lbl2kom.Text = kol.ToString();
            lbl2artikl.Text = art.Split('-')[1];
            lbl2cijena.Text = cijena + " kn";
            lbl2iznos.Text = (cijena * kol).ToString() + " kn";
            lblKodIznosa.Text = finalCost.ToString() + "kn";
        }

        private void PrviArtiklTreciBroj(string art, int kol)
        {
            int cijena = 8;
            int konacnaCijena = cijena * kol;
            int finalCost = Convert.ToInt32(lbl1iznos.Text.Split(' ')[0]) + Convert.ToInt32(lbl2iznos.Text.Split(' ')[0]) + konacnaCijena;
            lbl3kom.Text = kol.ToString();
            lbl3artikl.Text = art.Split('-')[1];
            lbl3cijena.Text = cijena + " kn";
            lbl3iznos.Text = (cijena * kol).ToString() + " kn";
            lblKodIznosa.Text = finalCost.ToString() + "kn";
        }
    }
}
