namespace EditorFiguras1
{
    partial class RepresentacionMI
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
            this.MatInci = new System.Windows.Forms.DataGridView();
            this.MatInciD = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.MatInci)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MatInciD)).BeginInit();
            this.SuspendLayout();
            // 
            // MatInci
            // 
            this.MatInci.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.MatInci.Location = new System.Drawing.Point(12, 35);
            this.MatInci.Name = "MatInci";
            this.MatInci.Size = new System.Drawing.Size(671, 238);
            this.MatInci.TabIndex = 0;
            // 
            // MatInciD
            // 
            this.MatInciD.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.MatInciD.Location = new System.Drawing.Point(12, 314);
            this.MatInciD.Name = "MatInciD";
            this.MatInciD.Size = new System.Drawing.Size(671, 238);
            this.MatInciD.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "No Dirigido";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 286);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Dirigido";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(565, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(209, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Nota: Las celdas sin numero representan 0";
            // 
            // RepresentacionMI
            // 
            this.AccessibleName = "MatrizIncidencia";
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(817, 551);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.MatInciD);
            this.Controls.Add(this.MatInci);
            this.Name = "RepresentacionMI";
            this.Text = "RepresentacionMI";
            ((System.ComponentModel.ISupportInitialize)(this.MatInci)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MatInciD)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.DataGridView MatInci;
        public System.Windows.Forms.DataGridView MatInciD;
    }
}