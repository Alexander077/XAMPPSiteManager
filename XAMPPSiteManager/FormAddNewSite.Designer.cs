using System.Windows.Forms;

namespace XAMPPSiteManager
{
	partial class FormAddNewSite
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAddNewSite));
			this.label1 = new System.Windows.Forms.Label();
			this.textBoxNewSiteDomainName = new System.Windows.Forms.TextBox();
			this.buttonAddSite = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(65, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Site domain:";
			// 
			// textBoxNewSiteDomainName
			// 
			this.textBoxNewSiteDomainName.Location = new System.Drawing.Point(83, 21);
			this.textBoxNewSiteDomainName.Name = "textBoxNewSiteDomainName";
			this.textBoxNewSiteDomainName.Size = new System.Drawing.Size(242, 20);
			this.textBoxNewSiteDomainName.TabIndex = 1;
			this.textBoxNewSiteDomainName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxNewSiteDomainName_KeyDown);
			// 
			// buttonAddSite
			// 
			this.buttonAddSite.Location = new System.Drawing.Point(250, 47);
			this.buttonAddSite.Name = "buttonAddSite";
			this.buttonAddSite.Size = new System.Drawing.Size(75, 23);
			this.buttonAddSite.TabIndex = 2;
			this.buttonAddSite.Text = "Add site";
			this.buttonAddSite.UseVisualStyleBackColor = true;
			this.buttonAddSite.Click += new System.EventHandler(this.buttonAddSite_Click);
			// 
			// FormAddNewSite
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(346, 91);
			this.Controls.Add(this.buttonAddSite);
			this.Controls.Add(this.textBoxNewSiteDomainName);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Name = "FormAddNewSite";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Add New Site";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox textBoxNewSiteDomainName;
		private System.Windows.Forms.Button buttonAddSite;
	}
}