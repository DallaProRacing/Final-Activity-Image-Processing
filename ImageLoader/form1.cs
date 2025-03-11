using System;
using System.Drawing;
using System.Windows.Forms;

namespace ImageLoader
{
    public partial class Form1 : Form
    {
        Bitmap img1; // Imagem original
        Bitmap img2; // Imagem alterada (cópia da original que será modificada)

        public Form1()
        {
            InitializeComponent();
        }

        private void btImg1_Click(object sender, EventArgs e)
        {
            // Configurações iniciais da OpenFileDialog
            openFileDialog1.InitialDirectory = "C:\\Matlab";
            openFileDialog1.Filter = "TIFF image (*.tif)|*.tif|JPG image (*.jpg)|*.jpg|BMP image (*.bmp)|*.bmp|PNG image (*.png)|*.png|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    img1 = new Bitmap(openFileDialog1.FileName);
                    img2 = new Bitmap(img1); // Cria uma cópia para edições

                    pictureBox1.Image = img1; // Exibe a imagem original
                    pictureBox2.Image = new Bitmap(img1); // Exibe a cópia na PictureBox2
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro ao abrir imagem...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnSum_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtSum.Text, out int sumValue) || sumValue < 0 || sumValue > 255)
            {
                MessageBox.Show("Digite um valor entre 0 e 255 para aumentar o brilho.", "Entrada Inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Aplicar o aumento de brilho
            img2 = AjustarBrilho(img2, sumValue);
            pictureBox2.Image = img2;
            txtSum.Clear();
        }

        private void btnSubt_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtSubt.Text, out int subValue) || subValue < 0 || subValue > 255)
            {
                MessageBox.Show("Digite um valor entre 0 e 255 para diminuir o brilho.", "Entrada Inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Aplicar a redução de brilho
            img2 = AjustarBrilho(img2, -subValue);
            pictureBox2.Image = img2;
            txtSubt.Clear();
        }        
        private Bitmap AjustarBrilho(Bitmap img, int ajuste)
        {
            Bitmap tempImg = new Bitmap(img.Width, img.Height);

            for (int i = 0; i < img.Width; i++)
            {
                for (int j = 0; j < img.Height; j++)
                {
                    Color pixel = img.GetPixel(i, j);
                    int r = Math.Max(0, Math.Min(255, pixel.R + ajuste));
                    int g = Math.Max(0, Math.Min(255, pixel.G + ajuste));
                    int b = Math.Max(0, Math.Min(255, pixel.B + ajuste));

                    tempImg.SetPixel(i, j, Color.FromArgb(pixel.A, r, g, b));
                }
            }
            return tempImg;
        }
        private void btnReset_Click_1(object sender, EventArgs e)
        {
            img2 = new Bitmap(img1); // Restaura a imagem original
            pictureBox2.Image = img2;
        }



        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

       
    }

}
