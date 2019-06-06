namespace AllPay_Lightout
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private  LightoutControl lightoutControl;

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
            this.lightoutControl = new AllPay_Lightout.LightoutControl();
            this.SuspendLayout();
            // 
            // lightoutControl
            // 
            this.lightoutControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lightoutControl.Location = new System.Drawing.Point(0, 0);
            this.lightoutControl.Name = "lightoutControl";
            this.lightoutControl.Size = new System.Drawing.Size(422, 373);
            this.lightoutControl.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(422, 373);
            this.Controls.Add(this.lightoutControl);
            this.Name = "Form1";
            this.Text = "AllPay_Lightout";
            this.ResumeLayout(false);

        }

        #endregion
    }
}

