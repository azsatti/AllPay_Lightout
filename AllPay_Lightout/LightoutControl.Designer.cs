using System;
using System.Threading;
using System.Windows.Forms;

namespace AllPay_Lightout
{
    partial class LightoutControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.TableLayoutPanel table;
        private System.ComponentModel.BackgroundWorker backgroundWorker;
        private System.Windows.Forms.LinkLabel lblWon;

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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;


            this.table = new System.Windows.Forms.TableLayoutPanel();
            this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.lblWon = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();

            //table
            this.table.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                                                                       | System.Windows.Forms.AnchorStyles.Left)
                                                                      | System.Windows.Forms.AnchorStyles.Right)));
            this.table.ColumnCount = 1;
            this.table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.table.Location = new System.Drawing.Point(0, 0);
            this.table.Name = "table";
            this.table.RowCount = 1;
            this.table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.table.Size = new System.Drawing.Size(260, 190);
            this.table.TabIndex = 0;

            //backgroundworker
            this.backgroundWorker.WorkerSupportsCancellation = true;
            this.backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_DoWork);

            //lblWon
            this.lblWon.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.lblWon.Location = new System.Drawing.Point(0, 193);
            this.lblWon.Name = "lblWon";
            this.lblWon.Size = new System.Drawing.Size(260, 23);
            this.lblWon.TabIndex = 0;

            // LightsOutGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.table);
            this.Name = "AllPay_LightOut";
            this.Size = new System.Drawing.Size(260, 219);
            this.ResumeLayout(false);
        }

        private void backgroundWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            var iteration = 0;
            while (this.table.Enabled && !this.table.IsDisposed && !backgroundWorker.CancellationPending)
            {
                SolvePuzzle(iteration);
                System.Threading.Thread.Sleep(150);
                iteration++;
            }
        }

        private void SolvePuzzle(int iteration)
        {
            var idx = 0;

            if (idx >= ResetIterations)
            {
                return;
            }

            idx = _resetIndexes[iteration];

            this.Invoke((ThreadStart)(() =>
            {
                ToggleControl((CheckBox)this.table.Controls[idx]);
                Button_Click(this.table.Controls[idx], EventArgs.Empty);
            }));
        }
        #endregion
        }
}
