using System;
using System.IO;
using System.Windows.Forms;

namespace Part_3
{
    public partial class Form1 : Form
    {
        static int S = 0;
        static int T = 0;
        static int B = 0;
        static int C = 0;  
        public Form1()
        {
            InitializeComponent();
        }
        //
        //methods
        //
        //method to open and read file
        void ReadTxt(string path)
        {
            try
            {
                //open file
                FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
                StreamReader sr = new StreamReader(fs);

                sr.Close();
                fs.Close();
            }
            //Error handling if the file does not exist
            catch
            {
                MessageBox.Show(" !! يوجد خطأ في إدخال مسار الملف ");
            }
        }
        void Students(string path)
        {
            //open file
            FileStream fs_r = new FileStream(path, FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs_r);
            int i = 0;
            string courses_ids = "";
            string books_ids = "";
            string content = "";
            while (i <= S)
            {
                //define array to storing Informations
                content = sr.ReadLine();

                //of enabled button
                if (sr.EndOfStream)
                    btn_Next_S.Enabled = false;
                else btn_Next_S.Enabled = true;
                //on enabled button
                if (S > 0)
                    btn_previous_S.Enabled = true;
                else btn_previous_S.Enabled = false;
                i++;
                courses_ids = "";
                books_ids = "";
            }
            try
            {

                string[] info = content.Split(',');
                //define array to storing courses ids
                string[] infoCourses = info[4].Split(' ');
                for (int j = 0; j < infoCourses.Length; j++)
                {
                    courses_ids += infoCourses[j] + " ";
                }
                //define array to storing books ids
                string[] infoBooks = info[5].Split(' ');
                for (int k = 0; k < infoBooks.Length; k++)
                {
                    books_ids += infoBooks[k] + " ";
                }
                //define the object of the class
                Students student = new Students(info[0], info[1], info[2], info[3], courses_ids, books_ids);
                //write the Informations
                txt_id_S.Text = info[0];
                txt_Fnume_S.Text = info[1];
                txt_Lnume_S.Text = info[2];
                txt_Year_S.Text = info[3];
                txt_Courses_S.Text = courses_ids;
                if (info[5] == "")
                    txt_BooksId.Text = " ";
                else
                    txt_BooksId.Text = books_ids;
            }
            //Error handing
            catch
            {
                MessageBox.Show(" !! يوجد خطأ في المعلومات ");
                if (sr.EndOfStream)
                    MessageBox.Show("    انتهى الملف    ");
                else
                {
                    S++;
                    Students(path);
                }
            }
            //sht down the file
            sr.Close();
            fs_r.Close();
        }
        //method to edit stududnts information
        void Change_Students(string path, string Students_id, string Fname, string Lname, string Year, string Courses_ids, string Books_ids)
        {
            //open file
            FileStream fs_r = new FileStream(path, FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs_r);
            
            int i = 0;
            string[] accumulation = File.ReadAllLines(path);

            while (!sr.EndOfStream)
            {
                accumulation[i] = sr.ReadLine();
                i++;
            }
            sr.Close();
            fs_r.Close();

            FileStream fs_w = new FileStream(path, FileMode.Create, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs_w);
            for (int l = 0; l < accumulation.Length; l++)
            {
                if (l == S)
                {
                    accumulation[l] = Students_id + ", " + Fname + ", " + Lname + ", " + Year + ", " + Courses_ids + ", " + Books_ids;
                }
                sw.WriteLine(accumulation[l]);
            }
            sw.Close();
            fs_w.Close();
        }
        void Teachers(string path)
        {
            //open file
            FileStream fs_r = new FileStream(path, FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs_r);
            int i = 0;
            string courses_ids = "";
            string content = "";

            while (i <= T)
            {
                //define array to storing Informations
                content = sr.ReadLine();

                //of enabled button
                if (sr.EndOfStream)
                    btn_Next_T.Enabled = false;
                else btn_Next_T.Enabled = true;
                //on enabled button
                if (T > 0)
                    btn_previous_T.Enabled = true;
                else btn_previous_T.Enabled = false;
                i++;
                courses_ids = "";
            }
            try
            {
                string[] info = content.Split(',');
                //define array to storing courses ids
                string[] infoCourses = info[4].Split(' ');
                for (int j = 0; j < infoCourses.Length; j++)
                {
                    courses_ids += infoCourses[j] + " ";
                }
                //define the object of the class
                Teachers teacher = new Teachers(info[0], info[1], info[2], info[3], courses_ids);
                //write the array
                txt_id_T.Text = info[0];
                txt_Fnume_T.Text = info[1];
                txt_Lnume_T.Text = info[2];
                txt_Specialization.Text = info[3];
                txt_Courses_T.Text = courses_ids;
            }
            //Error handling
            catch
            {
                MessageBox.Show(" !! يوجد خطأ في المعلومات ");
                if (sr.EndOfStream)
                    MessageBox.Show("    انتهى الملف    ");
                else
                {
                    T++;
                    Teachers(path);
                }
            }
            //shut down the file
            sr.Close();
            fs_r.Close();
        }
        //method to edit teachers information
        void Change_Teachers(string path, string Teachers_id, string Fname, string Lname, string Specialization, string Courses_ids)
        {
            //open file
            FileStream fs_r = new FileStream(path, FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs_r);
            int i = 0;
            string[] accumulation = File.ReadAllLines(path);

            while (!sr.EndOfStream)
            {
                accumulation[i] = sr.ReadLine();
                i++;
            }
            sr.Close();
            fs_r.Close();

            FileStream fs_w = new FileStream(path, FileMode.Create, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs_w);
            for (int l = 0; l < accumulation.Length; l++)
            {
                if (l == T)
                {
                    accumulation[l] = Teachers_id + ", " + Fname + ", " + Lname + ", " + Specialization + ", " + Courses_ids;
                }
                sw.WriteLine(accumulation[l]);
            }
            sw.Close();
            fs_w.Close();
        }
        void Courses(string path)
        {
            //open file
            FileStream fs_r = new FileStream(path, FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs_r);
            int i = 0;
            string content = "";
            while (i <= C)
            {
                //define array to storing Informations
                content = sr.ReadLine();

                //of enabled button
                if (sr.EndOfStream)
                    btn_Next_C.Enabled = false;
                else btn_Next_C.Enabled = true;
                //on enabled button
                if (C > 0)
                    btn_previous_C.Enabled = true;
                else btn_previous_C.Enabled = false;
                i++;
            }
            try
            {
                string[] info = content.Split(',');
                //define the object of the class
                Courses course = new Courses(int.Parse(info[0]), int.Parse(info[1]), info[2]);
                //write the Informations
                txt_id_C.Text = info[0];
                txt_Year_C.Text = info[1];
                txt_NameCourses.Text = info[2];
            }
            //Error handling
            catch
            {
                MessageBox.Show(" !! يوجد خطأ في المعلومات ");
                if (sr.EndOfStream)
                    MessageBox.Show("    انتهى الملف    ");
                else
                {
                    C++;
                    Courses(path);
                }
            }
            //shut down the file
            sr.Close();
            fs_r.Close();
        }
        //method to edit courses information
        void Change_Courses(string path, string Courses_id, string Year, string Name_C)
        {
            //open file
            FileStream fs_r = new FileStream(path, FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs_r);
            
            int i = 0;
            string[] accumulation = File.ReadAllLines(path);

            while (!sr.EndOfStream)
            {
                accumulation[i] = sr.ReadLine();
                i++;
            }
            sr.Close();
            fs_r.Close();

            FileStream fs_w = new FileStream(path, FileMode.Create, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs_w);
            for (int l = 0; l < accumulation.Length; l++)
            {
                if (l == C)
                {
                    accumulation[l] = Courses_id + ", " + Year + ", " + Name_C;
                }
                sw.WriteLine(accumulation[l]);
            }
            sw.Close();
            fs_w.Close();
        }
        void Books(string path)
        {
            //open file
            FileStream fs_r = new FileStream(path, FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs_r);
            int i = 0;
            string content = "";

            while (i <= B)
            {
                //define array to storing Informations
                content = sr.ReadLine();

                //of enabled button
                if (sr.EndOfStream)
                    btn_Next_B.Enabled = false;
                else btn_Next_B.Enabled = true;
                //on enabled button
                if (B > 0)
                    btn_previous_B.Enabled = true;
                else btn_previous_B.Enabled = false;
                i++;
            }
            try
            {
                string[] info = content.Split(',');
                //define the object of the class
                Books book = new Books(int.Parse(info[0]), int.Parse(info[1]), info[2]);
                //write the Informations
                txt_id_B.Text = info[0];
                txt_Year_B.Text = info[1];
                txt_NameBook.Text = info[2];
            }
            //Error handling
            catch
            {
                MessageBox.Show(" !! يوجد خطأ في المعلومات ");
                if (sr.EndOfStream)
                    MessageBox.Show("    انتهى الملف    ");
                else
                {
                    B++;
                    Books(path);
                }
            }
            //shut down the file
            sr.Close();
            fs_r.Close();
        }
        //method to edit books information
        void Change_Books(string path, string Books_id, string Year, string Name_B)
        {
            //open file
            FileStream fs_r = new FileStream(path, FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs_r);
           
            int i = 0;
            string[] accumulation = File.ReadAllLines(path);

            while (!sr.EndOfStream)
            {
                accumulation[i] = sr.ReadLine();
                i++;
            }
            sr.Close();
            fs_r.Close();

            FileStream fs_w = new FileStream(path, FileMode.Create, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs_w);
            for (int l = 0; l < accumulation.Length; l++)
            {
                if (l == B)
                {
                    accumulation[l] = Books_id + ", " + Year + ", " + Name_B;
                }
                sw.WriteLine(accumulation[l]);
            }
            sw.Close();
            fs_w.Close();
        }
        //
        //Students
        //
        //texts to read file path
        private void txtStudents_TextChanged_1(object sender, EventArgs e)
        {
            if (txtStudents.Text != "")
                btnStudents.Enabled = true;
            else
                btnStudents.Enabled = false;
        }
        //button to read file path
        private void btnStudents_Click_1(object sender, EventArgs e)
        {
            string path = txtStudents.Text;
            ReadTxt(path);
            Students(path);
        }
        //button to move next
        private void btn_Next_S_Click_1(object sender, EventArgs e)
        {
            S++;
            string path = txtStudents.Text;
            Students(path);
        }
        //button to go back
        private void btn_previous_S_Click_1(object sender, EventArgs e)
        {
            S--;
            string path = txtStudents.Text;
            Students(path);
        }
        //button to edit students information
        private void btn_Modification_S_Click(object sender, EventArgs e)
        {
            try
            {
                string Students_id = txt_id_S.Text;
                string Fname = txt_Fnume_S.Text;
                string Lname = txt_Lnume_S.Text;
                string Year = txt_Year_S.Text;
                string Courses_ids = txt_Courses_S.Text;
                string Books_ids = txt_BooksId.Text;
                string path = txtStudents.Text;
            
                Change_Students(path, Students_id, Fname, Lname, Year, Courses_ids, Books_ids);
                MessageBox.Show("تم تعديل المعلومات");
            }
            catch
            {
                MessageBox.Show("لم يتم التعديل");
            }         
        }
        //
        //Teachers
        //
        //texts to read file path
        private void txtTeachers_TextChanged_1(object sender, EventArgs e)
        {
            if (txtTeachers.Text != "")
                btnTeachers.Enabled = true;
            else
                btnTeachers.Enabled = false;
        }
        //button to read file path
        private void btnTeachers_Click_1(object sender, EventArgs e)
        {
            string path = txtTeachers.Text;
            ReadTxt(path);
            Teachers(path);
        }
        //button to move next
        private void btn_Next_T_Click_1(object sender, EventArgs e)
        {
            T++;
            string path = txtTeachers.Text;
            Teachers(path);
        }
        //button to go back
        private void btn_previous_T_Click_1(object sender, EventArgs e)
        {
            T--;
            string path = txtTeachers.Text;
            Teachers(path);
        }
        //button to edit teachers information
        private void btn_Modification_T_Click(object sender, EventArgs e)
        {
            try
            {
                string Teachers_id = txt_id_T.Text;
                string Fname = txt_Fnume_T.Text;
                string Lname = txt_Lnume_T.Text;
                string Specialization = txt_Specialization.Text;
                string Courses_ids = txt_Courses_T.Text;
                string path = txtTeachers.Text;
                Change_Teachers(path, Teachers_id, Fname, Lname, Specialization, Courses_ids);
                MessageBox.Show("تم تعديل المعلومات");
            }
            catch
            {
                MessageBox.Show("لم يتم التعديل");
            }
        }
        //
        //Courses
        //
        //texts to read file path
        private void txtCourses_TextChanged_1(object sender, EventArgs e)
        {
            if (txtCourses.Text != "")
                btnCourses.Enabled = true;
            else
                btnCourses.Enabled = false;
        }
        //button to read file path
        private void btnCourses_Click_1(object sender, EventArgs e)
        {
            string path = txtCourses.Text;
            ReadTxt(path);
            Courses(path);
        }
        //button to move next
        private void btn_Next_C_Click(object sender, EventArgs e)
        {
            C++;
            string path = txtCourses.Text;
            Courses(path);
        }
        //button to go back
        private void btn_previous_C_Click_1(object sender, EventArgs e)
        {
            C--;
            string path = txtCourses.Text;
            Courses(path);
        }
        //button to edit courses information
        private void btn_Modification_C_Click(object sender, EventArgs e)
        {
            try
            {
                string Courses_id = txt_id_C.Text;
                string Year = txt_Year_C.Text;
                string Name_C = txt_NameCourses.Text;
                string path = txtCourses.Text;
                Change_Courses(path, Courses_id, Year, Name_C);
                MessageBox.Show("تم تعديل المعلومات");
            }
            catch
            {
                MessageBox.Show("لم يتم التعديل");
            }
           
        }
        //
        //Books
        //
        //texts to read file path
        private void txtBooks_TextChanged_1(object sender, EventArgs e)
        {
            if (txtBooks.Text != "")
                btnBooks.Enabled = true;
            else
                btnBooks.Enabled = false;
        }
        //button to read file path
        private void btnBooks_Click_1(object sender, EventArgs e)
        {
            string path = txtBooks.Text;
            ReadTxt(path);
            Books(path);
        }
        //button to move next
        private void btn_Next_B_Click_1(object sender, EventArgs e)
        {
            B++;
            string path = txtBooks.Text;
            Books(path);
        }
        //button to go back
        private void btn_previous_B_Click_1(object sender, EventArgs e)
        {
            B--;
            string path = txtBooks.Text;
            Books(path);
        }
        //button to edit books information
        private void btn_Modification_B_Click(object sender, EventArgs e)
        {
            try
            {
                string Books_id = txt_id_B.Text;
                string Year = txt_Year_B.Text;
                string Name_B = txt_NameBook.Text;
                string path = txtBooks.Text;
                Change_Books(path, Books_id, Year, Name_B);
                MessageBox.Show("تم تعديل المعلومات");
            }
            catch
            {
                MessageBox.Show("لم يتم التعديل");
            }
        }
    }
}
