namespace ICA4_MyFirstEquals
{
    partial class ICA4_FirstEquals
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
            this.components = new System.ComponentModel.Container();
            this.RenderTick = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // RenderTick
            // 
            this.RenderTick.Interval = 50;
            this.RenderTick.Tick += new System.EventHandler(this.RenderTick_Tick);
            // 
            // ICA4_FirstEquals
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Name = "ICA4_FirstEquals";
            this.Text = "ICA4 First Equals";
            this.Load += new System.EventHandler(this.ICA4_FirstEquals_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer RenderTick;
    }
}

