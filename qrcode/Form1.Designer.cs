namespace qrcode
{
    partial class Form1
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.qRCodeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generateAllPossibilitiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gridSizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadTestQRCodeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.CombinaisonsCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.qrDisplay = new System.Windows.Forms.Panel();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.qRCodeToolStripMenuItem,
            this.optionsToolStripMenuItem,
            this.toolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(724, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // qRCodeToolStripMenuItem
            // 
            this.qRCodeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clearToolStripMenuItem,
            this.generateAllPossibilitiesToolStripMenuItem});
            this.qRCodeToolStripMenuItem.Name = "qRCodeToolStripMenuItem";
            this.qRCodeToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.qRCodeToolStripMenuItem.Text = "QR Code";
            // 
            // clearToolStripMenuItem
            // 
            this.clearToolStripMenuItem.Name = "clearToolStripMenuItem";
            this.clearToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.clearToolStripMenuItem.Text = "Clear";
            this.clearToolStripMenuItem.Click += new System.EventHandler(this.clearToolStripMenuItem_Click);
            // 
            // generateAllPossibilitiesToolStripMenuItem
            // 
            this.generateAllPossibilitiesToolStripMenuItem.Name = "generateAllPossibilitiesToolStripMenuItem";
            this.generateAllPossibilitiesToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.generateAllPossibilitiesToolStripMenuItem.Text = "Generate";
            this.generateAllPossibilitiesToolStripMenuItem.Click += new System.EventHandler(this.generateAllPossibilitiesToolStripMenuItem_Click);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gridSizeToolStripMenuItem,
            this.loadTestQRCodeToolStripMenuItem});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.optionsToolStripMenuItem.Text = "Options";
            // 
            // gridSizeToolStripMenuItem
            // 
            this.gridSizeToolStripMenuItem.Name = "gridSizeToolStripMenuItem";
            this.gridSizeToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.gridSizeToolStripMenuItem.Text = "Change QR code Size";
            this.gridSizeToolStripMenuItem.Click += new System.EventHandler(this.gridSizeToolStripMenuItem_Click);
            // 
            // loadTestQRCodeToolStripMenuItem
            // 
            this.loadTestQRCodeToolStripMenuItem.Name = "loadTestQRCodeToolStripMenuItem";
            this.loadTestQRCodeToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.loadTestQRCodeToolStripMenuItem.Text = "Load Test QR Code";
            this.loadTestQRCodeToolStripMenuItem.Click += new System.EventHandler(this.loadTestQRCodeToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(24, 20);
            this.toolStripMenuItem1.Text = "?";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CombinaisonsCount});
            this.statusStrip1.Location = new System.Drawing.Point(0, 538);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(724, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "Combinaisons :";
            // 
            // CombinaisonsCount
            // 
            this.CombinaisonsCount.Name = "CombinaisonsCount";
            this.CombinaisonsCount.Size = new System.Drawing.Size(98, 17);
            this.CombinaisonsCount.Text = "Combinaisons : 1";
            // 
            // qrDisplay
            // 
            this.qrDisplay.BackColor = System.Drawing.SystemColors.Highlight;
            this.qrDisplay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.qrDisplay.Location = new System.Drawing.Point(0, 24);
            this.qrDisplay.Margin = new System.Windows.Forms.Padding(2);
            this.qrDisplay.MaximumSize = new System.Drawing.Size(514, 514);
            this.qrDisplay.MinimumSize = new System.Drawing.Size(514, 514);
            this.qrDisplay.Name = "qrDisplay";
            this.qrDisplay.Size = new System.Drawing.Size(514, 514);
            this.qrDisplay.TabIndex = 2;
            this.qrDisplay.Paint += new System.Windows.Forms.PaintEventHandler(this.qrDisplay_Paint);
            this.qrDisplay.MouseClick += new System.Windows.Forms.MouseEventHandler(this.qrDisplay_MouseClick);
            this.qrDisplay.MouseMove += new System.Windows.Forms.MouseEventHandler(this.qrDisplay_MouseMove);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(519, 27);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(201, 511);
            this.listBox1.TabIndex = 4;
            this.listBox1.TabStop = false;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(724, 560);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.qrDisplay);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(740, 599);
            this.MinimumSize = new System.Drawing.Size(740, 599);
            this.Name = "Form1";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Dronolab QR Code - Brute Forcer";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem gridSizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem qRCodeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem generateAllPossibilitiesToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel CombinaisonsCount;
        private System.Windows.Forms.ToolStripMenuItem loadTestQRCodeToolStripMenuItem;
        private System.Windows.Forms.Panel qrDisplay;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
    }
}

