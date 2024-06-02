namespace PokerTry2
{
    partial class BottomCenterHand
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            HandPanel = new TableLayoutPanel();
            dealerMark = new PictureBox();
            tableLayoutPanel1 = new TableLayoutPanel();
            Stack = new Label();
            LastBet = new Label();
            BetType = new Label();
            HandPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dealerMark).BeginInit();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // HandPanel
            // 
            HandPanel.AutoScroll = true;
            HandPanel.AutoSize = true;
            HandPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            HandPanel.BackColor = Color.Transparent;
            HandPanel.ColumnCount = 5;
            HandPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 72F));
            HandPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 72F));
            HandPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 72F));
            HandPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 72F));
            HandPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 72F));
            HandPanel.Controls.Add(dealerMark, 4, 0);
            HandPanel.Controls.Add(tableLayoutPanel1, 0, 0);
            HandPanel.Controls.Add(BetType, 3, 0);
            HandPanel.Dock = DockStyle.Fill;
            HandPanel.Location = new Point(0, 0);
            HandPanel.Margin = new Padding(0);
            HandPanel.Name = "HandPanel";
            HandPanel.RowCount = 2;
            HandPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 67F));
            HandPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 96F));
            HandPanel.Size = new Size(360, 163);
            HandPanel.TabIndex = 0;
            // 
            // dealerMark
            // 
            dealerMark.Image = Properties.Resources.DealerMark;
            dealerMark.Location = new Point(288, 0);
            dealerMark.Margin = new Padding(0);
            dealerMark.Name = "dealerMark";
            dealerMark.Size = new Size(60, 66);
            dealerMark.SizeMode = PictureBoxSizeMode.AutoSize;
            dealerMark.TabIndex = 1;
            dealerMark.TabStop = false;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.AutoSize = true;
            tableLayoutPanel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            tableLayoutPanel1.ColumnCount = 1;
            HandPanel.SetColumnSpan(tableLayoutPanel1, 3);
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(Stack, 0, 0);
            tableLayoutPanel1.Controls.Add(LastBet, 0, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Margin = new Padding(0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(216, 67);
            tableLayoutPanel1.TabIndex = 2;
            // 
            // Stack
            // 
            Stack.AutoSize = true;
            Stack.Font = new Font("Segoe UI", 12F);
            Stack.ForeColor = Color.White;
            Stack.Location = new Point(0, 0);
            Stack.Margin = new Padding(0);
            Stack.Name = "Stack";
            Stack.Size = new Size(0, 28);
            Stack.TabIndex = 0;
            Stack.Click += Stack_Click;
            // 
            // LastBet
            // 
            LastBet.AutoSize = true;
            LastBet.Font = new Font("Segoe UI", 12F);
            LastBet.ForeColor = Color.White;
            LastBet.Location = new Point(0, 33);
            LastBet.Margin = new Padding(0);
            LastBet.Name = "LastBet";
            LastBet.Size = new Size(0, 28);
            LastBet.TabIndex = 1;
            // 
            // BetType
            // 
            BetType.AutoSize = true;
            BetType.Font = new Font("Segoe UI", 12F);
            BetType.ForeColor = Color.White;
            BetType.Location = new Point(216, 0);
            BetType.Margin = new Padding(0);
            BetType.Name = "BetType";
            BetType.Size = new Size(0, 28);
            BetType.TabIndex = 5;
            // 
            // BottomCenterHand
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BackColor = Color.Transparent;
            Controls.Add(HandPanel);
            Margin = new Padding(0);
            Name = "BottomCenterHand";
            Size = new Size(360, 163);
            HandPanel.ResumeLayout(false);
            HandPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dealerMark).EndInit();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TableLayoutPanel HandPanel;
        private PictureBox dealerMark;
        private TableLayoutPanel tableLayoutPanel1;
        private Label Stack;
        private Label LastBet;
        private Label BetType;
    }
}
