using System;
using System.Collections.Generic;
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
                MessageBox.Show("Carregue uma imagem antes de inverter verticalmente.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int largura = img1.Width;
            int altura = img1.Height;
            Bitmap invertida = new Bitmap(largura, altura);

            for (int y = 0; y < altura; y++)
            {
                for (int x = 0; x < largura; x++)
                {
                    Color cor = img1.GetPixel(x, y);
                    invertida.SetPixel(x, altura - 1 - y, cor);
                }
            }

            img1 = invertida;
            pictureBoxResult.Image = img1;
        }


        private void btnLeft_Click(object sender, EventArgs e)
        {
            if (img1 == null)
            {
                MessageBox.Show("Carregue uma imagem antes de inverter horizontalmente.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int largura = img1.Width;
            int altura = img1.Height;
            Bitmap invertida = new Bitmap(largura, altura);

            for (int y = 0; y < altura; y++)
            {
                for (int x = 0; x < largura; x++)
                {
                    Color cor = img1.GetPixel(x, y);
                    invertida.SetPixel(largura - 1 - x, y, cor);
                }
            }

            img1 = invertida;
            pictureBoxResult.Image = img1;
        }        
        private void btnMediaDuasImagens_Click(object sender, EventArgs e)
        {
            if (img1 == null || img2 == null)
            {
                MessageBox.Show("Carregue duas imagens para realizar a média.");
                return;
            }

            if (img1.Width != img2.Width || img1.Height != img2.Height)
            {
                MessageBox.Show("As imagens devem ter o mesmo tamanho.");
                return;
            }

            Bitmap resultado = new Bitmap(img1.Width, img1.Height);

            for (int y = 0; y < img1.Height; y++)
            {
                for (int x = 0; x < img1.Width; x++)
                {
                    Color pixel1 = img1.GetPixel(x, y);
                    Color pixel2 = img2.GetPixel(x, y);

                    int mediaR = (pixel1.R + pixel2.R) / 2;
                    int mediaG = (pixel1.G + pixel2.G) / 2;
                    int mediaB = (pixel1.B + pixel2.B) / 2;

                    resultado.SetPixel(x, y, Color.FromArgb(mediaR, mediaG, mediaB));
                }
            }

            img1 = resultado;
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
            if (img1 == null || cbxTamMatriz.SelectedItem == null)
            {
                MessageBox.Show("Carregue uma imagem e selecione o tamanho da matriz.");
                return;
            }

            int tamanhoMatriz = int.Parse(cbxTamMatriz.SelectedItem.ToString());
            img1 = AplicarFiltro(img1, tamanhoMatriz, "MAX");
            pictureBoxResult.Image = img1;
        }



        private void btnMEAN_Click(object sender, EventArgs e)
        {
            if (img1 == null || cbxTamMatriz.SelectedItem == null)
            {
                MessageBox.Show("Carregue uma imagem e selecione o tamanho da matriz.");
                return;
            }

            int tamanhoMatriz = int.Parse(cbxTamMatriz.SelectedItem.ToString());
            img1 = AplicarFiltro(img1, tamanhoMatriz, "MEAN");
            pictureBoxResult.Image = img1;
        }



        private void btnMIN_Click(object sender, EventArgs e)
        {
            if (img1 == null || cbxTamMatriz.SelectedItem == null)
            {
                MessageBox.Show("Carregue uma imagem e selecione o tamanho da matriz.");
                return;
            }

            int tamanhoMatriz = int.Parse(cbxTamMatriz.SelectedItem.ToString());
            img1 = AplicarFiltro(img1, tamanhoMatriz, "MIN");
            pictureBoxResult.Image = img1;
        }


        private Bitmap AplicarFiltro(Bitmap original, int tamanho, string tipoFiltro)
        {
            Bitmap resultado = new Bitmap(original.Width, original.Height);
            int offset = tamanho / 2;

            for (int y = 0; y < original.Height; y++)
            {
                for (int x = 0; x < original.Width; x++)
                {
                    int[] reds = new int[tamanho * tamanho];
                    int[] greens = new int[tamanho * tamanho];
                    int[] blues = new int[tamanho * tamanho];
                    int index = 0;

                    for (int j = -offset; j <= offset; j++)
                    {
                        for (int i = -offset; i <= offset; i++)
                        {
                            int px = x + i;
                            int py = y + j;

                            // Duplicação das bordas (espelhamento simples)
                            if (px < 0) px = 0;
                            if (py < 0) py = 0;
                            if (px >= original.Width) px = original.Width - 1;
                            if (py >= original.Height) py = original.Height - 1;

                            Color pixel = original.GetPixel(px, py);

                            reds[index] = pixel.R;
                            greens[index] = pixel.G;
                            blues[index] = pixel.B;
                            index++;
                        }
                    }

                    int r = 0, g = 0, b = 0;

                    if (tipoFiltro == "MAX")
                    {
                        r = MaxValor(reds);
                        g = MaxValor(greens);
                        b = MaxValor(blues);
                    }
                    else if (tipoFiltro == "MIN")
                    {
                        r = MinValor(reds);
                        g = MinValor(greens);
                        b = MinValor(blues);
                    }
                    else if (tipoFiltro == "MEAN")
                    {
                        r = Media(reds);
                        g = Media(greens);
                        b = Media(blues);
                    }

                    resultado.SetPixel(x, y, Color.FromArgb(r, g, b));
                }
            }

            return resultado;
        }

        private int MaxValor(int[] vetor)
        {
            int max = vetor[0];
            for (int i = 1; i < vetor.Length; i++)
            {
                if (vetor[i] > max) max = vetor[i];
            }
            return max;
        }

        private int MinValor(int[] vetor)
        {
            int min = vetor[0];
            for (int i = 1; i < vetor.Length; i++)
            {
                if (vetor[i] < min) min = vetor[i];
            }
            return min;
        }

        private int Media(int[] vetor)
        {
            int soma = 0;
            for (int i = 0; i < vetor.Length; i++)
            {
                soma += vetor[i];
            }
            return soma / vetor.Length;
        }

        private void btnMediana_Click(object sender, EventArgs e)
        {
            if (img1 == null || cbxTamMatriz.SelectedItem == null)
            {
                MessageBox.Show("Carregue uma imagem e selecione o tamanho da matriz.");
                return;
            }
            int tamanho = int.Parse(cbxTamMatriz.SelectedItem.ToString());
            img1 = AplicarFiltroMediana(img1, tamanho);
            pictureBoxResult.Image = img1;
        }
        private Bitmap AplicarFiltroMediana(Bitmap original, int tamanho)
        {
            Bitmap resultado = new Bitmap(original.Width, original.Height);
            int offset = tamanho / 2;
            int total = tamanho * tamanho;

            for (int y = 0; y < original.Height; y++)
            {
                for (int x = 0; x < original.Width; x++)
                {
                    int[] r = new int[total];
                    int[] g = new int[total];
                    int[] b = new int[total];
                    int index = 0;

                    for (int j = -offset; j <= offset; j++)
                    {
                        for (int i = -offset; i <= offset; i++)
                        {
                            int px = x + i;
                            int py = y + j;

                            if (px < 0) px = 0;
                            if (py < 0) py = 0;
                            if (px >= original.Width) px = original.Width - 1;
                            if (py >= original.Height) py = original.Height - 1;

                            Color pixel = original.GetPixel(px, py);
                            r[index] = pixel.R;
                            g[index] = pixel.G;
                            b[index] = pixel.B;
                            index++;
                        }
                    }

                    Array.Sort(r);
                    Array.Sort(g);
                    Array.Sort(b);
                    resultado.SetPixel(x, y, Color.FromArgb(r[total / 2], g[total / 2], b[total / 2]));
                }
            }

            return resultado;
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            if (img1 == null || cbxTamMatriz.SelectedItem == null)
            {
                MessageBox.Show("Carregue uma imagem e selecione o tamanho da matriz.");
                return;
            }
            int tamanho = int.Parse(cbxTamMatriz.SelectedItem.ToString());
            img1 = AplicarFiltroOrdem(img1, tamanho);
            pictureBoxResult.Image = img1;
        }
        private Bitmap AplicarFiltroOrdem(Bitmap original, int tamanho)
        {
            Bitmap resultado = new Bitmap(original.Width, original.Height);
            int offset = tamanho / 2;
            int total = tamanho * tamanho;

            for (int y = 0; y < original.Height; y++)
            {
                for (int x = 0; x < original.Width; x++)
                {
                    int[] r = new int[total];
                    int[] g = new int[total];
                    int[] b = new int[total];
                    int index = 0;

                    for (int j = -offset; j <= offset; j++)
                    {
                        for (int i = -offset; i <= offset; i++)
                        {
                            int px = x + i;
                            int py = y + j;

                            if (px < 0) px = 0;
                            if (py < 0) py = 0;
                            if (px >= original.Width) px = original.Width - 1;
                            if (py >= original.Height) py = original.Height - 1;

                            Color pixel = original.GetPixel(px, py);
                            r[index] = pixel.R;
                            g[index] = pixel.G;
                            b[index] = pixel.B;
                            index++;
                        }
                    }

                    Array.Sort(r);
                    Array.Sort(g);
                    Array.Sort(b);
                    resultado.SetPixel(x, y, Color.FromArgb(r[tamanho], g[tamanho], b[tamanho]));
                }
            }

            return resultado;
        }

        private void btnSuavizacao_Click(object sender, EventArgs e)
        {
            if (img1 == null || cbxTamMatriz.SelectedItem == null)
            {
                MessageBox.Show("Carregue uma imagem e selecione o tamanho da matriz.");
                return;
            }
            int tamanho = int.Parse(cbxTamMatriz.SelectedItem.ToString());
            img1 = AplicarFiltroSuavizacao(img1, tamanho);
            pictureBoxResult.Image = img1;
        }
        private Bitmap AplicarFiltroSuavizacao(Bitmap original, int tamanho)
        {
            Bitmap resultado = new Bitmap(original.Width, original.Height);
            int offset = tamanho / 2;
            int pesoCentro = 4;
            int pesoVizinho = 1;

            for (int y = 0; y < original.Height; y++)
            {
                for (int x = 0; x < original.Width; x++)
                {
                    int sumR = 0, sumG = 0, sumB = 0;
                    int totalPeso = 0;

                    for (int j = -offset; j <= offset; j++)
                    {
                        for (int i = -offset; i <= offset; i++)
                        {
                            int px = x + i;
                            int py = y + j;

                            if (px < 0) px = 0;
                            if (py < 0) py = 0;
                            if (px >= original.Width) px = original.Width - 1;
                            if (py >= original.Height) py = original.Height - 1;

                            int peso = (i == 0 && j == 0) ? pesoCentro : pesoVizinho;

                            Color pixel = original.GetPixel(px, py);
                            sumR += pixel.R * peso;
                            sumG += pixel.G * peso;
                            sumB += pixel.B * peso;
                            totalPeso += peso;
                        }
                    }

                    resultado.SetPixel(x, y, Color.FromArgb(sumR / totalPeso, sumG / totalPeso, sumB / totalPeso));
                }
            }

            return resultado;
        }

        private void btnGaussiano_Click(object sender, EventArgs e)
        {
            if (img1 == null || cbxTamMatriz.SelectedItem == null)
            {
                MessageBox.Show("Carregue uma imagem e selecione o tamanho da matriz.");
                return;
            }
            int tamanho = int.Parse(cbxTamMatriz.SelectedItem.ToString());
            img1 = AplicarFiltroGaussiano(img1, tamanho);
            pictureBoxResult.Image = img1;
        }
        private Bitmap AplicarFiltroGaussiano(Bitmap original, int tamanho)
        {
            Bitmap resultado = new Bitmap(original.Width, original.Height);
            int offset = tamanho / 2;

            // Cria máscara gaussiana simples normalizada (valor inteiro)
            int[,] mascara = new int[tamanho, tamanho];
            int soma = 0;
            for (int j = -offset; j <= offset; j++)
            {
                for (int i = -offset; i <= offset; i++)
                {
                    int valor = (int)(Math.Exp(-(i * i + j * j) / 2.0) * 100);
                    mascara[j + offset, i + offset] = valor;
                    soma += valor;
                }
            }

            for (int y = 0; y < original.Height; y++)
            {
                for (int x = 0; x < original.Width; x++)
                {
                    int sumR = 0, sumG = 0, sumB = 0;

                    for (int j = -offset; j <= offset; j++)
                    {
                        for (int i = -offset; i <= offset; i++)
                        {
                            int px = x + i;
                            int py = y + j;

                            if (px < 0) px = 0;
                            if (py < 0) py = 0;
                            if (px >= original.Width) px = original.Width - 1;
                            if (py >= original.Height) py = original.Height - 1;

                            int peso = mascara[j + offset, i + offset];

                            Color pixel = original.GetPixel(px, py);
                            sumR += pixel.R * peso;
                            sumG += pixel.G * peso;
                            sumB += pixel.B * peso;
                        }
                    }

                    resultado.SetPixel(x, y, Color.FromArgb(sumR / soma, sumG / soma, sumB / soma));
                }
            }

            return resultado;
        }

        private void btnBaixar_Click(object sender, EventArgs e)
        {
            if (pictureBoxResult.Image == null)
            {
                MessageBox.Show("Não há imagem no resultado para salvar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SaveFileDialog salvar = new SaveFileDialog())
            {
                salvar.Title = "Salvar Imagem";
                salvar.Filter = "PNG (*.png)|*.png|JPEG (*.jpg)|*.jpg|Bitmap (*.bmp)|*.bmp";
                salvar.DefaultExt = "png";

                if (salvar.ShowDialog() == DialogResult.OK)
                {
                    // Verifica o formato escolhido e salva no formato correto
                    System.Drawing.Imaging.ImageFormat formato = System.Drawing.Imaging.ImageFormat.Png;

                    if (salvar.FileName.EndsWith(".jpg"))
                        formato = System.Drawing.Imaging.ImageFormat.Jpeg;
                    else if (salvar.FileName.EndsWith(".bmp"))
                        formato = System.Drawing.Imaging.ImageFormat.Bmp;

                    pictureBoxResult.Image.Save(salvar.FileName, formato);
                    MessageBox.Show("Imagem salva com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
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
