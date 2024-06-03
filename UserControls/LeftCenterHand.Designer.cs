namespace PokerTry2
{
    partial class LeftCenterHand
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
        /// 
        private void InitializeComponent()
        {
            HandPanel = new TableLayoutPanel();
            DealerMark = new PictureBox();
            Stack = new Label();
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
            HandPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 96F));
            HandPanel.ColumnStyles.Add(new ColumnStyle());
            HandPanel.Controls.Add(DealerMark, 1, 4);
            HandPanel.Controls.Add(Stack, 1, 0);
            HandPanel.Controls.Add(LastBet, 1, 1);
            HandPanel.Controls.Add(BetType, 1, 2);
            HandPanel.Dock = DockStyle.Fill;
            HandPanel.Location = new Point(0, 0);
            HandPanel.Name = "HandPanel";
            HandPanel.RowCount = 5;
            HandPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 72F));
            HandPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 72F));
            HandPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 72F));
            HandPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 72F));
            HandPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 72F));
            HandPanel.Size = new Size(162, 360);
            HandPanel.TabIndex = 0;
            HandPanel.Paint += HandPanel_Paint;
            // 
            // DealerMark
            // 
            DealerMark.Image = Properties.Resources.DealerMark;
            DealerMark.Location = new Point(99, 291);
            DealerMark.Name = "DealerMark";
            DealerMark.Size = new Size(60, 66);
            DealerMark.SizeMode = PictureBoxSizeMode.AutoSize;
            DealerMark.TabIndex = 2;
            DealerMark.TabStop = false;
            // 
            // Stack
            // 
            Stack.AutoSize = true;
            Stack.Font = new Font("Segoe UI", 12F);
            Stack.ForeColor = Color.White;
            Stack.Location = new Point(96, 0);
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
            LastBet.Location = new Point(96, 72);
            LastBet.Margin = new Padding(0);
            LastBet.Name = "LastBet";
            LastBet.Size = new Size(0, 28);
            LastBet.TabIndex = 3;
            // 
            // BetType
            // 
            BetType.AutoSize = true;
            BetType.Font = new Font("Segoe UI", 12F);
            BetType.ForeColor = Color.White;
            BetType.Location = new Point(96, 144);
            BetType.Margin = new Padding(0);
            BetType.Name = "BetType";
            BetType.Size = new Size(0, 28);
            BetType.TabIndex = 4;
            // 
            // LeftCenterHand
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BackColor = Color.Transparent;
            Controls.Add(HandPanel);
            Name = "LeftCenterHand";
            Size = new Size(162, 360);
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
