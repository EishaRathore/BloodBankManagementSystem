namespace BloodBankSystem.UI
{
    partial class ManageBloodG
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManageBloodG));
            this.circularBtn2 = new BloodBankSystem.Classes.CircularBtn();
            this.circularBtn1 = new BloodBankSystem.Classes.CircularBtn();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // circularBtn2
            // 
            this.circularBtn2.BackColor = System.Drawing.Color.IndianRed;
            this.circularBtn2.FlatAppearance.BorderSize = 0;
            this.circularBtn2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.circularBtn2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Lavender;
            this.circularBtn2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.circularBtn2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.circularBtn2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.circularBtn2.Location = new System.Drawing.Point(374, 102);
            this.circularBtn2.Name = "circularBtn2";
            this.circularBtn2.Size = new System.Drawing.Size(145, 70);
            this.circularBtn2.TabIndex = 2;
            this.circularBtn2.Text = "Delete Donor";
            this.circularBtn2.UseVisualStyleBackColor = false;
            this.circularBtn2.Click += new System.EventHandler(this.circularBtn2_Click);
            // 
            // circularBtn1
            // 
            this.circularBtn1.BackColor = System.Drawing.Color.IndianRed;
            this.circularBtn1.FlatAppearance.BorderSize = 0;
            this.circularBtn1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.circularBtn1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Lavender;
            this.circularBtn1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.circularBtn1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.circularBtn1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.circularBtn1.Location = new System.Drawing.Point(86, 102);
            this.circularBtn1.Name = "circularBtn1";
            this.circularBtn1.Size = new System.Drawing.Size(155, 70);
            this.circularBtn1.TabIndex = 1;
            this.circularBtn1.Text = "Update Donor ";
            this.circularBtn1.UseVisualStyleBackColor = false;
            this.circularBtn1.Click += new System.EventHandler(this.circularBtn1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Modern No. 20", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(81, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(319, 25);
            this.label1.TabIndex = 3;
            this.label1.Text = "Choose an Option...given bellow";
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 249);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(720, 218);
            this.panel1.TabIndex = 4;
            // 
            // ManageBloodG
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(720, 467);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.circularBtn2);
            this.Controls.Add(this.circularBtn1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ManageBloodG";
            this.Text = "ManageBloodG";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Classes.CircularBtn circularBtn1;
        private Classes.CircularBtn circularBtn2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
    }
}