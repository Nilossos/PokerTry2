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
            label1 = new Label();
            dealerMark = new PictureBox();
            HandPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dealerMark).BeginInit();
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
            HandPanel.Controls.Add(label1, 0, 0);
            HandPanel.Controls.Add(dealerMark, 4, 0);
            HandPanel.Dock = DockStyle.Fill;
            HandPanel.Location = new Point(0, 0);
            HandPanel.Name = "HandPanel";
            HandPanel.RowCount = 2;
            HandPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            HandPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 96F));
            HandPanel.Size = new Size(360, 168);
            HandPanel.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.Size = new Size(50, 20);
            label1.TabIndex = 0;
            label1.Text = "label1";
            // 
            // dealerMark
            // 
            dealerMark.Image = Properties.Resources.DealerMark;
            dealerMark.Location = new Point(291, 3);
            dealerMark.Name = "dealerMark";
            dealerMark.Size = new Size(60, 66);
            dealerMark.SizeMode = PictureBoxSizeMode.AutoSize;
            dealerMark.TabIndex = 1;
            dealerMark.TabStop = false;
            // 
            // BottomCenterHand
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            BackColor = Color.Transparent;
            BorderStyle = BorderStyle.FixedSingle;
            Controls.Add(HandPanel);
            Name = "BottomCenterHand";
            Size = new Size(360, 168);
            HandPanel.ResumeLayout(false);
            HandPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dealerMark).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TableLayoutPanel HandPanel;
        private Label label1;
        private PictureBox dealerMark;
    }
}
