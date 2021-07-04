namespace EditorFiguras1
{
    partial class RepresentacionesLA
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
            this.LisAdy = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.LisAdyDi = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.LisAdy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LisAdyDi)).BeginInit();
            this.SuspendLayout();
            // 
            // LisAdy
            // 
            this.LisAdy.AccessibleName = "";
            this.LisAdy.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.LisAdy.Location = new System.Drawing.Point(0, 32);
            this.LisAdy.Name = "LisAdy";
            this.LisAdy.Size = new System.Drawing.Size(240, 423);
            this.LisAdy.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(77, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Dirigido";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(386, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "No Dirigido";
            // 
            // LisAdyDi
            // 
            this.LisAdyDi.AccessibleName = "";
            this.LisAdyDi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.LisAdyDi.Location = new System.Drawing.Point(276, 32);
            this.LisAdyDi.Name = "LisAdyDi";
            this.LisAdyDi.Size = new System.Drawing.Size(240, 423);
            this.LisAdyDi.TabIndex = 5;
            // 
            // RepresentacionesLA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(522, 450);
            this.Controls.Add(this.LisAdyDi);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LisAdy);
            this.Name = "RepresentacionesLA";
            this.Text = "ListaAdyacencia";
            this.Load += new System.EventHandler(this.Ventana_Relaciones_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Relaciones_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.LisAdy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LisAdyDi)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.DataGridView LisAdy;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.DataGridView LisAdyDi;
    }
}