
namespace HomeWork7
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.control_thL = new System.Windows.Forms.NumericUpDown();
            this.control_thR = new System.Windows.Forms.NumericUpDown();
            this.control_perL = new System.Windows.Forms.NumericUpDown();
            this.control_perR = new System.Windows.Forms.NumericUpDown();
            this.control_leng = new System.Windows.Forms.NumericUpDown();
            this.control_n = new System.Windows.Forms.NumericUpDown();
            this.label_thL = new System.Windows.Forms.Label();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.label_pen = new System.Windows.Forms.Label();
            this.label_thR = new System.Windows.Forms.Label();
            this.label_perL = new System.Windows.Forms.Label();
            this.label_perR = new System.Windows.Forms.Label();
            this.label_leng = new System.Windows.Forms.Label();
            this.label_n = new System.Windows.Forms.Label();
            this.vScrollBar2 = new System.Windows.Forms.VScrollBar();
            this.panel_paint = new System.Windows.Forms.Panel();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.button_color = new System.Windows.Forms.Button();
            this.button_draw = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.control_thL)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.control_thR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.control_perL)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.control_perR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.control_leng)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.control_n)).BeginInit();
            this.panel_paint.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button_draw);
            this.panel1.Controls.Add(this.button_color);
            this.panel1.Controls.Add(this.control_thL);
            this.panel1.Controls.Add(this.control_thR);
            this.panel1.Controls.Add(this.control_perL);
            this.panel1.Controls.Add(this.control_perR);
            this.panel1.Controls.Add(this.control_leng);
            this.panel1.Controls.Add(this.control_n);
            this.panel1.Controls.Add(this.label_thL);
            this.panel1.Controls.Add(this.splitter1);
            this.panel1.Controls.Add(this.label_pen);
            this.panel1.Controls.Add(this.label_thR);
            this.panel1.Controls.Add(this.label_perL);
            this.panel1.Controls.Add(this.label_perR);
            this.panel1.Controls.Add(this.label_leng);
            this.panel1.Controls.Add(this.label_n);
            this.panel1.Controls.Add(this.vScrollBar2);
            this.panel1.Cursor = System.Windows.Forms.Cursors.Default;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(267, 613);
            this.panel1.TabIndex = 0;
            // 
            // control_thL
            // 
            this.control_thL.Location = new System.Drawing.Point(143, 302);
            this.control_thL.Maximum = new decimal(new int[] {
            90,
            0,
            0,
            0});
            this.control_thL.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.control_thL.Name = "control_thL";
            this.control_thL.Size = new System.Drawing.Size(95, 25);
            this.control_thL.TabIndex = 21;
            this.control_thL.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // control_thR
            // 
            this.control_thR.Location = new System.Drawing.Point(143, 253);
            this.control_thR.Maximum = new decimal(new int[] {
            90,
            0,
            0,
            0});
            this.control_thR.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.control_thR.Name = "control_thR";
            this.control_thR.Size = new System.Drawing.Size(95, 25);
            this.control_thR.TabIndex = 20;
            this.control_thR.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // control_perL
            // 
            this.control_perL.DecimalPlaces = 1;
            this.control_perL.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.control_perL.Location = new System.Drawing.Point(143, 200);
            this.control_perL.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.control_perL.Name = "control_perL";
            this.control_perL.Size = new System.Drawing.Size(95, 25);
            this.control_perL.TabIndex = 19;
            this.control_perL.Value = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            // 
            // control_perR
            // 
            this.control_perR.DecimalPlaces = 1;
            this.control_perR.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.control_perR.Location = new System.Drawing.Point(143, 149);
            this.control_perR.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.control_perR.Name = "control_perR";
            this.control_perR.Size = new System.Drawing.Size(95, 25);
            this.control_perR.TabIndex = 18;
            this.control_perR.Value = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            // 
            // control_leng
            // 
            this.control_leng.Location = new System.Drawing.Point(143, 99);
            this.control_leng.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.control_leng.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.control_leng.Name = "control_leng";
            this.control_leng.Size = new System.Drawing.Size(95, 25);
            this.control_leng.TabIndex = 17;
            this.control_leng.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // control_n
            // 
            this.control_n.Location = new System.Drawing.Point(143, 46);
            this.control_n.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.control_n.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.control_n.Name = "control_n";
            this.control_n.Size = new System.Drawing.Size(95, 25);
            this.control_n.TabIndex = 16;
            this.control_n.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label_thL
            // 
            this.label_thL.AutoSize = true;
            this.label_thL.Font = new System.Drawing.Font("黑体", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_thL.Location = new System.Drawing.Point(12, 302);
            this.label_thL.Name = "label_thL";
            this.label_thL.Size = new System.Drawing.Size(98, 17);
            this.label_thL.TabIndex = 13;
            this.label_thL.Text = "左分支角度";
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(0, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 613);
            this.splitter1.TabIndex = 8;
            this.splitter1.TabStop = false;
            // 
            // label_pen
            // 
            this.label_pen.AutoSize = true;
            this.label_pen.Font = new System.Drawing.Font("黑体", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_pen.Location = new System.Drawing.Point(12, 358);
            this.label_pen.Name = "label_pen";
            this.label_pen.Size = new System.Drawing.Size(80, 17);
            this.label_pen.TabIndex = 7;
            this.label_pen.Text = "画笔颜色";
            // 
            // label_thR
            // 
            this.label_thR.AutoSize = true;
            this.label_thR.Font = new System.Drawing.Font("黑体", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_thR.Location = new System.Drawing.Point(12, 253);
            this.label_thR.Name = "label_thR";
            this.label_thR.Size = new System.Drawing.Size(98, 17);
            this.label_thR.TabIndex = 6;
            this.label_thR.Text = "右分支角度";
            // 
            // label_perL
            // 
            this.label_perL.AutoSize = true;
            this.label_perL.Font = new System.Drawing.Font("黑体", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_perL.Location = new System.Drawing.Point(12, 200);
            this.label_perL.Name = "label_perL";
            this.label_perL.Size = new System.Drawing.Size(116, 17);
            this.label_perL.TabIndex = 5;
            this.label_perL.Text = "左分支长度比";
            // 
            // label_perR
            // 
            this.label_perR.AutoSize = true;
            this.label_perR.Font = new System.Drawing.Font("黑体", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_perR.Location = new System.Drawing.Point(12, 149);
            this.label_perR.Name = "label_perR";
            this.label_perR.Size = new System.Drawing.Size(116, 17);
            this.label_perR.TabIndex = 4;
            this.label_perR.Text = "右分支长度比";
            // 
            // label_leng
            // 
            this.label_leng.AutoSize = true;
            this.label_leng.Font = new System.Drawing.Font("黑体", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_leng.Location = new System.Drawing.Point(12, 99);
            this.label_leng.Name = "label_leng";
            this.label_leng.Size = new System.Drawing.Size(80, 17);
            this.label_leng.TabIndex = 3;
            this.label_leng.Text = "主干长度";
            // 
            // label_n
            // 
            this.label_n.AutoSize = true;
            this.label_n.Font = new System.Drawing.Font("黑体", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_n.Location = new System.Drawing.Point(12, 46);
            this.label_n.Name = "label_n";
            this.label_n.Size = new System.Drawing.Size(80, 17);
            this.label_n.TabIndex = 2;
            this.label_n.Text = "递归深度";
            // 
            // vScrollBar2
            // 
            this.vScrollBar2.Location = new System.Drawing.Point(153, 170);
            this.vScrollBar2.Name = "vScrollBar2";
            this.vScrollBar2.Size = new System.Drawing.Size(8, 8);
            this.vScrollBar2.TabIndex = 1;
            // 
            // panel_paint
            // 
            this.panel_paint.Controls.Add(this.splitter2);
            this.panel_paint.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_paint.Location = new System.Drawing.Point(267, 0);
            this.panel_paint.Name = "panel_paint";
            this.panel_paint.Size = new System.Drawing.Size(675, 613);
            this.panel_paint.TabIndex = 1;
            // 
            // splitter2
            // 
            this.splitter2.Location = new System.Drawing.Point(0, 0);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(3, 613);
            this.splitter2.TabIndex = 0;
            this.splitter2.TabStop = false;
            // 
            // button_color
            // 
            this.button_color.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.button_color.Location = new System.Drawing.Point(100, 379);
            this.button_color.Name = "button_color";
            this.button_color.Size = new System.Drawing.Size(112, 110);
            this.button_color.TabIndex = 23;
            this.button_color.UseVisualStyleBackColor = false;
            this.button_color.Click += new System.EventHandler(this.button_color_Click);
            this.button_color.MouseEnter += new System.EventHandler(this.button_color_MouseEnter);
            // 
            // button_draw
            // 
            this.button_draw.AutoSize = true;
            this.button_draw.BackColor = System.Drawing.SystemColors.HighlightText;
            this.button_draw.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.button_draw.Location = new System.Drawing.Point(68, 538);
            this.button_draw.Margin = new System.Windows.Forms.Padding(0);
            this.button_draw.Name = "button_draw";
            this.button_draw.Size = new System.Drawing.Size(93, 39);
            this.button_draw.TabIndex = 24;
            this.button_draw.Text = "绘制";
            this.button_draw.UseVisualStyleBackColor = false;
            this.button_draw.Click += new System.EventHandler(this.button_draw_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(942, 613);
            this.Controls.Add(this.panel_paint);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "CayleyTreeForm";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.control_thL)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.control_thR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.control_perL)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.control_perR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.control_leng)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.control_n)).EndInit();
            this.panel_paint.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel_paint;
        private System.Windows.Forms.Label label_n;
        private System.Windows.Forms.VScrollBar vScrollBar2;
        private System.Windows.Forms.Label label_pen;
        private System.Windows.Forms.Label label_thR;
        private System.Windows.Forms.Label label_perL;
        private System.Windows.Forms.Label label_perR;
        private System.Windows.Forms.Label label_leng;
        private System.Windows.Forms.Label label_thL;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Splitter splitter2;
        private System.Windows.Forms.NumericUpDown control_thL;
        private System.Windows.Forms.NumericUpDown control_thR;
        private System.Windows.Forms.NumericUpDown control_perL;
        private System.Windows.Forms.NumericUpDown control_perR;
        private System.Windows.Forms.NumericUpDown control_leng;
        private System.Windows.Forms.NumericUpDown control_n;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Button button_color;
        private System.Windows.Forms.Button button_draw;
    }
}

