namespace PokerTry2
{
    partial class RightCenterHand
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
            Stack = new Label();
            DealerMark = new PictureBox();
            LastBet = new Label();
            BetType = new Label();
            HandPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DealerMark).BeginInit();
            SuspendLayout();
            // 
            // HandPanel
            // 
            HandPanel.AutoSize = true;
            HandPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            HandPanel.BackColor = Color.Transparent;
            HandPanel.ColumnCount = 2;
            HandPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 120F));
            HandPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 96F));
            HandPanel.Controls.Add(Stack, 0, 0);
            HandPanel.Controls.Add(DealerMark, 0, 4);
            HandPanel.Controls.Add(LastBet, 0, 1);
            HandPanel.Controls.Add(BetType, 0, 2);
            HandPanel.Dock = DockStyle.Fill;
            HandPanel.Location = new Point(0, 0);
            HandPanel.Margin = new Padding(0);
            HandPanel.Name = "HandPanel";
            HandPanel.RowCount = 5;
            HandPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 72F));
            HandPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 72F));
            HandPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 72F));
            HandPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 72F));
            HandPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 72F));
            HandPanel.Size = new Size(216, 360);
            HandPanel.TabIndex = 0;
            // 
            // Stack
            // 
            Stack.AutoSize = true;
            Stack.Dock = DockStyle.Fill;
            Stack.Font = new Font("Segoe UI", 12F);
            Stack.ForeColor = Color.White;
            Stack.Location = new Point(0, 0);
            Stack.Margin = new Padding(0);
            Stack.Name = "Stack";
            Stack.Size = new Size(120, 72);
            Stack.TabIndex = 0;
            // 
            // DealerMark
            // 
            DealerMark.Dock = DockStyle.Right;
            DealerMark.Image = Properties.Resources.DealerMark;
            DealerMark.Location = new Point(60, 288);
            DealerMark.Margin = new Padding(0);
            DealerMark.Name = "DealerMark";
            DealerMark.Size = new Size(60, 72);
            DealerMark.SizeMode = PictureBoxSizeMode.AutoSize;
            DealerMark.TabIndex = 2;
            DealerMark.TabStop = false;
            DealerMark.Click += DealerMark_Click;
            // 
            // LastBet
            // 
            LastBet.AutoSize = true;
            LastBet.Dock = DockStyle.Fill;
            LastBet.Font = new Font("Segoe UI", 12F);
            LastBet.ForeColor = Color.White;
            LastBet.Location = new Point(0, 72);
            LastBet.Margin = new Padding(0);
            LastBet.Name = "LastBet";
            LastBet.Size = new Size(120, 72);
            LastBet.TabIndex = 3;
            // 
            // BetType
            // 
            BetType.AutoSize = true;
            BetType.Dock = DockStyle.Fill;
            BetType.Font = new Font("Segoe UI", 12F);
            BetType.ForeColor = Color.White;
            BetType.Location = new Point(0, 144);
            BetType.Margin = new Padding(0);
            BetType.Name = "BetType";
            BetType.Size = new Size(120, 72);
            BetType.TabIndex = 4;
            // 
            // RightCenterHand
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BackColor = Color.Transparent;
            Controls.Add(HandPanel);
            Margin = new Padding(0);
            Name = "RightCenterHand";
            Size = new Size(216, 360);
            HandPanel.ResumeLayout(false);
            HandPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)DealerMark).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TableLayoutPanel HandPanel;
        private Label Stack;
        private PictureBox DealerMark;
        private Label LastBet;
        private Label BetType;
    }
}
