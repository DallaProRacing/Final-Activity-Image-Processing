using System;
using System.Drawing;
using System.Windows.Forms;

namespace ImageLoader
{
    public partial class Form1 : Form
    {
        Bitmap img1, img1Original;
        Bitmap img2;

        public Form1()
        {
            InitializeComponent();
        }

        private void btImg1_Click(object sender, EventArgs e)
        {
            img1 = CarregarImagem();
            if (img1 != null)
            {
                img1Original = new Bitmap(img1); // Criar cópia da imagem original
                pictureBox1.Image = img1;
            }
        }

        private void btImg2_Click(object sender, EventArgs e)
        {
            img2 = CarregarImagem();
            if (img2 != null)
            {
                if (img1 != null && (img1.Width != img2.Width || img1.Height != img2.Height))
                {
                    MessageBox.Show("As imagens devem ter o mesmo tamanho. Escolha outra imagem.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    img2 = null;
                    pictureBox2.Image = null;
                    return;
                }
                pictureBox2.Image = img2;
            }
        }

        private Bitmap CarregarImagem()
        {
            openFileDialog1.Filter = "Imagens|*.tif;*.jpg;*.bmp;*.png|Todos os arquivos|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    return new Bitmap(openFileDialog1.FileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao carregar imagem: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return null;
        }

        private void btnSum_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtSum.Text, out int sumValue) || sumValue < 0 || sumValue > 255)
            {
                MessageBox.Show("Digite um valor entre 0 e 255 para aumentar o brilho.", "Entrada Inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            img1 = AjustarBrilho(img1, sumValue);
            pictureBoxResult.Image = img1;
            txtSum.Clear();
        }

        private void btnSubt_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtSubt.Text, out int subValue) || subValue < 0 || subValue > 255)
            {
                MessageBox.Show("Digite um valor entre 0 e 255 para diminuir o brilho.", "Entrada Inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            img1 = AjustarBrilho(img1, -subValue);
            pictureBoxResult.Image = img1;
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
            if (img1Original != null)
            {
                img1 = new Bitmap(img1Original);
                pictureBoxResult.Image = img1;
            }
        }
        private void btnMult_Click(object sender, EventArgs e)
        {
            if (!double.TryParse(txtMult.Text, out double multValue) || multValue < 0)
            {
                MessageBox.Show("Digite um valor válido maior ou igual a 0 para multiplicação.", "Entrada Inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            img1 = AjustarMultiplicacao(new Bitmap(img1), multValue);
            pictureBoxResult.Image = img1;
            txtMult.Clear();
        }
        private Bitmap AjustarMultiplicacao(Bitmap img, double fator)
        {
            for (int i = 0; i < img.Width; i++)
            {
                for (int j = 0; j < img.Height; j++)
                {
                    Color pixel = img.GetPixel(i, j);
                    int r = Math.Max(0, Math.Min(255, (int)(pixel.R * fator)));
                    int g = Math.Max(0, Math.Min(255, (int)(pixel.G * fator)));
                    int b = Math.Max(0, Math.Min(255, (int)(pixel.B * fator)));

                    img.SetPixel(i, j, Color.FromArgb(pixel.A, r, g, b));
                }
            }
            return img;
        }


        private void btndiv_Click(object sender, EventArgs e)
        {
            if (!double.TryParse(txtDiv.Text, out double divValue) || divValue <= 0)
            {
                MessageBox.Show("Digite um valor maior que 0 para divisão.", "Entrada Inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            img1 = AjustarMultiplicacao(new Bitmap(img1), 1 / divValue);
            pictureBoxResult.Image = img1;
            txtDiv.Clear();
        }

        private void btnConvertGrayscale_Click(object sender, EventArgs e)
        {
            img1 = ConverterParaEscalaDeCinza(new Bitmap(img1));
            pictureBoxResult.Image = img1;
        }
        private Bitmap ConverterParaEscalaDeCinza(Bitmap img)
        {
            for (int i = 0; i < img.Width; i++)
            {
                for (int j = 0; j < img.Height; j++)
                {
                    Color pixel = img.GetPixel(i, j);
                    int gray = (int)(pixel.R * 0.3 + pixel.G * 0.59 + pixel.B * 0.11);
                    img.SetPixel(i, j, Color.FromArgb(pixel.A, gray, gray, gray));
                }
            }
            return img;
        }



        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (img1 == null || img2 == null)
            {
                MessageBox.Show("Carregue as duas imagens antes de somá-las.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            img1 = MesclarImagens(img1, img2, true);
            pictureBoxResult.Image = img1;
        }

        private void btnReduce_Click(object sender, EventArgs e)
        {
            if (img1 == null || img2 == null)
            {
                MessageBox.Show("Carregue as duas imagens antes de subtraí-las.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            img1 = MesclarImagens(img1, img2, false);
            pictureBoxResult.Image = img1;
        }
        private Bitmap MesclarImagens(Bitmap imgA, Bitmap imgB, bool isAddition)
        {
            Bitmap resultado = new Bitmap(imgA.Width, imgA.Height);

            for (int i = 0; i < imgA.Width; i++)
            {
                for (int j = 0; j < imgA.Height; j++)
                {
                    Color pixelA = imgA.GetPixel(i, j);
                    Color pixelB = imgB.GetPixel(i, j);

                    int r = isAddition ? Math.Min(255, pixelA.R + pixelB.R) : Math.Max(0, pixelA.R - pixelB.R);
                    int g = isAddition ? Math.Min(255, pixelA.G + pixelB.G) : Math.Max(0, pixelA.G - pixelB.G);
                    int b = isAddition ? Math.Min(255, pixelA.B + pixelB.B) : Math.Max(0, pixelA.B - pixelB.B);

                    resultado.SetPixel(i, j, Color.FromArgb(pixelA.A, r, g, b));
                }
            }
            return resultado;
        }
        private void btnClean_Click(object sender, EventArgs e)
        {
            pictureBoxResult.Image = null;
        }

       
    }

}
