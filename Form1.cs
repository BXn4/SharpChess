using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SharpChess
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int x = -75;
        int y = 0;
        int sor = 0;
        int sorszam = 0;
        int mezokx = -56;
        int mezoky = 18;
        int index = 0;
        List<string> mezokneve = new List<string>
        {
           "a8","b8","c8","d8","e8","f8","g8","h8","üres","üres","h7","g7","f7","e7","d7","c7","b7","a7","üres","üres",
           "a6","b6","c6","d6","e6","f6","g6","h6","üres","üres","h5","g5","f5","e5","d5","c5","b5","a5","üres","üres",
           "a4","b4","c4","d4","e4","f4","g4","h4","üres","üres","h3","g3","f3","e3","d3","c3","b3","a3","üres","üres",
           "a2","b2","c2","d2","e2","f2","g2","h2","üres","üres","h1","g1","f1","e1","d1","c1","b1","a1","üres","üres"
        };
        List<string> erremehet = new List<string> { };
        string w_babu1helye = "a2";
        private void Form1_Load(object sender, EventArgs e)
        {
            uj_jatek.Parent = board;
            uj_jatek.BackColor = Color.Transparent;
            beallitasok.Parent = board;
            beallitasok.BackColor = Color.Transparent;
            kilepes.Parent = board;
            kilepes.BackColor = Color.Transparent;
            alap.Parent = board;
            alap.BackColor = Color.Transparent;
            egyedi.Parent = board;
            egyedi.BackColor = Color.Transparent;
            vissza_jatek.Parent = board;
            vissza_jatek.BackColor = Color.Transparent;
        }

        private void place_Tick(object sender, EventArgs e)
        {
            if (sor < 8)
            {
                if (x < 610 && x > -76)
                {
                    if (sor == 0)
                    {
                        if (sor % 2 == 0)
                        {
                            x += 75;
                        }
                        else
                        {
                            x -= 75;
                        }
                    }
                    else
                    {
                        if (sor % 2 == 0)
                        {
                            x += 75;
                        }
                        else
                        {
                            x -= 75;
                        }
                    }
                    if (sorszam == 0)
                    {
                        sorszam = 1;
                        /*mezokx += 75;
                        var mezok = new PictureBox
                        {
                            Name = "a",
                            Size = new Size(40, 40),
                            Location = new Point(mezokx, mezoky),
                            BackColor = Color.FromArgb(128, 64, 0),
                            Tag = "feher"
                        };
                        Controls.Add(mezok);*/
                        var feher = new PictureBox
                        {
                            Name = mezokneve[index],
                            Size = new Size(75, 75),
                            Location = new Point(x, y),
                            BackColor = Color.FromArgb(235, 236, 208),
                            Tag = "feher"
                        };
                        //MessageBox.Show($"{mezokneve[index]}");
                        index++;
                        Controls.Add(feher);
                        feher.Click += new EventHandler(feherkatt);
                    }
                    else
                    {
                        /*mezokx += 75;
                        var mezok = new PictureBox
                        {
                            Name = "a",
                            Size = new Size(40, 40),
                            Location = new Point(mezokx, mezoky),
                            BackColor = Color.FromArgb(128, 64, 0),
                            Tag = "feher"
                        };
                        Controls.Add(mezok);*/
                        var fekete = new PictureBox
                        {
                            Name = mezokneve[index],
                            Size = new Size(75, 75),
                            Location = new Point(x, y),
                            BackColor = Color.FromArgb(119, 149, 86),
                            Tag = "fekete"
                        };
                        Controls.Add(fekete);
                        fekete.Click += new EventHandler(feketekatt);
                        //MessageBox.Show($"{mezokneve[index]}");
                        index++;
                        sorszam = 0;
                    }
                }
                else
                {
                    sor++;
                    mezokx = -56;
                    if (sor % 2 == 0)
                    {
                        x = -75;
                    }
                    else
                    {
                        x = 600;
                        mezokx = -56;
                    }
                    y += 75;
                    mezoky += 75;
                }
            }
            else
            {
                //board.Visible = true;
                babulerak();
                place.Stop();
            }
        }

        private void babucheck_Tick(object sender, EventArgs e)
        {
            //w_babu1.Location = new Point(Cursor.Position.X -600 , Cursor.Position.Y);
            foreach (Control x in this.Controls)
            {
                if (x is PictureBox)
                {
                    if ((string)x.Tag == "feher")
                    {
                        if (b_bastya1.Bounds.IntersectsWith(x.Bounds))
                        {
                            b_bastya1.BackColor = Color.FromArgb(235, 236, 208);
                        }
                        if (b_huszar1.Bounds.IntersectsWith(x.Bounds))
                        {
                            b_huszar1.BackColor = Color.FromArgb(235, 236, 208);
                        }
                        if (b_futo1.Bounds.IntersectsWith(x.Bounds))
                        {
                            b_futo1.BackColor = Color.FromArgb(235, 236, 208);
                        }
                        if (b_kiraly.Bounds.IntersectsWith(x.Bounds))
                        {
                            b_kiraly.BackColor = Color.FromArgb(235, 236, 208);
                        }
                        if (b_kiralyno.Bounds.IntersectsWith(x.Bounds))
                        {
                            b_kiralyno.BackColor = Color.FromArgb(235, 236, 208);
                        }
                        if (b_futo2.Bounds.IntersectsWith(x.Bounds))
                        {
                            b_futo2.BackColor = Color.FromArgb(235, 236, 208);
                        }
                        if (b_huszar2.Bounds.IntersectsWith(x.Bounds))
                        {
                            b_huszar2.BackColor = Color.FromArgb(235, 236, 208);
                        }
                        if (b_bastya2.Bounds.IntersectsWith(x.Bounds))
                        {
                            b_bastya2.BackColor = Color.FromArgb(235, 236, 208);
                        }
                        if (b_babu1.Bounds.IntersectsWith(x.Bounds))
                        {
                            b_babu1.BackColor = Color.FromArgb(235, 236, 208);
                        }
                        if (b_babu2.Bounds.IntersectsWith(x.Bounds))
                        {
                            b_babu2.BackColor = Color.FromArgb(235, 236, 208);
                        }
                        if (b_babu3.Bounds.IntersectsWith(x.Bounds))
                        {
                            b_babu3.BackColor = Color.FromArgb(235, 236, 208);
                        }
                        if (b_babu4.Bounds.IntersectsWith(x.Bounds))
                        {
                            b_babu4.BackColor = Color.FromArgb(235, 236, 208);
                        }
                        if (b_babu5.Bounds.IntersectsWith(x.Bounds))
                        {
                            b_babu5.BackColor = Color.FromArgb(235, 236, 208);
                        }
                        if (b_babu6.Bounds.IntersectsWith(x.Bounds))
                        {
                            b_babu6.BackColor = Color.FromArgb(235, 236, 208);
                        }
                        if (b_babu7.Bounds.IntersectsWith(x.Bounds))
                        {
                            b_babu7.BackColor = Color.FromArgb(235, 236, 208);
                        }
                        if (b_babu8.Bounds.IntersectsWith(x.Bounds))
                        {
                            b_babu8.BackColor = Color.FromArgb(235, 236, 208);
                        }
                        if (w_bastya1.Bounds.IntersectsWith(x.Bounds))
                        {
                            w_bastya1.BackColor = Color.FromArgb(235, 236, 208);
                        }
                        if (w_huszar1.Bounds.IntersectsWith(x.Bounds))
                        {
                            w_huszar1.BackColor = Color.FromArgb(235, 236, 208);
                        }
                        if (w_futo1.Bounds.IntersectsWith(x.Bounds))
                        {
                            w_futo1.BackColor = Color.FromArgb(235, 236, 208);
                        }
                        if (w_kiraly.Bounds.IntersectsWith(x.Bounds))
                        {
                            w_kiraly.BackColor = Color.FromArgb(235, 236, 208);
                        }
                        if (w_kiralyno.Bounds.IntersectsWith(x.Bounds))
                        {
                            w_kiralyno.BackColor = Color.FromArgb(235, 236, 208);
                        }
                        if (w_futo2.Bounds.IntersectsWith(x.Bounds))
                        {
                            w_futo2.BackColor = Color.FromArgb(235, 236, 208);
                        }
                        if (w_huszar2.Bounds.IntersectsWith(x.Bounds))
                        {
                            w_huszar2.BackColor = Color.FromArgb(235, 236, 208);
                        }
                        if (w_bastya2.Bounds.IntersectsWith(x.Bounds))
                        {
                            w_bastya2.BackColor = Color.FromArgb(235, 236, 208);
                        }
                        if (w_babu1.Bounds.IntersectsWith(x.Bounds))
                        {
                            w_babu1.BackColor = Color.FromArgb(235, 236, 208);
                        }
                        if (w_babu2.Bounds.IntersectsWith(x.Bounds))
                        {
                            w_babu2.BackColor = Color.FromArgb(235, 236, 208);
                        }
                        if (w_babu3.Bounds.IntersectsWith(x.Bounds))
                        {
                            w_babu3.BackColor = Color.FromArgb(235, 236, 208);
                        }
                        if (w_babu4.Bounds.IntersectsWith(x.Bounds))
                        {
                            w_babu4.BackColor = Color.FromArgb(235, 236, 208);
                        }
                        if (w_babu5.Bounds.IntersectsWith(x.Bounds))
                        {
                            w_babu5.BackColor = Color.FromArgb(235, 236, 208);
                        }
                        if (w_babu6.Bounds.IntersectsWith(x.Bounds))
                        {
                            w_babu6.BackColor = Color.FromArgb(235, 236, 208);
                        }
                        if (w_babu7.Bounds.IntersectsWith(x.Bounds))
                        {
                            w_babu7.BackColor = Color.FromArgb(235, 236, 208);
                        }
                        if (w_babu8.Bounds.IntersectsWith(x.Bounds))
                        {
                            w_babu8.BackColor = Color.FromArgb(235, 236, 208);
                        }

                    }
                    if ((string)x.Tag == "fekete")
                    {
                        if (b_bastya1.Bounds.IntersectsWith(x.Bounds))
                        {
                            b_bastya1.BackColor = Color.FromArgb(119, 149, 86);
                        }
                        if (b_huszar1.Bounds.IntersectsWith(x.Bounds))
                        {
                            b_huszar1.BackColor = Color.FromArgb(119, 149, 86);
                        }
                        if (b_futo1.Bounds.IntersectsWith(x.Bounds))
                        {
                            b_futo1.BackColor = Color.FromArgb(119, 149, 86);
                        }
                        if (b_kiraly.Bounds.IntersectsWith(x.Bounds))
                        {
                            b_kiraly.BackColor = Color.FromArgb(119, 149, 86);
                        }
                        if (b_kiralyno.Bounds.IntersectsWith(x.Bounds))
                        {
                            b_kiralyno.BackColor = Color.FromArgb(119, 149, 86);
                        }
                        if (b_futo2.Bounds.IntersectsWith(x.Bounds))
                        {
                            b_futo2.BackColor = Color.FromArgb(119, 149, 86);
                        }
                        if (b_huszar2.Bounds.IntersectsWith(x.Bounds))
                        {
                            b_huszar2.BackColor = Color.FromArgb(119, 149, 86);
                        }
                        if (b_bastya2.Bounds.IntersectsWith(x.Bounds))
                        {
                            b_bastya2.BackColor = Color.FromArgb(119, 149, 86);
                        }
                        if (b_babu1.Bounds.IntersectsWith(x.Bounds))
                        {
                            b_babu1.BackColor = Color.FromArgb(119, 149, 86);
                        }
                        if (b_babu2.Bounds.IntersectsWith(x.Bounds))
                        {
                            b_babu2.BackColor = Color.FromArgb(119, 149, 86);
                        }
                        if (b_babu3.Bounds.IntersectsWith(x.Bounds))
                        {
                            b_babu3.BackColor = Color.FromArgb(119, 149, 86);
                        }
                        if (b_babu4.Bounds.IntersectsWith(x.Bounds))
                        {
                            b_babu4.BackColor = Color.FromArgb(119, 149, 86);
                        }
                        if (b_babu5.Bounds.IntersectsWith(x.Bounds))
                        {
                            b_babu5.BackColor = Color.FromArgb(119, 149, 86);
                        }
                        if (b_babu6.Bounds.IntersectsWith(x.Bounds))
                        {
                            b_babu6.BackColor = Color.FromArgb(119, 149, 86);
                        }
                        if (b_babu7.Bounds.IntersectsWith(x.Bounds))
                        {
                            b_babu7.BackColor = Color.FromArgb(119, 149, 86);
                        }
                        if (b_babu8.Bounds.IntersectsWith(x.Bounds))
                        {
                            b_babu8.BackColor = Color.FromArgb(119, 149, 86);
                        }
                        if (w_bastya1.Bounds.IntersectsWith(x.Bounds))
                        {
                            w_bastya1.BackColor = Color.FromArgb(119, 149, 86);
                        }
                        if (w_huszar1.Bounds.IntersectsWith(x.Bounds))
                        {
                            w_huszar1.BackColor = Color.FromArgb(119, 149, 86);
                        }
                        if (w_futo1.Bounds.IntersectsWith(x.Bounds))
                        {
                            w_futo1.BackColor = Color.FromArgb(119, 149, 86);
                        }
                        if (w_kiraly.Bounds.IntersectsWith(x.Bounds))
                        {
                            w_kiraly.BackColor = Color.FromArgb(119, 149, 86);
                        }
                        if (w_kiralyno.Bounds.IntersectsWith(x.Bounds))
                        {
                            w_kiralyno.BackColor = Color.FromArgb(119, 149, 86);
                        }
                        if (w_futo2.Bounds.IntersectsWith(x.Bounds))
                        {
                            w_futo2.BackColor = Color.FromArgb(119, 149, 86);
                        }
                        if (w_huszar2.Bounds.IntersectsWith(x.Bounds))
                        {
                            w_huszar2.BackColor = Color.FromArgb(119, 149, 86);
                        }
                        if (w_bastya2.Bounds.IntersectsWith(x.Bounds))
                        {
                            w_bastya2.BackColor = Color.FromArgb(119, 149, 86);
                        }
                        if (w_babu1.Bounds.IntersectsWith(x.Bounds))
                        {
                            w_babu1.BackColor = Color.FromArgb(119, 149, 86);
                        }
                        if (w_babu2.Bounds.IntersectsWith(x.Bounds))
                        {
                            w_babu2.BackColor = Color.FromArgb(119, 149, 86);
                        }
                        if (w_babu3.Bounds.IntersectsWith(x.Bounds))
                        {
                            w_babu3.BackColor = Color.FromArgb(119, 149, 86);
                        }
                        if (w_babu4.Bounds.IntersectsWith(x.Bounds))
                        {
                            w_babu4.BackColor = Color.FromArgb(119, 149, 86);
                        }
                        if (w_babu5.Bounds.IntersectsWith(x.Bounds))
                        {
                            w_babu5.BackColor = Color.FromArgb(119, 149, 86);
                        }
                        if (w_babu6.Bounds.IntersectsWith(x.Bounds))
                        {
                            w_babu6.BackColor = Color.FromArgb(119, 149, 86);
                        }
                        if (w_babu7.Bounds.IntersectsWith(x.Bounds))
                        {
                            w_babu7.BackColor = Color.FromArgb(119, 149, 86);
                        }
                        if (w_babu8.Bounds.IntersectsWith(x.Bounds))
                        {
                            w_babu8.BackColor = Color.FromArgb(119, 149, 86);
                        }
                    }
                }
            }
        }

        private void b_kiralyno_Click(object sender, EventArgs e)
        {

        }

        private void uj_jatek_Click(object sender, EventArgs e)
        {
            alap.Visible = true;
            egyedi.Visible = true;
            vissza_jatek.Visible = true;
        }

        private void vissza_jatek_Click(object sender, EventArgs e)
        {
            alap.Visible = false;
            egyedi.Visible = false;
            vissza_jatek.Visible = false;
        }

        private void jatek_menu_Click(object sender, EventArgs e)
        {

        }

        private void uj_jatek_MouseEnter(object sender, EventArgs e)
        {
            uj_jatek.Font = new Font("Microsoft Sans Serif", 20, FontStyle.Bold);
        }

        private void uj_jatek_MouseLeave(object sender, EventArgs e)
        {
            uj_jatek.Font = new Font("Microsoft Sans Serif", 20, FontStyle.Regular);
        }

        private void beallitasok_MouseEnter(object sender, EventArgs e)
        {
            beallitasok.Font = new Font("Microsoft Sans Serif", 20, FontStyle.Bold);
        }

        private void beallitasok_MouseLeave(object sender, EventArgs e)
        {
            beallitasok.Font = new Font("Microsoft Sans Serif", 20, FontStyle.Regular);
        }

        private void kilepes_MouseEnter(object sender, EventArgs e)
        {
            kilepes.Font = new Font("Microsoft Sans Serif", 20, FontStyle.Bold);
        }

        private void kilepes_MouseLeave(object sender, EventArgs e)
        {
            kilepes.Font = new Font("Microsoft Sans Serif", 20, FontStyle.Regular);
        }

        private void vissza_jatek_MouseEnter(object sender, EventArgs e)
        {
            vissza_jatek.Font = new Font("Microsoft Sans Serif", 20, FontStyle.Bold);
        }

        private void vissza_jatek_MouseLeave(object sender, EventArgs e)
        {
            vissza_jatek.Font = new Font("Microsoft Sans Serif", 20, FontStyle.Regular);
        }

        private void kilepes_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        bool jatek_elindult = false;
        private void alap_Click(object sender, EventArgs e)
        {
            board.Visible = false;
            uj_jatek.Visible = false;
            beallitasok.Visible = false;
            kilepes.Visible = false;
            alap.Visible = false;
            egyedi.Visible = false;
            vissza_jatek.Visible = false;
            jatek_elindult = true;
            jatek.Start();
        }

        private void alap_MouseEnter(object sender, EventArgs e)
        {
            alap.Font = new Font("Microsoft Sans Serif", 20, FontStyle.Bold);
        }

        private void alap_MouseLeave(object sender, EventArgs e)
        {
            alap.Font = new Font("Microsoft Sans Serif", 20, FontStyle.Regular);
        }

        private void leraklephet_Tick(object sender, EventArgs e)
        {

        }
        void feherkatt(object sender, EventArgs e)
        {
            PictureBox kattintas = (PictureBox)sender;
            if (kattintas != null)
            {
                MessageBox.Show(kattintas.Name + " mező");
            }
        }
        void feketekatt(object sender, EventArgs e)
        {
            PictureBox kattintas = (PictureBox)sender;
            if (kattintas != null)
            {
                MessageBox.Show(kattintas.Name + " mező");
            }
        }
        private void jatek_Tick(object sender, EventArgs e)
        {
            Point kurzor = PointToClient(Cursor.Position);
            if(babutfog == true)
            w_babu1.Location = new Point(kurzor.X - 25 ,kurzor.Y - 25);
        }
        private void babuklerak_Tick(object sender, EventArgs e)
        {
            
        }
        bool babutfog = false;
        private void w_babu1_MouseDown(object sender, MouseEventArgs e)
        {
            w_babu1.Size = new Size(60, 60);
            w_babu1.Location = new Point(w_babu1.Location.X - 5, w_babu1.Location.Y - 5);
            babutfog = true;
        }

        private void w_babu1_MouseUp(object sender, MouseEventArgs e)
        {
            w_babu1.Size = new Size(50, 50);
            w_babu1.Location = new Point(w_babu1.Location.X + 5, w_babu1.Location.Y + 5);
            babutfog = false;
            foreach (Control control in this.Controls)
            {
                if (w_babu1helye == "a2")
                    if (control.Name == "a3" || control.Name == "a4")
                    {
                        if (w_babu1.Bounds.IntersectsWith(control.Bounds))
                        {
                            MessageBox.Show("a");
                            //w_babu1helye = control.Name;
                        }
                    }
            }
        }

        private void w_babu2_MouseDown(object sender, MouseEventArgs e)
        {
            w_babu2.Size = new Size(60, 60);
            w_babu2.Location = new Point(w_babu2.Location.X - 5, w_babu2.Location.Y - 5);
        }

        private void w_babu2_MouseUp(object sender, MouseEventArgs e)
        {
            w_babu2.Size = new Size(50, 50);
            w_babu2.Location = new Point(w_babu2.Location.X + 5, w_babu2.Location.Y + 5);
        }

        private void w_babu3_MouseDown(object sender, MouseEventArgs e)
        {
            w_babu3.Size = new Size(60, 60);
            w_babu3.Location = new Point(w_babu3.Location.X - 5, w_babu3.Location.Y - 5);
        }

        private void w_babu3_MouseUp(object sender, MouseEventArgs e)
        {
            w_babu3.Size = new Size(50, 50);
            w_babu3.Location = new Point(w_babu3.Location.X + 5, w_babu3.Location.Y + 5);
        }

        private void w_babu4_MouseDown(object sender, MouseEventArgs e)
        {
            w_babu4.Size = new Size(60, 60);
            w_babu4.Location = new Point(w_babu4.Location.X - 5, w_babu4.Location.Y - 5);
        }

        private void w_babu4_MouseUp(object sender, MouseEventArgs e)
        {
            w_babu4.Size = new Size(50, 50);
            w_babu4.Location = new Point(w_babu4.Location.X + 5, w_babu4.Location.Y + 5);
        }

        private void w_babu5_MouseDown(object sender, MouseEventArgs e)
        {
            w_babu5.Size = new Size(60, 60);
            w_babu5.Location = new Point(w_babu5.Location.X - 5, w_babu5.Location.Y - 5);
        }

        private void w_babu5_MouseUp(object sender, MouseEventArgs e)
        {
            w_babu5.Size = new Size(50, 50);
            w_babu5.Location = new Point(w_babu5.Location.X + 5, w_babu5.Location.Y + 5);
        }

        private void w_babu6_MouseDown(object sender, MouseEventArgs e)
        {
            w_babu6.Size = new Size(60, 60);
            w_babu6.Location = new Point(w_babu6.Location.X - 5, w_babu6.Location.Y - 5);
        }

        private void w_babu6_MouseUp(object sender, MouseEventArgs e)
        {
            w_babu6.Size = new Size(50, 50);
            w_babu6.Location = new Point(w_babu6.Location.X + 5, w_babu6.Location.Y + 5);
        }

        private void w_babu7_MouseDown(object sender, MouseEventArgs e)
        {
            w_babu7.Size = new Size(60, 60);
            w_babu7.Location = new Point(w_babu7.Location.X - 5, w_babu7.Location.Y - 5);
        }

        private void w_babu7_MouseUp(object sender, MouseEventArgs e)
        {
            w_babu7.Size = new Size(50, 50);
            w_babu7.Location = new Point(w_babu7.Location.X + 5, w_babu7.Location.Y + 5);
        }

        private void w_babu8_MouseDown(object sender, MouseEventArgs e)
        {
            w_babu8.Size = new Size(60, 60);
            w_babu8.Location = new Point(w_babu8.Location.X - 5, w_babu8.Location.Y - 5);
        }

        private void w_babu8_MouseUp(object sender, MouseEventArgs e)
        {
            w_babu8.Size = new Size(50, 50);
            w_babu8.Location = new Point(w_babu8.Location.X + 5, w_babu8.Location.Y + 5);
        }

        private void w_bastya1_MouseDown(object sender, MouseEventArgs e)
        {
            w_bastya1.Size = new Size(60, 60);
            w_bastya1.Location = new Point(w_bastya1.Location.X - 5, w_bastya1.Location.Y - 5);
        }

        private void w_bastya1_MouseUp(object sender, MouseEventArgs e)
        {
            w_bastya1.Size = new Size(50, 50);
            w_bastya1.Location = new Point(w_bastya1.Location.X + 5, w_bastya1.Location.Y + 5);
        }

        private void w_huszar2_MouseDown(object sender, MouseEventArgs e)
        {
            w_huszar2.Size = new Size(60, 60);
            w_huszar2.Location = new Point(w_huszar2.Location.X - 5, w_huszar2.Location.Y - 5);
        }

        private void w_huszar2_MouseUp(object sender, MouseEventArgs e)
        {
            w_huszar2.Size = new Size(50,50);
            w_huszar2.Location = new Point(w_huszar2.Location.X + 5, w_huszar2.Location.Y + 5);
        }

        private void w_huszar1_MouseDown(object sender, MouseEventArgs e)
        {
            w_huszar1.Size = new Size(60, 60);
            w_huszar1.Location = new Point(w_huszar1.Location.X - 5, w_huszar1.Location.Y - 5);
        }

        private void w_huszar1_MouseUp(object sender, MouseEventArgs e)
        {
            w_huszar1.Size = new Size(50, 50);
            w_huszar1.Location = new Point(w_huszar1.Location.X + 5, w_huszar1.Location.Y + 5);
        }

        private void w_futo2_MouseDown(object sender, MouseEventArgs e)
        {
            w_futo2.Size = new Size(60, 60);
            w_futo2.Location = new Point(w_futo2.Location.X - 5, w_futo2.Location.Y - 5);
        }

        private void w_futo2_MouseUp(object sender, MouseEventArgs e)
        {
            w_futo2.Size = new Size(50, 50);
            w_futo2.Location = new Point(w_futo2.Location.X + 5, w_futo2.Location.Y + 5);
        }

        private void w_futo1_MouseEnter(object sender, EventArgs e)
        {
            
        }

        private void w_futo1_MouseDown(object sender, MouseEventArgs e)
        {
            w_futo1.Size = new Size(60, 60);
            w_futo1.Location = new Point(w_futo1.Location.X - 5, w_futo1.Location.Y - 5);
        }

        private void w_futo1_MouseUp(object sender, MouseEventArgs e)
        {
            w_futo1.Size = new Size(50, 50);
            w_futo1.Location = new Point(w_futo1.Location.X + 5, w_futo1.Location.Y + 5);
        }

        private void w_kiraly_MouseDown(object sender, MouseEventArgs e)
        {
            w_kiraly.Size = new Size(60, 60);
            w_kiraly.Location = new Point(w_kiraly.Location.X - 5, w_kiraly.Location.Y - 5);
        }

        private void w_kiraly_MouseUp(object sender, MouseEventArgs e)
        {
            w_kiraly.Size = new Size(50, 50);
            w_kiraly.Location = new Point(w_kiraly.Location.X + 5, w_kiraly.Location.Y + 5);
        }

        private void w_kiralyno_MouseDown(object sender, MouseEventArgs e)
        {
            w_kiralyno.Size = new Size(60, 60);
            w_kiralyno.Location = new Point(w_kiralyno.Location.X - 5, w_kiralyno.Location.Y - 5);
        }

        private void w_kiralyno_MouseUp(object sender, MouseEventArgs e)
        {
            w_kiralyno.Size = new Size(50, 50);
            w_kiralyno.Location = new Point(w_kiralyno.Location.X + 5, w_kiralyno.Location.Y + 5);
        }

        private void w_bastya2_MouseDown(object sender, MouseEventArgs e)
        {
            w_bastya2.Size = new Size(60, 60);
            w_bastya2.Location = new Point(w_bastya2.Location.X - 5, w_bastya2.Location.Y - 5);
        }

        private void w_bastya2_MouseUp(object sender, MouseEventArgs e)
        {
            w_bastya2.Size = new Size(50,50);
            w_bastya2.Location = new Point(w_bastya2.Location.X + 5, w_bastya2.Location.Y + 5);
        }

        private void w_babu4_Click(object sender, EventArgs e)
        {

        }
        int babulerakx = 13;
        int babuleraky = 13;
        private async void babulerak()
        {
            for (int i = 0; i < 33; i++)
            {
                await Task.Delay(100);
                switch (i)
                {
                    case 0:
                        b_bastya1.Location = new Point(babulerakx, babuleraky);
                        break;
                    case 1:
                        b_huszar1.Location = new Point(babulerakx += 75, babuleraky);
                        break;
                    case 2:
                        b_futo1.Location = new Point(babulerakx += 75, babuleraky);
                        break;
                    case 3:
                        b_kiraly.Location = new Point(babulerakx += 75, babuleraky);
                        break;
                    case 4:
                        break;
                    case 5:
                        b_kiralyno.Location = new Point(babulerakx += 75, babuleraky);
                        break;
                    case 6:
                        b_futo2.Location = new Point(babulerakx += 75, babuleraky);
                        break;
                    case 7:
                        b_huszar2.Location = new Point(babulerakx += 75, babuleraky);
                        break;
                    case 8:
                        b_bastya2.Location = new Point(babulerakx += 75, babuleraky);
                        babulerakx = 13;
                        babuleraky = 88;
                        break;
                    case 9:
                        b_babu1.Location = new Point(babulerakx, babuleraky);
                        break;
                    case 10:
                        b_babu2.Location = new Point(babulerakx += 75, babuleraky);
                        break;
                    case 11:
                        b_babu3.Location = new Point(babulerakx += 75, babuleraky);
                        break;
                    case 12:
                        b_babu4.Location = new Point(babulerakx += 75, babuleraky);
                        break;
                    case 13:
                        b_babu5.Location = new Point(babulerakx += 75, babuleraky);
                        break;
                    case 14:
                        b_babu6.Location = new Point(babulerakx += 75, babuleraky);
                        break;
                    case 15:
                        b_babu7.Location = new Point(babulerakx += 75, babuleraky);
                        break;
                    case 16:
                        b_babu8.Location = new Point(babulerakx += 75, babuleraky);
                        babulerakx = 13;
                        babuleraky = 537;
                        break;
                    case 17:
                        w_bastya1.Location = new Point(babulerakx, babuleraky);
                        break;
                    case 18:
                        w_huszar1.Location = new Point(babulerakx += 75, babuleraky);
                        break;
                    case 19:
                        w_futo1.Location = new Point(babulerakx += 75, babuleraky);
                        break;
                    case 20:
                        w_kiraly.Location = new Point(babulerakx += 75, babuleraky);
                        break;
                    case 21:
                        w_kiralyno.Location = new Point(babulerakx += 75, babuleraky);
                        break;
                    case 22:
                        w_futo2.Location = new Point(babulerakx += 75, babuleraky);
                        break;
                    case 23:
                        w_huszar2.Location = new Point(babulerakx += 75, babuleraky);
                        break;
                    case 24:
                        w_bastya2.Location = new Point(babulerakx += 75, babuleraky);
                        babulerakx = 13;
                        babuleraky = 464;
                        break;
                    case 25:
                        w_babu1.Location = new Point(babulerakx, babuleraky);
                        break;
                    case 26:
                        w_babu2.Location = new Point(babulerakx += 75, babuleraky);
                        break;
                    case 27:
                        w_babu3.Location = new Point(babulerakx += 75, babuleraky);
                        break;
                    case 28:
                        w_babu4.Location = new Point(babulerakx += 75, babuleraky);
                        break;
                    case 29:
                        w_babu5.Location = new Point(babulerakx += 75, babuleraky);
                        break;
                    case 30:
                        w_babu6.Location = new Point(babulerakx += 75, babuleraky);
                        break;
                    case 31:
                        w_babu7.Location = new Point(babulerakx += 75, babuleraky);
                        break;
                    case 32:
                        w_babu8.Location = new Point(babulerakx += 75, babuleraky);
                        break;
                }
                if(i == 32)
                {
                    break;
                }
            }
            this.Size = new Size(615, 695);
            //Application.Restart();
        }
    }
}
