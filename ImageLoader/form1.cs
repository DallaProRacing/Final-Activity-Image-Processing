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
                pictureBoxResult.Image = null;
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
                    int gray = (int)(pixel.R * 0.3 + pixel.G * 0.3 + pixel.B * 0.3);
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

        private void btnDifference_Click(object sender, EventArgs e)
        {
            if (img1 == null || img2 == null)
            {
                MessageBox.Show("Carregue as duas imagens antes de calcular a diferença.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Bitmap C = MesclarImagens(img1, img2, false);
            Bitmap D = MesclarImagens(img2, img1, false);
            Bitmap resultado = MesclarImagens(C, D, true);

            pictureBoxResult.Image = resultado;
        }

        private void btnRight_Click(object sender, EventArgs e)
        {
            if (img1 == null)
            {
                MessageBox.Show("Carregue uma imagem antes de girá-la.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            img1 = RotacionarDireita(img1);
            pictureBoxResult.Image = img1;
        }
        private Bitmap RotacionarDireita(Bitmap img)
        {
            int largura = img.Height;
            int altura = img.Width;
            Bitmap rotacionada = new Bitmap(largura, altura);

            for (int i = 0; i < img.Width; i++)
            {
                for (int j = 0; j < img.Height; j++)
                {
                    rotacionada.SetPixel(j, img.Width - 1 - i, img.GetPixel(i, j));
                }
            }
            return rotacionada;
        }

        private void btnLeft_Click(object sender, EventArgs e)
        {
            if (img1 == null)
            {
                MessageBox.Show("Carregue uma imagem antes de girá-la.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            img1 = RotacionarEsquerda(img1);
            pictureBoxResult.Image = img1;
        }
        private Bitmap RotacionarEsquerda(Bitmap img)
        {
            int largura = img.Height;
            int altura = img.Width;
            Bitmap rotacionada = new Bitmap(largura, altura);

            for (int i = 0; i < img.Width; i++)
            {
                for (int j = 0; j < img.Height; j++)
                {
                    rotacionada.SetPixel(img.Height - 1 - j, i, img.GetPixel(i, j));
                }
            }
            return rotacionada;
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

        private void btnLimiar_Click(object sender, EventArgs e)
        {
            if (img1 == null)
            {
                MessageBox.Show("Carregue uma imagem antes de aplicar a limiarização.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txtLimiar.Text, out int limiar) || limiar < 0 || limiar > 255)
            {
                MessageBox.Show("Digite um valor entre 0 e 255 para o limiar.", "Entrada Inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!EhEscalaDeCinza(img1))
            {
                MessageBox.Show("A imagem carregada não está em escala de cinza. Carregue uma imagem em escala de cinza para aplicar a limiarização.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            img1 = AplicarLimiarizacao(img1, limiar);
            pictureBoxResult.Image = img1;
            txtLimiar.Clear();
        }

        private bool EhEscalaDeCinza(Bitmap img)
        {
            for (int i = 0; i < img.Width; i++)
            {
                for (int j = 0; j < img.Height; j++)
                {
                    Color pixel = img.GetPixel(i, j);
                    if (pixel.R != pixel.G || pixel.G != pixel.B)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private Bitmap AplicarLimiarizacao(Bitmap img, int limiar)
        {
            int largura = img.Width;
            int altura = img.Height;
            Bitmap resultado = new Bitmap(largura, altura);

            for (int i = 0; i < largura; i++)
            {
                for (int j = 0; j < altura; j++)
                {
                    Color pixel = img.GetPixel(i, j);
                    int novoPixel = pixel.R >= limiar ? 255 : 0;
                    resultado.SetPixel(i, j, Color.FromArgb(pixel.A, novoPixel, novoPixel, novoPixel));
                }
            }
            return resultado;
        }

        private void btnAND_Click(object sender, EventArgs e)
        {
            if (!SaoImagensBinarias(img1, img2)) return;
            img1 = OperacaoLogica(img1, img2, "AND");
            pictureBoxResult.Image = img1;
        }

        private void btnOR_Click(object sender, EventArgs e)
        {
            if (!SaoImagensBinarias(img1, img2)) return;
            img1 = OperacaoLogica(img1, img2, "OR");
            pictureBoxResult.Image = img1;
        }

        private void btnXOR_Click(object sender, EventArgs e)
        {
            if (!SaoImagensBinarias(img1, img2)) return;
            img1 = OperacaoLogica(img1, img2, "XOR");
            pictureBoxResult.Image = img1;
        }

        private void btnNOT_Click(object sender, EventArgs e)
        {
            if (!SaoImagensBinarias(img1, null)) return;
            img1 = OperacaoNot(img1);
            pictureBoxResult.Image = img1;
        }

        private bool SaoImagensBinarias(Bitmap imgA, Bitmap imgB)
        {
            if (!EhImagemBinaria(imgA))
            {
                MessageBox.Show("A imagem 1 não é binária. Carregue uma imagem binária.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (imgB != null && !EhImagemBinaria(imgB))
            {
                MessageBox.Show("A imagem 2 não é binária. Carregue uma imagem binária.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private bool EhImagemBinaria(Bitmap img)
        {
            for (int i = 0; i < img.Width; i++)
            {
                for (int j = 0; j < img.Height; j++)
                {
                    Color pixel = img.GetPixel(i, j);
                    if (pixel.R != 0 && pixel.R != 255)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private Bitmap OperacaoLogica(Bitmap imgA, Bitmap imgB, string operacao)
        {
            Bitmap resultado = new Bitmap(imgA.Width, imgA.Height);

            for (int i = 0; i < imgA.Width; i++)
            {
                for (int j = 0; j < imgA.Height; j++)
                {
                    int valorA = imgA.GetPixel(i, j).R == 255 ? 1 : 0;
                    int valorB = imgB.GetPixel(i, j).R == 255 ? 1 : 0;
                    int resultadoPixel = 0;

                    switch (operacao)
                    {
                        case "AND": resultadoPixel = valorA & valorB; break;
                        case "OR": resultadoPixel = valorA | valorB; break;
                        case "XOR": resultadoPixel = valorA ^ valorB; break;
                    }

                    resultado.SetPixel(i, j, Color.FromArgb(255, resultadoPixel * 255, resultadoPixel * 255, resultadoPixel * 255));
                }
            }
            return resultado;
        }

        private Bitmap OperacaoNot(Bitmap img)
        {
            Bitmap resultado = new Bitmap(img.Width, img.Height);

            for (int i = 0; i < img.Width; i++)
            {
                for (int j = 0; j < img.Height; j++)
                {
                    int valor = img.GetPixel(i, j).R == 255 ? 0 : 1;
                    resultado.SetPixel(i, j, Color.FromArgb(255, valor * 255, valor * 255, valor * 255));
                }
            }
            return resultado;
        }

        private void btnBlending_Click(object sender, EventArgs e)
        {
            if (img1 == null || img2 == null)
            {
                MessageBox.Show("Carregue as duas imagens antes de aplicar o blending.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (img1.Width != img2.Width || img1.Height != img2.Height)
            {
                MessageBox.Show("As imagens devem ter o mesmo tamanho para aplicar o blending.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!float.TryParse(txtBlending.Text, out float alpha) || alpha < 0 || alpha > 1)
            {
                MessageBox.Show("Digite um valor de blending entre 0 e 1.", "Valor inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Bitmap resultado = new Bitmap(img1.Width, img1.Height);

            for (int i = 0; i < img1.Width; i++)
            {
                for (int j = 0; j < img1.Height; j++)
                {
                    Color c1 = img1.GetPixel(i, j);
                    Color c2 = img2.GetPixel(i, j);

                    int r = (int)(alpha * c1.R + (1 - alpha) * c2.R);
                    int g = (int)(alpha * c1.G + (1 - alpha) * c2.G);
                    int b = (int)(alpha * c1.B + (1 - alpha) * c2.B);

                    resultado.SetPixel(i, j, Color.FromArgb(r, g, b));
                }
            }

            pictureBoxResult.Image = resultado;
            img1 = resultado;
        }

        private void btnHistograma_Click(object sender, EventArgs e)
        {
            if (img1 == null)
            {
                MessageBox.Show("Carregue uma imagem antes de visualizar o histograma.");
                return;
            }

            // Limpar dados antigos
            chartOrigImage.Series.Clear();

            int[] hist = new int[256];

            for (int i = 0; i < img1.Width; i++)
            {
                for (int j = 0; j < img1.Height; j++)
                {
                    Color pixel = img1.GetPixel(i, j);
                    // Convertendo para escala de cinza (ou usando só o canal R para simplificar)
                    int gray = (pixel.R + pixel.G + pixel.B) / 3;
                    hist[gray]++;
                }
            }

            var series = new System.Windows.Forms.DataVisualization.Charting.Series("Histograma");
            series.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;

            for (int i = 0; i < 256; i++)
            {
                series.Points.AddXY(i, hist[i]);
            }

            chartOrigImage.Series.Add(series);
        }

        private void btnEqualização_Click(object sender, EventArgs e)
        {
            if (img1 == null)
            {
                MessageBox.Show("Carregue uma imagem antes de aplicar a equalização.");
                return;
            }

            // Converter para escala de cinza
            Bitmap grayImg = new Bitmap(img1.Width, img1.Height);
            int[] hist = new int[256];
            int totalPixels = img1.Width * img1.Height;

            // Gerar imagem em tons de cinza e calcular histograma
            for (int i = 0; i < img1.Width; i++)
            {
                for (int j = 0; j < img1.Height; j++)
                {
                    Color pixel = img1.GetPixel(i, j);
                    int gray = (pixel.R + pixel.G + pixel.B) / 3;
                    hist[gray]++;
                    grayImg.SetPixel(i, j, Color.FromArgb(gray, gray, gray));
                }
            }

            // Calcular a função de distribuição acumulada (CDF)
            int[] cdf = new int[256];
            cdf[0] = hist[0];
            for (int i = 1; i < 256; i++)
            {
                cdf[i] = cdf[i - 1] + hist[i];
            }

            // Normalizar CDF
            int[] equalized = new int[256];
            for (int i = 0; i < 256; i++)
            {
                equalized[i] = (int)((cdf[i] - cdf[0]) * 255.0 / (totalPixels - 1));
                if (equalized[i] < 0) equalized[i] = 0;
                if (equalized[i] > 255) equalized[i] = 255;
            }

            // Aplicar a equalização
            Bitmap result = new Bitmap(grayImg.Width, grayImg.Height);
            for (int i = 0; i < grayImg.Width; i++)
            {
                for (int j = 0; j < grayImg.Height; j++)
                {
                    int gray = grayImg.GetPixel(i, j).R;
                    int eq = equalized[gray];
                    result.SetPixel(i, j, Color.FromArgb(eq, eq, eq));
                }
            }

            pictureBoxResult.Image = result;
            img1 = result; // Atualizar img1 com a imagem equalizada

            // Mostrar histograma da imagem equalizada
            chartEqualizedImage.Series.Clear();
            int[] histEq = new int[256];

            for (int i = 0; i < result.Width; i++)
            {
                for (int j = 0; j < result.Height; j++)
                {
                    int val = result.GetPixel(i, j).R;
                    histEq[val]++;
                }
            }

            var seriesEq = new System.Windows.Forms.DataVisualization.Charting.Series("Histograma Equalizado");
            seriesEq.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;

            for (int i = 0; i < 256; i++)
            {
                seriesEq.Points.AddXY(i, histEq[i]);
            }

            chartEqualizedImage.Series.Add(seriesEq);
        }

        private void btnMAX_Click(object sender, EventArgs e)
        {
            if (img1 == null)
            {
                MessageBox.Show("Carregue uma imagem antes de aplicar a efeito.");
                return;
            }
            img1 = AplicarFiltroMAX(img1);
            pictureBoxResult.Image = img1;
        }
        private Bitmap AplicarFiltroMAX(Bitmap original)
        {
            Bitmap resultado = new Bitmap(original.Width, original.Height);

            for (int y = 1; y < original.Height - 1; y++)
            {
                for (int x = 1; x < original.Width - 1; x++)
                {
                    int maxR = 0, maxG = 0, maxB = 0;

                    for (int j = -1; j <= 1; j++)
                    {
                        for (int i = -1; i <= 1; i++)
                        {
                            Color pixel = original.GetPixel(x + i, y + j);
                            if (pixel.R > maxR) maxR = pixel.R;
                            if (pixel.G > maxG) maxG = pixel.G;
                            if (pixel.B > maxB) maxB = pixel.B;
                        }
                    }

                    resultado.SetPixel(x, y, Color.FromArgb(maxR, maxG, maxB));
                }
            }

            return resultado;
        }


        private void btnMEAN_Click(object sender, EventArgs e)
        {
            if (img1 == null)
            {
                MessageBox.Show("Carregue uma imagem antes de aplicar a efeito.");
                return;
            }
            img1 = AplicarFiltroMEAN(img1);
            pictureBoxResult.Image = img1;
        }
        private Bitmap AplicarFiltroMEAN(Bitmap original)
        {
            Bitmap resultado = new Bitmap(original.Width, original.Height);

            for (int y = 1; y < original.Height - 1; y++)
            {
                for (int x = 1; x < original.Width - 1; x++)
                {
                    int sumR = 0, sumG = 0, sumB = 0;

                    for (int j = -1; j <= 1; j++)
                    {
                        for (int i = -1; i <= 1; i++)
                        {
                            Color pixel = original.GetPixel(x + i, y + j);
                            sumR += pixel.R;
                            sumG += pixel.G;
                            sumB += pixel.B;
                        }
                    }

                    int meanR = sumR / 9;
                    int meanG = sumG / 9;
                    int meanB = sumB / 9;

                    resultado.SetPixel(x, y, Color.FromArgb(meanR, meanG, meanB));
                }
            }

            return resultado;
        }


        private void btnMIN_Click(object sender, EventArgs e)
        {
            if (img1 == null)
            {
                MessageBox.Show("Carregue uma imagem antes de aplicar a efeito.");
                return;
            }
            img1 = AplicarFiltroMIN(img1);
            pictureBoxResult.Image = img1;
        }
        private Bitmap AplicarFiltroMIN(Bitmap original)
        {
            Bitmap resultado = new Bitmap(original.Width, original.Height);

            for (int y = 1; y < original.Height - 1; y++)
            {
                for (int x = 1; x < original.Width - 1; x++)
                {
                    int minR = 255, minG = 255, minB = 255;

                    for (int j = -1; j <= 1; j++)
                    {
                        for (int i = -1; i <= 1; i++)
                        {
                            Color pixel = original.GetPixel(x + i, y + j);
                            if (pixel.R < minR) minR = pixel.R;
                            if (pixel.G < minG) minG = pixel.G;
                            if (pixel.B < minB) minB = pixel.B;
                        }
                    }

                    resultado.SetPixel(x, y, Color.FromArgb(minR, minG, minB));
                }
            }

            return resultado;
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
       
    }

}
