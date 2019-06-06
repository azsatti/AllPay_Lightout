using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using AllPay_Lightout.Properties;

namespace AllPay_Lightout
{
    public partial class LightoutControl : UserControl
    {

        private const int GridSize = 5;
        private const int ResetIterations = 5;
        private readonly Random _rnd = new Random();
        private int[] _resetIndexes;

        /// <summary>
        /// Initialise a instance of class
        /// </summary>
        public LightoutControl()
        {
            InitializeComponent();
            InitializeGame();
            ResetControls();
        }

        private void InitializeGame()
        {
            this.table.RowCount = this.table.ColumnCount = GridSize;
            this.table.RowStyles.Clear();
            this.table.ColumnStyles.Clear();

            float percent = (float)(100.0 / GridSize);
            for (int i = 0; i < GridSize; i++)
                this.table.RowStyles.Add(new RowStyle(SizeType.Percent, percent));
            for (int i = 0; i < GridSize; i++)
                this.table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, percent));

            for (int i = 0; i < GridSize * GridSize; i++)
            {
                var button = new CheckBox
                {
                    Appearance = Appearance.Button,
                    Dock = DockStyle.Fill,
                    Margin = new Padding(0)
                };

                button.Click += this.Button_Click;

                this.table.Controls.Add(button, i % GridSize, i / GridSize);
            }
        }

        private static void ToggleControl(CheckBox btn)
        {
            btn.Checked = !btn.Checked;
            if (!VisualStyleInformation.IsEnabledByUser)
                btn.BackColor = btn.Checked ? Color.Green : Color.DarkGray;
        }

        private void ResetControls()
        {
            foreach (CheckBox btn in this.table.Controls)
            {
                btn.Checked = false;
                if (!VisualStyleInformation.IsEnabledByUser)
                    btn.BackColor = Color.DarkGray;
            }

            _resetIndexes = new int[ResetIterations];
            for (int i = 0; i < ResetIterations; i++)
            {
                var index = this._rnd.Next(GridSize * GridSize);
                _resetIndexes[i] = index;
                ToggleControl((CheckBox)this.table.Controls[index]);
                ToggleGrid(index);
            }

            this.table.Enabled = true;
        }
        private bool Winner()
        {
            bool first = ((CheckBox)this.table.Controls[0]).Checked;

            foreach (CheckBox btn in this.table.Controls)
                if (btn.Checked != first) return false;
            return true;
        }

        private void ToggleGrid(int index)
        {
            var colIdx = index % GridSize;
            var rowIdx = index / GridSize;

            // Toggle in all direction below to create lights pattern
            if (colIdx > 0) ToggleControl((CheckBox)this.table.Controls[index - 1]); 
            if (rowIdx < GridSize - 1) ToggleControl((CheckBox)this.table.Controls[index + GridSize]); 
            if (colIdx < GridSize - 1) ToggleControl((CheckBox)this.table.Controls[index + 1]); 
            if (rowIdx > 0) ToggleControl((CheckBox)this.table.Controls[index - GridSize]); 
        }

        private void Button_Click(object sender, EventArgs e)
        {
            int idx = this.table.Controls.IndexOf((Control)sender);

            if (!VisualStyleInformation.IsEnabledByUser)
            {
                var btn = (CheckBox)sender;
                btn.BackColor = btn.Checked ? Color.Green : Color.DarkGray;
            }

            ToggleGrid(idx);

            if (Winner())
            {
                this.table.Enabled = false;
                this.lblWon.Text = Resources.WinnerText;
            }
        }
    }
}
