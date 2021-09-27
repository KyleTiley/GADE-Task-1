
namespace GADE_Task_1
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
            this.up_button = new System.Windows.Forms.Button();
            this.left_button = new System.Windows.Forms.Button();
            this.right_button = new System.Windows.Forms.Button();
            this.down_button = new System.Windows.Forms.Button();
            this.playerStats_label = new System.Windows.Forms.Label();
            this.enemy_label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // up_button
            // 
            this.up_button.Location = new System.Drawing.Point(612, 355);
            this.up_button.Name = "up_button";
            this.up_button.Size = new System.Drawing.Size(75, 23);
            this.up_button.TabIndex = 0;
            this.up_button.Text = "UP";
            this.up_button.UseVisualStyleBackColor = true;
            // 
            // left_button
            // 
            this.left_button.Location = new System.Drawing.Point(531, 375);
            this.left_button.Name = "left_button";
            this.left_button.Size = new System.Drawing.Size(75, 23);
            this.left_button.TabIndex = 1;
            this.left_button.Text = "LEFT";
            this.left_button.UseVisualStyleBackColor = true;
            // 
            // right_button
            // 
            this.right_button.Location = new System.Drawing.Point(693, 375);
            this.right_button.Name = "right_button";
            this.right_button.Size = new System.Drawing.Size(75, 23);
            this.right_button.TabIndex = 2;
            this.right_button.Text = "RIGHT";
            this.right_button.UseVisualStyleBackColor = true;
            // 
            // down_button
            // 
            this.down_button.Location = new System.Drawing.Point(612, 395);
            this.down_button.Name = "down_button";
            this.down_button.Size = new System.Drawing.Size(75, 23);
            this.down_button.TabIndex = 3;
            this.down_button.Text = "DOWN";
            this.down_button.UseVisualStyleBackColor = true;
            // 
            // playerStats_label
            // 
            this.playerStats_label.AutoSize = true;
            this.playerStats_label.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.playerStats_label.Location = new System.Drawing.Point(491, 9);
            this.playerStats_label.Name = "playerStats_label";
            this.playerStats_label.Size = new System.Drawing.Size(297, 137);
            this.playerStats_label.TabIndex = 4;
            this.playerStats_label.Text = "                                                                                 " +
    "               \r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n";
            // 
            // enemy_label
            // 
            this.enemy_label.AutoSize = true;
            this.enemy_label.Location = new System.Drawing.Point(507, 233);
            this.enemy_label.Name = "enemy_label";
            this.enemy_label.Size = new System.Drawing.Size(12, 15);
            this.enemy_label.TabIndex = 5;
            this.enemy_label.Text = "-";
            this.enemy_label.Click += new System.EventHandler(this.enemy_label_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.enemy_label);
            this.Controls.Add(this.playerStats_label);
            this.Controls.Add(this.down_button);
            this.Controls.Add(this.right_button);
            this.Controls.Add(this.left_button);
            this.Controls.Add(this.up_button);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button up_button;
        private System.Windows.Forms.Button left_button;
        private System.Windows.Forms.Button right_button;
        private System.Windows.Forms.Button down_button;
        private System.Windows.Forms.Label playerStats_label;
        private System.Windows.Forms.Label enemy_label;
    }
}

