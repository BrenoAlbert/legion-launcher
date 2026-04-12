namespace Winforms
{
    partial class Main
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            gamesBox = new GroupBox();
            gamesPanel = new FlowLayoutPanel();
            gamesBox.SuspendLayout();
            SuspendLayout();
            // 
            // gamesBox
            // 
            gamesBox.Controls.Add(gamesPanel);
            gamesBox.ForeColor = SystemColors.Control;
            gamesBox.Location = new Point(12, 12);
            gamesBox.Name = "gamesBox";
            gamesBox.Size = new Size(315, 577);
            gamesBox.TabIndex = 0;
            gamesBox.TabStop = false;
            gamesBox.Text = "Games";
            // 
            // gamesPanel
            // 
            gamesPanel.Dock = DockStyle.Fill;
            gamesPanel.FlowDirection = FlowDirection.TopDown;
            gamesPanel.Location = new Point(3, 19);
            gamesPanel.Name = "gamesPanel";
            gamesPanel.Size = new Size(309, 555);
            gamesPanel.TabIndex = 0;
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(30, 30, 30);
            ClientSize = new Size(1068, 601);
            Controls.Add(gamesBox);
            Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "Main";
            Text = "Form1";
            Load += Main_Load;
            gamesBox.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private GroupBox gamesBox;
        private Label label1;
        private FlowLayoutPanel gamesPanel;
    }
}
