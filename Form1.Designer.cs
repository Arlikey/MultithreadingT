namespace MultithreadingT
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            movingButton = new Button();
            moveSpeedHScrollBar = new HScrollBar();
            SuspendLayout();
            // 
            // movingButton
            // 
            movingButton.Location = new Point(356, 204);
            movingButton.Name = "movingButton";
            movingButton.Size = new Size(91, 32);
            movingButton.TabIndex = 0;
            movingButton.Text = "I'm Moving!";
            movingButton.UseVisualStyleBackColor = true;
            // 
            // moveSpeedHScrollBar
            // 
            moveSpeedHScrollBar.Location = new Point(320, 336);
            moveSpeedHScrollBar.Name = "moveSpeedHScrollBar";
            moveSpeedHScrollBar.Size = new Size(165, 17);
            moveSpeedHScrollBar.TabIndex = 1;
            moveSpeedHScrollBar.Scroll += moveSpeedHScrollBar_Scroll;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(moveSpeedHScrollBar);
            Controls.Add(movingButton);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button movingButton;
        private HScrollBar moveSpeedHScrollBar;
    }
}
