using System.Windows.Forms;

namespace PokerTry2
{
    partial class Form1
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
            TableField = new Panel();
            Pot = new Label();
            pictureBox1 = new PictureBox();
            UI = new TableLayoutPanel();
            ButtonsField = new Panel();
            Fold = new Button();
            Call = new Button();
            Bet = new Button();
            TableField.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            UI.SuspendLayout();
            ButtonsField.SuspendLayout();
            SuspendLayout();
            // 
            // TableField
            // 
            TableField.BackgroundImage = Properties.Resources.table11;
            TableField.BackgroundImageLayout = ImageLayout.Zoom;
            TableField.Controls.Add(Pot);
            TableField.Controls.Add(pictureBox1);
            TableField.Dock = DockStyle.Fill;
            TableField.Location = new Point(3, 3);
            TableField.Name = "TableField";
            TableField.Size = new Size(1476, 721);
            TableField.TabIndex = 0;
            // 
            // Pot
            // 
            Pot.AutoSize = true;
            Pot.BackColor = Color.Transparent;
            Pot.Font = new Font("Segoe UI", 24F);
            Pot.ForeColor = Color.White;
            Pot.Location = new Point(641, 285);
            Pot.Name = "Pot";
            Pot.Size = new Size(101, 54);
            Pot.TabIndex = 6;
            Pot.Text = "Pot: ";
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.Image = Properties.Resources.Card_DeckA_88x140;
            pictureBox1.Location = new Point(452, 274);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(88, 140);
            pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // UI
            // 
            UI.AutoSize = true;
            UI.ColumnCount = 1;
            UI.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            UI.Controls.Add(ButtonsField, 0, 1);
            UI.Controls.Add(TableField, 0, 0);
            UI.Dock = DockStyle.Fill;
            UI.Location = new Point(0, 0);
            UI.Name = "UI";
            UI.RowCount = 2;
            UI.RowStyles.Add(new RowStyle(SizeType.Percent, 88.4194F));
            UI.RowStyles.Add(new RowStyle(SizeType.Percent, 11.580595F));
            UI.Size = new Size(1482, 823);
            UI.TabIndex = 1;
            // 
            // ButtonsField
            // 
            ButtonsField.Controls.Add(Fold);
            ButtonsField.Controls.Add(Call);
            ButtonsField.Controls.Add(Bet);
            ButtonsField.Dock = DockStyle.Fill;
            ButtonsField.Location = new Point(3, 730);
            ButtonsField.Name = "ButtonsField";
            ButtonsField.Size = new Size(1476, 90);
            ButtonsField.TabIndex = 1;
            // 
            // Fold
            // 
            Fold.Location = new Point(641, 23);
            Fold.Name = "Fold";
            Fold.Size = new Size(94, 29);
            Fold.TabIndex = 2;
            Fold.Text = "Fold";
            Fold.UseVisualStyleBackColor = true;
            Fold.Click += Fold_Click;
            // 
            // Call
            // 
            Call.Location = new Point(482, 22);
            Call.Name = "Call";
            Call.Size = new Size(94, 29);
            Call.TabIndex = 1;
            Call.Text = "Check";
            Call.UseVisualStyleBackColor = true;
            Call.Click += Call_Click;
            // 
            // Bet
            // 
            Bet.Location = new Point(315, 23);
            Bet.Name = "Bet";
            Bet.Size = new Size(94, 29);
            Bet.TabIndex = 0;
            Bet.Text = "Bet";
            Bet.UseVisualStyleBackColor = true;
            Bet.Click += Bet_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.MidnightBlue;
            ClientSize = new Size(1482, 823);
            Controls.Add(UI);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "Form1";
            Text = "Form1";
            TableField.ResumeLayout(false);
            TableField.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            UI.ResumeLayout(false);
            ButtonsField.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel TableField;
        private Panel ButtonsField;
        private PictureBox pictureBox1;
        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel UI;
        private Button Fold;
        private Button Call;
        private Button Bet;
        private Label label1;
        private Label Pot;
    }
}
