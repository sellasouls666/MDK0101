namespace BindingListExample
{
    partial class EditGame
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.changedName = new System.Windows.Forms.TextBox();
            this.changedGenre = new System.Windows.Forms.TextBox();
            this.labelName = new System.Windows.Forms.Label();
            this.labelGenre = new System.Windows.Forms.Label();
            this.labelPrice = new System.Windows.Forms.Label();
            this.labelRelease = new System.Windows.Forms.Label();
            this.boxPrice = new System.Windows.Forms.NumericUpDown();
            this.boxRelease = new System.Windows.Forms.DateTimePicker();
            this.buttonOk = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.boxPrice)).BeginInit();
            this.SuspendLayout();
            // 
            // changedName
            // 
            this.changedName.Location = new System.Drawing.Point(101, 20);
            this.changedName.Name = "changedName";
            this.changedName.Size = new System.Drawing.Size(200, 20);
            this.changedName.TabIndex = 0;
            // 
            // changedGenre
            // 
            this.changedGenre.Location = new System.Drawing.Point(101, 56);
            this.changedGenre.Name = "changedGenre";
            this.changedGenre.Size = new System.Drawing.Size(200, 20);
            this.changedGenre.TabIndex = 1;
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(45, 21);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(35, 13);
            this.labelName.TabIndex = 4;
            this.labelName.Text = "Name";
            // 
            // labelGenre
            // 
            this.labelGenre.AutoSize = true;
            this.labelGenre.Location = new System.Drawing.Point(43, 58);
            this.labelGenre.Name = "labelGenre";
            this.labelGenre.Size = new System.Drawing.Size(36, 13);
            this.labelGenre.TabIndex = 5;
            this.labelGenre.Text = "Genre";
            // 
            // labelPrice
            // 
            this.labelPrice.AutoSize = true;
            this.labelPrice.Location = new System.Drawing.Point(43, 97);
            this.labelPrice.Name = "labelPrice";
            this.labelPrice.Size = new System.Drawing.Size(31, 13);
            this.labelPrice.TabIndex = 6;
            this.labelPrice.Text = "Price";
            // 
            // labelRelease
            // 
            this.labelRelease.AutoSize = true;
            this.labelRelease.Location = new System.Drawing.Point(41, 139);
            this.labelRelease.Name = "labelRelease";
            this.labelRelease.Size = new System.Drawing.Size(46, 13);
            this.labelRelease.TabIndex = 7;
            this.labelRelease.Text = "Release";
            // 
            // boxPrice
            // 
            this.boxPrice.Location = new System.Drawing.Point(101, 97);
            this.boxPrice.Name = "boxPrice";
            this.boxPrice.Size = new System.Drawing.Size(200, 20);
            this.boxPrice.TabIndex = 8;
            // 
            // boxRelease
            // 
            this.boxRelease.Location = new System.Drawing.Point(101, 133);
            this.boxRelease.Name = "boxRelease";
            this.boxRelease.Size = new System.Drawing.Size(200, 20);
            this.boxRelease.TabIndex = 9;
            // 
            // buttonOk
            // 
            this.buttonOk.Location = new System.Drawing.Point(63, 179);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 23);
            this.buttonOk.TabIndex = 10;
            this.buttonOk.Text = "Ok";
            this.buttonOk.UseVisualStyleBackColor = true;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(190, 179);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 11;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // EditGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 227);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.boxRelease);
            this.Controls.Add(this.boxPrice);
            this.Controls.Add(this.labelRelease);
            this.Controls.Add(this.labelPrice);
            this.Controls.Add(this.labelGenre);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.changedGenre);
            this.Controls.Add(this.changedName);
            this.Name = "EditGame";
            this.Text = "Edit";
            this.Load += new System.EventHandler(this.EditGame_Load);
            ((System.ComponentModel.ISupportInitialize)(this.boxPrice)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox changedName;
        private System.Windows.Forms.TextBox changedGenre;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Label labelGenre;
        private System.Windows.Forms.Label labelPrice;
        private System.Windows.Forms.Label labelRelease;
        private System.Windows.Forms.NumericUpDown boxPrice;
        private System.Windows.Forms.DateTimePicker boxRelease;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button buttonCancel;
    }
}