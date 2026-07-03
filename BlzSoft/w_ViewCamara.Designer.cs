namespace BlzSoft
{
    partial class w_ViewCamara
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
            this.viewImg = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.viewImg)).BeginInit();
            this.SuspendLayout();
            // 
            // viewImg
            // 
            this.viewImg.Location = new System.Drawing.Point(12, 12);
            this.viewImg.Name = "viewImg";
            this.viewImg.Size = new System.Drawing.Size(763, 402);
            this.viewImg.TabIndex = 0;
            this.viewImg.TabStop = false;
            // 
            // w_ViewCamara
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.viewImg);
            this.Name = "w_ViewCamara";
            this.Text = "w_ViewCamara";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.w_ViewCamara_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.w_ViewCamara_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.viewImg)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox viewImg;
    }
}