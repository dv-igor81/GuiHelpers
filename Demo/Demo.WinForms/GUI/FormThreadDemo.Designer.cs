namespace GuiHelpers.Demo.GUI
{
    partial class FormThreadDemo
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
            this.label_DisplayModeWork = new System.Windows.Forms.Label();
            this.button_StartStop = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label_DisplayModeWork
            // 
            this.label_DisplayModeWork.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label_DisplayModeWork.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_DisplayModeWork.Location = new System.Drawing.Point(135, 12);
            this.label_DisplayModeWork.Name = "label_DisplayModeWork";
            this.label_DisplayModeWork.Size = new System.Drawing.Size(268, 44);
            this.label_DisplayModeWork.TabIndex = 0;
            this.label_DisplayModeWork.Text = "Режим работы";
            this.label_DisplayModeWork.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button_StartStop
            // 
            this.button_StartStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_StartStop.Location = new System.Drawing.Point(12, 12);
            this.button_StartStop.Name = "button_StartStop";
            this.button_StartStop.Size = new System.Drawing.Size(117, 44);
            this.button_StartStop.TabIndex = 1;
            this.button_StartStop.Text = "Старт";
            this.button_StartStop.UseVisualStyleBackColor = true;
            // 
            // FormThreadDemo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(415, 76);
            this.Controls.Add(this.button_StartStop);
            this.Controls.Add(this.label_DisplayModeWork);
            this.Name = "FormThreadDemo";
            this.Text = "FormThreadDemo";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label_DisplayModeWork;
        private System.Windows.Forms.Button button_StartStop;
    }
}