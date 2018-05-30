namespace WFGUI
{
    partial class Shop
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
            this.UserInventory = new System.Windows.Forms.ListBox();
            this.UsernameLabel = new System.Windows.Forms.Label();
            this.UserMoney = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.ShopInventory = new System.Windows.Forms.ListView();
            this.ShopError = new System.Windows.Forms.Label();
            this.ShopLogout = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // UserInventory
            // 
            this.UserInventory.Enabled = false;
            this.UserInventory.FormattingEnabled = true;
            this.UserInventory.Location = new System.Drawing.Point(12, 32);
            this.UserInventory.Name = "UserInventory";
            this.UserInventory.Size = new System.Drawing.Size(153, 108);
            this.UserInventory.TabIndex = 1;
            // 
            // UsernameLabel
            // 
            this.UsernameLabel.AutoSize = true;
            this.UsernameLabel.Location = new System.Drawing.Point(87, 9);
            this.UsernameLabel.Name = "UsernameLabel";
            this.UsernameLabel.Size = new System.Drawing.Size(35, 13);
            this.UsernameLabel.TabIndex = 2;
            this.UsernameLabel.Text = "label1";
            // 
            // UserMoney
            // 
            this.UserMoney.AutoSize = true;
            this.UserMoney.Location = new System.Drawing.Point(110, 166);
            this.UserMoney.Name = "UserMoney";
            this.UserMoney.Size = new System.Drawing.Size(35, 13);
            this.UserMoney.TabIndex = 3;
            this.UserMoney.Text = "label1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Current User: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 166);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Account Balance: ";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(208, 161);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "Buy";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ShopInventory
            // 
            this.ShopInventory.Alignment = System.Windows.Forms.ListViewAlignment.Left;
            this.ShopInventory.HideSelection = false;
            this.ShopInventory.Location = new System.Drawing.Point(211, 32);
            this.ShopInventory.MultiSelect = false;
            this.ShopInventory.Name = "ShopInventory";
            this.ShopInventory.Size = new System.Drawing.Size(153, 108);
            this.ShopInventory.TabIndex = 7;
            this.ShopInventory.UseCompatibleStateImageBehavior = false;
            this.ShopInventory.View = System.Windows.Forms.View.List;
            // 
            // ShopError
            // 
            this.ShopError.AutoSize = true;
            this.ShopError.Location = new System.Drawing.Point(211, 9);
            this.ShopError.Name = "ShopError";
            this.ShopError.Size = new System.Drawing.Size(35, 13);
            this.ShopError.TabIndex = 8;
            this.ShopError.Text = "label3";
            this.ShopError.Visible = false;
            // 
            // ShopLogout
            // 
            this.ShopLogout.Location = new System.Drawing.Point(289, 161);
            this.ShopLogout.Name = "ShopLogout";
            this.ShopLogout.Size = new System.Drawing.Size(75, 23);
            this.ShopLogout.TabIndex = 9;
            this.ShopLogout.Text = "Logout";
            this.ShopLogout.UseVisualStyleBackColor = true;
            this.ShopLogout.Click += new System.EventHandler(this.ShopLogout_Click);
            // 
            // Shop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(408, 207);
            this.Controls.Add(this.ShopLogout);
            this.Controls.Add(this.ShopError);
            this.Controls.Add(this.ShopInventory);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.UserMoney);
            this.Controls.Add(this.UsernameLabel);
            this.Controls.Add(this.UserInventory);
            this.Name = "Shop";
            this.Text = "Shop";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListBox UserInventory;
        private System.Windows.Forms.Label UsernameLabel;
        private System.Windows.Forms.Label UserMoney;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListView ShopInventory;
        private System.Windows.Forms.Label ShopError;
        private System.Windows.Forms.Button ShopLogout;
    }
}