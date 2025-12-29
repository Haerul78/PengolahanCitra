using System;
using System.Drawing;
using System.Windows.Forms;

namespace PengolahanCitra
{
    /// <summary>
    /// Popup Dialog untuk memilih operasi warna (Color Slicing / Pewarnaan Semu)
    /// </summary>
    public partial class ColorSlicingForm : Form
    {
        #region Properties

        /// <summary>
        /// Warna yang dipilih user
        /// </summary>
        public Color SelectedColor { get; set; }

        /// <summary>
        /// Toleransi untuk color slicing (0-200)
        /// </summary>
        public int Tolerance { get; private set; } = 50;

        /// <summary>
        /// Apakah menggunakan background grayscale
        /// </summary>
        public bool UseGrayBackground { get; private set; } = false;

        /// <summary>
        /// Operasi yang dipilih: "ColorSlicing", "PseudoColor", atau null jika cancel
        /// </summary>
        public string SelectedOperation { get; private set; } = null;

        #endregion

        #region Constructor

        public ColorSlicingForm(Color selectedColor)
        {
            InitializeComponent();
            SelectedColor = selectedColor;

            // Set color preview
            panelColorPreview.BackColor = SelectedColor;
            labelRGBValue.Text = $"R: {SelectedColor.R}  G: {SelectedColor.G}  B: {SelectedColor.B}";

            // Set default tolerance
            trackBarTolerance.Value = 50;
            labelToleranceValue.Text = "50";
        }

        #endregion

        #region Event Handlers

        private void btnColorSlicing_Click(object sender, EventArgs e)
        {
            SelectedOperation = "ColorSlicing";
            Tolerance = trackBarTolerance.Value;
            UseGrayBackground = checkBoxGrayBackground.Checked;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnPseudoColor_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Fitur Pewarnaan Semu akan segera hadir!", "Info",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            SelectedOperation = null;
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void trackBarTolerance_Scroll(object sender, EventArgs e)
        {
            Tolerance = trackBarTolerance.Value;
            labelToleranceValue.Text = Tolerance.ToString();
        }

        private void checkBoxGrayBackground_CheckedChanged(object sender, EventArgs e)
        {
            UseGrayBackground = checkBoxGrayBackground.Checked;
        }

        #endregion
    }
}