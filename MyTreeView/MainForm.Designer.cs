namespace MyTreeView
{
    partial class MainForm
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

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.MyTreeView = new System.Windows.Forms.TreeView();
            this.Table = new System.Windows.Forms.DataGridView();
            this.CarName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Engine = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Power = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Transmissionbox = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Drive = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Color = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Mileage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveCar = new System.Windows.Forms.ToolStripMenuItem();
            this.LoadCar = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.Table)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // MyTreeView
            // 
            this.MyTreeView.Location = new System.Drawing.Point(25, 65);
            this.MyTreeView.Name = "MyTreeView";
            this.MyTreeView.Size = new System.Drawing.Size(243, 373);
            this.MyTreeView.TabIndex = 0;
            this.MyTreeView.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.MyTreeView_NodeMouseDoubleClick);
            // 
            // Table
            // 
            this.Table.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Table.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CarName,
            this.Engine,
            this.Power,
            this.Transmissionbox,
            this.Drive,
            this.Color,
            this.Mileage});
            this.Table.Location = new System.Drawing.Point(307, 90);
            this.Table.Name = "Table";
            this.Table.Size = new System.Drawing.Size(717, 348);
            this.Table.TabIndex = 1;
            // 
            // CarName
            // 
            this.CarName.HeaderText = "Наименование";
            this.CarName.Name = "CarName";
            // 
            // Engine
            // 
            this.Engine.HeaderText = "Двигатель";
            this.Engine.Name = "Engine";
            // 
            // Power
            // 
            this.Power.HeaderText = "Мощность";
            this.Power.Name = "Power";
            // 
            // Transmissionbox
            // 
            this.Transmissionbox.HeaderText = "Коробка передач";
            this.Transmissionbox.Name = "Transmissionbox";
            // 
            // Drive
            // 
            this.Drive.HeaderText = "Привод";
            this.Drive.Name = "Drive";
            // 
            // Color
            // 
            this.Color.HeaderText = "Цвет";
            this.Color.Name = "Color";
            // 
            // Mileage
            // 
            this.Mileage.HeaderText = "Пробег";
            this.Mileage.Name = "Mileage";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1063, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SaveCar,
            this.LoadCar});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // SaveCar
            // 
            this.SaveCar.Name = "SaveCar";
            this.SaveCar.Size = new System.Drawing.Size(180, 22);
            this.SaveCar.Text = "Сохранить";
            this.SaveCar.Click += new System.EventHandler(this.Save_Click);
            // 
            // LoadCar
            // 
            this.LoadCar.Name = "LoadCar";
            this.LoadCar.Size = new System.Drawing.Size(180, 22);
            this.LoadCar.Text = "Загрузить";
            this.LoadCar.Click += new System.EventHandler(this.LoadCar_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1063, 450);
            this.Controls.Add(this.Table);
            this.Controls.Add(this.MyTreeView);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Cars";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Table)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView MyTreeView;
        private System.Windows.Forms.DataGridView Table;
        private System.Windows.Forms.DataGridViewTextBoxColumn CarName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Engine;
        private System.Windows.Forms.DataGridViewTextBoxColumn Power;
        private System.Windows.Forms.DataGridViewTextBoxColumn Transmissionbox;
        private System.Windows.Forms.DataGridViewTextBoxColumn Drive;
        private System.Windows.Forms.DataGridViewTextBoxColumn Color;
        private System.Windows.Forms.DataGridViewTextBoxColumn Mileage;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SaveCar;
        private System.Windows.Forms.ToolStripMenuItem LoadCar;
    }
}

