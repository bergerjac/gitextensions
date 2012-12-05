namespace GitUI.UserControls
{
    partial class Section
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.layoutChildren = new System.Windows.Forms.FlowLayoutPanel();
            this.btnObject = new System.Windows.Forms.Button();
            this.labImage = new System.Windows.Forms.Label();
            this.panelItem = new System.Windows.Forms.Panel();
            this.panelItem.SuspendLayout();
            this.SuspendLayout();
            // 
            // layoutChildren
            // 
            this.layoutChildren.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutChildren.Location = new System.Drawing.Point(0, 28);
            this.layoutChildren.Name = "layoutChildren";
            this.layoutChildren.Size = new System.Drawing.Size(150, 122);
            this.layoutChildren.TabIndex = 1;
            // 
            // btnObject
            // 
            this.btnObject.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnObject.FlatAppearance.BorderSize = 0;
            this.btnObject.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnObject.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnObject.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnObject.Location = new System.Drawing.Point(21, 0);
            this.btnObject.Name = "btnObject";
            this.btnObject.Size = new System.Drawing.Size(126, 25);
            this.btnObject.TabIndex = 0;
            this.btnObject.Text = "{Title}";
            this.btnObject.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnObject.UseVisualStyleBackColor = true;
            // 
            // labImage
            // 
            this.labImage.Image = global::GitUI.Properties.Resources.decrease;
            this.labImage.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labImage.Location = new System.Drawing.Point(0, 0);
            this.labImage.Name = "labImage";
            this.labImage.Size = new System.Drawing.Size(24, 24);
            this.labImage.TabIndex = 2;
            // 
            // panelItem
            // 
            this.panelItem.AutoSize = true;
            this.panelItem.Controls.Add(this.btnObject);
            this.panelItem.Controls.Add(this.labImage);
            this.panelItem.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelItem.Location = new System.Drawing.Point(0, 0);
            this.panelItem.Name = "panelItem";
            this.panelItem.Size = new System.Drawing.Size(150, 28);
            this.panelItem.TabIndex = 0;
            // 
            // Section
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.layoutChildren);
            this.Controls.Add(this.panelItem);
            this.Name = "Section";
            this.panelItem.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel layoutChildren;
        private System.Windows.Forms.Button btnObject;
        private System.Windows.Forms.Label labImage;
        private System.Windows.Forms.Panel panelItem;
    }
}
