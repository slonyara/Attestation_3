namespace Bombuzle
{
    partial class MainForm
    {
        /// <summary>
        /// Требуется переменная конструктора.
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

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.newGameButton = new System.Windows.Forms.Button();
            this.gameStateLabel = new System.Windows.Forms.Label();
            this.scoresLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.gameFieldDataGridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.gameFieldDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // newGameButton
            // 
            this.newGameButton.Location = new System.Drawing.Point(12, 12);
            this.newGameButton.Name = "newGameButton";
            this.newGameButton.Size = new System.Drawing.Size(103, 23);
            this.newGameButton.TabIndex = 6;
            this.newGameButton.Text = "Новая игра";
            this.newGameButton.UseVisualStyleBackColor = true;
            this.newGameButton.Click += new System.EventHandler(this.newGameButton_Click);
            // 
            // gameStateLabel
            // 
            this.gameStateLabel.AutoSize = true;
            this.gameStateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.gameStateLabel.Location = new System.Drawing.Point(121, 12);
            this.gameStateLabel.Name = "gameStateLabel";
            this.gameStateLabel.Size = new System.Drawing.Size(143, 20);
            this.gameStateLabel.TabIndex = 8;
            this.gameStateLabel.Text = "Игра не начилась";
            // 
            // scoresLabel
            // 
            this.scoresLabel.AutoSize = true;
            this.scoresLabel.Location = new System.Drawing.Point(121, 51);
            this.scoresLabel.Name = "scoresLabel";
            this.scoresLabel.Size = new System.Drawing.Size(13, 13);
            this.scoresLabel.TabIndex = 14;
            this.scoresLabel.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Очков собрано:";
            // 
            // gameFieldDataGridView
            // 
            this.gameFieldDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gameFieldDataGridView.Location = new System.Drawing.Point(12, 106);
            this.gameFieldDataGridView.Name = "gameFieldDataGridView";
            this.gameFieldDataGridView.Size = new System.Drawing.Size(240, 150);
            this.gameFieldDataGridView.TabIndex = 7;
            this.gameFieldDataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gameFieldDataGridView_CellClick);
            this.gameFieldDataGridView.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.gameFieldDataGridView_CellPainting);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(436, 480);
            this.Controls.Add(this.scoresLabel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.gameStateLabel);
            this.Controls.Add(this.gameFieldDataGridView);
            this.Controls.Add(this.newGameButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Бомбузли";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gameFieldDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button newGameButton;
        private System.Windows.Forms.Label gameStateLabel;
        private System.Windows.Forms.Label scoresLabel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView gameFieldDataGridView;
    }
}

