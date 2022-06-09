namespace Talho
{
    partial class FormDetalhes
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
            this.buttonFechar = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.labelPreco = new System.Windows.Forms.Label();
            this.labelDescricao = new System.Windows.Forms.Label();
            this.labelValidade = new System.Windows.Forms.Label();
            this.labelQuantidade = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.labelNome = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonFechar
            // 
            this.buttonFechar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonFechar.Location = new System.Drawing.Point(679, 367);
            this.buttonFechar.Name = "buttonFechar";
            this.buttonFechar.Size = new System.Drawing.Size(109, 36);
            this.buttonFechar.TabIndex = 51;
            this.buttonFechar.Text = "Fechar";
            this.buttonFechar.UseVisualStyleBackColor = true;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(167, 143);
            this.progressBar1.Maximum = 30;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(174, 32);
            this.progressBar1.TabIndex = 50;
            // 
            // labelPreco
            // 
            this.labelPreco.AutoSize = true;
            this.labelPreco.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPreco.Location = new System.Drawing.Point(426, 258);
            this.labelPreco.Name = "labelPreco";
            this.labelPreco.Size = new System.Drawing.Size(283, 73);
            this.labelPreco.TabIndex = 49;
            this.labelPreco.Text = "100,00 €";
            // 
            // labelDescricao
            // 
            this.labelDescricao.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDescricao.Location = new System.Drawing.Point(51, 246);
            this.labelDescricao.Name = "labelDescricao";
            this.labelDescricao.Size = new System.Drawing.Size(369, 149);
            this.labelDescricao.TabIndex = 48;
            this.labelDescricao.Text = "Texto da Descrição";
            // 
            // labelValidade
            // 
            this.labelValidade.AutoSize = true;
            this.labelValidade.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelValidade.Location = new System.Drawing.Point(521, 147);
            this.labelValidade.Name = "labelValidade";
            this.labelValidade.Size = new System.Drawing.Size(100, 24);
            this.labelValidade.TabIndex = 47;
            this.labelValidade.Text = "00/00/0000";
            // 
            // labelQuantidade
            // 
            this.labelQuantidade.AutoSize = true;
            this.labelQuantidade.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelQuantidade.Location = new System.Drawing.Point(347, 147);
            this.labelQuantidade.Name = "labelQuantidade";
            this.labelQuantidade.Size = new System.Drawing.Size(57, 24);
            this.labelQuantidade.TabIndex = 46;
            this.labelQuantidade.Text = "quant";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(426, 147);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(89, 24);
            this.label8.TabIndex = 45;
            this.label8.Text = "Validade:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(426, 212);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 24);
            this.label7.TabIndex = 44;
            this.label7.Text = "Preço:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(51, 147);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(113, 24);
            this.label6.TabIndex = 43;
            this.label6.Text = "Quantidade:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(51, 212);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(99, 24);
            this.label5.TabIndex = 42;
            this.label5.Text = "Descrição:";
            // 
            // labelNome
            // 
            this.labelNome.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelNome.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNome.Location = new System.Drawing.Point(12, 48);
            this.labelNome.Name = "labelNome";
            this.labelNome.Size = new System.Drawing.Size(776, 57);
            this.labelNome.TabIndex = 41;
            this.labelNome.Text = "NOME";
            this.labelNome.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FormDetalhes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonFechar);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.labelPreco);
            this.Controls.Add(this.labelDescricao);
            this.Controls.Add(this.labelValidade);
            this.Controls.Add(this.labelQuantidade);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.labelNome);
            this.Name = "FormDetalhes";
            this.Text = "FormDetalhes";
            this.Load += new System.EventHandler(this.FormDetalhes_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonFechar;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label labelPreco;
        private System.Windows.Forms.Label labelDescricao;
        private System.Windows.Forms.Label labelValidade;
        private System.Windows.Forms.Label labelQuantidade;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label labelNome;
    }
}