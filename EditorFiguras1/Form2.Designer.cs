namespace EditorFiguras1
{
    partial class Form2
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.figurasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nodoToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.aristasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.comprobarIsomorfismoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nodoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aristaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.borrarGrafoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.figurasToolStripMenuItem,
            this.comprobarIsomorfismoToolStripMenuItem,
            this.borrarGrafoToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // figurasToolStripMenuItem
            // 
            this.figurasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nodoToolStripMenuItem1,
            this.aristasToolStripMenuItem});
            this.figurasToolStripMenuItem.Name = "figurasToolStripMenuItem";
            this.figurasToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.figurasToolStripMenuItem.Text = "Objetos";
            this.figurasToolStripMenuItem.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.Shapes_Clicked);
            // 
            // nodoToolStripMenuItem1
            // 
            this.nodoToolStripMenuItem1.AccessibleName = "Nodo";
            this.nodoToolStripMenuItem1.Name = "nodoToolStripMenuItem1";
            this.nodoToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.nodoToolStripMenuItem1.Text = "Nodo";
            // 
            // aristasToolStripMenuItem
            // 
            this.aristasToolStripMenuItem.AccessibleName = "Arista";
            this.aristasToolStripMenuItem.Name = "aristasToolStripMenuItem";
            this.aristasToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.aristasToolStripMenuItem.Text = "Aristas";
            // 
            // comprobarIsomorfismoToolStripMenuItem
            // 
            this.comprobarIsomorfismoToolStripMenuItem.Name = "comprobarIsomorfismoToolStripMenuItem";
            this.comprobarIsomorfismoToolStripMenuItem.Size = new System.Drawing.Size(150, 20);
            this.comprobarIsomorfismoToolStripMenuItem.Text = "Comprobar isomorfismo";
            this.comprobarIsomorfismoToolStripMenuItem.Click += new System.EventHandler(this.comprobarIsomorfismoToolStripMenuItem_Click);
            // 
            // nodoToolStripMenuItem
            // 
            this.nodoToolStripMenuItem.Name = "nodoToolStripMenuItem";
            this.nodoToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.nodoToolStripMenuItem.Text = "Nodo";
            // 
            // aristaToolStripMenuItem
            // 
            this.aristaToolStripMenuItem.Name = "aristaToolStripMenuItem";
            this.aristaToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.aristaToolStripMenuItem.Text = "Arista";
            // 
            // borrarGrafoToolStripMenuItem
            // 
            this.borrarGrafoToolStripMenuItem.Name = "borrarGrafoToolStripMenuItem";
            this.borrarGrafoToolStripMenuItem.Size = new System.Drawing.Size(83, 20);
            this.borrarGrafoToolStripMenuItem.Text = "Borrar Grafo";
            this.borrarGrafoToolStripMenuItem.Click += new System.EventHandler(this.borrarGrafoToolStripMenuItem_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form2";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form2_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form2_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form2_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form2_MouseUp);
            this.Resize += new System.EventHandler(this.From2_Resize);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem nodoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aristaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem figurasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nodoToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem aristasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem comprobarIsomorfismoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem borrarGrafoToolStripMenuItem;
    }
}