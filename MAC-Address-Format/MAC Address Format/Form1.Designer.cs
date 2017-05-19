namespace MAC_Address_Format
{
    partial class frmMACAdressFormat
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
            this.lblMACInput = new System.Windows.Forms.Label();
            this.txtMACInput = new System.Windows.Forms.TextBox();
            this.btnFormat = new System.Windows.Forms.Button();
            this.txtMACFormatted = new System.Windows.Forms.TextBox();
            this.lblError = new System.Windows.Forms.Label();
            this.lblFormattedMacAddresses = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblMACInput
            // 
            this.lblMACInput.AutoSize = true;
            this.lblMACInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMACInput.Location = new System.Drawing.Point(112, 15);
            this.lblMACInput.Name = "lblMACInput";
            this.lblMACInput.Size = new System.Drawing.Size(147, 17);
            this.lblMACInput.TabIndex = 1;
            this.lblMACInput.Text = "Enter a MAC Address:";
            // 
            // txtMACInput
            // 
            this.txtMACInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMACInput.Location = new System.Drawing.Point(102, 35);
            this.txtMACInput.MaxLength = 17;
            this.txtMACInput.Name = "txtMACInput";
            this.txtMACInput.Size = new System.Drawing.Size(154, 23);
            this.txtMACInput.TabIndex = 0;
            this.txtMACInput.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnFormat
            // 
            this.btnFormat.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFormat.Location = new System.Drawing.Point(131, 79);
            this.btnFormat.Name = "btnFormat";
            this.btnFormat.Size = new System.Drawing.Size(97, 27);
            this.btnFormat.TabIndex = 1;
            this.btnFormat.Text = "Format";
            this.btnFormat.UseVisualStyleBackColor = true;
            this.btnFormat.Click += new System.EventHandler(this.btnFormat_Click);
            // 
            // txtMACFormatted
            // 
            this.txtMACFormatted.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMACFormatted.Location = new System.Drawing.Point(12, 255);
            this.txtMACFormatted.Multiline = true;
            this.txtMACFormatted.Name = "txtMACFormatted";
            this.txtMACFormatted.ReadOnly = true;
            this.txtMACFormatted.Size = new System.Drawing.Size(334, 159);
            this.txtMACFormatted.TabIndex = 2;
            this.txtMACFormatted.Text = "\r\n";
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.ForeColor = System.Drawing.Color.Red;
            this.lblError.Location = new System.Drawing.Point(127, 124);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(0, 13);
            this.lblError.TabIndex = 3;
            // 
            // lblFormattedMacAddresses
            // 
            this.lblFormattedMacAddresses.AutoSize = true;
            this.lblFormattedMacAddresses.Location = new System.Drawing.Point(13, 236);
            this.lblFormattedMacAddresses.Name = "lblFormattedMacAddresses";
            this.lblFormattedMacAddresses.Size = new System.Drawing.Size(135, 13);
            this.lblFormattedMacAddresses.TabIndex = 4;
            this.lblFormattedMacAddresses.Text = "Formatted MAC Addresses:";
            // 
            // frmMACAdressFormat
            // 
            this.AcceptButton = this.btnFormat;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(358, 426);
            this.Controls.Add(this.lblFormattedMacAddresses);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.txtMACFormatted);
            this.Controls.Add(this.btnFormat);
            this.Controls.Add(this.txtMACInput);
            this.Controls.Add(this.lblMACInput);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmMACAdressFormat";
            this.Text = "MAC Address Format v1.2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblMACInput;
        private System.Windows.Forms.TextBox txtMACInput;
        private System.Windows.Forms.Button btnFormat;
        private System.Windows.Forms.TextBox txtMACFormatted;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.Label lblFormattedMacAddresses;
    }
}

