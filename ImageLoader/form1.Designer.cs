namespace ImageLoader
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btImg1 = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBoxResult = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btImg2 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSum = new System.Windows.Forms.Button();
            this.btnSubt = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSum = new System.Windows.Forms.TextBox();
            this.txtSubt = new System.Windows.Forms.TextBox();
            this.btnReset = new System.Windows.Forms.Button();
            this.txtDiv = new System.Windows.Forms.TextBox();
            this.txtMult = new System.Windows.Forms.TextBox();
            this.btndiv = new System.Windows.Forms.Button();
            this.btnMult = new System.Windows.Forms.Button();
            this.btnConvertGrayscale = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnReduce = new System.Windows.Forms.Button();
            this.btnClean = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxResult)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // btImg1
            // 
            this.btImg1.BackColor = System.Drawing.Color.White;
            this.btImg1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btImg1.ForeColor = System.Drawing.Color.Black;
            this.btImg1.Location = new System.Drawing.Point(63, 64);
            this.btImg1.Name = "btImg1";
            this.btImg1.Size = new System.Drawing.Size(125, 24);
            this.btImg1.TabIndex = 0;
            this.btImg1.Text = "Upload";
            this.btImg1.UseVisualStyleBackColor = false;
            this.btImg1.Click += new System.EventHandler(this.btImg1_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Location = new System.Drawing.Point(25, 90);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(202, 161);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBoxResult
            // 
            this.pictureBoxResult.BackColor = System.Drawing.Color.White;
            this.pictureBoxResult.Location = new System.Drawing.Point(27, 481);
            this.pictureBoxResult.Name = "pictureBoxResult";
            this.pictureBoxResult.Size = new System.Drawing.Size(202, 161);
            this.pictureBoxResult.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxResult.TabIndex = 2;
            this.pictureBoxResult.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(77, 461);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "Uploaded Image";
            // 
            // panel1
            // 
            this.panel1.AllowDrop = true;
            this.panel1.AutoScroll = true;
            this.panel1.BackColor = System.Drawing.Color.DarkCyan;
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.btImg2);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.pictureBoxResult);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btImg1);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(257, 800);
            this.panel1.TabIndex = 4;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.White;
            this.pictureBox2.Location = new System.Drawing.Point(27, 285);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(202, 161);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 8;
            this.pictureBox2.TabStop = false;
            // 
            // btImg2
            // 
            this.btImg2.BackColor = System.Drawing.Color.White;
            this.btImg2.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btImg2.ForeColor = System.Drawing.Color.Black;
            this.btImg2.Location = new System.Drawing.Point(63, 257);
            this.btImg2.Name = "btImg2";
            this.btImg2.Size = new System.Drawing.Size(125, 24);
            this.btImg2.TabIndex = 7;
            this.btImg2.Text = "Upload";
            this.btImg2.UseVisualStyleBackColor = false;
            this.btImg2.Click += new System.EventHandler(this.btImg2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Algerian", 7F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(5, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 11);
            this.label3.TabIndex = 6;
            this.label3.Text = "Ruan C. Dalla Rosa";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Algerian", 20F, System.Drawing.FontStyle.Italic);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(-1, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(258, 30);
            this.label2.TabIndex = 5;
            this.label2.Text = "Image Processing";
            // 
            // btnSum
            // 
            this.btnSum.BackColor = System.Drawing.Color.White;
            this.btnSum.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSum.ForeColor = System.Drawing.Color.Black;
            this.btnSum.Location = new System.Drawing.Point(278, 74);
            this.btnSum.Name = "btnSum";
            this.btnSum.Size = new System.Drawing.Size(91, 24);
            this.btnSum.TabIndex = 7;
            this.btnSum.Text = "Sum";
            this.btnSum.UseVisualStyleBackColor = false;
            this.btnSum.Click += new System.EventHandler(this.btnSum_Click);
            // 
            // btnSubt
            // 
            this.btnSubt.BackColor = System.Drawing.Color.White;
            this.btnSubt.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubt.ForeColor = System.Drawing.Color.Black;
            this.btnSubt.Location = new System.Drawing.Point(278, 104);
            this.btnSubt.Name = "btnSubt";
            this.btnSubt.Size = new System.Drawing.Size(91, 24);
            this.btnSubt.TabIndex = 8;
            this.btnSubt.Text = "Subtract";
            this.btnSubt.UseVisualStyleBackColor = false;
            this.btnSubt.Click += new System.EventHandler(this.btnSubt_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(287, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(141, 15);
            this.label4.TabIndex = 7;
            this.label4.Text = "Mathematical Operations";
            // 
            // txtSum
            // 
            this.txtSum.Font = new System.Drawing.Font("Times New Roman", 9.75F);
            this.txtSum.Location = new System.Drawing.Point(375, 74);
            this.txtSum.Name = "txtSum";
            this.txtSum.Size = new System.Drawing.Size(65, 22);
            this.txtSum.TabIndex = 9;
            // 
            // txtSubt
            // 
            this.txtSubt.Font = new System.Drawing.Font("Times New Roman", 9.75F);
            this.txtSubt.Location = new System.Drawing.Point(375, 104);
            this.txtSubt.Name = "txtSubt";
            this.txtSubt.Size = new System.Drawing.Size(65, 22);
            this.txtSubt.TabIndex = 10;
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.Color.White;
            this.btnReset.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.ForeColor = System.Drawing.Color.Black;
            this.btnReset.Location = new System.Drawing.Point(280, 40);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(67, 24);
            this.btnReset.TabIndex = 11;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click_1);
            // 
            // txtDiv
            // 
            this.txtDiv.Font = new System.Drawing.Font("Times New Roman", 9.75F);
            this.txtDiv.Location = new System.Drawing.Point(375, 162);
            this.txtDiv.Name = "txtDiv";
            this.txtDiv.Size = new System.Drawing.Size(65, 22);
            this.txtDiv.TabIndex = 15;
            // 
            // txtMult
            // 
            this.txtMult.Font = new System.Drawing.Font("Times New Roman", 9.75F);
            this.txtMult.Location = new System.Drawing.Point(375, 132);
            this.txtMult.Name = "txtMult";
            this.txtMult.Size = new System.Drawing.Size(65, 22);
            this.txtMult.TabIndex = 14;
            // 
            // btndiv
            // 
            this.btndiv.BackColor = System.Drawing.Color.White;
            this.btndiv.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btndiv.ForeColor = System.Drawing.Color.Black;
            this.btndiv.Location = new System.Drawing.Point(278, 162);
            this.btndiv.Name = "btndiv";
            this.btndiv.Size = new System.Drawing.Size(91, 24);
            this.btndiv.TabIndex = 13;
            this.btndiv.Text = "Division";
            this.btndiv.UseVisualStyleBackColor = false;
            this.btndiv.Click += new System.EventHandler(this.btndiv_Click);
            // 
            // btnMult
            // 
            this.btnMult.BackColor = System.Drawing.Color.White;
            this.btnMult.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMult.ForeColor = System.Drawing.Color.Black;
            this.btnMult.Location = new System.Drawing.Point(278, 132);
            this.btnMult.Name = "btnMult";
            this.btnMult.Size = new System.Drawing.Size(91, 24);
            this.btnMult.TabIndex = 12;
            this.btnMult.Text = "Multiplication";
            this.btnMult.UseVisualStyleBackColor = false;
            this.btnMult.Click += new System.EventHandler(this.btnMult_Click);
            // 
            // btnConvertGrayscale
            // 
            this.btnConvertGrayscale.BackColor = System.Drawing.Color.White;
            this.btnConvertGrayscale.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConvertGrayscale.ForeColor = System.Drawing.Color.Black;
            this.btnConvertGrayscale.Location = new System.Drawing.Point(278, 192);
            this.btnConvertGrayscale.Name = "btnConvertGrayscale";
            this.btnConvertGrayscale.Size = new System.Drawing.Size(162, 24);
            this.btnConvertGrayscale.TabIndex = 17;
            this.btnConvertGrayscale.Text = "Convert Grayscale";
            this.btnConvertGrayscale.UseVisualStyleBackColor = false;
            this.btnConvertGrayscale.Click += new System.EventHandler(this.btnConvertGrayscale_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.White;
            this.btnAdd.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.ForeColor = System.Drawing.Color.Black;
            this.btnAdd.Location = new System.Drawing.Point(280, 227);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(162, 24);
            this.btnAdd.TabIndex = 18;
            this.btnAdd.Text = "Add the two images";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnReduce
            // 
            this.btnReduce.BackColor = System.Drawing.Color.White;
            this.btnReduce.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReduce.ForeColor = System.Drawing.Color.Black;
            this.btnReduce.Location = new System.Drawing.Point(280, 257);
            this.btnReduce.Name = "btnReduce";
            this.btnReduce.Size = new System.Drawing.Size(162, 24);
            this.btnReduce.TabIndex = 19;
            this.btnReduce.Text = "Reduce both images";
            this.btnReduce.UseVisualStyleBackColor = false;
            this.btnReduce.Click += new System.EventHandler(this.btnReduce_Click);
            // 
            // btnClean
            // 
            this.btnClean.BackColor = System.Drawing.Color.White;
            this.btnClean.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClean.ForeColor = System.Drawing.Color.Black;
            this.btnClean.Location = new System.Drawing.Point(373, 41);
            this.btnClean.Name = "btnClean";
            this.btnClean.Size = new System.Drawing.Size(67, 24);
            this.btnClean.TabIndex = 20;
            this.btnClean.Text = "To Clean";
            this.btnClean.UseVisualStyleBackColor = false;
            this.btnClean.Click += new System.EventHandler(this.btnClean_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.panel2.Location = new System.Drawing.Point(258, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 293);
            this.panel2.TabIndex = 21;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.GhostWhite;
            this.ClientSize = new System.Drawing.Size(759, 645);
            this.Controls.Add(this.btnClean);
            this.Controls.Add(this.btnReduce);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnConvertGrayscale);
            this.Controls.Add(this.txtDiv);
            this.Controls.Add(this.txtMult);
            this.Controls.Add(this.btndiv);
            this.Controls.Add(this.btnMult);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.txtSubt);
            this.Controls.Add(this.txtSum);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnSubt);
            this.Controls.Add(this.btnSum);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Font = new System.Drawing.Font("Corbel", 8.25F);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Image Processing";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxResult)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btImg1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBoxResult;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSum;
        private System.Windows.Forms.Button btnSubt;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtSum;
        private System.Windows.Forms.TextBox txtSubt;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btImg2;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.TextBox txtDiv;
        private System.Windows.Forms.TextBox txtMult;
        private System.Windows.Forms.Button btndiv;
        private System.Windows.Forms.Button btnMult;
        private System.Windows.Forms.Button btnConvertGrayscale;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnReduce;
        private System.Windows.Forms.Button btnClean;
        private System.Windows.Forms.Panel panel2;
    }
}

