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
            label1 = new Label();
            DealerMark = new PictureBox();
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
            HandPanel.ColumnStyles.Add(new ColumnStyle());
            HandPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 96F));
            HandPanel.Controls.Add(label1, 0, 0);
            HandPanel.Controls.Add(DealerMark, 0, 4);
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
            // DealerMark
            // 
            DealerMark.Image = Properties.Resources.DealerMark;
            DealerMark.Location = new Point(3, 291);
            DealerMark.Name = "DealerMark";
            DealerMark.Size = new Size(60, 66);
            DealerMark.SizeMode = PictureBoxSizeMode.AutoSize;
            DealerMark.TabIndex = 2;
            DealerMark.TabStop = false;
            // 
            // RightCenterHand
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BackColor = Color.Transparent;
            BorderStyle = BorderStyle.FixedSingle;
            Controls.Add(HandPanel);
            Name = "RightCenterHand";
            Size = new Size(162, 360);
            HandPanel.ResumeLayout(false);
            HandPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)DealerMark).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TableLayoutPanel HandPanel;
        private Label label1;
        private PictureBox DealerMark;
    }
}
