namespace EditorFiguras1
{
    partial class RepresentacionMA
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
            this.MatAdya = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.MatAdyaND = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.MatAdya)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MatAdyaND)).BeginInit();
            this.SuspendLayout();
            // 
            // MatAdya
            // 
            this.MatAdya.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.MatAdya.Location = new System.Drawing.Point(12, 32);
            this.MatAdya.Name = "MatAdya";
            this.MatAdya.Size = new System.Drawing.Size(534, 181);
            this.MatAdya.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(62, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Dirigido";
            // 
            // MatAdyaND
            // 
            this.MatAdyaND.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.MatAdyaND.Location = new System.Drawing.Point(12, 257);
            this.MatAdyaND.Name = "MatAdyaND";
            this.MatAdyaND.Size = new System.Drawing.Size(534, 181);
            this.MatAdyaND.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(62, 230);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "No Dirigido";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(413, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(198, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Nota: Las celdas sin 1, representan un 0";
            // 
            // RepresentacionMA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 450);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.MatAdyaND);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.MatAdya);
            this.Name = "RepresentacionMA";
            this.Text = "Matriz Adyacencia";
            this.Load += new System.EventHandler(this.RepresentacionMA_Load);
            ((System.ComponentModel.ISupportInitialize)(this.MatAdya)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MatAdyaND)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.DataGridView MatAdya;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.DataGridView MatAdyaND;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}