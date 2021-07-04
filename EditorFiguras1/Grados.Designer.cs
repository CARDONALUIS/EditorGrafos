namespace EditorFiguras1
{
    partial class Grados
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
            this.GradosNoDi = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.GradosDiri = new System.Windows.Forms.DataGridView();
            this.Dirigido = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.GradosNoDi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GradosDiri)).BeginInit();
            this.SuspendLayout();
            // 
            // GradosNoDi
            // 
            this.GradosNoDi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GradosNoDi.Location = new System.Drawing.Point(31, 40);
            this.GradosNoDi.Name = "GradosNoDi";
            this.GradosNoDi.Size = new System.Drawing.Size(242, 328);
            this.GradosNoDi.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(61, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "No dirigido";
            // 
            // GradosDiri
            // 
            this.GradosDiri.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GradosDiri.Location = new System.Drawing.Point(294, 40);
            this.GradosDiri.Name = "GradosDiri";
            this.GradosDiri.Size = new System.Drawing.Size(407, 328);
            this.GradosDiri.TabIndex = 2;
            // 
            // Dirigido
            // 
            this.Dirigido.AutoSize = true;
            this.Dirigido.Location = new System.Drawing.Point(474, 9);
            this.Dirigido.Name = "Dirigido";
            this.Dirigido.Size = new System.Drawing.Size(42, 13);
            this.Dirigido.TabIndex = 3;
            this.Dirigido.Text = "Dirigido";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(379, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Entrada";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(568, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Salida";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(276, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 13);
            this.label4.TabIndex = 6;
            // 
            // Grados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(713, 372);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Dirigido);
            this.Controls.Add(this.GradosDiri);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.GradosNoDi);
            this.Name = "Grados";
            this.Text = "Grados";
            this.Load += new System.EventHandler(this.Grados_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GradosNoDi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GradosDiri)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView GradosNoDi;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView GradosDiri;
        private System.Windows.Forms.Label Dirigido;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}