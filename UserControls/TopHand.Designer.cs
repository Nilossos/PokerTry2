namespace PokerTry2
{
    partial class TopHand
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
            BetType = new Label();
            DealerMark = new PictureBox();
            tableLayoutPanel1 = new TableLayoutPanel();
            Stack = new Label();
            LastBet = new Label();
            HandPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DealerMark).BeginInit();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // HandPanel
            // 
            HandPanel.AutoSize = true;
            HandPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            HandPanel.BackColor = Color.Transparent;
            HandPanel.ColumnCount = 5;
            HandPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 72F));
            HandPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 72F));
            HandPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 72F));
            HandPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 72F));
            HandPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 72F));
            HandPanel.Controls.Add(BetType, 0, 1);
            HandPanel.Controls.Add(DealerMark, 4, 1);
            HandPanel.Controls.Add(tableLayoutPanel1, 0, 1);
            HandPanel.Dock = DockStyle.Fill;
            HandPanel.Location = new Point(0, 0);
            HandPanel.Margin = new Padding(0);
            HandPanel.Name = "HandPanel";
            HandPanel.RowCount = 2;
            HandPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 96F));
            HandPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 66F));
            HandPanel.Size = new Size(360, 162);
            HandPanel.TabIndex = 0;
            // 
            // BetType
            // 
            BetType.AutoSize = true;
            BetType.Dock = DockStyle.Fill;
            BetType.Font = new Font("Segoe UI", 12F);
            BetType.ForeColor = Color.White;
            BetType.Location = new Point(216, 96);
            BetType.Margin = new Padding(0);
            BetType.Name = "BetType";
            BetType.Size = new Size(72, 66);
            BetType.TabIndex = 5;
            // 
            // DealerMark
            // 
            DealerMark.Image = Properties.Resources.DealerMark;
            DealerMark.Location = new Point(288, 96);
            DealerMark.Margin = new Padding(0);
            DealerMark.Name = "DealerMark";
            DealerMark.Size = new Size(60, 66);
            DealerMark.SizeMode = PictureBoxSizeMode.AutoSize;
            DealerMark.TabIndex = 1;
            DealerMark.TabStop = false;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            HandPanel.SetColumnSpan(tableLayoutPanel1, 3);
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(Stack, 0, 0);
            tableLayoutPanel1.Controls.Add(LastBet, 0, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 96);
            tableLayoutPanel1.Margin = new Padding(0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(216, 66);
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
            // TopHand
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BackColor = Color.Transparent;
            Controls.Add(HandPanel);
            Margin = new Padding(0);
            Name = "TopHand";
            Size = new Size(360, 162);
            HandPanel.ResumeLayout(false);
            HandPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)DealerMark).EndInit();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TableLayoutPanel HandPanel;
        private Label Stack;
        private PictureBox DealerMark;
        private TableLayoutPanel tableLayoutPanel1;
        private Label LastBet;
        private Label BetType;
    }
}
