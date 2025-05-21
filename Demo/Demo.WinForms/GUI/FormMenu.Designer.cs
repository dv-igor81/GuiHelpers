namespace GuiHelpers.Demo.GUI
{
    partial class FormMenu
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
            this.button_IntHelper = new System.Windows.Forms.Button();
            this.checkBox_HideMenu = new System.Windows.Forms.CheckBox();
            this.button_CloseForm = new System.Windows.Forms.Button();
            this.button_ThreadHelper = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button_IntHelper
            // 
            this.button_IntHelper.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_IntHelper.Location = new System.Drawing.Point(34, 12);
            this.button_IntHelper.Name = "button_IntHelper";
            this.button_IntHelper.Size = new System.Drawing.Size(257, 47);
            this.button_IntHelper.TabIndex = 0;
            this.button_IntHelper.Text = "Int Text Helpers Demo";
            this.button_IntHelper.UseVisualStyleBackColor = true;
            // 
            // checkBox_HideMenu
            // 
            this.checkBox_HideMenu.AutoSize = true;
            this.checkBox_HideMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.checkBox_HideMenu.Location = new System.Drawing.Point(89, 442);
            this.checkBox_HideMenu.Name = "checkBox_HideMenu";
            this.checkBox_HideMenu.Size = new System.Drawing.Size(146, 24);
            this.checkBox_HideMenu.TabIndex = 1;
            this.checkBox_HideMenu.Text = "Hide Menu Form";
            this.checkBox_HideMenu.UseVisualStyleBackColor = true;
            // 
            // button_CloseForm
            // 
            this.button_CloseForm.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_CloseForm.Location = new System.Drawing.Point(34, 118);
            this.button_CloseForm.Name = "button_CloseForm";
            this.button_CloseForm.Size = new System.Drawing.Size(257, 47);
            this.button_CloseForm.TabIndex = 2;
            this.button_CloseForm.Text = "Закрыть форму";
            this.button_CloseForm.UseVisualStyleBackColor = true;
            // 
            // button_ThreadHelper
            // 
            this.button_ThreadHelper.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_ThreadHelper.Location = new System.Drawing.Point(34, 65);
            this.button_ThreadHelper.Name = "button_ThreadHelper";
            this.button_ThreadHelper.Size = new System.Drawing.Size(257, 47);
            this.button_ThreadHelper.TabIndex = 3;
            this.button_ThreadHelper.Text = "Thread Helpers Demo";
            this.button_ThreadHelper.UseVisualStyleBackColor = true;
            // 
            // FormMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(325, 478);
            this.Controls.Add(this.button_ThreadHelper);
            this.Controls.Add(this.button_CloseForm);
            this.Controls.Add(this.checkBox_HideMenu);
            this.Controls.Add(this.button_IntHelper);
            this.Name = "FormMenu";
            this.Text = "FormMenu";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_IntHelper;
        private System.Windows.Forms.CheckBox checkBox_HideMenu;
        private System.Windows.Forms.Button button_CloseForm;
        private System.Windows.Forms.Button button_ThreadHelper;
    }
}