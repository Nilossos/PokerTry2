using System.Windows.Forms;

namespace PokerTry2
{
    partial class Poker
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
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            Pot = new Label();
            pictureBox1 = new PictureBox();
            UI = new TableLayoutPanel();
            ButtonsField = new Panel();
            tableLayoutPanel2 = new TableLayoutPanel();
            Call = new Button();
            BetAmount = new TextBox();
            Replace = new Button();
            Increase_Button = new Button();
            Decrease_button = new Button();
            Bet = new Button();
            Fold = new Button();
            TableField.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            UI.SuspendLayout();
            ButtonsField.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            SuspendLayout();
            // 
            // TableField
            // 
            TableField.BackColor = Color.Green;
            TableField.BackgroundImage = Properties.Resources.table11;
            TableField.BackgroundImageLayout = ImageLayout.Zoom;
            TableField.Controls.Add(label4);
            TableField.Controls.Add(label3);
            TableField.Controls.Add(label2);
            TableField.Controls.Add(label1);
            TableField.Controls.Add(Pot);
            TableField.Controls.Add(pictureBox1);
            TableField.Dock = DockStyle.Fill;
            TableField.Location = new Point(0, 0);
            TableField.Margin = new Padding(0);
            TableField.Name = "TableField";
            TableField.Size = new Size(1482, 727);
            TableField.TabIndex = 0;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Segoe UI", 12F);
            label4.ForeColor = SystemColors.Control;
            label4.Location = new Point(1420, 160);
            label4.Name = "label4";
            label4.Size = new Size(59, 28);
            label4.TabIndex = 10;
            label4.Text = "Бот 4";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Segoe UI", 12F);
            label3.ForeColor = SystemColors.Control;
            label3.Location = new Point(157, 0);
            label3.Name = "label3";
            label3.Size = new Size(59, 28);
            label3.TabIndex = 9;
            label3.Text = "Бот 2";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI", 12F);
            label2.ForeColor = SystemColors.Control;
            label2.Location = new Point(1238, 0);
            label2.Name = "label2";
            label2.Size = new Size(59, 28);
            label2.TabIndex = 8;
            label2.Text = "Бот 3";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 12F);
            label1.ForeColor = SystemColors.Control;
            label1.Location = new Point(0, 145);
            label1.Name = "label1";
            label1.Size = new Size(59, 28);
            label1.TabIndex = 7;
            label1.Text = "Бот 1";
            // 
            // Pot
            // 
            Pot.AutoSize = true;
            Pot.BackColor = Color.Transparent;
            Pot.Font = new Font("Segoe UI", 24F);
            Pot.ForeColor = Color.White;
            Pot.Location = new Point(641, 285);
            Pot.Name = "Pot";
            Pot.Size = new Size(123, 54);
            Pot.TabIndex = 6;
            Pot.Text = "Pot: 0";
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
            ButtonsField.Controls.Add(tableLayoutPanel2);
            ButtonsField.Controls.Add(Bet);
            ButtonsField.Controls.Add(Fold);
            ButtonsField.Dock = DockStyle.Fill;
            ButtonsField.Location = new Point(0, 727);
            ButtonsField.Margin = new Padding(0);
            ButtonsField.Name = "ButtonsField";
            ButtonsField.Size = new Size(1482, 96);
            ButtonsField.TabIndex = 1;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.BackColor = Color.Green;
            tableLayoutPanel2.ColumnCount = 3;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 45F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Controls.Add(Call, 0, 1);
            tableLayoutPanel2.Controls.Add(BetAmount, 0, 0);
            tableLayoutPanel2.Controls.Add(Replace, 2, 1);
            tableLayoutPanel2.Controls.Add(Increase_Button, 1, 0);
            tableLayoutPanel2.Controls.Add(Decrease_button, 1, 1);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(94, 0);
            tableLayoutPanel2.Margin = new Padding(0);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 2;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Size = new Size(1294, 96);
            tableLayoutPanel2.TabIndex = 3;
            // 
            // Call
            // 
            Call.BackColor = Color.Gray;
            Call.Dock = DockStyle.Fill;
            Call.Enabled = false;
            Call.FlatStyle = FlatStyle.Popup;
            Call.Location = new Point(0, 48);
            Call.Margin = new Padding(0);
            Call.Name = "Call";
            Call.Size = new Size(582, 48);
            Call.TabIndex = 1;
            Call.Text = "Check";
            Call.UseVisualStyleBackColor = false;
            Call.Click += Call_Click;
            // 
            // BetAmount
            // 
            BetAmount.BorderStyle = BorderStyle.None;
            BetAmount.Dock = DockStyle.Fill;
            BetAmount.Font = new Font("Segoe UI", 12F);
            BetAmount.Location = new Point(0, 0);
            BetAmount.Margin = new Padding(0);
            BetAmount.Name = "BetAmount";
            BetAmount.PlaceholderText = "Amount";
            BetAmount.Size = new Size(582, 27);
            BetAmount.TabIndex = 2;
            BetAmount.Text = "0";
            BetAmount.KeyPress += BetAmount_KeyPress;
            // 
            // Replace
            // 
            Replace.BackColor = Color.Gray;
            Replace.Enabled = false;
            Replace.FlatStyle = FlatStyle.Popup;
            Replace.Location = new Point(646, 48);
            Replace.Margin = new Padding(0);
            Replace.Name = "Replace";
            Replace.Size = new Size(634, 45);
            Replace.TabIndex = 3;
            Replace.Text = "Replace";
            Replace.UseVisualStyleBackColor = false;
            Replace.Click += Replace_Click;
            // 
            // Increase_Button
            // 
            Increase_Button.Location = new Point(585, 3);
            Increase_Button.Name = "Increase_Button";
            Increase_Button.Size = new Size(58, 29);
            Increase_Button.TabIndex = 4;
            Increase_Button.Text = "+";
            Increase_Button.UseVisualStyleBackColor = true;
            Increase_Button.Click += Increase_Click;
            // 
            // Decrease_button
            // 
            Decrease_button.Location = new Point(585, 51);
            Decrease_button.Name = "Decrease_button";
            Decrease_button.Size = new Size(58, 29);
            Decrease_button.TabIndex = 5;
            Decrease_button.Text = "-";
            Decrease_button.UseVisualStyleBackColor = true;
            Decrease_button.Click += Decrease_Click;
            // 
            // Bet
            // 
            Bet.BackColor = Color.Gray;
            Bet.Dock = DockStyle.Left;
            Bet.Enabled = false;
            Bet.FlatStyle = FlatStyle.Flat;
            Bet.Location = new Point(0, 0);
            Bet.Margin = new Padding(0);
            Bet.Name = "Bet";
            Bet.Size = new Size(94, 96);
            Bet.TabIndex = 0;
            Bet.Text = "Bet";
            Bet.UseVisualStyleBackColor = false;
            Bet.Click += Bet_Click;
            // 
            // Fold
            // 
            Fold.BackColor = Color.Gray;
            Fold.Dock = DockStyle.Right;
            Fold.Enabled = false;
            Fold.FlatStyle = FlatStyle.Flat;
            Fold.Location = new Point(1388, 0);
            Fold.Name = "Fold";
            Fold.Size = new Size(94, 96);
            Fold.TabIndex = 2;
            Fold.Text = "Fold";
            Fold.UseVisualStyleBackColor = false;
            Fold.Click += Fold_Click;
            // 
            // Poker
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.MidnightBlue;
            ClientSize = new Size(1482, 823);
            Controls.Add(UI);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            MaximizeBox = false;
            Name = "Poker";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Poker";
            TableField.ResumeLayout(false);
            TableField.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            UI.ResumeLayout(false);
            ButtonsField.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
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
        private TableLayoutPanel tableLayoutPanel2;
        private TextBox BetAmount;
        private Button Replace;
        private Button Increase_Button;
        private Button Decrease_button;
        private Label label4;
        private Label label3;
        private Label label2;
    }
}
