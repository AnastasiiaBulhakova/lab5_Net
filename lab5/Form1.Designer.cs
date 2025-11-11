namespace lab5
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
            label1 = new Label();
            dataGridView1 = new DataGridView();
            label2 = new Label();
            label3 = new Label();
            type = new TextBox();
            grade = new TextBox();
            quantity = new TextBox();
            label4 = new Label();
            label5 = new Label();
            textBox1 = new TextBox();
            add = new Button();
            delete = new Button();
            filter = new Button();
            fiter = new NumericUpDown();
            sort = new Button();
            resert = new Button();
            load = new Button();
            save = new Button();
            Filternew = new Button();
            filtertype = new TextBox();
            groupby = new Button();
            tquantity = new Button();
            tprice = new Button();
            aprice = new Button();
            avprice = new Label();
            allquantity = new Label();
            allprice = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)fiter).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label1.Location = new Point(27, 10);
            label1.Name = "label1";
            label1.Size = new Size(125, 30);
            label1.TabIndex = 0;
            label1.Text = "Продукти ";
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(19, 58);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.Size = new Size(1003, 194);
            dataGridView1.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(39, 276);
            label2.Name = "label2";
            label2.Size = new Size(41, 25);
            label2.TabIndex = 2;
            label2.Text = "Тип";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(39, 340);
            label3.Name = "label3";
            label3.Size = new Size(57, 25);
            label3.TabIndex = 3;
            label3.Text = "Сорт ";
            // 
            // type
            // 
            type.Location = new Point(135, 276);
            type.Name = "type";
            type.Size = new Size(150, 31);
            type.TabIndex = 4;
            // 
            // grade
            // 
            grade.Location = new Point(138, 336);
            grade.Name = "grade";
            grade.Size = new Size(150, 31);
            grade.TabIndex = 5;
            // 
            // quantity
            // 
            quantity.Location = new Point(561, 276);
            quantity.Name = "quantity";
            quantity.Size = new Size(150, 31);
            quantity.TabIndex = 7;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(439, 276);
            label4.Name = "label4";
            label4.Size = new Size(81, 25);
            label4.TabIndex = 8;
            label4.Text = "Кількість";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(439, 340);
            label5.Name = "label5";
            label5.Size = new Size(48, 25);
            label5.TabIndex = 9;
            label5.Text = "Ціна";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(561, 336);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(150, 31);
            textBox1.TabIndex = 10;
            // 
            // add
            // 
            add.BackColor = SystemColors.ActiveCaption;
            add.Location = new Point(841, 274);
            add.Name = "add";
            add.Size = new Size(112, 34);
            add.TabIndex = 11;
            add.Text = "Додати";
            add.UseVisualStyleBackColor = false;
            add.Click += add_Click;
            // 
            // delete
            // 
            delete.BackColor = SystemColors.ActiveCaption;
            delete.Location = new Point(841, 336);
            delete.Name = "delete";
            delete.Size = new Size(112, 31);
            delete.TabIndex = 12;
            delete.Text = "Видалити";
            delete.UseVisualStyleBackColor = false;
            delete.Click += delete_Click;
            // 
            // filter
            // 
            filter.Location = new Point(39, 398);
            filter.Name = "filter";
            filter.Size = new Size(143, 34);
            filter.TabIndex = 13;
            filter.Text = "Фільтрувати за";
            filter.UseVisualStyleBackColor = true;
            filter.Click += filter_Click;
            // 
            // fiter
            // 
            fiter.Location = new Point(221, 401);
            fiter.Name = "fiter";
            fiter.Size = new Size(180, 31);
            fiter.TabIndex = 14;
            // 
            // sort
            // 
            sort.Location = new Point(439, 398);
            sort.Name = "sort";
            sort.Size = new Size(112, 34);
            sort.TabIndex = 15;
            sort.Text = "Сортувати";
            sort.UseVisualStyleBackColor = true;
            sort.Click += sort_Click;
            // 
            // resert
            // 
            resert.Location = new Point(590, 398);
            resert.Name = "resert";
            resert.Size = new Size(112, 34);
            resert.TabIndex = 16;
            resert.Text = "Скинути";
            resert.UseVisualStyleBackColor = true;
            resert.Click += resert_Click;
            // 
            // load
            // 
            load.Location = new Point(743, 398);
            load.Name = "load";
            load.Size = new Size(128, 34);
            load.TabIndex = 17;
            load.Text = "Завантажити ";
            load.UseVisualStyleBackColor = true;
            load.Click += load_Click;
            // 
            // save
            // 
            save.Location = new Point(895, 398);
            save.Name = "save";
            save.Size = new Size(112, 34);
            save.TabIndex = 18;
            save.Text = "Зберегти";
            save.UseVisualStyleBackColor = true;
            save.Click += save_Click;
            // 
            // Filternew
            // 
            Filternew.Location = new Point(39, 472);
            Filternew.Name = "Filternew";
            Filternew.Size = new Size(143, 34);
            Filternew.TabIndex = 19;
            Filternew.Text = "Фільтрувати за";
            Filternew.UseVisualStyleBackColor = true;
            Filternew.Click += Filternew_Click;
            // 
            // filtertype
            // 
            filtertype.Location = new Point(221, 472);
            filtertype.Name = "filtertype";
            filtertype.Size = new Size(150, 31);
            filtertype.TabIndex = 20;
            // 
            // groupby
            // 
            groupby.Location = new Point(39, 541);
            groupby.Name = "groupby";
            groupby.Size = new Size(248, 32);
            groupby.TabIndex = 21;
            groupby.Text = "Групувати за сортом";
            groupby.UseVisualStyleBackColor = true;
            groupby.Click += groupby_Click;
            // 
            // tquantity
            // 
            tquantity.Location = new Point(328, 540);
            tquantity.Name = "tquantity";
            tquantity.Size = new Size(258, 34);
            tquantity.TabIndex = 22;
            tquantity.Text = "Загальна кількість продуктів";
            tquantity.UseVisualStyleBackColor = true;
            tquantity.Click += tquantity_Click;
            // 
            // tprice
            // 
            tprice.Location = new Point(682, 540);
            tprice.Name = "tprice";
            tprice.Size = new Size(258, 34);
            tprice.TabIndex = 23;
            tprice.Text = "Загальна вартість продуктів";
            tprice.UseVisualStyleBackColor = true;
            tprice.Click += tprice_Click;
            // 
            // aprice
            // 
            aprice.Location = new Point(439, 472);
            aprice.Name = "aprice";
            aprice.Size = new Size(251, 34);
            aprice.TabIndex = 24;
            aprice.Text = "Середня ціна продукту";
            aprice.UseVisualStyleBackColor = true;
            aprice.Click += aprice_Click;
            // 
            // avprice
            // 
            avprice.AutoSize = true;
            avprice.Location = new Point(746, 475);
            avprice.Name = "avprice";
            avprice.Size = new Size(0, 25);
            avprice.TabIndex = 25;
            // 
            // allquantity
            // 
            allquantity.AutoSize = true;
            allquantity.Location = new Point(609, 545);
            allquantity.Name = "allquantity";
            allquantity.Size = new Size(0, 25);
            allquantity.TabIndex = 26;
            // 
            // allprice
            // 
            allprice.AutoSize = true;
            allprice.Location = new Point(963, 545);
            allprice.Name = "allprice";
            allprice.Size = new Size(0, 25);
            allprice.TabIndex = 27;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1173, 614);
            Controls.Add(allprice);
            Controls.Add(allquantity);
            Controls.Add(avprice);
            Controls.Add(aprice);
            Controls.Add(tprice);
            Controls.Add(tquantity);
            Controls.Add(groupby);
            Controls.Add(filtertype);
            Controls.Add(Filternew);
            Controls.Add(save);
            Controls.Add(load);
            Controls.Add(resert);
            Controls.Add(sort);
            Controls.Add(fiter);
            Controls.Add(filter);
            Controls.Add(delete);
            Controls.Add(add);
            Controls.Add(textBox1);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(quantity);
            Controls.Add(grade);
            Controls.Add(type);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(dataGridView1);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)fiter).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private DataGridView dataGridView1;
        private Label label2;
        private Label label3;
        private TextBox type;
        private TextBox grade;
        private TextBox quantity;
        private Label label4;
        private Label label5;
        private TextBox textBox1;
        private Button add;
        private Button delete;
        private Button filter;
        private NumericUpDown fiter;
        private Button sort;
        private Button resert;
        private Button load;
        private Button save;
        private Button Filternew;
        private TextBox filtertype;
        private Button groupby;
        private Button tquantity;
        private Button tprice;
        private Button aprice;
        private Label avprice;
        private Label allquantity;
        private Label allprice;
    }
}
