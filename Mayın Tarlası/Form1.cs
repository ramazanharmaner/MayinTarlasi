using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Mayın_Tarlası
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //Başlangıç Kordinati (372,332)
        String kaydet;
        bool kaydetKontrol = false,dereceKontrol = false,bitis = false;
        int mayinSayisi=0,konum=389,etraftakiMayinlarDegisken=0;
        int[] mayinliBolge = new int[80];
        int dakikaBirler = 0, dakikaOnlar = 0, saniyeBirler = 0, saniyeOnlar = 0;
        PictureBox[] resimler = new PictureBox[400];

        private void button4_Click(object sender, EventArgs e)
        {
            if(kaydetKontrol)
            {
                kontrolFonksiyon();
                if (oyuncuPicture.Location.Y <= 47)
                {
                    MessageBox.Show("Sınıra Ulaştınız !" , "Mayın Tarlası" , MessageBoxButtons.OK , MessageBoxIcon.Information);
                }
                else
                {
                    resimler[konum].BackColor = Color.White;
                    konum -= 20;
                    oyuncuPicture.Location = new Point(oyuncuPicture.Location.X, oyuncuPicture.Location.Y - 15);
                    zamanYazdir.Enabled = true;
                    etraftakiMayinlarDegisken = 0;
                    etraftakiMayinlar();
                    mayinYazdir.Enabled = true;
                    
                    if (oyuncuPicture.Location.Y == 47)
                    {
                        resimler[konum].BackColor = Color.White;
                    }

                }
            }
            else
            {
                mesajGoster();
            }



        }

        private void button7_Click(object sender, EventArgs e)
        {
            if(kaydetKontrol)
            {
                kontrolFonksiyon();
                if (oyuncuPicture.Location.X <= 237)
                {
                    MessageBox.Show("Sınıra Ulaştınız !", "Mayın Tarlası", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    resimler[konum].BackColor = Color.White;
                    konum -= 1;
                    oyuncuPicture.Location = new Point(oyuncuPicture.Location.X - 15, oyuncuPicture.Location.Y);
                    zamanYazdir.Enabled = true;
                    etraftakiMayinlarDegisken = 0;
                    etraftakiMayinlar();
                    mayinYazdir.Enabled = true;
                    
                }
            }
            else
            {
                mesajGoster();
            }

        }

        private void button6_Click(object sender, EventArgs e)
        {
            if(kaydetKontrol)
            {
                kontrolFonksiyon();
                if (oyuncuPicture.Location.X >= 522)
                {
                    MessageBox.Show("Sınıra Ulaştınız !", "Mayın Tarlası", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    resimler[konum].BackColor = Color.White;
                    konum += 1;
                    oyuncuPicture.Location = new Point(oyuncuPicture.Location.X + 15, oyuncuPicture.Location.Y);
                    zamanYazdir.Enabled = true;
                    etraftakiMayinlarDegisken = 0;
                    etraftakiMayinlar();
                    mayinYazdir.Enabled = true;
                    
                }
            }
            else
            {
                mesajGoster();
            }


        }
        private void button5_Click(object sender, EventArgs e)
        {
            if(kaydetKontrol)
            {
                kontrolFonksiyon();
                {
                    if (oyuncuPicture.Location.Y >= 332)
                    {
                        MessageBox.Show("Sınıra Ulaştınız !", "Mayın Tarlası", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        resimler[konum].BackColor = Color.White;
                        konum += 20;
                        oyuncuPicture.Location = new Point(oyuncuPicture.Location.X, oyuncuPicture.Location.Y + 15);
                        zamanYazdir.Enabled = true;
                        etraftakiMayinlarDegisken = 0;
                        etraftakiMayinlar();
                        mayinYazdir.Enabled = true;
                    }
                }
            }
            else
            {
                mesajGoster();
            }
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            oyuncuPicture.Visible = false;
        }

        void kutucukYerlestir()
        {
            for (int i = 0; i < 400; i++)
            {
                PictureBox kutucuk = new PictureBox();
                kutucuk.Width = 15;
                kutucuk.Height = 15;
                kutucuk.BackColor = Color.Cyan;
                kutucuk.SizeMode = PictureBoxSizeMode.StretchImage;

                kutucuk.Margin = new Padding(0);
                flowLayoutPanel1.Controls.Add(kutucuk);

                resimler[i] = kutucuk;
            }
        }

        void mayinYerlestir()
        {
            Random ata = new Random();
           

            for (int i = 0; i < mayinSayisi; i++)
            {
                int t;
                t = ata.Next(0, 400);

                mayinliBolge[i] = t;
               // resimler[t].Image = Properties.Resources.mayin;
            }
            timer1.Enabled = true;
        }
        void degerUret()  //range deger aynı olursa degistir
        {
            int sayac = 0,t=0;
            Random ata = new Random();
            for(int i = 0; i<mayinSayisi; i++)
            {
                for(int j = 0; j<mayinSayisi; j++)
                {
                    if(j != i)
                    {
                        if(mayinliBolge[j] == mayinliBolge[i])
                        {
                            t = ata.Next(0,400);
                            mayinliBolge[i] = t;
                           // resimler[t].Image = Properties.Resources.mayin;
                            sayac++;
                        }
                    }
                }
            }
            if(sayac == 0)
            {
                timer1.Enabled = false;
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            degerUret();

        }
        void etraftakiMayinlar()
        {
            for (int i = 0; i < mayinSayisi; i++)
            {
                if ((konum == mayinliBolge[i] - 20) || (konum == mayinliBolge[i] + 20) || (konum == mayinliBolge[i] - 1) || (konum == mayinliBolge[i] + 1))
                {
                    etraftakiMayinlarDegisken += 1;
                    
                } 
                if(konum == mayinliBolge[i])
                {
                    oyunbitti("Kaybettiniz");
                }       
            }

        }
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if(radioButton1.Checked)
            {
                dereceKontrol = true;
                mayinSayisi = 40;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                dereceKontrol = true;
                mayinSayisi = 50;
            }
        }

        private void timerKontrol_Tick(object sender, EventArgs e)
        {
            if((resimler[0].Image != null) && (resimler[19].Image != null))
            {
                if(oyuncuPicture.Location.Y == 47)
                {
                    timerKontrol.Enabled = false;
                    zamanYazdir.Enabled = false;
                    MessageBox.Show("Tebrikler Oyunu Kazandınız.", "Mayın Tarlası" , MessageBoxButtons.OK , MessageBoxIcon.Information);
                    oyunbitti("Kazandınız");
                    
                }
            }
            else if ((resimler[0].Image == null) || (resimler[19].Image == null))
            {
                if ((oyuncuPicture.Location.X == 237) && (oyuncuPicture.Location.Y == 47))
                {
                    timerKontrol.Enabled = false;
                    zamanYazdir.Enabled = false;
                    MessageBox.Show("Tebrikler Oyunu Kazandınız.", "Mayın Tarlası", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    oyunbitti("Kazandınız");
                    
                }
                else if((oyuncuPicture.Location.X == 522) && (oyuncuPicture.Location.Y == 47))
                {
                    timerKontrol.Enabled = false;
                    zamanYazdir.Enabled = false;
                    MessageBox.Show("Tebrikler Oyunu Kazandınız.", "Mayın Tarlası", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    oyunbitti("Kazandınız");
                    
                }

            } 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bu Proje Ramazan Harmaner Tarafından Geliştirilmiştir." +
               "\nİletişim : ramazanharmaner@gmail.com" +
               "\nNasıl Oynanır ? \n1-) Oyana Başlamadan önce Zorluk Derecesi Seçilir ve Oyuncu İsmi Girilerek Kaydedilir." + 
               "\n2-) Oyunda Bulunan Yönledirme Butonları İle Oyun Oynanır." + 
               "\n3-) Oyunda Dört Bir Tarafında Kaç Tane Mayın Olduğu Bilgisi Verilir Panelden Takip Edebilirsiniz." + 
               "\n4-) Oyunda Herhangi Bir Mayına Basarsanız Oyunu Kaybedersiniz." + 
               "\n5-) Oyunu Kazabilmek İçin Yukardaki Kenarların Herhangi Birine Ulaşmak Zorundasınız." + 
               "\nEğer Her iki Kenar da Doluysa Yukarıdaki Herhangi Bir Hücreye Ulaşmanız Yeterli Olacaktır.",
               "Mayın Tarlası - Yapımcı & Nasıl Oynanır ?" , MessageBoxButtons.OK , MessageBoxIcon.Information);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(textBox1.Text != "")
            {
                MessageBox.Show("Şuan Oynayan Kişi : " + textBoxDegeri);
            }
            skorTablosuForm listele = new skorTablosuForm();
            dosyadanOku();
            listele.Show();
            
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked)
            {
                dereceKontrol = true;
                mayinSayisi = 80;
            }
        }

        private void mayinYazdir_Tick(object sender, EventArgs e)
        {
            label5.Text = etraftakiMayinlarDegisken.ToString();
        }

        private void zamanYazdir_Tick(object sender, EventArgs e)
        {
            saniyeOnlar++;
            if(saniyeOnlar > 9)
            {
                saniyeBirler++;
                saniyeOnlar = 0;
                if(saniyeBirler >= 6)
                {
                    dakikaOnlar++;
                    saniyeBirler = 0;
                    if(dakikaOnlar >= 10)
                    {
                        dakikaBirler++;
                        dakikaOnlar = 0;
                    }
                }
            }

            label4.Text = dakikaBirler.ToString() + dakikaOnlar.ToString() + ":" + saniyeBirler.ToString() + saniyeOnlar.ToString();
        }
        string textBoxDegeri = "";
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                textBoxDegeri = textBox1.Text;
                if (dereceKontrol)
                {
                    oyuncuPicture.Visible = true;
                    kaydetKontrol = true;
                    timerKontrol.Enabled = true;
                    Array.Resize(ref mayinliBolge, mayinSayisi);
                    if (bitis == false)
                    {
                        kutucukYerlestir();
                    }
                    mayinYerlestir();
                    oyuncuPicture.Location = new Point(372, 332);
                    oyuncuPicture.Visible = true;
                    MessageBox.Show(textBox1.Text + " Kaydedildi", "Mayın Tarlası", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                }
                else
                {
                    MessageBox.Show("Lütfen Önce Seviye Seçiniz.", "Mayın Tarlası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Lütfen İsminizi Giriniz.", "Mayın Tarlası", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public static string[] skorlar = new string[20];
        public static int sayac = 0;
        void dosyadanOku()
        {
            sayac = 0;
            string dizin = "C:\\Windows\\Temp\\Mayın_Tarlası_Skorlar.txt";
            if (File.Exists(dizin) == true)
            {
                FileStream fs = new FileStream(dizin, FileMode.Open, FileAccess.Read);
                StreamReader sw = new StreamReader(fs);
                string satir = sw.ReadLine();
                while (satir != null)
                {
                    skorlar[sayac] = satir;
                    satir = sw.ReadLine();
                    sayac++;
                }
                sw.Close();
                fs.Close();
                Array.Resize(ref skorlar , sayac);
            }

        }

        void dosyayaYaz()
        {
            sayac++;
            Array.Resize(ref skorlar , sayac);
            skorlar[sayac-1] = textBoxDegeri + " " + label4.Text;
            string dizin = "C:\\Windows\\Temp\\Mayın_Tarlası_Skorlar.txt";
            System.IO.File.Delete(dizin);

            FileStream fs = new FileStream(dizin, FileMode.OpenOrCreate, FileAccess.Write);

            StreamWriter sw = new StreamWriter(fs);
            for(int i = 0; i<sayac; i++)
            {
                sw.WriteLine(skorlar[i]);
            }

            sw.Flush();
            sw.Close();
            fs.Close();

        }

        void kontrolFonksiyon()
        {
                textBox1.Text = "";
        }
        void mesajGoster()
        {
            MessageBox.Show("Lütfen Önce Oyuncu İsmini Giriniz.", "Mayın Tarlası", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        void oyunbitti(string cesit)
        {
            DialogResult cevap = new DialogResult();
            this.BackColor = Color.Yellow;
            bitis = true;
            mayinYazdir.Enabled = false;
            zamanYazdir.Enabled = false;
            timerKontrol.Enabled = false;
            dosyayaYaz();

            for (int i = 0; i < mayinSayisi; i++)
            {
                resimler[mayinliBolge[i]].Image = Properties.Resources.mayin;
            }

            cevap = MessageBox.Show("Yeni Oyun" , cesit , MessageBoxButtons.YesNo , MessageBoxIcon.Information);
            if(cevap == DialogResult.Yes)
            {
               
                radioButton1.Checked = false;
                radioButton2.Checked = false;
                radioButton3.Checked = false;
                label5.Text = "0";
                label4.Text = "00:00";
                dakikaBirler = 0;dakikaOnlar = 0; saniyeBirler = 0; saniyeOnlar = 0;


                for (int i = 0; i<400; i++)
                {

                    resimler[i].Image = null;
                    resimler[i].BackColor = Color.Cyan;
                    
                }
                oyuncuPicture.Visible = false;
                konum = 389;
                this.BackColor = Color.LightGray;
                kaydetKontrol = false;
                dereceKontrol = false;
                oyuncuPicture.Location = new Point(372, 332);
            }
            else
            {

            }
        }
    }
}
